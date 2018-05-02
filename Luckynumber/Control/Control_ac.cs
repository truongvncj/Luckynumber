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


        public bool checkVATnameanddtodata()
        {



            // kiểm tra xem khachs hangf trong vat out da co trong master data ?? da co trong data chua, neu chua co thi add
            //   tblVat vat = new tblVat();
            //  tblCustomer cust = new tblCustomer();
            //        updateVATstatinmaster


            #region  updateVATstatinmaster ra TREN SQL da  viet ok
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateVATstatinmaster", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
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

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            db.CommandTimeout = 0;
            db.ExecuteCommand("DELETE FROM tblCustomerTmp");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            #region  insert into  tblCustomerTmp tempcust = new tblCustomerTmp(); where      where tblVat.Statuscheck == false// true// false
            // SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;

            //      string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("inserttblvatstatusfalseintblCustomerTmp", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

                rdr1 = cmd1.ExecuteReader();



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





            var q = from tblCustomerTmp in dc.tblCustomerTmps
                    select tblCustomerTmp;

            if (q.Count() > 0)
            {



                var typeff = typeof(tblCustomerTmp);

                //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
                View.VInputchange inputcdata = new View.VInputchange("MASTER DATA CUSTOMER ", "LIST CUST IN VATOUT BUT NOT IN CUST MASTER", db, "tblCustomer", "tblCustomerTmp", typeff, "id", "id");
                inputcdata.Visible = false;
                inputcdata.ShowDialog();
                //   Viewtable viewtbl = new Viewtable(q, dc, "List customer có trong VAT out không có trong master customer data !");

                return false;

            }
            else
            {
                return true;

            }


        }


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



        public bool checkVATandFBL5n()
        {

            tblFBL5N fb5 = new tblFBL5N();
            tblVat vat = new tblVat();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;
            //     updatetblFBL5NnewthisperiodFromOM


            #region  updatetblFBL5NnewthisperiodFromOM ra TREN SQL dang viet 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updatetblFBL5NnewthisperiodFromOM", conn2);
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


            #region q8 List các document có deposit trong fbl5n  không có trong tblEDLP

            var q8 = from fbl5n in dc.tblFBL5Ns
                     where fbl5n.Deposit != 0 && !(from tblEDLP in dc.tblEDLPs
                                                   select tblEDLP.Invoice_Doc_Nr
                                       ).Contains(fbl5n.Document_Number)

                     select fbl5n;


            if (q8.Count() != 0)
            {

                Viewtable viewtbl = new Viewtable(q8, dc, "List các document có trong fbl5n deposit không có trong tblEDLP  ! Please check !", 1, DateTime.Today, DateTime.Today);

                viewtbl.Visible = false;
                viewtbl.ShowDialog();
                return false;
            }

            #endregion List các document có trong tblEDLP không có trong VAT


            #region q List các document có trong bảng VAT không có trong bảng FBL5N !
            //---
            var q = from tblVat in dc.tblVats
                    where !(from tblFBL5N in dc.tblFBL5Ns
                            select tblFBL5N.Document_Number).Contains(tblVat.SAP_Invoice_Number)
                    //Tương đương từ khóa NOT IN trong SQL
                    select tblVat;



            if (q.Count() != 0)
            {

                Viewtable viewtbl = new Viewtable(q, dc, "List các document có trong bảng VAT không có trong bảng FBL5N ! Please check ", 1, DateTime.Today, DateTime.Today);
                return false;
            }

            #endregion q "List các document có trong bảng VAT không có trong bảng FBL5N !


            // CHIR NGUOI CO QUYEN MOI DUOC MAKE CUAR 

            Username user = new Username();
          //  Boolean right = user.right;


            //int rightnumber = Utils.getrightnumber();

            //      MessageBox.Show(rightnumber.ToString());

            if (!user.uploadpriviousPriod)
            {
                //  this.dELETEALLDATABASEEDITToolStripMenuItem.Visible = true;


                #region q1 List các document POSTINGD DATE < = MAX POTING DAT =E CUA THANG TRUOC
                //---
                DateTime maxpotingdate = (from tblFBL5Nnew in dc.tblFBL5Nnews
                                          select tblFBL5Nnew.Posting_Date).Max().GetValueOrDefault();

                if (maxpotingdate != null)
                {
                    var q11 = from tblFBL5N in dc.tblFBL5Ns
                              where tblFBL5N.Posting_Date <= maxpotingdate
                              //Tương đương từ khóa NOT IN trog SQL
                              select tblFBL5N;
                    
                    if (q11.Count() != 0)
                    {

                        Viewtable viewtbl = new Viewtable(q11, dc, "Data có các list sau có ngày post thuộc các tháng trước đã post ! Please check ", 1, DateTime.Today, DateTime.Today);
                        return false;
                    }

                
                }


                #endregion q "List các document có trong bảng VAT không có trong bảng FBL5N !

            }






            #region q2 List các document có trong bảng FBL5N không có trong bảng VAT 

            var q2 = from tblFBL5N in dc.tblFBL5Ns
                     where !(from tblVat in dc.tblVats
                             select tblVat.SAP_Invoice_Number).Contains(tblFBL5N.Document_Number) && (tblFBL5N.Document_Type == "RV")
                     //Tương đương từ khóa NOT IN trong SQL
                     select tblFBL5N;

            if (q2.Count() != 0)
            {
                // fbl5n_ctrl md = new fbl5n_ctrl();
                //var rs = md.fbl5nsetlect_all();

                Viewtable viewtbl = new Viewtable(q2, dc, "List các document có trong bảng FBL5N không có trong bảng VAT ! Please check ", 1, DateTime.Today, DateTime.Today);
                viewtbl.Visible = false;
                viewtbl.ShowDialog();

                return false;
            }

            #endregion List các document có trong bảng FBL5N không có trong bảng VAT 


            #region q3 List các document có trong tblEDLP không có trong VAT

            var q3 = (from tblEDLP in dc.tblEDLPs
                      group tblEDLP by tblEDLP.Invoice_Doc_Nr into OD//Tương đương GROUP BY trong SQL
                      orderby OD.Key
                      where !(from tblVat in dc.tblVats
                              select tblVat.SAP_Invoice_Number).Contains(OD.Key)

                      select new
                      {
                          Document_Number = OD.Key,
                          Name = OD.Select(m => m.Cust_Name).FirstOrDefault(),
                          Value_Count = OD.Sum(m => m.Cond_Value)




                      });

            if (q3.Count() != 0)
            {

                Viewtable viewtbl = new Viewtable(q3, dc, "List các document có trong tblEDLP không có trong VAT ! Please check !", 1, DateTime.Today, DateTime.Today);

                viewtbl.Visible = false;
                viewtbl.ShowDialog();
                return false;
            }

            #endregion List các document có trong tblEDLP không có trong VAT


            #region q4 List các document có trong FBL5n đã update data

            var q4 = from tblFBL5N in dc.tblFBL5Ns
                     from tblFBL5Nnew in dc.tblFBL5Nnews
                     where (tblFBL5N.Document_Number == tblFBL5Nnew.Document_Number)
                     select tblFBL5N;

            if (q4.Count() != 0)
            {


                Viewtable viewtbl = new Viewtable(q4, dc, "List các document có trong FBL5n đã update trên server ! Please check !", 1, DateTime.Today, DateTime.Today);
                viewtbl.Visible = false;
                viewtbl.ShowDialog();

                return false;
            }
            #endregion List các document có trong FBL5n đã update data


            #region  q5 List các document có trong bảng EDLP không có trong bảng FBL5n 
            var q5 = from tblEDLP in dc.tblEDLPs
                     where !(from tblFBL5N in dc.tblFBL5Ns
                             where tblFBL5N.Document_Type == "RV"
                             select tblFBL5N.Document_Number).Contains(tblEDLP.Invoice_Doc_Nr)
                     //Tương đương từ khóa NOT IN trong SQL
                     select tblEDLP;

            if (q5.Count() != 0)
            {
                // fbl5n_ctrl md = new fbl5n_ctrl();
                //var rs = md.fbl5nsetlect_all();
                Viewtable viewtbl = new Viewtable(q5, dc, "List các document có trong bảng EDLP không có trong bảng FBL5n ! Please check ", 1, DateTime.Today, DateTime.Today);
                viewtbl.Visible = false;
                viewtbl.ShowDialog();

                return false;
            }


            #endregion


            #region q6  các doc có số tiền vỏ lệch giữ EDLP/ FBL5n/ VAT



            var q6 = from tblEDLP in dc.tblEDLPs
                     group tblEDLP by tblEDLP.Invoice_Doc_Nr into OD//Tương đương GROUP BY trong SQL
                     from tblFBL5N in dc.tblFBL5Ns
                     from tblVat in dc.tblVats
                     where tblVat.SAP_Invoice_Number == tblFBL5N.Document_Number && tblFBL5N.Document_Number == OD.Key
                       && tblFBL5N.Amount_in_local_currency.GetValueOrDefault(0) != (tblVat.VAT_Amount.GetValueOrDefault(0) + tblVat.Invoice_Amount_Before_VAT.GetValueOrDefault(0))
                        && OD.Sum(m => m.Cond_Value).GetValueOrDefault(0) != tblFBL5N.Amount_in_local_currency.GetValueOrDefault(0) - (tblVat.VAT_Amount.GetValueOrDefault(0) + tblVat.Invoice_Amount_Before_VAT.GetValueOrDefault(0))
                     select new
                     {

                         Document_Number = OD.Key,
                         //   Name = OD.Select(m => m.Cust_Name).FirstOrDefault(),
                         EmptyAmountByEDLP = OD.Sum(m => m.Cond_Value),
                         tblFBL5N.Amount_in_local_currency,
                         tblVat.Invoice_Amount_Before_VAT,
                         tblVat.VAT_Amount,
                         tblVATAmount_in_local_currency = (tblVat.VAT_Amount.GetValueOrDefault(0) + tblVat.Invoice_Amount_Before_VAT.GetValueOrDefault(0)),
                         EmptyAmountByFBL5n = tblFBL5N.Amount_in_local_currency.GetValueOrDefault(0) - (tblVat.VAT_Amount.GetValueOrDefault(0) + tblVat.Invoice_Amount_Before_VAT.GetValueOrDefault(0)),

                     };

            if (q6.Count() > 0)
            {

                Viewtable viewtbl = new Viewtable(q6, dc, "List các doc có số tiền vỏ lệch giữ EDLP/ FBL5n/ VAT ! Please check ", 1, DateTime.Today, DateTime.Today);
                viewtbl.Visible = false;
                viewtbl.ShowDialog();

                return false;

            }
            #endregion



            #region q7 product co trong edlp khong co trong product list



            var q7 = from tblEDLP in dc.tblEDLPs
                     where !(from tbl_Productlist in dc.tbl_Productlists
                             select tbl_Productlist.Mat_Number).Contains(tblEDLP.Mat_Number)
                     group tblEDLP by tblEDLP.Mat_Number into gbg
                     select new

                     {
                         Mat_Number = gbg.Key,
                         Mat_Group = gbg.Select(gg => gg.Mat_Group).FirstOrDefault(),

                         Mat_Text = gbg.Select(gg => gg.Mat_Text).FirstOrDefault(),

                         Mat_Group_Text = gbg.Select(gg => gg.Mat_Group_Text).FirstOrDefault()


                     };



            if (q7.Count() > 0)
            {

                foreach (var item in q7)
                {
                    tbl_ProductlistTMP prdtemp = new tbl_ProductlistTMP();


                    prdtemp.Mat_Number = item.Mat_Number;//.key;
                    try
                    {
                        prdtemp.Mat_Group = double.Parse(item.Mat_Group);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Cột dữ liệu bảng EDLP , mat_group thiếu dữ liệu hoặc sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }

                    prdtemp.Mat_Text = item.Mat_Text;
                    prdtemp.Mat_Group_Text = item.Mat_Group_Text;
                    //  prdtemp.Empty_Group = 1;
                    // prdtemp. = item.Mat_Number;
                    //prdtemp.Mat_Number = item.Mat_Number;
                    //prdtemp.Mat_Number = item.Mat_Number;
                    //prdtemp.Mat_Number = item.Mat_Number;
                    dc.tbl_ProductlistTMPs.InsertOnSubmit(prdtemp);
                    dc.SubmitChanges();



                }





                var typeff = typeof(tbl_ProductlistTMP);

                VInputchange inputcdata = new VInputchange("PRODUCTS CODE MASTER DATA ", "LIST CUST NOT IN PRODUCT CODE MASTER DATA", dc, "tbl_Productlist", "tbl_ProductlistTMP", typeff, "id", "id");

                inputcdata.Visible = false;
                inputcdata.ShowDialog();
                return false;
            }



            #endregion q7 product co trong edlp khong co trong product list



            if (q.Count() + q2.Count() + q3.Count() + q4.Count() + q5.Count() + q7.Count() + q6.Count() + q8.Count() == 0) //  + q9.Count() 
            {
                //  MessageBox.Show("Great!, Data Ready for AR Confirmation reports !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                return false;
            }




        }

        internal void xoavatEDLPandFBL5nDochaveinFbl5nthis()
        {


            #region xoavatEDLPandFBL5nDochaveinFbl5nth
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("DeleteVATEDLPandFBL5nDocexistinFbl5nthis", conn2);
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




            #region    deposit da save

                  SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;
            //  string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("saveDepositemp", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
            //    cmd1.CommandTimeout = 0;
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



            #region update remark from remak to FBL5N


            dc.CommandTimeout = 0;
            dc.ExecuteCommand("DELETE FROM tblFBL5Nnewthisperiod");

            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();

            #endregion




            #region update remark from remak to FBL5N
            //    SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateRemarktoFBL5N", conn2);
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



            #region insert fBL5N BY PRODUCE EXCEUTE

        //    SqlConnection conn2 = null;
        //    SqlDataReader rdr1 = null;

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("insertFbl5nthisfromFBL5n", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //   cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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
            //   MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion UPDATE FBL5N





            #region update fbl5n

            string userupdate = Utils.getusername();
              //    SqlConnection conn2 = null;
                //  SqlDataReader rdr1 = null;
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("UpdateFbl5n", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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

            #endregion UPDATE FBL5N






            #region update codegroup from code group
            //updateCustgoupThistable

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateCustgoupThistable", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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



            #region update VAT out to this preriod
            //   updateVATout

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateVATout", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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





            #endregion update vat out


            #region update edlp lên this priod

            //    updateEdlp

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateEdlp", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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



            #region update comboudlisst group acoout and account
            tbl_Comboundtemp t = new tbl_Comboundtemp();
            //    t.Code
            //    t.codeGroup
            //      t.name
            //   updateComountemp
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateComountemp", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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


            #region   update deposit da save

            //      SqlConnection conn2 = null;
            //    SqlDataReader rdr1 = null;
            //  string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateagaindepositSave", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
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

        public void inputVATandFBL5toFBL5newthisperiod()
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            dc.ExecuteCommand("DELETE FROM tbl_Comboundtemp");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();



            // Utils ut = new Utils();
            string destConnString = Utils.getConnectionstr();


            #region update remark from remak to FBL5N
            SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateRemarktoFBL5N", conn2);
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



            #region insert fBL5N BY PRODUCE EXCEUTE

       //     SqlConnection conn2 = null;
       //     SqlDataReader rdr1 = null;

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("insertFbl5nthisfromFBL5n", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //   cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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
            //   MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion UPDATE FBL5N



            #region UPDATE fBL5N BY PRODUCE EXCEUTE

            string userupdate = Utils.getusername();
            //      SqlConnection conn2 = null;
            //      SqlDataReader rdr1 = null;
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("UpdateFbl5n", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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

            #endregion UPDATE FBL5N


            #region update codegroup from code group
            //updateCustgoupThistable

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateCustgoupThistable", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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



            #region update VAT out to this preriod
            //   updateVATout

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateVATout", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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





            #endregion update vat out


            #region update edlp lên this priod

            //    updateEdlp

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateEdlp", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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



            #region update comboudlisst group acoout and account
            tbl_Comboundtemp t = new tbl_Comboundtemp();
            //    t.Code
            //    t.codeGroup
            //      t.name
            //   updateComountemp
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateComountemp", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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


        public void inputthisisperiodtoFBL5nnew()
        {

            //   Thread.Sleep(5000);
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            #region update to fbl5n new
            // kiểm tra nếu doc tblFBL5Nnewthisperiod đã có trong tblFBL5Nnew thì thoát luôn





            #region copy kiểu sql vao sql


            var rsfbl5n = from tblFBL5Nnewthisperiod in dc.tblFBL5Nnewthisperiods
                          select tblFBL5Nnewthisperiod;

            #region // neeys lớn hơn o có da ta thì updae
            if (rsfbl5n.Count() > 0)
            {


                #region insert thismonth to fbl5new

                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;
                string destConnString = Utils.getConnectionstr();

                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("copyfromThismonthtoFbl5new", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandTimeout = 0;
                    //   cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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
                //   MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #endregion UPDATE FBL5N




            }

            #endregion






            #endregion





            #endregion update to fbl5n 

        }



        public void ARlettermakebyGroupcode2(LinqtoSQLDataContext db, DateTime fromdate, DateTime todate, DateTime returndate)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;

            List<tbl_ColdetailRpt> tbl_ColdetailRptlist = new List<tbl_ColdetailRpt>();
            List<tbl_ArletterdetailRpt> tbl_ArletterdetailRptlist = new List<tbl_ArletterdetailRpt>();
            List<tbl_ARdetalheaderRpt> tbl_ARdetalheaderRptlist = new List<tbl_ARdetalheaderRpt>();

            List<tbl_ArletterRpt> tbl_ArletterRptlist = new List<tbl_ArletterRpt>();




            #region  updateCustgoupinListcustmakeRptVN ra TREN SQL dang viet 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateCustgoupinListcustmakeRptVN", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor run: updateCustgoupinListcustmakeRptVN \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                



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



            #region // xóa ar belance begine temp cu để chuẩn bị cái mới
            //  LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            try
            {
                dc.CommandTimeout = 0;
                dc.ExecuteCommand("DELETE FROM tblFBL5beginbalaceTemp");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRor run: tblFBL5beginbalaceTemp \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion



            #region // xóa data AR letter data reports cũ



            //var rs2 = from tbl_ArletterRpt in db.tbl_ArletterRpts
            //          select tbl_ArletterRpt;


            //db.tbl_ArletterRpts.DeleteAllOnSubmit(rs2);

            //db.SubmitChanges();
            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.CommandTimeout = 0;
            try
            {
                dc.ExecuteCommand("DELETE FROM tbl_ArletterRpt");
            }
            catch (Exception ex)
            {

                 MessageBox.Show("ERRor run: tblFBL5beginbalaceTemp \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);

            dc.SubmitChanges();
            #endregion

            #endregion        //   xóa data AR letter


            #region // xóa ar header cdata reports cũ
            //var rs6 = from tbl_ARdetalheaderRpt in db.tbl_ARdetalheaderRpts
            //          select tbl_ARdetalheaderRpt;
            //db.tbl_ARdetalheaderRpts.DeleteAllOnSubmit(rs6);
            //db.SubmitChanges();


            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            try
            {
                dc.CommandTimeout = 0;
                dc.ExecuteCommand("DELETE FROM tbl_ARdetalheaderRpt");
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERRor delete: tbl_ARdetalheaderRpt \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion
            #endregion// xóa ddataa cũ sau do update data mới


            #region // xóa col cũ data reports cũ
            //var rs7 = from tbl_ColdetailRpt in db.tbl_ColdetailRpts
            //          select tbl_ColdetailRpt;
            //db.tbl_ColdetailRpts.DeleteAllOnSubmit(rs7);
            //db.SubmitChanges();


            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.CommandTimeout = 0;
            try
            {
                dc.ExecuteCommand("DELETE FROM tbl_ColdetailRpt");
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERRor delete: tbl_ColdetailRpt \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion




            #endregion// xóa ddataa cũ sau do update data mới


            #region // xóa ddataadetail data reports cũ
            //var rs3 = from tbl_ArletterdetailRpt in db.tbl_ArletterdetailRpts
            //          select tbl_ArletterdetailRpt;
            //db.tbl_ArletterdetailRpts.DeleteAllOnSubmit(rs3);
            //db.SubmitChanges();





            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.CommandTimeout = 0;
            try
            {
                dc.ExecuteCommand("DELETE FROM tbl_ArletterdetailRpt");
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERRor delete: tbl_ArletterdetailRpt \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
           
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion

            #endregion// xóa ddataa cũ sau do update data mới


            #region update beginbalece  customer group để lọc ra TREN SQL dang viet 
            //   SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;

            //  string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updatebeginBalacegruop", conn2);
                cmd1.CommandTimeout = 0;
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
                dc.CommandTimeout = 0;

                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor make: updatebeginBalacegruop \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            



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




            #region update update Fbl5nnew  customer group để lọc ra để lọc ra TREN SQL dang viet 
            //   SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;


            // Create the connection.
            using (SqlConnection connection = new SqlConnection(destConnString))
            {
                // Open the connection.
                connection.Open();

                // Create the command.
                using (SqlCommand command = new SqlCommand("updaFBL5nreportsBalacegroupVN", connection))
                {
                    // Set the command type.
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandTimeout = 0;
                    // Add the parameter.
                    SqlParameter parameter = command.Parameters.Add("@todate",
                        System.Data.SqlDbType.DateTime);

                    // Set the value.
                    parameter.Value = todate;

                    // Make the call.
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("ERRor make: updatebeginBalacegruop \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                  
                }
            }





            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion






            #region update  update Freglasess  customer group để lọc ra trên sql
            //    SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;

            //   string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateFreglasessgroupVN", conn2);
                cmd1.CommandTimeout = 0;
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor make: updateFreglasessgroupVN \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              



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




            #region  // tính bàng tbl_ArletterRptra trên sql

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ArletterRptcaculationinserts", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                cmd1.Parameters.Add("@byregion", SqlDbType.Int).Value = 0;
                cmd1.CommandTimeout = 0;
                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor make: tbl_ArletterRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                



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

            #endregion old


            #region  //  //tính bảng tbl_ArletterdetailRpt tren sql

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ArletterdetailRptcaculationinserts", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                cmd1.CommandTimeout = 0;

                try
                {
                    rdr1 = cmd1.ExecuteReader();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor make: tbl_ArletterdetailRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               


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


            #region  //  tính bảng   tbl_ARdetalheaderRpt  tren sql

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ARdetalheaderRptcaculationinserts", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                cmd1.Parameters.Add("@byregion", SqlDbType.Int).Value = 0;
                 cmd1.CommandTimeout = 0;

                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor make: tbl_ARdetalheaderRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              



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



            #region  //  tính bảng  tbl_Coldetail tren sql

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ColdetailRptcaculationinserts", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                cmd1.CommandTimeout = 0;
                try
                {
                    rdr1 = cmd1.ExecuteReader();

                }
                catch (Exception ex)
                {

                        MessageBox.Show("ERRor make: tbl_ColdetailRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           


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


        public void ARlettermakebyGroupcodeRegionOld(LinqtoSQLDataContext db, DateTime fromdate, DateTime todate, DateTime returndate)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            List<tbl_ColdetailRpt> tbl_ColdetailRptlist = new List<tbl_ColdetailRpt>();
            List<tbl_ArletterdetailRpt> tbl_ArletterdetailRptlist = new List<tbl_ArletterdetailRpt>();
            List<tbl_ARdetalheaderRpt> tbl_ARdetalheaderRptlist = new List<tbl_ARdetalheaderRpt>();

            List<tbl_ArletterRpt> tbl_ArletterRptlist = new List<tbl_ArletterRpt>();




            #region  updateCustgoupinListcustmakeRptregion ra TREN SQL dang viet 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateCustgoupinListcustmakeRptRegion", conn2);
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



            #region // xóa ar belance begine temp cu để chuẩn bị cái mới
            //var betmp = from tblFBL5beginbalaceTemp in db.tblFBL5beginbalaceTemps
            //            select tblFBL5beginbalaceTemp;

            //if (betmp.Count() > 0)
            //{
            //    db.tblFBL5beginbalaceTemps.DeleteAllOnSubmit(betmp);
            //    db.SubmitChanges();
            //}

            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.ExecuteCommand("DELETE FROM tblFBL5beginbalaceTemp");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion


            #endregion


            #region // xóa data AR letter data reports cũ



            //var rs2 = from tbl_ArletterRpt in db.tbl_ArletterRpts
            //          select tbl_ArletterRpt;


            //db.tbl_ArletterRpts.DeleteAllOnSubmit(rs2);

            //db.SubmitChanges();




            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.ExecuteCommand("DELETE FROM tbl_ArletterRpt");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion

            #endregion        //   xóa data AR letter


            #region // xóa ar header cdata reports cũ
            //var rs6 = from tbl_ARdetalheaderRpt in db.tbl_ARdetalheaderRpts
            //          select tbl_ARdetalheaderRpt;
            //db.tbl_ARdetalheaderRpts.DeleteAllOnSubmit(rs6);
            //db.SubmitChanges();





            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.ExecuteCommand("DELETE FROM tbl_ARdetalheaderRpt");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion


            #endregion// xóa ddataa cũ sau do update data mới


            #region // xóa col cũ data reports cũ
            //var rs7 = from tbl_ColdetailRpt in db.tbl_ColdetailRpts
            //          select tbl_ColdetailRpt;
            //db.tbl_ColdetailRpts.DeleteAllOnSubmit(rs7);
            //db.SubmitChanges();




            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.ExecuteCommand("DELETE FROM tbl_ColdetailRpt");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion
            #endregion// xóa ddataa cũ sau do update data mới


            #region // xóa ddataadetail data reports cũ
            //var rs3 = from tbl_ArletterdetailRpt in db.tbl_ArletterdetailRpts
            //          select tbl_ArletterdetailRpt;
            //db.tbl_ArletterdetailRpts.DeleteAllOnSubmit(rs3);
            //db.SubmitChanges();


            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.ExecuteCommand("DELETE FROM tbl_ArletterdetailRpt");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion
            #endregion// xóa ddataa cũ sau do update data mới





            #region update beginbalece  customer group region để lọc ra TREN SQL dang viet 
            //   SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;

            //  string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updatebeginBalacegruopRegion", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
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





            #region update update Fbl5nnew  customer group để lọc ra để lọc ra TREN SQL dang viet 
            //   SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;


            // Create the connection.
            using (SqlConnection connection = new SqlConnection(destConnString))
            {
                // Open the connection.
                connection.Open();

                // Create the command.
                using (SqlCommand command = new SqlCommand("updaFBL5nreportsBalacegroupRegion", connection))
                {
                    // Set the command type.
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add the parameter.
                    SqlParameter parameter = command.Parameters.Add("@todate",
                        System.Data.SqlDbType.DateTime);

                    // Set the value.
                    parameter.Value = todate;

                    // Make the call.
                    command.ExecuteNonQuery();
                }
            }





            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion




            #region update  update Freglasess  customer group để lọc ra trên sql
            //    SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;

            //   string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateFreglasessgroupREgion", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
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




            #region   // tính bàng tbl_ArletterRpt


            var rsmain = from tblCustomer in dc.tblCustomers
                         where tblCustomer.Reportsend == true
                         select tblCustomer;

            int stt = 0;
            foreach (var tblCustomerv in rsmain)
            {
                tbl_ArletterRpt rptleter = new tbl_ArletterRpt();
                //  stt = stt + 1;
                //   rptleter.No = stt;
                rptleter.address = tblCustomerv.Address;
                rptleter.code = tblCustomerv.Customer;
                //DateTime returndate;
                rptleter.returndate = returndate;
                rptleter.custcodegRoup = tblCustomerv.Cusromergroup;

                rptleter.customername = tblCustomerv.Name_1;
                rptleter.fromdate = fromdate;
                rptleter.toDate = todate;
                rptleter.phone = tblCustomerv.Telephone_1;
                rptleter.region = tblCustomerv.SOrg;



                rptleter.StringAmountEmpty = "";// tính tiếp ở dưới  strign stringemty;
                int vothuong = 0;
                int Chaivothuong = 0;
                int Chaivo1lit = 0;
                int Ketvolit = 0;
                int Ketnhuathuong = 0;
                int Ketnhua1lit = 0;
                int joy20l = 0;
                int Binhpmicc02 = 0;
                int binhpmix9l = 0;
                int palletgo = 0;
                int paletnhua = 0;

                rptleter.sumAmountfull = 0; //tính tblCustomerv.
                rptleter.sumEmptydeposit = 0;  // tính em ty
                rptleter.sumoffreeclass = 0;  // tính fress glasesse

                #region //tính freeglasses vào 

                var rsgl = from tbl_FreGlass in dc.tbl_FreGlasses
                           where tbl_FreGlass.CUSTOMERgroupcode == tblCustomerv.Cusromergroup
                           group tbl_FreGlass by tbl_FreGlass.CUSTOMERgroupcode into gr
                           select gr;

                foreach (var item in rsgl)
                {
                    rptleter.sumoffreeclass = item.Sum(gr => gr.COLAMT);
                }



                #endregion // tính freeglasses vào


                #region //tính sumEmptydeposit ps cộng đầu kỳ + số dư đầu vào 

                var rsemp = from tblFBL5Nnew in dc.tblFBL5Nnews
                            where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date <= todate // && tblFBL5Nnew.Posting_Date >= fromdate
                            group tblFBL5Nnew by tblFBL5Nnew.codeGroup into gr
                            select gr;
                double sumAmountfulldkps = 0;
                double sumEmptydepositdkps = 0;
                double sumAmountfulldkbg = 0;
                double sumEmptydepositdkbg = 0;

                foreach (var item in rsemp)
                {




                    sumAmountfulldkps = (double)item.Sum(gr => gr.Invoice_Amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Payment_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Adjusted_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0));// (double)item.Sum(gr => gr.Fullgood_amount); // đầu kỳ
                    sumEmptydepositdkps = (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0)); // phát sinh trong kỳ


                    vothuong = (int)item.Sum(m => m.Ketvothuong);
                    Chaivothuong = (int)item.Sum(m => m.Chaivothuong);
                    Chaivo1lit = (int)item.Sum(m => m.Chaivo1lit);
                    Ketvolit = (int)item.Sum(m => m.Ketvolit);
                    Ketnhuathuong = (int)item.Sum(m => m.Ketnhuathuong);
                    Ketnhua1lit = (int)item.Sum(m => m.Ketnhua1lit);
                    joy20l = (int)item.Sum(m => m.joy20l);
                    Binhpmicc02 = (int)item.Sum(m => m.Binhpmicc02);
                    binhpmix9l = (int)item.Sum(m => m.binhpmix9l);
                    palletgo = (int)item.Sum(m => m.palletgo);
                    paletnhua = (int)item.Sum(m => m.paletnhua);


                }

                // tính số dư đầu nữa




                var rsdk = from tblFBL5beginbalace in dc.tblFBL5beginbalaces
                           where tblFBL5beginbalace.codeGroup == tblCustomerv.Cusromergroup // && tblFBL5Nnew.Posting_Date <= todate // && tblFBL5Nnew.Posting_Date >= fromdate
                           group tblFBL5beginbalace by tblFBL5beginbalace.codeGroup into gr
                           select gr;

                foreach (var item in rsdk)
                {

                    sumAmountfulldkbg = (double)item.Sum(gr => gr.Fullgood_amount.GetValueOrDefault(0)); // phát sinh trong kỳ
                    sumEmptydepositdkbg = (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0)); // phát sinh trong kỳ



                    vothuong = vothuong + (int)item.Sum(m => m.Ketvothuong);
                    Chaivothuong = Chaivothuong + (int)item.Sum(m => m.Chaivothuong);
                    Chaivo1lit = Chaivo1lit + (int)item.Sum(m => m.Chaivo1lit);
                    Ketvolit = Ketvolit + (int)item.Sum(m => m.Ketvolit);
                    Ketnhuathuong = Ketnhuathuong + (int)item.Sum(m => m.Ketnhuathuong);
                    Ketnhua1lit = Ketnhua1lit + (int)item.Sum(m => m.Ketnhua1lit);
                    joy20l = joy20l + (int)item.Sum(m => m.joy20l);
                    Binhpmicc02 = Binhpmicc02 + (int)item.Sum(m => m.Binhpmicc02);
                    binhpmix9l = binhpmix9l + (int)item.Sum(m => m.binhpmix9l);
                    palletgo = palletgo + (int)item.Sum(m => m.palletgo);
                    paletnhua = paletnhua + (int)item.Sum(m => m.paletnhua);



                }


                rptleter.sumAmountfull = sumAmountfulldkbg + sumAmountfulldkps; // phát sinh trong kỳ
                rptleter.sumEmptydeposit = sumEmptydepositdkbg + sumEmptydepositdkps;

                // tính số dư đầu nữa


                String str = "";
                if (vothuong != 0)
                {

                    str = str + String.Format(vothuong.ToString(), "#,###") + " két vỏ thường; ";

                }
                if (Chaivothuong != 0)
                {

                    str = str + String.Format(Chaivothuong.ToString(), "#,###") + " chai vỏ thường; ";

                }
                if (Chaivo1lit != 0)
                {

                    str = str + String.Format(Chaivo1lit.ToString(), "#,###") + " chai vỏ 1 lít; ";

                }
                if (Ketvolit != 0)
                {

                    str = str + String.Format(Ketvolit.ToString(), "#,###") + " Két vỏ 1 lít; ";

                }
                if (Ketnhuathuong != 0)
                {

                    str = str + String.Format(Ketnhuathuong.ToString(), "#,###") + " Két nhựa; ";

                }
                if (Ketnhua1lit != 0)
                {

                    str = str + String.Format(Ketnhua1lit.ToString(), "#,###") + " Két nhựa 1 lít; ";

                }
                if (joy20l != 0)
                {

                    str = str + String.Format(joy20l.ToString(), "#,###") + " Bình joy 20l; ";

                }
                if (Binhpmicc02 != 0)
                {

                    str = str + String.Format(Binhpmicc02.ToString(), "#,###") + " Bình postmix/CO2; ";

                }
                if (binhpmix9l != 0)
                {

                    str = str + String.Format(binhpmix9l.ToString(), "#,###") + " Bình Postmix9l; ";

                }
                if (palletgo != 0)
                {

                    str = str + String.Format(palletgo.ToString(), "#,###") + " Pallet gỗ; ";

                }
                if (paletnhua != 0)
                {

                    str = str + String.Format(paletnhua.ToString(), "#,###") + " Pallet nhựa; ";

                }

                if (str == "")
                {
                    str = "Không nợ vỏ";
                }
                rptleter.StringAmountEmpty = str;// dòng chữ thể hiện số vỏ nợ


                #endregion // tính freeglasses vào



                if (rptleter.custcodegRoup != null)
                {
                    // tbl_ArletterRptlist.Add(rptleter);
                    //
                    stt = stt + 1;
                    rptleter.No = stt;
                    tbl_ArletterRptlist.Add(rptleter);

                    //   db.tbl_ArletterRpts.InsertOnSubmit(rptleter);
                    //      db.SubmitChanges();



                }




            }

            db.tbl_ArletterRpts.InsertAllOnSubmit(tbl_ArletterRptlist);
            db.SubmitChanges();
            #endregion   // tính bàng tbl_ArletterRpt



            #region   //tính bảng detail reports     tbl_ArletterdetailRpt rpldetail = new tbl_ArletterdetailRpt();


            var rsdETAIL2 = from tblCustomer in dc.tblCustomers
                            where tblCustomer.Reportsend == true
                            select tblCustomer;


            foreach (var tblCustomerv in rsdETAIL2)
            {

                var rsemp = from tblFBL5Nnew in dc.tblFBL5Nnews
                            where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date <= todate && tblFBL5Nnew.Posting_Date >= fromdate
                            // group tblFBL5Nnew by tblFBL5Nnew.codeGroup into gr
                            select tblFBL5Nnew;

                foreach (var item in rsemp)
                {




                    tbl_ArletterdetailRpt rpldetail = new tbl_ArletterdetailRpt();

                    //      rpldetail.amountinloca = item.Fullgood_amount; // full amount
                    rpldetail.customergroup = item.codeGroup;

                    rpldetail.Depositamount = 0;// depossit amount
                    rpldetail.Adjamount = 0;//
                    rpldetail.InvoiceAmount = 0;//
                    rpldetail.Paymentamount = 0;//


                    if (item.Deposit_amount != null)
                    {
                        rpldetail.Depositamount = item.Deposit_amount;   // depossit amount
                    }
                    if (item.Adjusted_amount != null)
                    {
                        rpldetail.Adjamount = item.Adjusted_amount;
                    }

                    if (item.Invoice_Amount != null)
                    {
                        rpldetail.InvoiceAmount = item.Invoice_Amount;
                    }

                    if (item.Payment_amount != null)
                    {
                        rpldetail.Paymentamount = item.Payment_amount;
                    }







                    rpldetail.PostingDate = item.Posting_Date;

                    double kq2 = (double)rpldetail.Depositamount + (double)rpldetail.Adjamount + (double)rpldetail.InvoiceAmount + (double)rpldetail.Paymentamount;

                    //if (rpldetail.InvoiceAmount == null && item.Document_Type == "RV")
                    //{
                    //    rpldetail.InvoiceAmount = item.Amount_in_local_currency - item.Empty_Amount;

                    //}
                    if (item.Document_Type == "RV")
                    {
                        rpldetail.DocNumber = item.Invoice;

                        if (rpldetail.DocNumber == null)
                        {
                            rpldetail.DocNumber = item.SoDelivery.ToString();
                        }

                    }




                    if (item.Document_Type != "RV")
                    {
                        rpldetail.DocNumber = item.Assignment;
                        if (rpldetail.DocNumber == null)
                        {
                            rpldetail.DocNumber = item.Document_Number.ToString();
                        }


                    }






                    if (rpldetail.customergroup != null && kq2 != 0)
                    {




                        tbl_ArletterdetailRptlist.Add(rpldetail);

                        // db.tbl_ArletterdetailRpts.InsertOnSubmit(tbl_ArletterdetailRptlist);
                        //  db.SubmitChanges();

                    }
                }


            }

            db.tbl_ArletterdetailRpts.InsertAllOnSubmit(tbl_ArletterdetailRptlist);
            db.SubmitChanges();
            #endregion   //tính bảng detail reports




            #region   // tính bảng        tbl_ARdetalheaderRpt headerrpt = new tbl_ARdetalheaderRpt();
            //  int stt = 0;

            var rsdETAIL = from tblCustomer in dc.tblCustomers
                           where tblCustomer.Reportsend == true
                           select tblCustomer;


            foreach (var tblCustomerv in rsdETAIL)
            {



                tbl_ARdetalheaderRpt headerrpt = new tbl_ARdetalheaderRpt();


                headerrpt.custcodeGRoup = tblCustomerv.Cusromergroup;
                headerrpt.customername = tblCustomerv.Name_1;
                headerrpt.address = tblCustomerv.Address;
                headerrpt.Fromdate = fromdate;
                headerrpt.Todate = todate;
                headerrpt.region = tblCustomerv.SOrg;// "VN"; // TAM THOI LA CHUNG vn
                headerrpt.phone = tblCustomerv.Telephone_1;
                headerrpt.code = tblCustomerv.Customer;

                #region đầu kỳ  tinh toán số đầu kỳ
                headerrpt.dknuoc = 0; // full good amiunt
                headerrpt.dkvo = 0; // depossit amount

                // headerrpt.No = from tbl_ArletterRpt in dc.tbl_ArletterRpts
                //                where tbl_ArletterRpt.custcodegRoup == 
                //headerrpt.psnuoc = 0;
                //headerrpt.psvo = 0;

                double dknuocps = 0;
                double dkvocps = 0;
                double dkbeginnuoc = 0;
                double dkbeginvo = 0;
                // tính đầu kỳ trên fbl5nnew

                var rsemp = from tblFBL5Nnew in dc.tblFBL5Nnews
                            where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date < fromdate // && tblFBL5Nnew.Posting_Date >= fromdate
                            group tblFBL5Nnew by tblFBL5Nnew.codeGroup into gr
                            select gr;

                foreach (var item in rsemp)
                {

                    dknuocps = (double)item.Sum(gr => gr.Invoice_Amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Payment_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Adjusted_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0));// (double)item.Sum(gr => gr.Fullgood_amount); // đầu kỳ
                    dkvocps = (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0)); // đầu kỳ

                }

                // cộng thêm số dư dầu nữa;
                var rsdk = from tblFBL5beginbalace in dc.tblFBL5beginbalaces
                           where tblFBL5beginbalace.codeGroup == tblCustomerv.Cusromergroup // && tblFBL5Nnew.Posting_Date <= todate // && tblFBL5Nnew.Posting_Date >= fromdate
                           group tblFBL5beginbalace by tblFBL5beginbalace.codeGroup into gr
                           select gr;

                foreach (var item in rsdk)
                {

                    dkbeginnuoc = (double)item.Sum(gr => gr.Fullgood_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Payment_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Adjusted_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0));// chính là amount on local
                    dkbeginvo = (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0)); // phát sinh trong kỳ

                }

                headerrpt.dknuoc = dknuocps + dkbeginnuoc; // full good amiunt
                headerrpt.dkvo = dkvocps + dkbeginvo; // depossit amount


                //double dknuocps = 0;
                //double dkvocps = 0;
                //double dkbeginnuoc = 0;
                //double dkbeginvo = 0;


                #endregion đầu kỳ
                //headerrpt.psnuoc
                //headerrpt.psvo
                #region phát sinh
                headerrpt.psnuoc = 0;
                headerrpt.psvo = 0;
                var rsps = from tblFBL5Nnew in dc.tblFBL5Nnews
                           where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date >= fromdate && tblFBL5Nnew.Posting_Date <= todate
                           group tblFBL5Nnew by tblFBL5Nnew.codeGroup into gr
                           select gr;

                foreach (var item in rsps)
                {

                    headerrpt.psnuoc = (double)item.Sum(gr => gr.Invoice_Amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Payment_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Adjusted_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0));// (double)item.Sum(gr => gr.Fullgood_amount); // đầu kỳ
                    headerrpt.psvo = (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0)); // phát sinh

                }

                #endregion phát sinh


                //headerrpt.cknuoc
                //headerrpt.ckvo

                #region cuối kỳ

                headerrpt.cknuoc = headerrpt.dknuoc + headerrpt.psnuoc;
                headerrpt.ckvo = headerrpt.dkvo + headerrpt.psvo;

                #endregion cuối kỳ





                if (headerrpt.custcodeGRoup != null)
                {
                    //stt = stt + 1;
                    //headerrpt.No = stt.ToString();

                    //     tbl_ArletterRpt

                    headerrpt.No = (from tbl_ArletterRpt in dc.tbl_ArletterRpts
                                    where tbl_ArletterRpt.custcodegRoup == headerrpt.custcodeGRoup
                                    select tbl_ArletterRpt.No).First();

                    tbl_ARdetalheaderRptlist.Add(headerrpt);

                    //  db.tbl_ARdetalheaderRpts.InsertOnSubmit(headerrpt);
                    //   db.SubmitChanges();

                }


            }
            db.tbl_ARdetalheaderRpts.InsertAllOnSubmit(tbl_ARdetalheaderRptlist);
            db.SubmitChanges();

            #endregion //tính bảng a      tbl_ARdetalheaderRpt headerrpt = new tbl_ARdetalheaderRpt();





            #region//tính bàng col vỏ detail  tbl_ColdetailRpt rptCol = new tbl_ColdetailRpt();


            var rscol2 = from tblCustomer in dc.tblCustomers
                         where tblCustomer.Reportsend == true
                         select tblCustomer;


            foreach (var tblCustomerv in rscol2)
            {



                #region // tính số đầu kỳ
                tbl_ColdetailRpt rptColdk = new tbl_ColdetailRpt();

                //   rptColdk.Account = tblCustomerv.Customer;
                rptColdk.codeGroup = tblCustomerv.Cusromergroup;
                rptColdk.SoDelivery = "x";

                rptColdk.dkBinhpmicc02 = 0;
                rptColdk.dkbinhpmix9l = 0;
                rptColdk.dkChaivo1lit = 0;
                rptColdk.dkChaivothuong = 0;
                rptColdk.dkjoy20 = 0;
                rptColdk.dkKetnhua1lit = 0;
                rptColdk.dkKetnhuathuong = 0;
                rptColdk.dkKetvolit = 0;
                rptColdk.dkKetvothuong = 0;
                rptColdk.dkpaletnhua = 0;
                rptColdk.dkpalletgo = 0;

                // đầu kỳ begine

                int dkBinhpmicc02bg = 0;// dkBinhpmicc02 + item3.Sum(gr => gr.Binhpmicc02);
                int dkbinhpmix9lbg = 0;// dkbinhpmix9l + item3.Sum(gr => gr.binhpmix9l);
                int dkChaivo1litbg = 0;// dkChaivo1lit + item3.Sum(gr => gr.Chaivo1lit);
                int dkChaivothuongbg = 0;// dkChaivothuong + item3.Sum(gr => gr.Chaivothuong);
                int dkjoy20bg = 0;// dkjoy20 + item3.Sum(gr => gr.joy20l);
                int dkKetnhua1litbg = 0;//  dkKetnhua1lit + item3.Sum(gr => gr.Ketnhua1lit);
                int dkKetnhuathuongbg = 0;// dkKetnhuathuong + item3.Sum(gr => gr.Ketnhuathuong);
                int dkKetvolitbg = 0;// dkKetvolit + item3.Sum(gr => gr.Ketvolit);
                int dkKetvothuongbg = 0;// dkKetvothuong + item3.Sum(gr => gr.Ketvothuong);
                int dkpaletnhuabg = 0;// dkpaletnhua + item3.Sum(gr => gr.paletnhua);
                int dkpalletgobg = 0;// dkpalletgo + item3.Sum(gr => gr.palletgo);




                var rsdk = from tblFBL5beginbalace in dc.tblFBL5beginbalaces
                           where tblFBL5beginbalace.codeGroup == tblCustomerv.Cusromergroup // && tblFBL5Nnew.Posting_Date <= todate // && tblFBL5Nnew.Posting_Date >= fromdate
                           group tblFBL5beginbalace by tblFBL5beginbalace.codeGroup into gr
                           select gr;

                foreach (var item3 in rsdk)
                {

                    //  headerrpt.dknuoc = headerrpt.dknuoc + item3.Sum(gr => gr.Fullgood_amount); // phát sinh trong kỳ
                    // headerrpt.dkvo = headerrpt.dknuoc + item3.Sum(gr => gr.Deposit_amount); // phát sinh trong kỳ

                    dkBinhpmicc02bg = (int)item3.Sum(gr => gr.Binhpmicc02);
                    dkbinhpmix9lbg = (int)item3.Sum(gr => gr.binhpmix9l);
                    dkChaivo1litbg = (int)item3.Sum(gr => gr.Chaivo1lit);
                    dkChaivothuongbg = (int)item3.Sum(gr => gr.Chaivothuong);
                    dkjoy20bg = (int)item3.Sum(gr => gr.joy20l);
                    dkKetnhua1litbg = (int)item3.Sum(gr => gr.Ketnhua1lit);
                    dkKetnhuathuongbg = (int)item3.Sum(gr => gr.Ketnhuathuong);
                    dkKetvolitbg = (int)item3.Sum(gr => gr.Ketvolit);
                    dkKetvothuongbg = (int)item3.Sum(gr => gr.Ketvothuong);
                    dkpaletnhuabg = (int)item3.Sum(gr => gr.paletnhua);
                    dkpalletgobg = (int)item3.Sum(gr => gr.palletgo);



                }


                int dkBinhpmicc02ps = 0;// dkBinhpmicc02 + item3.Sum(gr => gr.Binhpmicc02);
                int dkbinhpmix9lps = 0;// dkbinhpmix9l + item3.Sum(gr => gr.binhpmix9l);
                int dkChaivo1litps = 0;// dkChaivo1lit + item3.Sum(gr => gr.Chaivo1lit);
                int dkChaivothuongps = 0;// dkChaivothuong + item3.Sum(gr => gr.Chaivothuong);
                int dkjoy20ps = 0;// dkjoy20 + item3.Sum(gr => gr.joy20l);
                int dkKetnhua1litps = 0;//  dkKetnhua1lit + item3.Sum(gr => gr.Ketnhua1lit);
                int dkKetnhuathuongps = 0;// dkKetnhuathuong + item3.Sum(gr => gr.Ketnhuathuong);
                int dkKetvolitps = 0;// dkKetvolit + item3.Sum(gr => gr.Ketvolit);
                int dkKetvothuongps = 0;// dkKetvothuong + item3.Sum(gr => gr.Ketvothuong);
                int dkpaletnhuaps = 0;// dkpaletnhua + item3.Sum(gr => gr.paletnhua);
                int dkpalletgops = 0;// dkpalletgo + item3.Sum(gr => gr.palletgo);



                var rsdk2 = from tblFBL5Nnew in dc.tblFBL5Nnews
                            where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date < fromdate //= todate && tblFBL5Nnew.Posting_Date >= fromdate
                            group tblFBL5Nnew by tblFBL5Nnew.codeGroup into gr
                            select gr;

                foreach (var item2 in rsdk2)
                {

                    //    headerrpt.dknuoc = item.Sum(gr => gr.Fullgood_amount); // đầu kỳ
                    //    headerrpt.dkvo = item.Sum(gr => gr.Deposit_amount); // đầu kỳ


                    dkBinhpmicc02ps = (int)item2.Sum(gr => gr.Binhpmicc02); // đầu kỳ
                    dkbinhpmix9lps = (int)item2.Sum(gr => gr.binhpmix9l); // đầu kỳ
                    dkChaivo1litps = (int)item2.Sum(gr => gr.Chaivo1lit); // đầu kỳ
                    dkChaivothuongps = (int)item2.Sum(gr => gr.Chaivothuong); // đầu kỳ
                    dkjoy20ps = (int)item2.Sum(gr => gr.joy20l); // đầu kỳ
                    dkKetnhua1litps = (int)item2.Sum(gr => gr.Ketnhua1lit); // đầu kỳ
                    dkKetnhuathuongps = (int)item2.Sum(gr => gr.Ketnhuathuong); // đầu kỳ
                    dkKetvolitps = (int)item2.Sum(gr => gr.Ketvolit); // đầu kỳ
                    dkKetvothuongps = (int)item2.Sum(gr => gr.Ketvothuong); // đầu kỳ
                    dkpaletnhuaps = (int)item2.Sum(gr => gr.paletnhua); // đầu kỳ 
                    dkpalletgops = (int)item2.Sum(gr => gr.palletgo); // đầu kỳ 


                }

                rptColdk.dkBinhpmicc02 = dkBinhpmicc02bg + dkBinhpmicc02ps;
                rptColdk.dkbinhpmix9l = dkbinhpmix9lbg + dkbinhpmix9lps;
                rptColdk.dkChaivo1lit = dkChaivo1litbg + dkChaivo1litps;
                rptColdk.dkChaivothuong = dkChaivothuongbg + dkChaivothuongps;
                rptColdk.dkjoy20 = dkjoy20bg + dkjoy20ps;
                rptColdk.dkKetnhua1lit = dkKetnhua1litbg + dkKetnhua1litps;
                rptColdk.dkKetnhuathuong = dkKetnhuathuongbg + dkKetnhuathuongps;
                rptColdk.dkKetvolit = dkKetvolitbg + dkKetvolitps;
                rptColdk.dkKetvothuong = dkKetvothuongbg + dkKetvothuongps;
                rptColdk.dkpaletnhua = dkpaletnhuabg + dkpaletnhuaps;
                rptColdk.dkpalletgo = dkpalletgobg + dkpalletgops;





                if (rptColdk.codeGroup != 0)
                {
                    dc.tbl_ColdetailRpts.InsertOnSubmit(rptColdk);
                    dc.SubmitChanges();

                }





                #endregion // tính số đầu kỳ




                var rsemp = from tblFBL5Nnew in dc.tblFBL5Nnews
                            where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date <= todate && tblFBL5Nnew.Posting_Date >= fromdate
                             && tblFBL5Nnew.Document_Type == "RV"
                            select tblFBL5Nnew;

                //   MessageBox.Show(rsemp.Count().ToString());
                foreach (var item in rsemp)
                {
                    tbl_ColdetailRpt rptCol = new tbl_ColdetailRpt();
                    rptCol.codeGroup = tblCustomerv.Cusromergroup;
                    rptCol.Account = item.Account;
                    rptCol.SoDelivery = "";
                    rptCol.Binhpmicc02 = 0;
                    rptCol.binhpmix9l = 0;// item.binhpmix9l;

                    rptCol.Chaivo1lit = 0;// item.Chaivo1lit;
                    rptCol.Chaivothuong = 0;// item.Chaivothuong;
                    rptCol.joy20l = 0;// item.joy20l;
                    rptCol.Ketnhua1lit = 0;// item.Ketnhua1lit;
                    rptCol.Ketnhuathuong = 0;// item.Ketnhuathuong;
                    rptCol.Ketvolit = 0;// item.Ketvolit;
                    rptCol.Ketvothuong = 0;// item.Ketvothuong;
                    rptCol.paletnhua = 0;// item.paletnhua;
                    rptCol.palletgo = 0;// item.palletgo;


                    #region // tính số phát sinh
                    //   rptColdk.codeGroup = tblCustomerv.Cusromergroup;



                    rptCol.Postingdate = (DateTime)item.Posting_Date;
                    rptCol.SoDelivery = item.SoDelivery;


                    if (rptCol.SoDelivery == null || rptCol.SoDelivery == "")
                    {
                        rptCol.SoDelivery = item.Assignment;

                    }
                    rptCol.InvoiceNumber = item.Invoice;// + " " + item.Invoice_Number;
                    //if (rptCol.InvoiceNumber == null || rptCol.InvoiceNumber == "")
                    //{
                    //    rptCol.InvoiceNumber = item.Assignment;
                    //}




                    if (item.Binhpmicc02 != null)
                    {
                        rptCol.Binhpmicc02 = item.Binhpmicc02;
                    }

                    if (item.binhpmix9l != null)
                    {
                        rptCol.binhpmix9l = item.binhpmix9l;
                    }

                    if (item.Chaivo1lit != null)
                    {
                        rptCol.Chaivo1lit = item.Chaivo1lit;
                    }

                    if (item.Chaivothuong != null)
                    {
                        rptCol.Chaivothuong = item.Chaivothuong;
                    }

                    if (item.joy20l != null)
                    {
                        rptCol.joy20l = item.joy20l;
                    }

                    if (item.Ketnhua1lit != null)
                    {
                        rptCol.Ketnhua1lit = item.Ketnhua1lit;
                    }

                    if (item.Ketnhuathuong != null)
                    {
                        rptCol.Ketnhuathuong = item.Ketnhuathuong;
                    }

                    if (item.Ketvolit != null)
                    {
                        rptCol.Ketvolit = item.Ketvolit;
                    }

                    if (item.Ketvothuong != null)
                    {
                        rptCol.Ketvothuong = item.Ketvothuong;
                    }

                    if (item.paletnhua != null)
                    {
                        rptCol.paletnhua = item.paletnhua;
                    }

                    if (item.palletgo != null)
                    {
                        rptCol.palletgo = item.palletgo;
                    }






                    #endregion // tính số phát sinh


                    int kq = (int)rptCol.Binhpmicc02 + (int)rptCol.binhpmix9l + (int)rptCol.Chaivo1lit + (int)rptCol.Chaivothuong + (int)rptCol.joy20l + (int)rptCol.Ketnhua1lit + (int)rptCol.Ketnhuathuong + (int)rptCol.Ketvolit + (int)rptCol.Ketvothuong + (int)rptCol.paletnhua + (int)rptCol.palletgo;

                    if (rptCol.codeGroup != 0 && kq != 0)
                    {


                        //     tbl_ColdetailRptlist.Add(rptCol);

                        dc.tbl_ColdetailRpts.InsertOnSubmit(rptCol);
                        dc.SubmitChanges();

                    }
                }

            }

            //  dc.tbl_ColdetailRpts.InsertAllOnSubmit(tbl_ColdetailRptlist);
            //    dc.SubmitChanges();



            #endregion //tính bảng col vỏ



        }

        public void ARlettermakebyGroupcode2Onlycode(LinqtoSQLDataContext db, DateTime fromdate, DateTime todate, DateTime returndate, double onlycode)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;

            List<tbl_ColdetailRpt> tbl_ColdetailRptlist = new List<tbl_ColdetailRpt>();
            List<tbl_ArletterdetailRpt> tbl_ArletterdetailRptlist = new List<tbl_ArletterdetailRpt>();
            List<tbl_ARdetalheaderRpt> tbl_ARdetalheaderRptlist = new List<tbl_ARdetalheaderRpt>();

            List<tbl_ArletterRpt> tbl_ArletterRptlist = new List<tbl_ArletterRpt>();




            #region  updateCustgoupinListcustmakeRptVN ra TREN SQL dang viet 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateCustgoupinListcustmakeRptVNO_Onlycode", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                   cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;
                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor run: updateCustgoupinListcustmakeRptVN \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




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



            #region // xóa ar belance begine temp cu để chuẩn bị cái mới
            //  LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            try
            {
                dc.CommandTimeout = 0;
                dc.ExecuteCommand("DELETE FROM tblFBL5beginbalaceTemp");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRor run: tblFBL5beginbalaceTemp \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion



            #region // xóa data AR letter data reports cũ



            //var rs2 = from tbl_ArletterRpt in db.tbl_ArletterRpts
            //          select tbl_ArletterRpt;


            //db.tbl_ArletterRpts.DeleteAllOnSubmit(rs2);

            //db.SubmitChanges();
            #region // XÓA toàn bộ tbl_ArletterRpt
            dc.CommandTimeout = 0;
            try
            {
                dc.ExecuteCommand("DELETE FROM tbl_ArletterRpt");
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERRor run: tblFBL5beginbalaceTemp \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);

            dc.SubmitChanges();
            #endregion

            #endregion        //   xóa data AR letter


            #region // xóa ar header cdata reports cũ
            //var rs6 = from tbl_ARdetalheaderRpt in db.tbl_ARdetalheaderRpts
            //          select tbl_ARdetalheaderRpt;
            //db.tbl_ARdetalheaderRpts.DeleteAllOnSubmit(rs6);
            //db.SubmitChanges();


            #region // XÓA toàn bộ tbl_ARdetalheaderRpt
            try
            {
                dc.CommandTimeout = 0;
                dc.ExecuteCommand("DELETE FROM tbl_ARdetalheaderRpt");
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERRor delete: tbl_ARdetalheaderRpt \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion
            #endregion// xóa ddataa cũ sau do update data mới


            #region // xóa col cũ data reports cũ
            //var rs7 = from tbl_ColdetailRpt in db.tbl_ColdetailRpts
            //          select tbl_ColdetailRpt;
            //db.tbl_ColdetailRpts.DeleteAllOnSubmit(rs7);
            //db.SubmitChanges();


            #region // XÓA toàn bộ tbl_ColdetailRpt
            dc.CommandTimeout = 0;
            try
            {
                dc.ExecuteCommand("DELETE FROM tbl_ColdetailRpt");
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERRor delete: tbl_ColdetailRpt \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion




            #endregion// xóa ddataa cũ sau do update data mới


            #region // xóa ddataadetail datatbl_ArletterdetailRpt cũ
            //var rs3 = from tbl_ArletterdetailRpt in db.tbl_ArletterdetailRpts
            //          select tbl_ArletterdetailRpt;
            //db.tbl_ArletterdetailRpts.DeleteAllOnSubmit(rs3);
            //db.SubmitChanges();





            #region // XÓA toàn bộ tbl_ArletterdetailRpt ok
            dc.CommandTimeout = 0;
            try
            {
                dc.ExecuteCommand("DELETE FROM tbl_ArletterdetailRpt");
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERRor delete: tbl_ArletterdetailRpt \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion

            #endregion// xóa ddataa cũ sau do update data mới


            #region update updatebeginBalacegruop_Onlycode viet ok
            //   SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;

            //  string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updatebeginBalacegruop_Onlycode", conn2);
                cmd1.CommandTimeout = 0;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;


                dc.CommandTimeout = 0;

                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor make: updatebeginBalacegruop \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




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




            #region update update Fbl5nnew  customer group để lọc ra để lọc ra TREN SQL dang viet  ok
            //   SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;


            // Create the connection.
            using (SqlConnection connection = new SqlConnection(destConnString))
            {
                // Open the connection.
                connection.Open();

                // Create the command.
                using (SqlCommand command = new SqlCommand("updaFBL5nreportsBalacegroupVN_Onlycode", connection))
                {
                    // Set the command type.
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandTimeout = 0;
                    // Add the parameter.
                    SqlParameter parameter = command.Parameters.Add("@todate",
                        System.Data.SqlDbType.DateTime);
                    command.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

                    // Set the value.
                    parameter.Value = todate;

                    // Make the call.
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("ERRor make: updatebeginBalacegruop \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }





            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion


     

            #region update  update Freglasess  customer group để lọc ra trên sql ok
            //    SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;

            //   string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateFreglasessgroupVN_onlycode", conn2);
                cmd1.CommandTimeout = 0;
                cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;
                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor make: updateFreglasessgroupVN \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




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




            #region  // tính bàng tbl_ArletterRptra trên sql ok

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ArletterRptcaculationinserts_Onlycode", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                cmd1.Parameters.Add("@byregion", SqlDbType.Int).Value = 0;
                cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

                cmd1.CommandTimeout = 0;
                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor make: tbl_ArletterRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




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

            #endregion old


            #region  //  //tính bảng tbl_ArletterdetailRpt tren sql ok

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ArletterdetailRptcaculationinserts_onlycode", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

                cmd1.CommandTimeout = 0;

                try
                {
                    rdr1 = cmd1.ExecuteReader();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor make: tbl_ArletterdetailRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



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


            #region  //  tính bảng   tbl_ARdetalheaderRpt  tren sql ok

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ARdetalheaderRptcaculationinserts_onlycode", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                cmd1.Parameters.Add("@byregion", SqlDbType.Int).Value = 0;
                cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

                cmd1.CommandTimeout = 0;

                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor make: tbl_ARdetalheaderRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




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



            #region  //  tính bảng  tbl_Coldetail tren sql ok

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ColdetailRptcaculationinserts_onlycode", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

                cmd1.CommandTimeout = 0;
                try
                {
                    rdr1 = cmd1.ExecuteReader();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor make: tbl_ColdetailRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



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






            //throw new NotImplementedException();
        }

        public void ARlettermakebyGroupcodeRegion(LinqtoSQLDataContext db, DateTime fromdate, DateTime todate, DateTime returndate)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            List<tbl_ColdetailRpt> tbl_ColdetailRptlist = new List<tbl_ColdetailRpt>();
            List<tbl_ArletterdetailRpt> tbl_ArletterdetailRptlist = new List<tbl_ArletterdetailRpt>();
            List<tbl_ARdetalheaderRpt> tbl_ARdetalheaderRptlist = new List<tbl_ARdetalheaderRpt>();

            List<tbl_ArletterRpt> tbl_ArletterRptlist = new List<tbl_ArletterRpt>();




            #region  updateCustgoupinListcustmakeRptregion ra TREN SQL dang viet 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateCustgoupinListcustmakeRptRegion", conn2);
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



            #region // xóa ar belance begine temp cu để chuẩn bị cái mới
            //var betmp = from tblFBL5beginbalaceTemp in db.tblFBL5beginbalaceTemps
            //            select tblFBL5beginbalaceTemp;

            //if (betmp.Count() > 0)
            //{
            //    db.tblFBL5beginbalaceTemps.DeleteAllOnSubmit(betmp);
            //    db.SubmitChanges();
            //}

            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.ExecuteCommand("DELETE FROM tblFBL5beginbalaceTemp");
            dc.CommandTimeout = 0;
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion


            #endregion


            #region // xóa data AR letter data reports cũ



            //var rs2 = from tbl_ArletterRpt in db.tbl_ArletterRpts
            //          select tbl_ArletterRpt;


            //db.tbl_ArletterRpts.DeleteAllOnSubmit(rs2);

            //db.SubmitChanges();




            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.ExecuteCommand("DELETE FROM tbl_ArletterRpt");
            dc.CommandTimeout = 0;
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion

            #endregion        //   xóa data AR letter


            #region // xóa ar header cdata reports cũ
            //var rs6 = from tbl_ARdetalheaderRpt in db.tbl_ARdetalheaderRpts
            //          select tbl_ARdetalheaderRpt;
            //db.tbl_ARdetalheaderRpts.DeleteAllOnSubmit(rs6);
            //db.SubmitChanges();





            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.ExecuteCommand("DELETE FROM tbl_ARdetalheaderRpt");
            dc.CommandTimeout = 0;
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion


            #endregion// xóa ddataa cũ sau do update data mới


            #region // xóa col cũ data reports cũ
            //var rs7 = from tbl_ColdetailRpt in db.tbl_ColdetailRpts
            //          select tbl_ColdetailRpt;
            //db.tbl_ColdetailRpts.DeleteAllOnSubmit(rs7);
            //db.SubmitChanges();




            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.ExecuteCommand("DELETE FROM tbl_ColdetailRpt");
            dc.CommandTimeout = 0;
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion
            #endregion// xóa ddataa cũ sau do update data mới


            #region // xóa ddataadetail data reports cũ
            //var rs3 = from tbl_ArletterdetailRpt in db.tbl_ArletterdetailRpts
            //          select tbl_ArletterdetailRpt;
            //db.tbl_ArletterdetailRpts.DeleteAllOnSubmit(rs3);
            //db.SubmitChanges();


            #region // XÓA toàn bộ tblFBL5Nnewthisperiod
            dc.ExecuteCommand("DELETE FROM tbl_ArletterdetailRpt");
            dc.CommandTimeout = 0;
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();
            #endregion
            #endregion// xóa ddataa cũ sau do update data mới





            #region update beginbalece  customer group region để lọc ra TREN SQL dang viet 
            //   SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;

            //  string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updatebeginBalacegruopRegion", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRor run: updatebeginBalacegruopRegion \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   // throw;
                }
          



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





            #region update update Fbl5nnew  customer group để lọc ra để lọc ra TREN SQL dang viet 
            //   SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;


            // Create the connection.
            using (SqlConnection connection = new SqlConnection(destConnString))
            {
                // Open the connection.
                connection.Open();

                // Create the command.
                using (SqlCommand command = new SqlCommand("updaFBL5nreportsBalacegroupRegion", connection))
                {
                    // Set the command type.
                    command.CommandTimeout = 0;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add the parameter.
                    SqlParameter parameter = command.Parameters.Add("@todate",
                        System.Data.SqlDbType.DateTime);

                    // Set the value.
                    parameter.Value = todate;

                    // Make the call.
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("ERRor run: updaFBL5nreportsBalacegroupRegion \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }





            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion




            #region update  update Freglasess  customer group để lọc ra trên sql
            //    SqlConnection conn2 = null;
            //   SqlDataReader rdr1 = null;

            //   string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateFreglasessgroupREgion", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor run: updateFreglasessgroupREgion \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
          
                
           


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


            #region  // tính bàng tbl_ArletterRptra trên sql

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ArletterRptcaculationinserts", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                cmd1.Parameters.Add("@byregion", SqlDbType.Int).Value = 1;
                cmd1.CommandTimeout = 0;
                try
                {

                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor run: tbl_ArletterRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



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

            #endregion old


            #region  //  //tính bảng tbl_ArletterdetailRpt tren sql

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ArletterdetailRptcaculationinserts", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                //  cmd1.CommandTimeout = 0;
                try
                {
                    rdr1 = cmd1.ExecuteReader();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor run: tbl_ArletterdetailRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             


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


            #region  //  tính bảng   tbl_ARdetalheaderRpt  tren sql

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ARdetalheaderRptcaculationinserts", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                cmd1.Parameters.Add("@byregion", SqlDbType.Int).Value = 1;
                cmd1.CommandTimeout = 0;

                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor run: tbl_ARdetalheaderRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
          



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



            #region  //  tính bảng  tbl_Coldetail tren sql

            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("tbl_ColdetailRptcaculationinserts", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@returndate", SqlDbType.Date).Value = returndate;
                cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                 cmd1.CommandTimeout = 0;

                try
                {
                    rdr1 = cmd1.ExecuteReader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERRor run: tbl_ColdetailRptcaculationinserts \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             



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

        internal void inputthisisperiodtoFBL5nnewTEMP()
        {
            //   Thread.Sleep(5000);
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            #region update to fbl5n new
            // kiểm tra nếu doc tblFBL5Nnewthisperiod đã có trong tblFBL5Nnew thì thoát luôn





            #region copy kiểu sql vao sql


            var rsfbl5n = from tblFBL5Nnewthisperiod in dc.tblFBL5Nnewthisperiods
                          select tblFBL5Nnewthisperiod;

            #region // neeys lớn hơn o có da ta thì updae
            if (rsfbl5n.Count() > 0)
            {


                #region insert thismonth to fbl5new

                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;
                string destConnString = Utils.getConnectionstr();

                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("copyfromThismonthtoFbl5newtEMP", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandTimeout = 0;
                    //   cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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
                //   MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #endregion UPDATE FBL5N




            }

            #endregion






            #endregion





            #endregion update to fbl5n 





        }


        // ARlettermakebyGroupcodeRegion

        public IQueryable letterdetaildataset2(LinqtoSQLDataContext db)
        {

            #region lấy dữ liệu ra để cho vào báo cáo 


            var rs = from tbl_ARdetalheaderRpt in db.tbl_ARdetalheaderRpts
                     where tbl_ARdetalheaderRpt.prt == true
                     orderby tbl_ARdetalheaderRpt.custcodeGRoup
                     select tbl_ARdetalheaderRpt;

            return rs;
            #endregion lấy dữ liệu ra
        }

        public IQueryable letterdetaildataset1(LinqtoSQLDataContext db)
        {



            #region lấy dữ liệu ra để cho vào báo cáo 


            var rs = from tbl_Arletterdetail in db.tbl_ArletterdetailRpts
                     where tbl_Arletterdetail.prt == true
                     orderby tbl_Arletterdetail.customergroup
                     select tbl_Arletterdetail;

            return rs;
            #endregion lấy dữ liệu ra

            //  throw new NotImplementedException();
        }

        public IQueryable ARletterdataset2(LinqtoSQLDataContext db)
        {

            string usrname = Utils.getusername();
            //    var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_Temp in db.tbl_Temps
                     where tbl_Temp.username == usrname
                     //  where tbl_ArletterRpt.prt == true
                     select new
                     {
                         addressofbarnch = tbl_Temp.addressofbarnch,

                         contactperson = tbl_Temp.contactperson,
                         nameofbarnch = tbl_Temp.nameofbarnch,
                         phonecontact = tbl_Temp.phonecontact,


                         possition = tbl_Temp.possition,
                         signoffby = tbl_Temp.signoffby,
                         siteid = tbl_Temp.siteid,
                         imagesign = tbl_Temp.imagesign,


                     };




            return rs;




            //  throw new NotImplementedException();
        }

        public IQueryable nkaARletterdataset2(LinqtoSQLDataContext db)
        {

            string usrname = Utils.getusername();
            //    var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_Temp in db.tbl_Temps
                     where tbl_Temp.username == usrname
                     //  where tbl_ArletterRpt.prt == true
                     select new
                     {
                         addressofbarnch = tbl_Temp.addressofbarnch,

                         contactperson = tbl_Temp.contactperson,
                         nameofbarnch = tbl_Temp.nameofbarnch,
                         phonecontact = tbl_Temp.phonecontact,


                         possition = tbl_Temp.possition,
                         signoffby = tbl_Temp.signoffby,
                         siteid = tbl_Temp.siteid,
                         imagesign = tbl_Temp.imagesign,


                     };




            return rs;




            //  throw new NotImplementedException();
        }

        public IQueryable nkaARletterdataset1(LinqtoSQLDataContext db)
        {



            #region lấy dữ liệu bảng ar letter reports ra


            var rs = from P in db.tblNKAArletterRpts
                  //       where P.prt == true
                     orderby P.stt
                     select P;

            return rs;

            #endregion lấy dữ liệu bảng ar letter reports ra


        }

        public IQueryable ARletterdataset1(LinqtoSQLDataContext db)
        {



            #region lấy dữ liệu bảng ar letter reports ra


            var rs = from tbl_ArletterRpt in db.tbl_ArletterRpts
                     where tbl_ArletterRpt.prt == true
                     orderby tbl_ArletterRpt.custcodegRoup
                     select tbl_ArletterRpt;

            return rs;

            #endregion lấy dữ liệu bảng ar letter reports ra


        }

        public IQueryable ARcoldataset2(LinqtoSQLDataContext db)
        {

            #region lấy dữ liệu ra để cho vào báo cáo 


            var rs = from tbl_ARdetalheaderRpt in db.tbl_ARdetalheaderRpts
                     where tbl_ARdetalheaderRpt.prt == true
                     orderby tbl_ARdetalheaderRpt.custcodeGRoup
                     select tbl_ARdetalheaderRpt;

            return rs;
            #endregion lấy dữ liệu ra
            // Viewtable viewtbl = new Viewtable(rs, db, "List of datadeital header !");
        }

        public IQueryable ARcoldataset1(LinqtoSQLDataContext db)
        {

            #region lấy dữ liệu ra để cho vào báo cáo 


            var rs = from tbl_ColdetailRpt in db.tbl_ColdetailRpts
                     where tbl_ColdetailRpt.prt == true
                     orderby tbl_ColdetailRpt.codeGroup
                     select tbl_ColdetailRpt;

            return rs;
            #endregion lấy dữ liệu ra


        }


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