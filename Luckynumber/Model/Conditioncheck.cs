using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Luckynumber.Model
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
                     where p.enduser == enduser
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


            #region  updatemã ctkm cho don hang km
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {
                string enduser = Utils.getusername();
                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updeMaCTKMchodonhangKM", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@enduser", SqlDbType.NVarChar).Value = enduser;
                cmd1.CommandTimeout = 0;
                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion

            //string connection_string = Utils.getConnectionstr();

            //var db = new LinqtoSQLDataContext(connection_string);
            //string enduser = Utils.getusername();
            //var rs = from p in db.tbl_SalesFreeOrders
            //         where p.enduser == enduser
            //               && p.ma_CTKM == ""
            //         select p;


            //foreach (var item in rs)
            //{

            //    string maCTKM = Model.Conditioncheck.FindProgarmebymessageandmaterial(item.PO_number, item.Material.Trim());
            //    item.ma_CTKM = maCTKM;

            //    if (maCTKM != "")
            //    {
            //        item.New_PO_number = (from p in db.tbl_CTKMs
            //                              where p.enduser == enduser && p.Mã_CT == maCTKM
            //                              select p.PO_Message).FirstOrDefault();
            //    }
            //    db.SubmitChanges();

            //}

        }


        //public static void checkIsunenoughtpaid(double tyle, string materialbuy, string materialfree)
        //{
        //    #region // kiem tra xem co sai mesage

        //    string connection_string = Utils.getConnectionstr();

        //    var db = new LinqtoSQLDataContext(connection_string);

        //    var rs = from p in db.tbl_Salesorders
        //             where p.Material == materialbuy
        //             group p by new
        //             {
        //                 p.Created,//.Customer,
        //                 p.Material,//  tblCustomer.SOrg,
        //             }
        //            into g

        //             select new

        //             {
        //                 Created = g.Key.Created,
        //                 Material = g.Key.Material,
        //                 Quantytibuy = g.Sum(m => m.Order_quantity),


        //                 Quantityfree = (g.Sum(m => m.Order_quantity)) / tyle,
        //                 FreeclasesPaid = 0.0,
        //                 filter = 0,

        //             };

        //    foreach (var item in rs)
        //    {


        //        var rsQuantityfree = (from p in db.tbl_SalesFreeOrders
        //                              where p.Material == materialfree
        //                              && p.Created == item.Created
        //                              group p by new
        //                              {
        //                                  p.Created,//.Customer,
        //                                  p.Material,//  tblCustomer.SOrg,
        //                              }
        //                               into g
        //                              select new
        //                              {
        //                                  Quantityfree = g.Sum(m => m.Order_quantity),
        //                              }).FirstOrDefault();

        //        if (rsQuantityfree != null)
        //        {

        //            if (item.Quantityfree > rsQuantityfree.Quantityfree)
        //            {
        //                tbl_rptnotEnought rpt = new tbl_rptnotEnought();
        //                rpt.Created = item.Created;
        //                rpt.Material = item.Material;
        //                rpt.Quantytibuy = item.Quantytibuy;
        //                rpt.Quantityfree = item.Quantityfree;
        //                rpt.FreeclasesPaid = rsQuantityfree.Quantityfree;

        //                rpt.filter = true;


        //                db.tbl_rptnotEnoughts.InsertOnSubmit(rpt);
        //                db.SubmitChanges();

        //            }




        //        }


        //    }


        //    #endregion

        //}

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
                if (ctkm.Từ_ngày <= deliverydate && ctkm.Đến_Ngày >= deliverydate)
                {
                    kq = false;
                }


            }

            return kq;






        }

        public static void tinhvaupdatefreeetimatetable(double ordernumber, DateTime ngayorder)
        {


            //   bool kq = true;
            string connection_string = Utils.getConnectionstr();
            string enduser = Utils.getusername();
            var db = new LinqtoSQLDataContext(connection_string);

            var rs = from p in db.tbl_Salesorders

                     where p.enduser == enduser
                     // && p.Dlv_Date == ngayorder
                     select p;







            //   throw new NotImplementedException();
        }


        public static bool checkoverschemebyorderandate(double ordernumber, DateTime ngayorder)
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

        public static void UpdateMaCTKMchodonhangmua(string material, DateTime dlv_Date, string nhomKHKM, int id)
        {

            string connection_string = Utils.getConnectionstr();
            string enduser = Utils.getusername();
            var db = new LinqtoSQLDataContext(connection_string);

            var rs = from p in db.tbl_CTKMs
                     where p.enduser == enduser
                     select p;

            foreach (var item in rs)
            {
                if (item.Mã_SP_Mua == material && item.Từ_ngày <= dlv_Date && item.Đến_Ngày >= dlv_Date && (item.Nhóm_khách_hàng == nhomKHKM || item.Nhóm_khách_hàng == ""))
                {

                    var rs2 = from kh in db.tbl_Salesorders
                              where kh.id == id
                              select kh;

                    foreach (var item2 in rs2)
                    {
                        item2.maCTKM = item.Mã_CT;
                        item2.Ma_SP_Duoc_KM = item.Mã_SP_KM;
                        item2.So_luong_duoc_KM = item2.ConfirmQty / item.Tỷ_lệ_CTKM;
                        db.SubmitChanges();
                    }



                }



            }







            //   throw new NotImplementedException();
        }

        public static void updaMAKHKM()
        {



            string connection_string = Utils.getConnectionstr();

            var db = new LinqtoSQLDataContext(connection_string);
            string enduser = Utils.getusername();

            var rs = from p in db.tbl_Salesorders
                     where p.enduser == enduser

                     select p;

            foreach (var item in rs)
            {



                string maKH = (from kh in db.tbl_NhomKHKMs
                               where kh.enduser == enduser
                               && kh.CodeKH == item.Sold_to_party

                               select kh.Mã_nhóm_KH).FirstOrDefault();

                if (maKH != null)
                {
                    item.Mã_nhóm_KH = maKH;
                }
                else
                {
                    item.Mã_nhóm_KH = "";
                }


                db.SubmitChanges();

            }



            //throw new NotImplementedException();
        }

        public static void updaCTVAsoluongKM()
        {
            //

            ///

            #region  updatemã khcash hàng và mã ct km và só luong km
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {
                string enduser = Utils.getusername();
                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updeMaKHKMvaCTVAsoluongKM", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@enduser", SqlDbType.NVarChar).Value = enduser;
                cmd1.CommandTimeout = 0;
                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion



            //pppppppp

            //string connection_string = Utils.getConnectionstr();
            //var db = new LinqtoSQLDataContext(connection_string);
            //string enduser = Utils.getusername();

            //#region update ctkm
            //var rs1 = from p in db.tbl_Salesorders

            //          where p.enduser == enduser
            //          select p;

            //foreach (var item in rs1)
            //{
            //    item.selectprt = false;


             //  Model.Conditioncheck.UpdateMaCTKMchodonhangmua(item.Material, (DateTime)item.Dlv_Date, item.Mã_nhóm_KH, item.id);


            //}



            //#endregion
        }
    }
}
