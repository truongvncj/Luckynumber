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
            //  #region // kiem tra xem co sai mesage
            bool kq = true;
            string connection_string = Utils.getConnectionstr();
            string enduser = Utils.getusername();
            var db = new LinqtoSQLDataContext(connection_string);

            var rs = from p in db.tbl_CTKMs
                   where  p.enduser == enduser
                     where p.Mã_SP_KM.Trim() == material
                     //    && message.IndexOf(p.PO_Message) > 0
                     select p;
            foreach (var item in rs)
            {

                if (message.Contains(item.PO_Message.Trim()))
                {
                    // message dung
                    // order message sai
                    kq = false;
                    //    return true;

                }

            }



            return kq;

        }

        public static string FindProgarmebymessageandmaterial(string message, string material)
        {
            //  #region // kiem tra xem co sai mesage
            //    bool kq = true;
            string maprogarme = "";

            string connection_string = Utils.getConnectionstr();

            var db = new LinqtoSQLDataContext(connection_string);
            string enduser = Utils.getusername();
            var rs = from p in db.tbl_CTKMs

                     where p.Mã_SP_KM.Trim() == material
                     && p.enduser == enduser
                     //    && message.IndexOf(p.PO_Message) > 0
                     select p;
            foreach (var item in rs)
            {

                if (message.Contains(item.PO_Message.Trim()))
                {
                    // message dung
                    // order message sai
                    //     kq = false;
                    maprogarme = item.Mã_CT;

                    //    return true;

                }

            }


            return maprogarme;
            //      return kq;

        }


        public static void UpdateMaCTKM()
        {


            string connection_string = Utils.getConnectionstr();

            var db = new LinqtoSQLDataContext(connection_string);
            string enduser = Utils.getusername();
            var rs = from p in db.tbl_SalesFreeOrders
                     where p.enduser ==enduser
                           && p.ma_CTKM == ""
                     select p;


            foreach (var item in rs)
            {

                item.ma_CTKM = Model.Conditioncheck.FindProgarmebymessageandmaterial(item.PO_number, item.Material.Trim());

                db.SubmitChanges();

            }

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


                         Quantityfree = (g.Sum(m => m.Order_quantity)) / tyle,
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

        public static bool checkIsOvertimeofGROgarame(string mact, DateTime deliverydate)
        {
            bool kq = true;
            string connection_string = Utils.getConnectionstr();
            string enduser = Utils.getusername();
            var db = new LinqtoSQLDataContext(connection_string);

            var ctkm = (from p in db.tbl_CTKMs

                     where p.Mã_CT == mact
                     && p.enduser == enduser
                     select p).FirstOrDefault();

            if (ctkm != null)
            {
                if (ctkm.Từ_ngày <= deliverydate && ctkm.Đến_Ngày >=deliverydate)
                {
                    kq = false;
                }


            }

            return kq;
          





        }

        public static void tinhvaupdatefreeetimatetable(double ordernumber, DateTime ngayorder)
        {


            bool kq = true;
            string connection_string = Utils.getConnectionstr();
            string enduser = Utils.getusername();
            var db = new LinqtoSQLDataContext(connection_string);

            var rs = from p in db.tbl_Salesorders
                     
                     where  p.enduser == enduser
                     && p.Dlv_Date == ngayorder
                     select p;







            //   throw new NotImplementedException();
        }


        public static bool checkoverschemebyorderandate(double  ordernumber, DateTime  ngayorder)
        {

            bool kq = true;
            string connection_string = Utils.getConnectionstr();
            string enduser = Utils.getusername();
            var db = new LinqtoSQLDataContext(connection_string);

            var rs = from p in db.tbl_SalesFreeOrders

                     where p.rptselect == true && p.enduser == enduser
                     select p;






            return kq;


            //   throw new NotImplementedException();
        }


    }
}
