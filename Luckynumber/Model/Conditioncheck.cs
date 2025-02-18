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

        

        }


     
    
     

     
    
     
        public static void updaCTVAsoluongKM()  /// --- not use to update puchare order
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
        }  /// --- not use



    }
}
