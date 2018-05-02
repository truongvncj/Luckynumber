using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using cExcel = Microsoft.Office.Interop.Excel;
using arconfirmationletter.View;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;

//arconfirmationletter.LinqtoSQLDataContext

namespace arconfirmationletter.Control
{
    class Control_ac
    {


        //public bool checkVATnameanddtodata()
        //{



        //    // kiểm tra xem khachs hangf trong vat out da co trong master data ?? da co trong data chua, neu chua co thi add
        //    //   tblVat vat = new tblVat();
        //    //  tblCustomer cust = new tblCustomer();
        //    //        updateVATstatinmaster


        //    #region  updateVATstatinmaster ra TREN SQL da  viet ok
        //    SqlConnection conn2 = null;
        //    SqlDataReader rdr1 = null;

        //    string destConnString = Utils.getConnectionstr();
        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("updateVATstatinmaster", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;

        //        //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
        //        cmd1.CommandTimeout = 0;
        //        rdr1 = cmd1.ExecuteReader();
               


        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    #endregion

        //    string connection_string = Utils.getConnectionstr();
        //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
        //    db.CommandTimeout = 0;
        //    db.ExecuteCommand("DELETE FROM tblCustomerTmp");
        //    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    db.SubmitChanges();

        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



        //    #region  insert into  tblCustomerTmp tempcust = new tblCustomerTmp(); where      where tblVat.Statuscheck == false// true// false
        //    // SqlConnection conn2 = null;
        //    //   SqlDataReader rdr1 = null;

        //    //      string destConnString = Utils.getConnectionstr();
        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("inserttblvatstatusfalseintblCustomerTmp", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    #endregion





        //    var q = from tblCustomerTmp in dc.tblCustomerTmps
        //            select tblCustomerTmp;

        //    if (q.Count() > 0)
        //    {



        //        var typeff = typeof(tblCustomerTmp);

        //        //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
        //        View.VInputchange inputcdata = new View.VInputchange("MASTER DATA CUSTOMER ", "LIST CUST IN VATOUT BUT NOT IN CUST MASTER", db, "tblCustomer", "tblCustomerTmp", typeff, "id", "id");
        //        inputcdata.Visible = false;
        //        inputcdata.ShowDialog();
        //        //   Viewtable viewtbl = new Viewtable(q, dc, "List customer có trong VAT out không có trong master customer data !");

        //        return false;

        //    }
        //    else
        //    {
        //        return true;

        //    }


        //}


        public void UpdateVATregionFromFBL5Nregion()
        {
            //  UpdateRerionintoVATouFromFBL5n



            #region  updateCustgoupinListcustmakeRptVN ra TREN SQL dang viet 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("UpdateRerionintoVATouFromFBL5n", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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


        
        internal void xoavatEDLPandFBL5nDochaveinFbl5nthis()
        {


            //#region xoavatEDLPandFBL5nDochaveinFbl5nth
            //SqlConnection conn2 = null;
            //SqlDataReader rdr1 = null;

            //string destConnString = Utils.getConnectionstr();
            //try
            //{

            //    conn2 = new SqlConnection(destConnString);
            //    conn2.Open();
            //    SqlCommand cmd1 = new SqlCommand("DeleteVATEDLPandFBL5nDocexistinFbl5nthis", conn2);
            //    cmd1.CommandType = CommandType.StoredProcedure;
            //    cmd1.CommandTimeout = 0;
            //    //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

            //    rdr1 = cmd1.ExecuteReader();



            //    //       rdr1 = cmd1.ExecuteReader();

            //}
            //finally
            //{
            //    if (conn2 != null)
            //    {
            //        conn2.Close();
            //    }
            //    if (rdr1 != null)
            //    {
            //        rdr1.Close();
            //    }
            //}
            ////     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //#endregion



        }

        //  inputVATandFBL5toFBL5newthisperiodAgain


        public void inputVATandFBL5toFBL5newthisperiodAgain()
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            dc.ExecuteCommand("DELETE FROM tbl_Comboundtemp");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();



            // Utils ut = new Utils();
            string destConnString = Utils.getConnectionstr();




        //    #region    deposit da save

        //          SqlConnection conn2 = null;
        //        SqlDataReader rdr1 = null;
        //    //  string destConnString = Utils.getConnectionstr();
        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("saveDepositemp", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        cmd1.CommandTimeout = 0;
        //        //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
        //    //    cmd1.CommandTimeout = 0;
        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);





        //    #endregion



        //    #region update remark from remak to FBL5N


        //    dc.CommandTimeout = 0;
        //    dc.ExecuteCommand("DELETE FROM tblFBL5Nnewthisperiod");

        //    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    dc.SubmitChanges();

        //    #endregion




        //    #region update remark from remak to FBL5N
        //    //    SqlConnection conn2 = null;
        //    //   SqlDataReader rdr1 = null;
        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("updateRemarktoFBL5N", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        cmd1.CommandTimeout = 0;
        //        //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    #endregion



        //    #region insert fBL5N BY PRODUCE EXCEUTE

        ////    SqlConnection conn2 = null;
        ////    SqlDataReader rdr1 = null;

        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("insertFbl5nthisfromFBL5n", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        cmd1.CommandTimeout = 0;
        //        //   cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //   MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    #endregion UPDATE FBL5N





        //    #region update fbl5n

        //    string userupdate = Utils.getusername();
        //      //    SqlConnection conn2 = null;
        //        //  SqlDataReader rdr1 = null;
        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("UpdateFbl5n", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    #endregion UPDATE FBL5N






        //    #region update codegroup from code group
        //    //updateCustgoupThistable

        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("updateCustgoupThistable", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    #endregion



        //    #region update VAT out to this preriod
        //    //   updateVATout

        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("updateVATout", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        cmd1.CommandTimeout = 0;
        //        //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);





        //    #endregion update vat out


        //    #region update edlp lên this priod

        //    //    updateEdlp

        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("updateEdlp", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        cmd1.CommandTimeout = 0;
        //        //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);





        //    #endregion



        //    #region update comboudlisst group acoout and account
        //    tbl_Comboundtemp t = new tbl_Comboundtemp();
        //    //    t.Code
        //    //    t.codeGroup
        //    //      t.name
        //    //   updateComountemp
        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("updateComountemp", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        cmd1.CommandTimeout = 0;
        //        //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



        //    #endregion


        //    #region   update deposit da save

        //    //      SqlConnection conn2 = null;
        //    //    SqlDataReader rdr1 = null;
        //    //  string destConnString = Utils.getConnectionstr();
        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("updateagaindepositSave", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        cmd1.CommandTimeout = 0;
        //        //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
        //        cmd1.CommandTimeout = 0;
        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);





        //    #endregion





        }

        public void inputVATandFBL5toFBL5newthisperiod()
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            dc.ExecuteCommand("DELETE FROM tbl_Comboundtemp");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();



            // Utils ut = new Utils();
            string destConnString = Utils.getConnectionstr();


       //     #region update remark from remak to FBL5N
       //     SqlConnection conn2 = null;
       //         SqlDataReader rdr1 = null;
       //     try
       //     {

       //         conn2 = new SqlConnection(destConnString);
       //         conn2.Open();
       //         SqlCommand cmd1 = new SqlCommand("updateRemarktoFBL5N", conn2);
       //         cmd1.CommandType = CommandType.StoredProcedure;
       //         cmd1.CommandTimeout = 0;
       //         //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

       //         rdr1 = cmd1.ExecuteReader();



       //         //       rdr1 = cmd1.ExecuteReader();

       //     }
       //     finally
       //     {
       //         if (conn2 != null)
       //         {
       //             conn2.Close();
       //         }
       //         if (rdr1 != null)
       //         {
       //             rdr1.Close();
       //         }
       //     }
       //     //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

       //     #endregion



       //     #region insert fBL5N BY PRODUCE EXCEUTE

       ////     SqlConnection conn2 = null;
       ////     SqlDataReader rdr1 = null;

       //     try
       //     {

       //         conn2 = new SqlConnection(destConnString);
       //         conn2.Open();
       //         SqlCommand cmd1 = new SqlCommand("insertFbl5nthisfromFBL5n", conn2);
       //         cmd1.CommandType = CommandType.StoredProcedure;
       //         cmd1.CommandTimeout = 0;
       //         //   cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

       //         rdr1 = cmd1.ExecuteReader();



       //         //       rdr1 = cmd1.ExecuteReader();

       //     }
       //     finally
       //     {
       //         if (conn2 != null)
       //         {
       //             conn2.Close();
       //         }
       //         if (rdr1 != null)
       //         {
       //             rdr1.Close();
       //         }
       //     }
       //     //   MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

       //     #endregion UPDATE FBL5N



       //     #region UPDATE fBL5N BY PRODUCE EXCEUTE

       //     string userupdate = Utils.getusername();
       //     //      SqlConnection conn2 = null;
       //     //      SqlDataReader rdr1 = null;
       //     try
       //     {

       //         conn2 = new SqlConnection(destConnString);
       //         conn2.Open();
       //         SqlCommand cmd1 = new SqlCommand("UpdateFbl5n", conn2);
       //         cmd1.CommandType = CommandType.StoredProcedure;
       //         cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

       //         rdr1 = cmd1.ExecuteReader();



       //         //       rdr1 = cmd1.ExecuteReader();

       //     }
       //     finally
       //     {
       //         if (conn2 != null)
       //         {
       //             conn2.Close();
       //         }
       //         if (rdr1 != null)
       //         {
       //             rdr1.Close();
       //         }
       //     }
       //     //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

       //     #endregion UPDATE FBL5N


       //     #region update codegroup from code group
       //     //updateCustgoupThistable

       //     try
       //     {

       //         conn2 = new SqlConnection(destConnString);
       //         conn2.Open();
       //         SqlCommand cmd1 = new SqlCommand("updateCustgoupThistable", conn2);
       //         cmd1.CommandType = CommandType.StoredProcedure;
       //         cmd1.CommandTimeout = 0;
       //         //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

       //         rdr1 = cmd1.ExecuteReader();



       //         //       rdr1 = cmd1.ExecuteReader();

       //     }
       //     finally
       //     {
       //         if (conn2 != null)
       //         {
       //             conn2.Close();
       //         }
       //         if (rdr1 != null)
       //         {
       //             rdr1.Close();
       //         }
       //     }
       //     //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

       //     #endregion



       //     #region update VAT out to this preriod
       //     //   updateVATout

       //     try
       //     {

       //         conn2 = new SqlConnection(destConnString);
       //         conn2.Open();
       //         SqlCommand cmd1 = new SqlCommand("updateVATout", conn2);
       //         cmd1.CommandType = CommandType.StoredProcedure;
       //         cmd1.CommandTimeout = 0;
       //         //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

       //         rdr1 = cmd1.ExecuteReader();



       //         //       rdr1 = cmd1.ExecuteReader();

       //     }
       //     finally
       //     {
       //         if (conn2 != null)
       //         {
       //             conn2.Close();
       //         }
       //         if (rdr1 != null)
       //         {
       //             rdr1.Close();
       //         }
       //     }
       //     //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);





       //     #endregion update vat out


       //     #region update edlp lên this priod

       //     //    updateEdlp

       //     try
       //     {

       //         conn2 = new SqlConnection(destConnString);
       //         conn2.Open();
       //         SqlCommand cmd1 = new SqlCommand("updateEdlp", conn2);
       //         cmd1.CommandType = CommandType.StoredProcedure;
       //         cmd1.CommandTimeout = 0;
       //         //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

       //         rdr1 = cmd1.ExecuteReader();



       //         //       rdr1 = cmd1.ExecuteReader();

       //     }
       //     finally
       //     {
       //         if (conn2 != null)
       //         {
       //             conn2.Close();
       //         }
       //         if (rdr1 != null)
       //         {
       //             rdr1.Close();
       //         }
       //     }
       //     //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);





       //     #endregion



       //     #region update comboudlisst group acoout and account
       //     tbl_Comboundtemp t = new tbl_Comboundtemp();
       //     //    t.Code
       //     //    t.codeGroup
       //     //      t.name
       //     //   updateComountemp
       //     try
       //     {

       //         conn2 = new SqlConnection(destConnString);
       //         conn2.Open();
       //         SqlCommand cmd1 = new SqlCommand("updateComountemp", conn2);
       //         cmd1.CommandType = CommandType.StoredProcedure;
       //         cmd1.CommandTimeout = 0;
       //         //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

       //         rdr1 = cmd1.ExecuteReader();



       //         //       rdr1 = cmd1.ExecuteReader();

       //     }
       //     finally
       //     {
       //         if (conn2 != null)
       //         {
       //             conn2.Close();
       //         }
       //         if (rdr1 != null)
       //         {
       //             rdr1.Close();
       //         }
       //     }
       //     //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



       //     #endregion





        }


        public void inputthisisperiodtoFBL5nnew()
        {

            //   Thread.Sleep(5000);
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            #region update to fbl5n new
            // kiểm tra nếu doc tblFBL5Nnewthisperiod đã có trong tblFBL5Nnew thì thoát luôn





            #region copy kiểu sql vao sql


       





            #endregion





            #endregion update to fbl5n 

        }



        public void ARlettermakebyGroupcode2(LinqtoSQLDataContext db, DateTime fromdate, DateTime todate, DateTime returndate)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;

       
            

        }


        public void ARlettermakebyGroupcodeRegionOld(LinqtoSQLDataContext db, DateTime fromdate, DateTime todate, DateTime returndate)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        



        }

        public void ARlettermakebyGroupcode2Onlycode(LinqtoSQLDataContext db, DateTime fromdate, DateTime todate, DateTime returndate, double onlycode)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;

            //List<tbl_ColdetailRpt> tbl_ColdetailRptlist = new List<tbl_ColdetailRpt>();
            //List<tbl_ArletterdetailRpt> tbl_ArletterdetailRptlist = new List<tbl_ArletterdetailRpt>();
            //List<tbl_ARdetalheaderRpt> tbl_ARdetalheaderRptlist = new List<tbl_ARdetalheaderRpt>();

            //List<tbl_ArletterRpt> tbl_ArletterRptlist = new List<tbl_ArletterRpt>();




            //#region  updateCustgoupinListcustmakeRptVN ra TREN SQL dang viet 
            //SqlConnection conn2 = null;
            //SqlDataReader rdr1 = null;

            //string destConnString = Utils.getConnectionstr();
            //try
            //{

            //    conn2 = new SqlConnection(destConnString);
            //    conn2.Open();
            //    SqlCommand cmd1 = new SqlCommand("updateCustgoupinListcustmakeRptVNO_Onlycode", conn2);
            //    cmd1.CommandType = CommandType.StoredProcedure;
            //    cmd1.CommandTimeout = 0;
            //       cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;
            //    try
            //    {
            //        rdr1 = cmd1.ExecuteReader();
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("ERRor run: updateCustgoupinListcustmakeRptVN \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }




            //    //       rdr1 = cmd1.ExecuteReader();

            //}
            //finally
            //{
            //    if (conn2 != null)
            //    {
            //        conn2.Close();
            //    }
            //    if (rdr1 != null)
            //    {
            //        rdr1.Close();
            //    }
            //}
            ////     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //#endregion



            //#region // xóa ar belance begine temp cu để chuẩn bị cái mới
            ////  LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //try
            //{
            //    dc.CommandTimeout = 0;
            //    dc.ExecuteCommand("DELETE FROM tblFBL5beginbalaceTemp");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ERRor run: tblFBL5beginbalaceTemp \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            //dc.SubmitChanges();
            //#endregion



            //#region // xóa data AR letter data reports cũ



            ////var rs2 = from tbl_ArletterRpt in db.tbl_ArletterRpts
            ////          select tbl_ArletterRpt;


            ////db.tbl_ArletterRpts.DeleteAllOnSubmit(rs2);

            ////db.SubmitChanges();
            //#region // XÓA toàn bộ tbl_ArletterRpt
            //dc.CommandTimeout = 0;
            //try
            //{
            //    dc.ExecuteCommand("DELETE FROM tbl_ArletterRpt");
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("ERRor run: tblFBL5beginbalaceTemp \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);

            //dc.SubmitChanges();
            //#endregion

            //#endregion        //   xóa data AR letter


            //#region // xóa ar header cdata reports cũ
            ////var rs6 = from tbl_ARdetalheaderRpt in db.tbl_ARdetalheaderRpts
            ////          select tbl_ARdetalheaderRpt;
            ////db.tbl_ARdetalheaderRpts.DeleteAllOnSubmit(rs6);
            ////db.SubmitChanges();


            //#region // XÓA toàn bộ tbl_ARdetalheaderRpt
            //try
            //{
            //    dc.CommandTimeout = 0;
            //    dc.ExecuteCommand("DELETE FROM tbl_ARdetalheaderRpt");
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("ERRor delete: tbl_ARdetalheaderRpt \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            //dc.SubmitChanges();
            //#endregion
            //#endregion// xóa ddataa cũ sau do update data mới


            //#region // xóa col cũ data reports cũ
            ////var rs7 = from tbl_ColdetailRpt in db.tbl_ColdetailRpts
            ////          select tbl_ColdetailRpt;
            ////db.tbl_ColdetailRpts.DeleteAllOnSubmit(rs7);
            ////db.SubmitChanges();


            //#region // XÓA toàn bộ tbl_ColdetailRpt
            //dc.CommandTimeout = 0;
            //try
            //{
            //    dc.ExecuteCommand("DELETE FROM tbl_ColdetailRpt");
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("ERRor delete: tbl_ColdetailRpt \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            //dc.SubmitChanges();
            //#endregion




            //#endregion// xóa ddataa cũ sau do update data mới


            //#region // xóa ddataadetail datatbl_ArletterdetailRpt cũ
            ////var rs3 = from tbl_ArletterdetailRpt in db.tbl_ArletterdetailRpts
            ////          select tbl_ArletterdetailRpt;
            ////db.tbl_ArletterdetailRpts.DeleteAllOnSubmit(rs3);
            ////db.SubmitChanges();





            //#region // XÓA toàn bộ tbl_ArletterdetailRpt ok
            //dc.CommandTimeout = 0;
            //try
            //{
            //    dc.ExecuteCommand("DELETE FROM tbl_ArletterdetailRpt");
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("ERRor delete: tbl_ArletterdetailRpt \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            //dc.SubmitChanges();
            //#endregion

            //#endregion// xóa ddataa cũ sau do update data mới


            //#region update updatebeginBalacegruop_Onlycode viet ok
            ////   SqlConnection conn2 = null;
            ////   SqlDataReader rdr1 = null;

            ////  string destConnString = Utils.getConnectionstr();
            //try
            //{

            //    conn2 = new SqlConnection(destConnString);
            //    conn2.Open();
            //    SqlCommand cmd1 = new SqlCommand("updatebeginBalacegruop_Onlycode", conn2);
            //    cmd1.CommandTimeout = 0;
            //    cmd1.CommandType = CommandType.StoredProcedure;
            //    cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;


            //    dc.CommandTimeout = 0;

            //    try
            //    {
            //        rdr1 = cmd1.ExecuteReader();
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("ERRor make: updatebeginBalacegruop \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }




            //    //       rdr1 = cmd1.ExecuteReader();

            //}
            //finally
            //{
            //    if (conn2 != null)
            //    {
            //        conn2.Close();
            //    }
            //    if (rdr1 != null)
            //    {
            //        rdr1.Close();
            //    }
            //}
            ////     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //#endregion




            //#region update update Fbl5nnew  customer group để lọc ra để lọc ra TREN SQL dang viet  ok
            ////   SqlConnection conn2 = null;
            ////   SqlDataReader rdr1 = null;


            //// Create the connection.
            //using (SqlConnection connection = new SqlConnection(destConnString))
            //{
            //    // Open the connection.
            //    connection.Open();

            //    // Create the command.
            //    using (SqlCommand command = new SqlCommand("updaFBL5nreportsBalacegroupVN_Onlycode", connection))
            //    {
            //        // Set the command type.
            //        command.CommandType = System.Data.CommandType.StoredProcedure;
            //        command.CommandTimeout = 0;
            //        // Add the parameter.
            //        SqlParameter parameter = command.Parameters.Add("@todate",
            //            System.Data.SqlDbType.DateTime);
            //        command.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

            //        // Set the value.
            //        parameter.Value = todate;

            //        // Make the call.
            //        try
            //        {
            //            command.ExecuteNonQuery();
            //        }
            //        catch (Exception ex)
            //        {

            //            MessageBox.Show("ERRor make: updatebeginBalacegruop \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //    }
            //}





            ////     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //#endregion


     

            //#region update  update Freglasess  customer group để lọc ra trên sql ok
            ////    SqlConnection conn2 = null;
            ////   SqlDataReader rdr1 = null;

            ////   string destConnString = Utils.getConnectionstr();
            //try
            //{

            //    conn2 = new SqlConnection(destConnString);
            //    conn2.Open();
            //    SqlCommand cmd1 = new SqlCommand("updateFreglasessgroupVN_onlycode", conn2);
            //    cmd1.CommandTimeout = 0;
            //    cmd1.CommandType = CommandType.StoredProcedure;
            //        cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;
            //    try
            //    {
            //        rdr1 = cmd1.ExecuteReader();
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("ERRor make: updateFreglasessgroupVN \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }




            //    //       rdr1 = cmd1.ExecuteReader();

            //}
            //finally
            //{
            //    if (conn2 != null)
            //    {
            //        conn2.Close();
            //    }
            //    if (rdr1 != null)
            //    {
            //        rdr1.Close();
            //    }
            //}
            ////     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //#endregion




            //#region  // tính bàng tbl_ArletterRptra trên sql ok

            //try
            //{

            //    conn2 = new SqlConnection(destConnString);
            //    conn2.Open();
            //    SqlCommand cmd1 = new SqlCommand("tbl_ArletterRptcaculationinserts_Onlycode", conn2);
            //    cmd1.CommandType = CommandType.StoredProcedure;

            //    cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
            //    cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
            //    cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
            //    cmd1.Parameters.Add("@byregion", SqlDbType.Int).Value = 0;
            //    cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

            //    cmd1.CommandTimeout = 0;
            //    try
            //    {
            //        rdr1 = cmd1.ExecuteReader();
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("ERRor make: tbl_ArletterRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }




            //    //       rdr1 = cmd1.ExecuteReader();

            //}
            //finally
            //{
            //    if (conn2 != null)
            //    {
            //        conn2.Close();
            //    }
            //    if (rdr1 != null)
            //    {
            //        rdr1.Close();
            //    }
            //}
            ////     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //#endregion old


            //#region  //  //tính bảng tbl_ArletterdetailRpt tren sql ok

            //try
            //{

            //    conn2 = new SqlConnection(destConnString);
            //    conn2.Open();
            //    SqlCommand cmd1 = new SqlCommand("tbl_ArletterdetailRptcaculationinserts_onlycode", conn2);
            //    cmd1.CommandType = CommandType.StoredProcedure;

            //    cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
            //    cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
            //    cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
            //    cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

            //    cmd1.CommandTimeout = 0;

            //    try
            //    {
            //        rdr1 = cmd1.ExecuteReader();

            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("ERRor make: tbl_ArletterdetailRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }



            //    //       rdr1 = cmd1.ExecuteReader();

            //}
            //finally
            //{
            //    if (conn2 != null)
            //    {
            //        conn2.Close();
            //    }
            //    if (rdr1 != null)
            //    {
            //        rdr1.Close();
            //    }
            //}
            ////     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //#endregion


            //#region  //  tính bảng   tbl_ARdetalheaderRpt  tren sql ok

            //try
            //{

            //    conn2 = new SqlConnection(destConnString);
            //    conn2.Open();
            //    SqlCommand cmd1 = new SqlCommand("tbl_ARdetalheaderRptcaculationinserts_onlycode", conn2);
            //    cmd1.CommandType = CommandType.StoredProcedure;

            //    cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
            //    cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
            //    cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
            //    cmd1.Parameters.Add("@byregion", SqlDbType.Int).Value = 0;
            //    cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

            //    cmd1.CommandTimeout = 0;

            //    try
            //    {
            //        rdr1 = cmd1.ExecuteReader();
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("ERRor make: tbl_ARdetalheaderRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }




            //    //       rdr1 = cmd1.ExecuteReader();

            //}
            //finally
            //{
            //    if (conn2 != null)
            //    {
            //        conn2.Close();
            //    }
            //    if (rdr1 != null)
            //    {
            //        rdr1.Close();
            //    }
            //}
            ////     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //#endregion



            //#region  //  tính bảng  tbl_Coldetail tren sql ok

            //try
            //{

            //    conn2 = new SqlConnection(destConnString);
            //    conn2.Open();
            //    SqlCommand cmd1 = new SqlCommand("tbl_ColdetailRptcaculationinserts_onlycode", conn2);
            //    cmd1.CommandType = CommandType.StoredProcedure;

            //    cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
            //    cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
            //    cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
            //    cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

            //    cmd1.CommandTimeout = 0;
            //    try
            //    {
            //        rdr1 = cmd1.ExecuteReader();

            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("ERRor make: tbl_ColdetailRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }



            //    //       rdr1 = cmd1.ExecuteReader();

            //}
            //finally
            //{
            //    if (conn2 != null)
            //    {
            //        conn2.Close();
            //    }
            //    if (rdr1 != null)
            //    {
            //        rdr1.Close();
            //    }
            //}
            ////     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //#endregion






            //throw new NotImplementedException();
        }

        public void ARlettermakebyGroupcodeRegion(LinqtoSQLDataContext db, DateTime fromdate, DateTime todate, DateTime returndate)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        
        }

        internal void inputthisisperiodtoFBL5nnewTEMP()
        {
         
        }


        // ARlettermakebyGroupcodeRegion




        class datatoExport
        {
            public System.Data.DataTable dataGrid1 { get; set; }
            public string filename { get; set; }
            public string tittle { get; set; }
        }
        public static void exportsexcel(object objextoEl)
        {

            datatoExport dat = (datatoExport)objextoEl;


            //      DataTable table, string filename
            DataTable dt = dat.dataGrid1;
            string filename = dat.filename;
            //   SpreadsheetDocument spse = SpreadsheetDocument.Create(filename, SpreadsheetDocumentType.Workbook);
            //Exporting to Excel

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            //ExcelDocument xls = new ExcelDocument();
            //xls.easy_WriteXLSFile_FromDataSet("datatable.xls", ds,
            //           new ExcelAutoFormat(DocumentFormat.OpenXml.Wordprocessing.Styles.AUTOFORMAT_EASYXLS1), "DataTable");


            //string folderPath = "C:\\Excel\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            try
            {
                //using (XLWorkbook wb = new XLWorkbook())
                //{

                ExportToExcel.ExportToExcel.ExportDataSet(ds, filename);
                //    wb.Worksheets.Add(ds);
                //    wb.SaveAs(filename);
                //}
                MessageBox.Show(filename + " exported !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Thông báo không excel export được ! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public static string GetExcelColumnName(int columnIndex)
        {
            //  eg  (0) should return "A"
            //      (1) should return "B"
            //      (25) should return "Z"
            //      (26) should return "AA"
            //      (27) should return "AB"
            //      ..etc..
            char firstChar;
            char secondChar;
            char thirdChar;

            if (columnIndex < 26)
            {
                return ((char)('A' + columnIndex)).ToString();
            }

            if (columnIndex < 702)
            {
                firstChar = (char)('A' + (columnIndex / 26) - 1);
                secondChar = (char)('A' + (columnIndex % 26));

                return string.Format("{0}{1}", firstChar, secondChar);
            }

            int firstInt = columnIndex / 26 / 26;
            int secondInt = (columnIndex - firstInt * 26 * 26) / 26;
            if (secondInt == 0)
            {
                secondInt = 26;
                firstInt = firstInt - 1;
            }
            int thirdInt = (columnIndex - firstInt * 26 * 26 - secondInt * 26);

            firstChar = (char)('A' + firstInt - 1);
            secondChar = (char)('A' + secondInt - 1);
            thirdChar = (char)('A' + thirdInt);

            return string.Format("{0}{1}{2}", firstChar, secondChar, thirdChar);
        }



        public static void exportsexcelold(object objextoEl)
        {

            datatoExport dat = (datatoExport)objextoEl;

            //    DataTable dataTble = new DataTable();
            //   DataSet dataSet, string outputPath

            // Create the Excel Application object
            cExcel.ApplicationClass excelApp = new cExcel.ApplicationClass();

            // Create a new Excel Workbook
            cExcel.Workbook excelWorkbook = excelApp.Workbooks.Add();

            int sheetIndex = 0;

            System.Data.DataTable DataTable = dat.dataGrid1;
            var tittle = dat.tittle;
            var ExcelFilePath = dat.filename;

            // Copy the DataTable to an object array
            //  object[,] Arr = new object[dt.Rows.Count, dt.Columns.Count];

            cExcel.Worksheet Worksheet = (cExcel.Worksheet)excelWorkbook.Sheets.Add(
            excelWorkbook.Sheets.get_Item(++sheetIndex),
            Type.Missing, 1, cExcel.XlSheetType.xlWorksheet);


            #region
            try
            {
                int ColumnsCount;

                if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                //    Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                //     Excel.Workbooks.Add();
                ColumnsCount = DataTable.Columns.Count;
                int RowsCount = DataTable.Rows.Count;
                // single worksheet
                //    Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;

                object[] Header = new object[ColumnsCount];

                // column headings               
                for (int i = 0; i < ColumnsCount; i++)
                    Header[i] = DataTable.Columns[i].ColumnName;

                Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
                HeaderRange.Value = Header;
                HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                HeaderRange.Font.Bold = true;

                // DataCells
                int downloadtimes = 0;
                int rowdown = 30000;
                int totalrowcount = 0;
                int maxrows = 0;
                do
                {
                    downloadtimes++;
                    totalrowcount = rowdown * downloadtimes;


                    object[,] Cells = new object[rowdown, ColumnsCount];

                    //for (int j = 0; j < RowsCount; j++)
                    //    for (int i = 0; i < ColumnsCount; i++)
                    //        Cells[j, i] = DataTable.Rows[j][i
                    if (RowsCount >= (downloadtimes) * rowdown)
                    {
                        maxrows = (downloadtimes) * rowdown;
                    }
                    else
                    {
                        maxrows = RowsCount;
                    }
                    for (int j = (downloadtimes - 1) * rowdown; j < maxrows; j++)
                        for (int i = 0; i < ColumnsCount; i++)
                            Cells[j, i] = DataTable.Rows[j][i];



                    Worksheet.get_Range("A" + GetExcelColumnName((downloadtimes - 1) * rowdown + 1) + ":" + GetExcelColumnName(ColumnsCount - 1) + (RowsCount + 1).ToString(), Type.Missing).Value2 = Cells;


                } while (maxrows == RowsCount);


                if (ExcelFilePath != null && ExcelFilePath != "")
                {
                    try
                    {
                        Worksheet.SaveAs(ExcelFilePath, cExcel.XlFileFormat.xlOpenXMLWorkbook);
                        excelApp.Quit();
                        excelApp = null;
                        MessageBox.Show(ExcelFilePath + " exported !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! \n"
                            + ex.Message);
                    }
                }
                else    // no filepath is given
                {
                    excelApp.Visible = true;
                }






            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
            #endregion


        }




        //---------





        public void exportExceldatagridtofile(IQueryable IQuery, LinqtoSQLDataContext db, string tittle)
        {


            System.Data.DataTable datatable1 = new System.Data.DataTable();
            //

          //  Utils ul = new Utils();

            datatable1 = Utils.ToDataTable(db, IQuery);


            //  this.dataGridView2.DataSource =  dataGridView1.DataSource;
            //
            #region // connect to excel
            SaveFileDialog theDialog = new SaveFileDialog();
            //


            //   DataGridView dataGridView1 = new DataGridView();
            //   dataGridView1.DataSource = dataGrid.DataSource;

            theDialog.Title = "Export to Excel file";
            theDialog.Filter = "Excel files|*.xlsx";
            theDialog.InitialDirectory = @"C:\";

            #endregion
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string filename = theDialog.FileName.ToString();

                //   DataGridView datagr1 = new DataGridView();
                //  datagr1 = dataGrid1;

                Thread t1 = new Thread(exportsexcel);
                t1.IsBackground = true;
                t1.Start(new datatoExport() { dataGrid1 = datatable1, filename = filename, tittle = tittle });
                // t1.Join();
            }



        }




    }

}