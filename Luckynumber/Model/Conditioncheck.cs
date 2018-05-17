using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arconfirmationletter.Model
{
    class Conditioncheck
    {

        public static bool Iswrongmessage(string message, string material)
        {
            #region // kiem tra xem co sai mesage

            string connection_string = Utils.getConnectionstr();

            var db = new LinqtoSQLDataContext(connection_string);

            var rs = from p in db.tbl_CTKMs
                     where p.Mã_SP_KM == material
                     && message.IndexOf(p.PO_Message) > 0
                     select p;

            if (rs.Count() > 0)
            {
                return true;
            }

            // s1.IndexOf(s2)
            // / string.Compare



            return false;
            #endregion

        }

        public static void checkIsunenoughtpaid(double tyle, string materialbuy, string materialfree)
        {
            #region // kiem tra xem co sai mesage

            string connection_string = Utils.getConnectionstr();

            var db = new LinqtoSQLDataContext(connection_string);

            var rs = from p in db.tbl_Salesorders
                     where p.Material == materialbuy
                     group p by new
                     {
                         p.Created,//.Customer,
                         p.Material,//  tblCustomer.SOrg,
                     }
                    into g

                     select new

                     {
                         Created = g.Key.Created,
                         Material = g.Key.Material,
                         Quantytibuy = g.Sum(m => m.Order_quantity),
                          
                      
                         Quantityfree = (g.Sum(m => m.Order_quantity))/ tyle,
                         FreeclasesPaid = 0.0,
                         filter = 0,

                     };

            foreach (var item in rs)
            {


                var rsQuantityfree = (from p in db.tbl_SalesFreeOrders
                                      where p.Material == materialfree
                                      && p.Created == item.Created
                                      group p by new
                                      {
                                          p.Created,//.Customer,
                                          p.Material,//  tblCustomer.SOrg,
                                      }
                                       into g
                                      select new
                                      {
                                          Quantityfree = g.Sum(m => m.Order_quantity),
                                      }).FirstOrDefault();

                if (rsQuantityfree != null)
                {

                    if (item.Quantityfree > rsQuantityfree.Quantityfree)
                    {
                        tbl_rptnotEnought rpt = new tbl_rptnotEnought();
                        rpt.Created = item.Created;
                        rpt.Material = item.Material;
                        rpt.Quantytibuy = item.Quantytibuy;
                        rpt.Quantityfree = item.Quantityfree;
                      rpt.FreeclasesPaid = rsQuantityfree.Quantityfree;

                        rpt.filter = true;


                        db.tbl_rptnotEnoughts.InsertOnSubmit(rpt);
                        db.SubmitChanges();

                    }




                }


            }


            #endregion

        }

    }
}
