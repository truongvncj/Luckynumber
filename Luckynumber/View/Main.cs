﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using arconfirmationletter.Model;
using arconfirmationletter.Control;
//using arconfirmationletter.Entity;

using System.Threading;
using System.Data.SqlClient;
using arconfirmationletter.View;
//using System.Collections.Generic;
//using System.Linq;

namespace arconfirmationletter.View
{
    public partial class Main : Form
    {


        //   private string rptname;
        private IQueryable rs1;
        private IQueryable rs2;
        //
        public Main()
        {
            InitializeComponent();

            #region right setup




            this.lbusername.Text = Utils.getusername();
            this.lblocate.Text = Utils.getDatalocate();


            Username user = new Username();
            Boolean right = user.right;


            //int rightnumber = Utils.getrightnumber();

            //      MessageBox.Show(rightnumber.ToString());

            if (right == false) // không ró quyền/ đóng luôn
            {
                MessageBox.Show("No Authorise !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;


            }
            if (user.deleteAlldate)
            {
                this.dELETEALLDATABASEEDITToolStripMenuItem.Visible = true;
            }
            else
            {
                this.dELETEALLDATABASEEDITToolStripMenuItem.Visible = false;
            }

            if (user.nationKA)
            {



                this.inputDataToolStripMenuItem.Enabled = false;
                this.masterDataToolStripMenuItem.Enabled = false;
                this.reportsToolStripMenuItem.Enabled = false;
                this.nKAToolStripMenuItem.Visible = true;
            }
            else
            {

                this.inputDataToolStripMenuItem.Enabled = true;
                this.masterDataToolStripMenuItem.Enabled = true;
                this.reportsToolStripMenuItem.Enabled = true;
                this.nKAToolStripMenuItem.Visible = false;
            }

            // editOlddatabase
            if (user.editOlddatabase)
            {
                this.eDITALLDATABASEToolStripMenuItem.Visible = true;
            }
            else
            {
                this.eDITALLDATABASEToolStripMenuItem.Visible = false;
            }

            //   Depositintput
            if (user.Depositintput)
            {
                this.dataCheckToolStripMenuItem.Visible = true;
                this.iNPUTPERIODDEPOSITAMOUNTToolStripMenuItem.Visible = true;
                this.cLOSETHISPRERIODToolStripMenuItem.Visible = true;
                this.toolStripSeparator6.Visible = true;
            }
            else
            {
                this.dataCheckToolStripMenuItem.Visible = false;
                this.iNPUTPERIODDEPOSITAMOUNTToolStripMenuItem.Visible = false;
                this.cLOSETHISPRERIODToolStripMenuItem.Visible = false;
                this.toolStripSeparator6.Visible = false;
            }
            //  Systemconfig

            if (user.Systemconfig)
            {
                this.systemConfigToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.systemConfigToolStripMenuItem.Enabled = false;
            }

            // uploadBeginbalance

            if (user.uploadBeginbalance)
            {
                this.beginingBalanceToolStripMenuItem1.Visible = true;
            }
            else
            {
                this.beginingBalanceToolStripMenuItem1.Visible = false;
            }

            // endyearPackdata

            if (user.endyearPackdata)
            {
                this.yEARENDPACKDATAToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.yEARENDPACKDATAToolStripMenuItem.Enabled = false;
            }
            // InputDepositInpass
            if (user.InputDepositInpass)
            {
                this.rEEDITDEPOSITVERIFYToolStripMenuItem.Visible = true;
            }
            else
            {
                this.rEEDITDEPOSITVERIFYToolStripMenuItem.Visible = false;
            }


            if (user.redoInputviry)
            {
                this.uNBLOCKDEPOSITVERIFYToolStripMenuItem.Visible = true;
            }
            else
            {
                this.uNBLOCKDEPOSITVERIFYToolStripMenuItem.Visible = false;
            }




            #endregion

        }


        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {







        }

        private void bt_caculating_Click(object sender, EventArgs e)
        {
            //var db = new LinqtoSQLDataContext(connection_string);
            //var cltour = from p in db.tours
            //             where p.TourID != 0
            //             select p;

            //dataGridView1.DataSource = cltour;

        }

        private void button1_Click(object sender, EventArgs e)
        {


            //var db = new LinqtoSQLDataContext(connection_string);


            //tour tour = db.tours.Single(p => p.TourID == 20);
            ////  Tourid.TourID =  Convert.ToInt32(cb_id.Text);
            //tour.TourName = cb_name.Text;
            ////   db.
            //db.SubmitChanges();

            //string[] days = { "Sunday", "Monday", "TuesDay", "Wednesday", "Thursday", "Friday", "Saturday" };
            //foreach (string day in days)
            //{
            //    MessageBox.Show("The day is : " + day, "The day ");


            //           }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void bt_insert_Click(object sender, EventArgs e)
        {

            //var db = new LinqtoSQLDataContext(connection_string);

            //tour tb = new tour();

            //tb.TourID = int.Parse(cb_id.Text);
            //tb.TourName = cb_name.Text;
            //tb.Image = cb_image.Text;
            //tb.Nights = byte.Parse(cb_night.Text);
            //tb.Price = int.Parse(cb_price.Text);


            //db.tours.InsertOnSubmit(tb);

            //db.SubmitChanges();


            //  dataGridView1.Refresh();

        }

        private void dataGridView1_DataMemberChanged(object sender, EventArgs e)
        {



        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var db = new LinqtoSQLDataContext(connection_string);
            //var rs = from Tour in db.tours
            //         select Tour;


            //db.tours.DeleteAllOnSubmit(rs);
            //db.SubmitChanges();

        }

        private void button3_Click(object sender, EventArgs e)
        {


            //Form.ActiveForm(MasterdataInput);


        }

        private void bt_inputcsv_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {







        }

        private void fBL5nInputToolStripMenuItem_Click(object sender, EventArgs e)
        {





        }

        private void masterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void upLoadProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void updateNewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fbl5n_ctrl md = new fbl5n_ctrl();
            //   customerinput_ctrl md = new customerinput_ctrl();
            DialogResult kq1 = MessageBox.Show("Xóa tblFBL5n thay thế bằng bảng mới ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // bool kq;
            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:


                    //   this.updateNewAllToolStripMenuItem.Enabled = false;
                    //   this.reportsToolStripMenuItem.Enabled = false;


                    md.Fbl5n_input2();


                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }





        }

        private void addCustormerToolStripMenuItem_Click(object sender, EventArgs e)
        {




        }

        private void changeProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {




        }

        private void addUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  fbl5n_ctrl md = new fbl5n_ctrl();
            //   md.Fbl5n_input();





        }

        private void uploadAndChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void viewFBL5NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            fbl5n_ctrl md = new fbl5n_ctrl();
            var rs = md.fbl5nsetlect_all(db);

            Viewtable viewtbl = new Viewtable(rs, db, "FBL5n data", 100, DateTime.Today, DateTime.Today);
            //     viewtbl.Visible = false;
            //       viewtbl.Show();
        }

        private void viewCustomerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void viewCustomerDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            customerinput_ctrl md = new customerinput_ctrl();
            var rs = md.customersetlect_all(db);

            //  MessageBox.Show("Data add/ change Customer done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Viewtable viewtbl = new Viewtable(rs, db, "CUSTOMER DATA", 100, DateTime.Today, DateTime.Today);
            //     viewtbl.Show();

        }


        private void updateNewAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //     bool kq;
            vat_ctrl md = new vat_ctrl();

            DialogResult kq1 = MessageBox.Show("Xóa VAT out thay thế bằng bảng mới ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:


                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:


                    md.vat_input();


                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }



        }

        private void viewVATDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            vat_ctrl md = new vat_ctrl();
            var rs = md.vatsetlect_all(db);
            Viewtable viewtbl = new Viewtable(rs, db, "VAT ZFI data uploaded ", 100, DateTime.Today, DateTime.Today);
            //    viewtbl.Show();

        }

        private void addUpdateAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vat_ctrl md = new vat_ctrl();
            md.vat_input();



        }

        private void setCustomerRecieveReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        private void dataCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            //        LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            dc.CommandTimeout = 0;
            dc.ExecuteCommand("DELETE FROM tbl_ProductlistTMP");

            dc.SubmitChanges();


            dc.ExecuteCommand("DELETE FROM tblEDLP WHERE  tblEDLP.[Sold-to] IN (SELECT  tbl_unuserCustomer.Customer FROM tbl_unuserCustomer )");
            dc.SubmitChanges();


            dc.ExecuteCommand("DELETE FROM tblVat  WHERE  tblVat.[Customer Number] IN (SELECT  tbl_unuserCustomer.Customer FROM tbl_unuserCustomer )");
            dc.SubmitChanges();


            dc.ExecuteCommand("DELETE FROM tblFBL5N  WHERE  tblFBL5N.[Account] IN (SELECT  tbl_unuserCustomer.Customer FROM tbl_unuserCustomer )");
            dc.SubmitChanges();

            //dc.ExecuteCommand("DELETE FROM tblFBL5Nnew  WHERE  tblFBL5Nnew.[Tempmark] = 1");  // xóa các tem
            //dc.SubmitChanges();




            #region  DeleteTempFBL5nnew DeleteTempFBL5nnew
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("DeleteTempFBL5nnew", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;

                ////     cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                ///     cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                //  System.Data.SqlDbType.DateTime
                try
                {
                    rdr1 = cmd1.ExecuteReader();
                    //  MessageBox.Show("OK, please go to Input verify to reinput !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error  Delete TempFBL5n new \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            #endregion

            //SqlConnection conn2 = null;
            //SqlDataReader rdr1 = null;
            //string destConnString = Utils.getConnectionstr();



            var rs = (from tblEDLP in dc.tblEDLPs
                      select tblEDLP).Take(5);
            if (rs.Count() <= 0)
            {
                MessageBox.Show("Ban chưa up load bản data EDLP , please check again !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }



            var rs2 = (from tblVat in dc.tblVats
                       select tblVat).Take(5);
            if (rs2.Count() <= 0)
            {
                MessageBox.Show("Ban chưa up load bảng data VAT , please check again !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            var rs3 = (from tblFBL5N in dc.tblFBL5Ns
                       select tblFBL5N).Take(5);
            if (rs3.Count() <= 0)
            {
                MessageBox.Show("Bạn đã up load data tblFBL5N chưa , please check again !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            Control_ac ct = new Control_ac();
            DialogResult Kq = MessageBox.Show("Bạn xóa workingdata bởi bản mới hay chỉ add thêm ?" + "\n" + "                 Xóa->Yes/ Add thêm->No !", "Thông báo !", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);


            switch (Kq)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    //  this.Close();
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    {

                        DialogResult Kq2 = MessageBox.Show("Bạn có chắc xóa ?", "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        switch (Kq2)
                        {

                            case DialogResult.Yes:
                                {

                                    #region yes xóa tblFBL5Nnewthisperiod

                                    dc.CommandTimeout = 0;
                                    dc.ExecuteCommand("DELETE FROM tblFBL5Nnewthisperiod");

                                    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
                                    dc.SubmitChanges();

                                    #region    ClearABbelanceZezoinFbl5n

                                    ////      SqlConnection conn2 = null;
                                    //       SqlDataReader rdr1 = null;
                                    //       string destConnString = Utils.getConnectionstr();
                                    try
                                    {

                                        conn2 = new SqlConnection(destConnString);
                                        conn2.Open();
                                        SqlCommand cmd1 = new SqlCommand("ClearABbelanceZezo", conn2);
                                        cmd1.CommandTimeout = 0;
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



                                    bool kq1 = ct.checkVATandFBL5n();


                                    if (kq1)
                                    {

                                        ct.UpdateVATregionFromFBL5Nregion();

                                        bool kq2 = ct.checkVATnameanddtodata();
                                        // nếu không ok data khong có data trong  fbl5new

                                        if (kq1 && kq2)// new data ok thi updload data
                                        {

                                            Thread t1 = new Thread(new ThreadStart(ct.inputVATandFBL5toFBL5newthisperiod));

                                            t1.Start();


                                            Thread t2 = new Thread(showwait);
                                            t2.Start();

                                            t1.Join();
                                            if (t1.ThreadState != ThreadState.Running)
                                            {
                                                Thread.Sleep(3999);
                                                try
                                                {
                                                    t2.Abort();
                                                }
                                                catch (Exception)
                                                {

                                                    //throw;
                                                }


                                            }


                                        }

                                        //---kiểm tra data nếu khác thì showmessage/ deleted toadn bộ các dòng đó trên thispreriod
                                        dc.CommandTimeout = 0;

                                        var eror = from tblFBL5Nnewthisperiod in dc.tblFBL5Nnewthisperiods
                                                   where tblFBL5Nnewthisperiod.COL_value != tblFBL5Nnewthisperiod.Empty_Amount
                                                   select new
                                                   {
                                                       Account_Group = tblFBL5Nnewthisperiod.codeGroup,
                                                       Account = tblFBL5Nnewthisperiod.Account,
                                                       Doc_Number = tblFBL5Nnewthisperiod.Document_Number,
                                                       Customer_Name = tblFBL5Nnewthisperiod.name,
                                                       coL_EDLP_Value = tblFBL5Nnewthisperiod.COL_value,
                                                       Empty_AmountinVAT = tblFBL5Nnewthisperiod.Empty_Amount,


                                                   };
                                        if (eror.Count() > 0)
                                        {
                                            Viewtable viewtbl = new Viewtable(eror, dc, "List các doc chưa update được do có lệch giữ data FBL5n Và VAT/Edlp về phần vỏ , please check !", 1, DateTime.Today, DateTime.Today);
                                            viewtbl.Visible = false;
                                            viewtbl.ShowDialog();

                                        }




                                    }
                                    break;
                                    #endregion


                                }


                        }





                        break;

                    }
                case DialogResult.No:

                    {


                        #region    ClearABbelanceZezoinFbl5n

                        //       SqlConnection conn2 = null;
                        //     SqlDataReader rdr1 = null;
                        //    string destConnString = Utils.getConnectionstr();
                        try
                        {

                            conn2 = new SqlConnection(destConnString);
                            conn2.Open();
                            SqlCommand cmd1 = new SqlCommand("ClearABbelanceZezo", conn2);
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


                        //      bool kqo = true;

                        //    if (kqo)
                        //    {


                        #region udapte vào this priod


                        bool kq1 = ct.checkVATandFBL5n();


                        if (kq1)
                        {

                            ct.UpdateVATregionFromFBL5Nregion();

                            bool kq2 = ct.checkVATnameanddtodata();




                            if (kq1 && kq2)// new data ok thi updload data
                            {

                                Thread t1 = new Thread(new ThreadStart(ct.inputVATandFBL5toFBL5newthisperiodAgain));

                                t1.Start();


                                Thread t2 = new Thread(showwait);
                                t2.Start();

                                t1.Join();
                                if (t1.ThreadState != ThreadState.Running)
                                {
                                    Thread.Sleep(1999);
                                    t2.Abort();

                                }


                            }



                        }

                        #endregion update

                        ///  }


                        break;
                    }
                default:
                    break;
            }







        }

        private void uploadCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerinput_ctrl md = new customerinput_ctrl();
            DialogResult kq1 = MessageBox.Show("Xóa toàn bộ dataCustomer ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //      bool kq;
            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.Yes:

                    // this.uploadCustomerToolStripMenuItem.Enabled = false;

                    // this.reportsToolStripMenuItem.Enabled = false;


                    md.customerinput();





                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }



        }

        private void addChangeCustomerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerinput_ctrl md = new customerinput_ctrl();





        }

        private void productCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {




            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tbl_Productlist);

            VInputchange inputcdata = new VInputchange("", "LIST PRODUCT AND EMPTY GROUP", dc, "tbl_Productlist", "tbl_Productlist", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();
            //View.Inputchange kq = new View.Inputchange
        }

        private void viewProductsListToolStripMenuItem_Click(object sender, EventArgs e)
        {



            string connection_string = Utils.getConnectionstr();

            var db = new LinqtoSQLDataContext(connection_string);
            var rs = (from tbl_Productlist in db.tbl_Productlists
                      join tbl_EmptyGroup in db.tbl_EmptyGroups on tbl_Productlist.Empty_Group equals tbl_EmptyGroup.id into tblnew
                      from cat in tblnew
                      select new
                      {

                          tbl_Productlist.Mat_Number,
                          tbl_Productlist.Mat_Text,
                          tbl_Productlist.Empty_Group,
                          tbl_Productlist.Mat_Group,
                          tbl_Productlist.Mat_Group_Text,
                          cat.Name_Group_Emptty



                          //tbl_Productlist.Empty_Group


                      }
                      );



            Viewtable viewtbl = new Viewtable(rs, db, "List of product", 100, DateTime.Today, DateTime.Today);
            //      viewtbl.Show();







        }



        private void byMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //var db = new LinqtoSQLDataContext(connection_string);
            //      fRM_AROPTION fromoptiong = new fRM_AROPTION("ARletter.rdlc");
            //     fromoptiong.Show();

            //
            string connection_string = Utils.getConnectionstr();

            var db = new LinqtoSQLDataContext(connection_string);

            Control_ac ctrac = new Control_ac();

            rs1 = ctrac.ARletterdataset1(db);
            rs2 = ctrac.ARletterdataset2(db);





            if (rs1 != null && rs2 != null)
            {

                //    Utils ut = new Utils();
                var dataset1 = Utils.ToDataTable(db, rs1);
                var dataset2 = Utils.ToDataTable(db, rs2);
                Reportsview rpt = new Reportsview(dataset1, dataset2, "ARletter.rdlc");
                rpt.Show();

            }




        }

        private void byDateFromToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // fRM_AROPTION fromoptiong = new fRM_AROPTION("ARletterdetail.rdlc");
            //fRM_AROPTION fromoptiong = new fRM_AROPTION("SubARletterdetail.rdlc");

            string connection_string = Utils.getConnectionstr();

            //    var db = new LinqtoSQLDataContext(connection_string);
            var db = new LinqtoSQLDataContext(connection_string);


            string rptname = "ARletterdetail.rdlc";
            //      string rptname = "SubARletterdetail.rdlc";
            Control_ac ctrac = new Control_ac();

            var rs1 = ctrac.letterdetaildataset1(db);
            var rs2 = ctrac.letterdetaildataset2(db);


            if (rs1 != null && rs2 != null)
            {
                //      var db = new LinqtoSQLDataContext(connection_string);
                //  Utils ut = new Utils();
                var dataset1 = Utils.ToDataTable(db, rs1);
                var dataset2 = Utils.ToDataTable(db, rs2);
                Reportsview rpt = new Reportsview(dataset1, dataset2, rptname);
                rpt.Show();

            }
        }

        private void cOLReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void viewDataLetterReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_ArletterRpt in db.tbl_ArletterRpts
                     select tbl_ArletterRpt;


            Viewtable viewtbl = new Viewtable(rs, db, "Letter data reports", 100, DateTime.Today, DateTime.Today);
            //   viewtbl.Show();



        }

        private void groupCustomerSentARLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tbl_CustomerGroupTemp);
            //  var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_CustomerGroupTemp in db.tbl_CustomerGroupTemps
                     select tbl_CustomerGroupTemp;



            VInputchange inputcdata = new VInputchange("LIST MASTER DATA CUSTOMER GROUP", "LIST CODE TO CREAT GROUP  ", db, "tbl_CustomerGroup", "tbl_CustomerGroupTemp", typeff, "id", "id");
            //    inputcdata.Visible = false;
            inputcdata.Show();


        }

        private void viewEdlpDataToolStripMenuItem_Click(object sender, EventArgs e)
        {


            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            edlpinput_ctrl md = new edlpinput_ctrl();
            var rs = md.Edlpsetlect_all(db);
            Viewtable viewtbl = new Viewtable(rs, db, "EDLP data uploaded ", 100, DateTime.Today, DateTime.Today);
            //   viewtbl.Show();

        }

        private void addUpdateAndReplaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //    bool kq;
            edlpinput_ctrl md = new edlpinput_ctrl();

            DialogResult kq1 = MessageBox.Show("Xóa Edlpinput thay thế bằng bảng mới ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:


                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:


                    //     this.addUpdateAndReplaceToolStripMenuItem1.Enabled = false;
                    //    this.reportsToolStripMenuItem.Enabled = false;

                    md.edlpinput();



                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }






        }

        private void vATInputToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eDLPInputToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewDataCOLReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);





            var dc = new LinqtoSQLDataContext(connection_string);



            IQueryable q3 = from Productlist in dc.tbl_ColdetailRpts
                            select Productlist;




            Viewtable viewtbl = new Viewtable(q3, dc, "Col Reports detail data", 1, DateTime.Today, DateTime.Today);
            //    viewtbl.Show();











        }

        private void viewChangeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tbl_Remark);

            VInputchange inputcdata = new VInputchange("", "LIST REMARK TO UPDATE ", dc, "tbl_Remark", "tbl_Remark", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();



        }

        private void viewChangeDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tbl_FreGlass);

            VInputchange inputcdata = new VInputchange("", "LIST FREE GLASS PROGRAM ", dc, "tbl_FreGlass", "tbl_FreGlass", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();
        }

        private void lETTERCOLREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);



            var db = new LinqtoSQLDataContext(connection_string);


            string rptname = "ARCOLrpt.rdlc";
            //      string rptname = "SubARletterdetail.rdlc";
            Control_ac ctrac = new Control_ac();

            var rs1 = ctrac.ARcoldataset1(db);
            var rs2 = ctrac.ARcoldataset2(db);


            if (rs1 != null && rs2 != null)
            {
                //      var db = new LinqtoSQLDataContext(connection_string);
                //     Utils ut = new Utils();
                var dataset1 = Utils.ToDataTable(db, rs1);
                var dataset2 = Utils.ToDataTable(db, rs2);
                Reportsview rpt = new Reportsview(dataset1, dataset2, rptname);
                rpt.Show();



            }

        }

        private void eDITCUSTOMERDATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tblCustomer);

            VInputchange inputcdata = new VInputchange("", "LIST MASTER DATA CUSTOMER ", dc, "tblCustomer", "tblCustomer", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();
        }

        private void eDITLETTERDATAREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tbl_ArletterRpt);

            VInputchange inputcdata = new VInputchange("", "DATA ARLETTER REPORTS- CAREFULLY BEFORE CHANGE IT ! ", dc, "tbl_ArletterRpt", "tbl_ArletterRpt", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();

        }

        private void editFBL5NDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tblFBL5N);

            VInputchange inputcdata = new VInputchange("", "FBL5N PREPRAIRE TO UP TO DATA  ", dc, "tblFBL5N", "tblFBL5N", typeff, "Fbl5nID", "Fbl5nID");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();



        }

        private void eDITVATDATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   Control_ac ct = new Control_ac();
            // ct.UpdateVATregionFromFBL5Nregion();

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tblVat);

            VInputchange inputcdata = new VInputchange("", "VAT PREPRAIRE TO UP TO DATA  ", dc, "tblVat", "tblVat", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();

        }

        private void eDITEDLPDATAToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tblEDLP);

            VInputchange inputcdata = new VInputchange("", "EDLP PREPRAIRE TO UP TO DATA  ", dc, "tblEDLP", "tblEDLP", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();
        }

        private void vIEWPRODUCTGROUPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eDITPRODUCTSGROUPToolStripMenuItem_Click(object sender, EventArgs e)
        {






        }

        private void beginingBalanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tblFBL5beginbalace);

            VInputchange inputcdata = new VInputchange("", "BEGINNING BALANCE ARCONFIRMATION LETTER", dc, "tblFBL5beginbalace", "tblFBL5beginbalace", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();

        }

        private void eDITPRODUCTSGROUPToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tbl_CustomerGroup);

            VInputchange inputcdata = new VInputchange("", "LIST CUSTOMER GROUP  ", dc, "tbl_CustomerGroup", "tbl_CustomerGroup", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();




        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  bool kq;
            Remarks md = new Remarks();

            DialogResult kq1 = MessageBox.Show("Xóa Remark thay thế bằng bảng mới ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:


                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:



                    //this.updateNewAllToolStripMenuItem1.Enabled = false;

                    //this.reportsToolStripMenuItem.Enabled = false;
                    md.Remark_input();


                    //      var rs = md.vatsetlect_all();
                    //        Viewtable viewtbl = new Viewtable(rs, "VAT ZFI data uploaded ");













                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }


        }

        private void vIEWREMARKLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            Remarks md = new Remarks();
            var rs = md.Remarksetlect_all(db);
            Viewtable viewtbl = new Viewtable(rs, db, "LIST OF UPDAD REMARKS  ", 100, DateTime.Today, DateTime.Today);
            //    viewtbl.Show();

        }

        private void vIEWREMARKSLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            fREEGALSSES_CTRL md = new fREEGALSSES_CTRL();
            var rs = md.Fregalssessetlect_all(db);
            Viewtable viewtbl = new Viewtable(rs, db, "LIST OF REEGALSSES TABLE ", 100, DateTime.Today, DateTime.Today);
            //   viewtbl.Show();





        }

        private void uploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            //  bool kq;
            fREEGALSSES_CTRL md = new fREEGALSSES_CTRL();

            DialogResult kq1 = MessageBox.Show("Xóa FREEGALSSES  thay thế bằng bảng mới ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:


                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:



                    //this.updateNewAllToolStripMenuItem1.Enabled = false;

                    //this.reportsToolStripMenuItem.Enabled = false;
                    md.Freglasses_input();


                    //      var rs = md.vatsetlect_all();
                    //        Viewtable viewtbl = new Viewtable(rs, "VAT ZFI data uploaded ");













                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }




        }

        private void rEPORTSMAKEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////var db = new LinqtoSQLDataContext(connection_string);
            //fRM_AROPTION fromoptiong = new fRM_AROPTION();//("ARletter.rdlc");
            //fromoptiong.Show();

        }

        private void sETLISTCUSTOMERMAKEREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            customerinput_ctrl md = new customerinput_ctrl();
            var rs = md.customersetlect_all(db);
            Viewtable viewtbl = new Viewtable(rs, db, "Update Customer make reports !", 1, DateTime.Today, DateTime.Today);
            //    viewtbl.Show();




        }

        private void vIEWLISTCUSTMAKEREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Control_ac ct = new Control_ac();
            //    ct.updateCustgoupinListcustmakeRpt();

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rsCust2 = from tblCustomer in dc.tblCustomers
                          where tblCustomer.Reportsend == true
                          orderby tblCustomer.Customer
                          select tblCustomer;

            //  MessageBox.Show("Data add/ change Customer done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Viewtable viewtbl = new Viewtable(rsCust2, dc, "LIST CUSTOMER MAKE REPORTS", 1, DateTime.Today, DateTime.Today);
            //    viewtbl.Show();


        }

        private void rEPORTSMAKEToolStripMenuItem_Click_1(object sender, EventArgs e)
        {





        }

        private void eDITLISTCUSTMAKEREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void vIEWALLDATABASEONSERVERToolStripMenuItem_Click(object sender, EventArgs e)
        {



            fromdateandcode fromtochoice = new View.fromdateandcode();
            Control_ac ctrac = new Control_ac();

            fromtochoice.ShowDialog();


            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //      LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);




            DateTime fromdate = fromtochoice.tungay;
            DateTime todate = fromtochoice.denngay;
            double custcode = fromtochoice.custcode;

            bool choice = fromtochoice.chon;




            if (choice == true)
            {
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                dc.CommandTimeout = 0;

                if (custcode != 0)
                {
                    #region  chọn 1 coed



                    var rs2 = from tblFBL5Nnew in dc.tblFBL5Nnews
                              where tblFBL5Nnew.Posting_Date >= fromdate && tblFBL5Nnew.Posting_Date <= todate
                              && tblFBL5Nnew.Account == custcode
                              // select tblFBL5Nnew;

                              select new


                              {
                                  tblFBL5Nnew.codeGroup,

                                  //         check = tblFBL5Nnewthisperiod.Account.ToString(),
                                  Sorg = tblFBL5Nnew.Business_Area,
                                  tblFBL5Nnew.Account,
                                  Customer_Name = tblFBL5Nnew.name,

                                  //     tblFBL5Nnewthisperiod.COL_value,

                                  tblFBL5Nnew.Posting_Date,
                                  tblFBL5Nnew.Assignment,
                                  tblFBL5Nnew.Document_Number,

                                  FBL5N_amount = tblFBL5Nnew.Amount_in_local_currency,


                                  tblFBL5Nnew.Payment_amount,
                                  Adj_amount = tblFBL5Nnew.Adjusted_amount,

                                  //    tblFBL5Nnewthisperiod.Invoice_Amount,
                                  tblFBL5Nnew.Fullgood_amount,
                                  tblFBL5Nnew.Empty_Amount,
                                  tblFBL5Nnew.Deposit_amount,


                                  Invoice_date = tblFBL5Nnew.Formula_invoice_date,
                                  //       Invoice =   tblFBL5Nnewthisperiod.Invoice_Registration + " " + tblFBL5Nnewthisperiod.Invoice_Number,

                                  tblFBL5Nnew.Invoice,
                                  //    tblFBL5Nnewthisperiod.Vat_amount,
                                  Type = tblFBL5Nnew.Document_Type,
                                  tblFBL5Nnew.Binhpmicc02,
                                  tblFBL5Nnew.binhpmix9l,
                                  tblFBL5Nnew.Chaivothuong,
                                  tblFBL5Nnew.Chaivo1lit,
                                  tblFBL5Nnew.joy20l,
                                  tblFBL5Nnew.Ketnhua1lit,
                                  tblFBL5Nnew.Ketnhuathuong,
                                  tblFBL5Nnew.Ketvolit,
                                  tblFBL5Nnew.Ketvothuong,
                                  tblFBL5Nnew.paletnhua,
                                  tblFBL5Nnew.palletgo,
                                  tblFBL5Nnew.userupdate,
                                  tblFBL5Nnew.id,
                                  //   tblFBL5Nnewthisperiod.Empty_Amount_Notmach,


                              };


                    #endregion chon 1 code
                    Viewtable viewtbl = new Viewtable(rs2, dc, "VIEWLIST DATABASE UPLOADED ON SYSYEM FROM-" + fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year, 100, fromdate, todate); //view loại 5 là có fromdatetodate

                    //   viewtbl.Show();


                }

                if (custcode == 0) // chon nhieu code
                {
                    #region  chọn 1 coed



                    var rs2 = from tblFBL5Nnew in dc.tblFBL5Nnews
                              where tblFBL5Nnew.Posting_Date >= fromdate && tblFBL5Nnew.Posting_Date <= todate
                              //   && tblFBL5Nnew.Account == custcode
                              // select tblFBL5Nnew;

                              select new


                              {
                                  tblFBL5Nnew.codeGroup,

                                  //         check = tblFBL5Nnewthisperiod.Account.ToString(),
                                  Sorg = tblFBL5Nnew.Business_Area,
                                  tblFBL5Nnew.Account,
                                  Customer_Name = tblFBL5Nnew.name,

                                  //     tblFBL5Nnewthisperiod.COL_value,

                                  tblFBL5Nnew.Posting_Date,
                                  tblFBL5Nnew.Assignment,
                                  tblFBL5Nnew.Document_Number,

                                  FBL5N_amount = tblFBL5Nnew.Amount_in_local_currency,


                                  tblFBL5Nnew.Payment_amount,
                                  Adj_amount = tblFBL5Nnew.Adjusted_amount,

                                  //    tblFBL5Nnewthisperiod.Invoice_Amount,
                                  tblFBL5Nnew.Fullgood_amount,
                                  tblFBL5Nnew.Empty_Amount,
                                  tblFBL5Nnew.Deposit_amount,


                                  Invoice_date = tblFBL5Nnew.Formula_invoice_date,
                                  //       Invoice =   tblFBL5Nnewthisperiod.Invoice_Registration + " " + tblFBL5Nnewthisperiod.Invoice_Number,

                                  tblFBL5Nnew.Invoice,
                                  //    tblFBL5Nnewthisperiod.Vat_amount,
                                  Type = tblFBL5Nnew.Document_Type,
                                  tblFBL5Nnew.Binhpmicc02,
                                  tblFBL5Nnew.binhpmix9l,
                                  tblFBL5Nnew.Chaivothuong,
                                  tblFBL5Nnew.Chaivo1lit,
                                  tblFBL5Nnew.joy20l,
                                  tblFBL5Nnew.Ketnhua1lit,
                                  tblFBL5Nnew.Ketnhuathuong,
                                  tblFBL5Nnew.Ketvolit,
                                  tblFBL5Nnew.Ketvothuong,
                                  tblFBL5Nnew.paletnhua,
                                  tblFBL5Nnew.palletgo,
                                  tblFBL5Nnew.userupdate,
                                  tblFBL5Nnew.id,
                                  //   tblFBL5Nnewthisperiod.Empty_Amount_Notmach,


                              };


                    #endregion chon 1 code
                    Viewtable viewtbl = new Viewtable(rs2, dc, "VIEWLIST DATABASE UPLOADED ON SYSYEM FROM-" + fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year, 100, fromdate, todate); //view loại 5 là có fromdatetodate

                    //    viewtbl.Show();

                }




            }
        }

        private void vIEWLETTERDETAILREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_ArletterdetailRpt in db.tbl_ArletterdetailRpts
                     select tbl_ArletterdetailRpt;


            Viewtable viewtbl = new Viewtable(rs, db, "Letter data detail reporst", 100, DateTime.Today, DateTime.Today);
            viewtbl.Show();

        }

        private void vIEWLETTERCOLREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_ColdetailRpt in db.tbl_ColdetailRpts
                     select tbl_ColdetailRpt;


            Viewtable viewtbl = new Viewtable(rs, db, "Letter COL detail reporst", 100, DateTime.Today, DateTime.Today);
            //    viewtbl.Show();

        }

        private void eDITLETTERDETAILREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tbl_ArletterdetailRpt);

            VInputchange inputcdata = new VInputchange("", "DATA Arletter DetailRpt REPORTS- CAREFULLY BEFORE CHANGE IT ! ", dc, "tbl_ArletterdetailRpt", "tbl_ArletterdetailRpt", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();

        }

        private void vIEWLETTERCOLREPORTSToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tbl_ColdetailRpt);

            VInputchange inputcdata = new VInputchange("", "DATA Arletter Col Detail Reports- CAREFULLY BEFORE CHANGE IT ! ", dc, "tbl_ColdetailRpt", "tbl_ColdetailRpt", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();
        }

        private void eDITALLDATABASEToolStripMenuItem_Click(object sender, EventArgs e)
        {


            fromdateandcode fromtochoice = new View.fromdateandcode();
            Control_ac ctrac = new Control_ac();

            fromtochoice.ShowDialog();


            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //      LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            db.CommandTimeout = 0;




            DateTime fromdate = fromtochoice.tungay;
            DateTime todate = fromtochoice.denngay;
            double custcode = fromtochoice.custcode;

            bool choice = fromtochoice.chon;




            if (choice == true && custcode != 0)
            {



                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                var rs2 = from tblFBL5Nnew in dc.tblFBL5Nnews
                          where tblFBL5Nnew.Posting_Date >= fromdate && tblFBL5Nnew.Posting_Date <= todate
                           && tblFBL5Nnew.Account == custcode
                          select tblFBL5Nnew;


                Viewtable viewtbl = new Viewtable(rs2, dc, "EDIT DATABASE UPLOADED ON SYSYEM FROM-" + fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year, 7, fromdate, todate); //view loại 7 là có LÀ CHO EDIT TOÀN BỘ THEO TỪNG DÒNG, CÓ HỖ TRỢ F3 CODE

                viewtbl.Show();



            }
        }

        private void uploadFreeGlassToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iNPUTPERIODDEPOSITAMOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);




            dc.CommandTimeout = 0;




            #region update codegroup from code group
            //updateCustgoupThistable
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;
            try
            {

                conn2 = new SqlConnection(connection_string);
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



            IQueryable rsthisperiod = null;
            Viewtable viewtbl = new Viewtable(rsthisperiod, dc, "iNPUT DEPOSIT AMOUNTT !", 1, DateTime.Today, DateTime.Today); // màn hình inpot data có mas2
            viewtbl.Visible = false;
            viewtbl.ShowDialog();
            //    viewtbl.Activate();
            //  }



        }
        public void showwait()
        {
            View.Caculating wat = new View.Caculating();

            wat.ShowDialog();


        }




        private void cLOSETHISPRERIODToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult kq1 = MessageBox.Show("ENDMONTH DATA CLOSE ? ", "CONFIRN CLOSE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:


                    #region  DeleteTempFBL5nnew DeleteTempFBL5nnew
                    SqlConnection conn2 = null;
                    SqlDataReader rdr1 = null;

                    string destConnString = Utils.getConnectionstr();
                    try
                    {

                        conn2 = new SqlConnection(destConnString);
                        conn2.Open();
                        SqlCommand cmd1 = new SqlCommand("DeleteTempFBL5nnew", conn2);
                        cmd1.CommandType = CommandType.StoredProcedure;

                        ////     cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                        ///     cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                        //  System.Data.SqlDbType.DateTime
                        try
                        {
                            rdr1 = cmd1.ExecuteReader();
                            //  MessageBox.Show("OK, please go to Input verify to reinput !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Error  Delete TempFBL5n new \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    #endregion




                    #region q List các document có trong bảng  FBL5Nnew rồi !
                    //---

                    string connection_string = Utils.getConnectionstr();

                    //  var db = new LinqtoSQLDataContext(connection_string);
                    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                    db.CommandTimeout = 0;

                    var q = from tblFBL5Nnewthisperiod in db.tblFBL5Nnewthisperiods
                            where (from tblFBL5Nnew in db.tblFBL5Nnews
                                   where tblFBL5Nnew.Tempmark == false  // false  == 0; true == 1

                                   select tblFBL5Nnew.Document_Number).Contains(tblFBL5Nnewthisperiod.Document_Number)
                            //Tương đương từ khóa NOT IN trong SQL
                            select tblFBL5Nnewthisperiod;



                    if (q.Count() != 0)
                    {



                        Viewtable viewtbl = new Viewtable(q, db, "Data không close được do có List các document sau đã update lên rồi !", 1, DateTime.Today, DateTime.Today);
                        viewtbl.Visible = false;
                        viewtbl.ShowDialog();
                    }
                    if (q.Count() == 0)
                    {

                        Control_ac ct = new Control_ac();

                        Thread t1 = new Thread(ct.inputthisisperiodtoFBL5nnew);
                        //   t1.IsBackground = true;
                        t1.Start();


                        Thread t2 = new Thread(showwait);
                        t2.Start();

                        t1.Join();


                        if (t1.ThreadState != ThreadState.Running)
                        {

                            Thread.Sleep(1299);

                            t2.Abort();

                        }





                    }
                    #endregion q "List các document có trong bảng VAT không có trong bảng FBL5N !





                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }




        }

        private void bYTIMEPICKERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bYPRERIODToolStripMenuItem_Click(object sender, EventArgs e)
        {





        }

        class RunreportsOnlyCode
        {
            public LinqtoSQLDataContext dc { get; set; }
            public DateTime fromdate { get; set; }
            public DateTime todate { get; set; }
            public DateTime returndate { get; set; }
            public double onlyCode { get; set; }


        }

        class Runreports
        {
            public LinqtoSQLDataContext dc { get; set; }
            public DateTime fromdate { get; set; }
            public DateTime todate { get; set; }
            public DateTime returndate { get; set; }


        }



        static void ReportVNRunOnecode(object objextRPt)
        {

            RunreportsOnlyCode dat = (RunreportsOnlyCode)objextRPt;
            LinqtoSQLDataContext db = dat.dc;
            DateTime fromdate = dat.fromdate;
            DateTime todate = dat.todate;
            DateTime returndate = dat.returndate;
            double onlycode = dat.onlyCode;

            Control_ac ctrac = new Control_ac();
            try
            {
                ctrac.ARlettermakebyGroupcode2Onlycode(db, fromdate, todate, returndate, onlycode);
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERRor run: make ARlettermakebyGroupcode2 \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }

        static void ReportVNRun(object objextRPt)
        {

            Runreports dat = (Runreports)objextRPt;
            LinqtoSQLDataContext db = dat.dc;
            DateTime fromdate = dat.fromdate;
            DateTime todate = dat.todate;
            DateTime returndate = dat.returndate;
            Control_ac ctrac = new Control_ac();
            try
            {
                ctrac.ARlettermakebyGroupcode2(db, fromdate, todate, returndate);
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERRor run: make ARlettermakebyGroupcode2 \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }


        static void ReportVNRegiom(object objextRPt)
        {

            Runreports dat = (Runreports)objextRPt;
            LinqtoSQLDataContext db = dat.dc;
            DateTime fromdate = dat.fromdate;
            DateTime todate = dat.todate;
            DateTime returndate = dat.returndate;
            Control_ac ctrac = new Control_ac();
            ctrac.ARlettermakebyGroupcodeRegion(db, fromdate, todate, returndate);





        }


        private void rEPORTSMAKEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            db.CommandTimeout = 0;
            try
            {
                db.ExecuteCommand("DELETE FROM tblFBL5beginbalaceTemp");
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERRor delete: tblFBL5beginbalaceTemp \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.SubmitChanges();


            //var db = new LinqtoSQLDataContext(connection_string);
            fRM_AROPTION fromoptiong = new fRM_AROPTION();
            Control_ac ctrac = new Control_ac();

            fromoptiong.ShowDialog();



            DateTime fromdate = fromoptiong.fromdate;
            DateTime todate = fromoptiong.todate;
            DateTime returndate = fromoptiong.returndate;
            bool regionby = fromoptiong.byregion;
            bool choice = fromoptiong.choice;
            double onlycode = fromoptiong.custcode;


            //     bool onlycodechoi = fromoptiong.onlycheckbook;
            if (choice == true && onlycode != 0)  // chi tạo báo cáo 1 code
            {
                #region    // kiểm tra xem có số dư đầu kỳ không nếu không có bật ra bản thêm vào và kết thúc

                //    db.SubmitChanges();

                //    db.CommandTimeout = 10000;
                var q13 = from tblCustomer in db.tblCustomers
                          where tblCustomer.Customer == onlycode && !(from tblFBL5beginbalace in db.tblFBL5beginbalaces
                                                                      select tblFBL5beginbalace.Account.ToString() + tblFBL5beginbalace.Business_Area).Contains(tblCustomer.Customer.ToString() + tblCustomer.SOrg)
                          //  orderby tblCustomer.Customer
                          group tblCustomer by new
                          {
                              tblCustomer.Customer,
                              tblCustomer.SOrg,
                          }
                         into g
                          select g;



                if (q13.Count() > 0)

                {


                    #region mở update số dư dầu kỳ khi codegroupkhoong co trong so du dau ky nếu không có bắn ra bàng không có



                    foreach (var item in q13)
                    {


                        var slqtext = @"insert into  tblFBL5beginbalaceTemp ( Account, [Business Area],[Amount in local currency],
 Binhpmicc02,binhpmix9l,Chaivo1lit,Chaivothuong,[Deposit amount],[Adjusted amount],[Empty Amount],[Empty Amount Notmach],
[Fullgood amount],joy20l,Ketnhua1lit,Ketnhuathuong,paletnhua,palletgo,[Payment amount] ) 

values (" + (double)item.Key.Customer + ",'" + item.Key.SOrg + @"',0,
 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";


                        db.CommandTimeout = 0;

                        try
                        {
                            db.ExecuteCommand(slqtext);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("ERRor insert : tblFBL5beginbalaceTemp \n" + slqtext + "\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        db.SubmitChanges();



                    }



                    var typeff = typeof(tblFBL5beginbalaceTemp);

                    //     LinqtoSQLDataContext dbx = new LinqtoSQLDataContext(connection_string);


                    View.VInputchange inputcdata = new View.VInputchange("MASTER BEGIN BALACE ", "LIST CUST NOT HAVE BEGIN BALACE, PLEASE CHECK ! ", db, "tblFBL5beginbalace", "tblFBL5beginbalaceTemp", typeff, "id", "id");
                    inputcdata.Show();// = false;
                    inputcdata.Focus();
                    return;

                    #endregion mở update số dư dầu kỳ khi codegroupkhoong co trong so du dau ky



                }

                //  MessageBox.Show("ok");

                #endregion  // kiểm tra xem có so du dau ky không

                if (q13.Count() == 0)
                {
                    #region nếu không có số dư đủ thì thực hiện

                    if (regionby == false && choice == true)
                    {
                        LinqtoSQLDataContext dbx = new LinqtoSQLDataContext(connection_string);
                        Thread t1 = new Thread(ReportVNRunOnecode);
                        t1.IsBackground = true;
                        t1.Start(new RunreportsOnlyCode() { dc = dbx, fromdate = fromdate, todate = todate, returndate = returndate, onlyCode = onlycode });

                        Thread t2 = new Thread(showwait);
                        t2.Start();

                        t1.Join();
                        if (t1.ThreadState != ThreadState.Running)

                        {



                            Thread.Sleep(2999);

                            t2.Abort();






                        }

                        // ctrac.ARlettermakebyGroupcode2(db, fromdate, todate);

                    }


                    #endregion nếu không có số dư đủ thì thực hiện
                }


                //   make reports luon   eDITLISTCUSTMAKEREPORTSToolStripMenuItem_Click

                #region  updatepriterinvoice grouppriter
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("updategroupprintletterOnlycodeChoice", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

                    try
                    {
                        rdr1 = cmd1.ExecuteReader();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("error  updategroupprintletterChoice \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
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


                #region print invoce


                //      string connection_string = Utils.getConnectionstr();

                //   var db = new LinqtoSQLDataContext(connection_string);

                //   Control_ac ctrac = new Control_ac();

                rs1 = ctrac.ARletterdataset1(db);
                rs2 = ctrac.ARletterdataset2(db);





                if (rs1 != null && rs2 != null)
                {

                    //  Utils ut = new Utils();
                    var dataset1 = Utils.ToDataTable(db, rs1);
                    var dataset2 = Utils.ToDataTable(db, rs2);
                    Reportsview rpt = new Reportsview(dataset1, dataset2, "ARletter.rdlc");
                    rpt.Show();

                }


                #endregion

                #region print detail

                //   string connection_string = Utils.getConnectionstr();

                //    var db = new LinqtoSQLDataContext(connection_string);
                //     var db = new LinqtoSQLDataContext(connection_string);


                //   string rptname = "ARletterdetail.rdlc";
                //      string rptname = "SubARletterdetail.rdlc";
                //    Control_ac ctrac = new Control_ac();

                var rs3 = ctrac.letterdetaildataset1(db);
                var rs4 = ctrac.letterdetaildataset2(db);


                if (rs1 != null && rs2 != null)
                {
                    //      var db = new LinqtoSQLDataContext(connection_string);
                    //   Utils ut = new Utils();
                    var dataset1 = Utils.ToDataTable(db, rs3);
                    var dataset2 = Utils.ToDataTable(db, rs4);
                    Reportsview rpt = new Reportsview(dataset1, dataset2, "ARletterdetail.rdlc");
                    rpt.Show();

                }

                #endregion

                #region print col
                //     string connection_string = Utils.getConnectionstr();

                //  var db = new LinqtoSQLDataContext(connection_string);
                //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);



                //  var db = new LinqtoSQLDataContext(connection_string);


                //   string rptname3 = "ARCOLrpt.rdlc";
                //      string rptname = "SubARletterdetail.rdlc";
                //      Control_ac ctrac = new Control_ac();

                var rs5 = ctrac.ARcoldataset1(db);
                var rs6 = ctrac.ARcoldataset2(db);


                if (rs1 != null && rs2 != null)
                {
                    //      var db = new LinqtoSQLDataContext(connection_string);
                    //   Utils ut = new Utils();
                    var dataset1 = Utils.ToDataTable(db, rs5);
                    var dataset2 = Utils.ToDataTable(db, rs6);
                    Reportsview rpt = new Reportsview(dataset1, dataset2, "ARCOLrpt.rdlc");
                    rpt.Show();



                }



                #endregion

            }





            if (choice == true && onlycode == 0)  /// với nhiều coed
            {



                #region    // kiểm tra xem có số dư đầu kỳ không nếu không có bật ra bản thêm vào và kết thúc

                //    db.SubmitChanges();

                //    db.CommandTimeout = 10000;
                var q9 = from tblCustomer in db.tblCustomers
                         where (tblCustomer.Reportsend == true) && !(from tblFBL5beginbalace in db.tblFBL5beginbalaces
                                                                     select tblFBL5beginbalace.Account.ToString() + tblFBL5beginbalace.Business_Area).Contains(tblCustomer.Customer.ToString() + tblCustomer.SOrg)
                         //  orderby tblCustomer.Customer
                         group tblCustomer by new
                         {
                             tblCustomer.Customer,
                             tblCustomer.SOrg,
                         }
                         into g
                         select g;



                if (q9.Count() > 0)

                {


                    #region mở update số dư dầu kỳ khi codegroupkhoong co trong so du dau ky nếu không có bắn ra bàng không có



                    foreach (var item in q9)
                    {


                        var slqtext = @"insert into  tblFBL5beginbalaceTemp ( Account, [Business Area],[Amount in local currency],
 Binhpmicc02,binhpmix9l,Chaivo1lit,Chaivothuong,[Deposit amount],[Adjusted amount],[Empty Amount],[Empty Amount Notmach],
[Fullgood amount],joy20l,Ketnhua1lit,Ketnhuathuong,paletnhua,palletgo,[Payment amount] ) 

values (" + (double)item.Key.Customer + ",'" + item.Key.SOrg + @"',0,
 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";


                        db.CommandTimeout = 0;

                        try
                        {
                            db.ExecuteCommand(slqtext);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("ERRor insert : tblFBL5beginbalaceTemp \n" + slqtext + "\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        db.SubmitChanges();



                    }



                    var typeff = typeof(tblFBL5beginbalaceTemp);

                    //     LinqtoSQLDataContext dbx = new LinqtoSQLDataContext(connection_string);


                    View.VInputchange inputcdata = new View.VInputchange("MASTER BEGIN BALACE ", "LIST CUST NOT HAVE BEGIN BALACE, PLEASE CHECK ! ", db, "tblFBL5beginbalace", "tblFBL5beginbalaceTemp", typeff, "id", "id");
                    inputcdata.Show();// = false;
                    inputcdata.Focus();


                    #endregion mở update số dư dầu kỳ khi codegroupkhoong co trong so du dau ky



                }

                //  MessageBox.Show("ok");

                #endregion  // kiểm tra xem có so du dau ky không



                if (q9.Count() == 0)
                {
                    #region nếu không có số dư đủ thì thực hiện

                    if (regionby == false && choice == true)
                    {
                        LinqtoSQLDataContext dbx = new LinqtoSQLDataContext(connection_string);
                        Thread t1 = new Thread(ReportVNRun);
                        t1.IsBackground = true;
                        t1.Start(new Runreports() { dc = dbx, fromdate = fromdate, todate = todate, returndate = returndate });

                        Thread t2 = new Thread(showwait);
                        t2.Start();

                        t1.Join();
                        if (t1.ThreadState != ThreadState.Running)

                        {



                            Thread.Sleep(2999);

                            t2.Abort();






                        }

                        // ctrac.ARlettermakebyGroupcode2(db, fromdate, todate);

                    }

                    if (regionby == true && choice == true)
                    {

                        LinqtoSQLDataContext dbx = new LinqtoSQLDataContext(connection_string);
                        Thread t1 = new Thread(ReportVNRegiom);
                        t1.IsBackground = true;
                        t1.Start(new Runreports() { dc = dbx, fromdate = fromdate, todate = todate, returndate = returndate });

                        Thread t2 = new Thread(showwait);
                        t2.Start();

                        t1.Join();
                        if (t1.ThreadState != ThreadState.Running)
                        {
                            Thread.Sleep(2299);

                            t2.Abort();




                        }



                        //  ctrac.ARlettermakebyGroupcodeRegion(db, fromdate, todate);
                    }
                    #endregion nếu không có số dư đủ thì thực hiện
                }

                #region update cho view heet baso caso

                //     updategroupprintletterChoiceALL

                #region  updatepriterinvoice updategroupprintletterChoiceALL
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("updategroupprintletterChoiceALL", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandTimeout = 0;
                    //    cmd1.Parameters.Add("@groupsending", SqlDbType.VarChar).Value = groupsending;
                    try
                    {
                        rdr1 = cmd1.ExecuteReader();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("updategroupprintletterChoiceALL \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                #endregion


            }






        }

        private void userAndRightToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tbl_Temp);

            VInputchange inputcdata = new VInputchange("", "USERNAME AND PASSWORD CONFIG ! ", dc, "tbl_Temp", "tbl_Temp", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();
        }

        private void serverNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.Serversetup stup = new Serversetup();
            stup.Show();
        }



        private void bEGINBALANCEVIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rsthisperiod = from tblFBL5beginbalace in dc.tblFBL5beginbalaces
                               orderby tblFBL5beginbalace.Account
                               select tblFBL5beginbalace;

            if (rsthisperiod.Count() != 0)
            {
                // fbl5n_ctrl md = new fbl5n_ctrl();
                //var rs = md.fbl5nsetlect_all();

                Viewtable viewtbl = new Viewtable(rsthisperiod, dc, "LIST BEGIN BALANCE !", 100, DateTime.Today, DateTime.Today);
                //   viewtbl.Visible = false;
                // viewtbl.Show();

            }


        }

        private void dELETEALLDATABASEEDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult kq1 = MessageBox.Show(" BẠN MUỐN XÓA DỮ LIỆU TRÊN SERVER ! ", "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            // bool kq;
            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:


                    fromdate fromtochoice = new View.fromdate();
                    Control_ac ctrac = new Control_ac();

                    fromtochoice.ShowDialog();


                    string connection_string = Utils.getConnectionstr();

                    //  var db = new LinqtoSQLDataContext(connection_string);
                    //      LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);




                    DateTime fromdate = fromtochoice.tungay;
                    DateTime todate = fromtochoice.denngay;
                    bool choice = fromtochoice.chon;




                    if (choice == true)
                    {

                        string query = @"DELETE FROM tblFBL5Nnew where " +
                                        "tblFBL5Nnew.[Posting Date] >= '" + fromdate.Year + "-" + fromdate.Month + "-" + fromdate.Day + "' and " +
                                        "tblFBL5Nnew.[Posting Date] <= '" + todate.Year + "-" + todate.Month + "-" + todate.Day + "'";
                        //  MessageBox.Show(query);
                        try
                        {
                            db.ExecuteCommand(query);
                        }
                        catch (Exception)
                        {

                            MessageBox.Show(" Error uteCommand(query \n" + query, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
                        db.SubmitChanges();
                        //   dc.tblFBL5Nnews.DeleteAllOnSubmit(rs2);
                        //   dc.SubmitChanges();
                        MessageBox.Show("Deleted !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //   string connection_string = Utils.getConnectionstr();

                    //  var db = new LinqtoSQLDataContext(connection_string);
                    //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


                    //   LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    //    var rs2 = from tblFBL5Nnew in dc.tblFBL5Nnews
                    //             select tblFBL5Nnew;




                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }

        }

        private void pRINTREPORTSBYOPTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLetterOption PrintOption = new PrintLetterOption();
            // Control_ac ctrac = new Control_ac();

            PrintOption.ShowDialog();


            int choice = PrintOption.choice;

            double onlycode = PrintOption.onlycode;
            double fromcode = PrintOption.fromcode;
            double tocode = PrintOption.tocode;

            string groupsending = PrintOption.groupsending;


            if (choice == 1)//grooup print
            {
                // string groupsending = PrintOption.groupsending;
                //    MessageBox.Show(groupsending + "-groupprint--" );

                string connection_string = Utils.getConnectionstr();


                //     MessageBox.Show(groupsending + "-groupprint--");


                #region  updatepriterinvoice grouppriter
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("updategroupprintletterChoice", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@groupsending", SqlDbType.VarChar).Value = groupsending;
                    try
                    {
                        rdr1 = cmd1.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error  updategroupprintletterChoice \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (choice == 2)//fromcode to code print
            {

                //double fromcode = PrintOption.fromcode;
                //double tocode = PrintOption.tocode;
                //         MessageBox.Show(fromcode.ToString() + "-fromto--" + tocode.ToString());


                #region  updatepriterinvoice grouppriter
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("updategroupprintletterfromcodetocodeChoice", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@fromcode", SqlDbType.Float).Value = fromcode;
                    cmd1.Parameters.Add("@tocode", SqlDbType.Float).Value = tocode;
                    try
                    {
                        rdr1 = cmd1.ExecuteReader();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("error  updategroupprintletterChoice \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (choice == 3)   //only code
            {
                //   MessageBox.Show(onlycode.ToString() + "-onlycepde--");

                #region  updatepriterinvoice grouppriter
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("updategroupprintletterOnlycodeChoice", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

                    try
                    {
                        rdr1 = cmd1.ExecuteReader();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("error  updategroupprintletterChoice \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (choice == 4)   //all code
            {



                #region update cho view heet baso caso

                //     updategroupprintletterChoiceALL

                #region  updatepriterinvoice updategroupprintletterChoiceALL
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("updategroupprintletterChoiceALL", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    //    cmd1.Parameters.Add("@groupsending", SqlDbType.VarChar).Value = groupsending;
                    try
                    {
                        rdr1 = cmd1.ExecuteReader();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("error  updategroupprintletterChoiceALL \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                #endregion


            }



            if (choice == 1 || choice == 2 || choice == 3 || choice == 4)
            {
                #region print invoce


                string connection_string = Utils.getConnectionstr();

                var db = new LinqtoSQLDataContext(connection_string);

                Control_ac ctrac = new Control_ac();

                rs1 = ctrac.ARletterdataset1(db);
                rs2 = ctrac.ARletterdataset2(db);





                if (rs1 != null && rs2 != null)
                {

                    //  Utils ut = new Utils();
                    var dataset1 = Utils.ToDataTable(db, rs1);
                    var dataset2 = Utils.ToDataTable(db, rs2);
                    Reportsview rpt = new Reportsview(dataset1, dataset2, "ARletter.rdlc");
                    rpt.Show();

                }


                #endregion

                #region print detail

                //   string connection_string = Utils.getConnectionstr();

                //    var db = new LinqtoSQLDataContext(connection_string);
                //     var db = new LinqtoSQLDataContext(connection_string);


                //   string rptname = "ARletterdetail.rdlc";
                //      string rptname = "SubARletterdetail.rdlc";
                //    Control_ac ctrac = new Control_ac();

                var rs3 = ctrac.letterdetaildataset1(db);
                var rs4 = ctrac.letterdetaildataset2(db);


                if (rs1 != null && rs2 != null)
                {
                    //      var db = new LinqtoSQLDataContext(connection_string);
                    //   Utils ut = new Utils();
                    var dataset1 = Utils.ToDataTable(db, rs3);
                    var dataset2 = Utils.ToDataTable(db, rs4);
                    Reportsview rpt = new Reportsview(dataset1, dataset2, "ARletterdetail.rdlc");
                    rpt.Show();

                }

                #endregion

                #region print col
                //     string connection_string = Utils.getConnectionstr();

                //  var db = new LinqtoSQLDataContext(connection_string);
                //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);



                //  var db = new LinqtoSQLDataContext(connection_string);


                //   string rptname3 = "ARCOLrpt.rdlc";
                //      string rptname = "SubARletterdetail.rdlc";
                //      Control_ac ctrac = new Control_ac();

                var rs5 = ctrac.ARcoldataset1(db);
                var rs6 = ctrac.ARcoldataset2(db);


                if (rs1 != null && rs2 != null)
                {
                    //      var db = new LinqtoSQLDataContext(connection_string);
                    //   Utils ut = new Utils();
                    var dataset1 = Utils.ToDataTable(db, rs5);
                    var dataset2 = Utils.ToDataTable(db, rs6);
                    Reportsview rpt = new Reportsview(dataset1, dataset2, "ARCOLrpt.rdlc");
                    rpt.Show();



                }



                #endregion

            }




        }

        private void lETTERRETURNUPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {



            fromdate fromtochoice = new View.fromdate();
            Control_ac ctrac = new Control_ac();

            fromtochoice.ShowDialog();


            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //      LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);




            DateTime fromdate = fromtochoice.tungay;
            DateTime todate = fromtochoice.denngay;
            bool choice = fromtochoice.chon;




            if (choice == true)
            {
                var rs = from tbl_Preriod in db.tbl_Preriods
                         where tbl_Preriod.fromdate >= fromdate && tbl_Preriod.todate <= todate
                         orderby tbl_Preriod.customercodeGR
                         select tbl_Preriod;



                Viewtable viewtbl = new Viewtable(rs, db, "LETTER RETURN STATUS UPDATE", 1, DateTime.Today, DateTime.Today);
                //      viewtbl.Visible = false;
                //     viewtbl.Show();



            }






            //    string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


        }

        private void aRBalanceAndReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rEEDITDEPOSITVERIFYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //---


            fromdate fromtochoice = new View.fromdate();
            Control_ac ctrac = new Control_ac();

            fromtochoice.ShowDialog();


            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //      LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);




            DateTime fromdate = fromtochoice.tungay;
            DateTime todate = fromtochoice.denngay;
            bool choice = fromtochoice.chon;




            if (choice == true)
            {



                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                IQueryable rs2 = null;

                Viewtable viewtbl = new Viewtable(rs2, dc, "REINPUT DEPOSIT DATA FROM-" + fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year, 2, fromdate, todate); //view 3 để reupdate

                viewtbl.Show();










            }



        }

        private void lISTUNUSECUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerinput_ctrl md = new customerinput_ctrl();
            DialogResult kq1 = MessageBox.Show("Xoa list unuse thay bằng list mói ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //      bool kq;
            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.Yes:

                    //  this.uploadCustomerToolStripMenuItem.Enabled = false;

                    //    this.reportsToolStripMenuItem.Enabled = false;

                    md.deleteunuselistcustomer();
                    md.customerUNUSEinput();





                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.No:

                    md.customerUNUSEinput();

                    break;
                default:
                    break;
            }


        }

        private void vIEWLISTUNUSECUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            customerinput_ctrl md = new customerinput_ctrl();
            //var rs = md.customersetlect_all(db);

            var rs = from tbl_unuserCustomer in db.tbl_unuserCustomers
                     select tbl_unuserCustomer;

            //  MessageBox.Show("Data add/ change Customer done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Viewtable viewtbl = new Viewtable(rs, db, "CUSTOMER UNSEND LIST", 100, DateTime.Today, DateTime.Today);
            //     viewtbl.Show();

        }

        private void eDITLISTUNUSECUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tbl_unuserCustomer);

            VInputchange inputcdata = new VInputchange("", "CUSTOMER UNSEND LIST", dc, "tbl_unuserCustomer", "tbl_unuserCustomer", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();

        }

        private void systemConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uNBLOCKDEPOSITVERIFYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult kq1 = MessageBox.Show("REDO DEPOSIT VERIFY ! ", "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            // bool kq;
            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:


                    fromdate fromtochoice = new View.fromdate();
                    //   Control_ac ctrac = new Control_ac();

                    fromtochoice.ShowDialog();


                    string connection_string = Utils.getConnectionstr();

                    //  var db = new LinqtoSQLDataContext(connection_string);
                    //      LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);




                    DateTime fromdate = fromtochoice.tungay;
                    DateTime todate = fromtochoice.denngay;
                    bool choice = fromtochoice.chon;




                    if (choice == true)
                    {

                        #region  updatepriterinvoice updategroupprintletterChoiceALL
                        SqlConnection conn2 = null;
                        SqlDataReader rdr1 = null;

                        string destConnString = Utils.getConnectionstr();
                        try
                        {

                            conn2 = new SqlConnection(destConnString);
                            conn2.Open();
                            SqlCommand cmd1 = new SqlCommand("RedoDEPOSITverify", conn2);
                            cmd1.CommandType = CommandType.StoredProcedure;

                            cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                            cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                            //  System.Data.SqlDbType.DateTime
                            try
                            {
                                rdr1 = cmd1.ExecuteReader();
                                MessageBox.Show("OK, please go to Input verify to reinput !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Error  Redodepositverify \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        #endregion






                    }


                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult kq1 = MessageBox.Show("ENDMONTH CLOSE TEMP ? ", "CONFIRN CLOSE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:

                    //   string filename = theDialog.FileName.ToString();updatetoFBL5nnew
                    //    updatetoFBL5nnew(); // teo xoa sau


                    #region  DeleteTempFBL5nnew DeleteTempFBL5nnew
                    SqlConnection conn2 = null;
                    SqlDataReader rdr1 = null;

                    string destConnString = Utils.getConnectionstr();
                    try
                    {

                        conn2 = new SqlConnection(destConnString);
                        conn2.Open();
                        SqlCommand cmd1 = new SqlCommand("DeleteTempFBL5nnew", conn2);
                        cmd1.CommandType = CommandType.StoredProcedure;

                        ////     cmd1.Parameters.Add("@fromdate", SqlDbType.Date).Value = fromdate;
                        ///     cmd1.Parameters.Add("@todate", SqlDbType.Date).Value = todate;
                        //  System.Data.SqlDbType.DateTime
                        try
                        {
                            rdr1 = cmd1.ExecuteReader();
                            //  MessageBox.Show("OK, please go to Input verify to reinput !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Error  Delete TempFBL5n new \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    #endregion




                    #region q List các document có trong bảng  FBL5Nnew rồi !
                    //---

                    string connection_string = Utils.getConnectionstr();

                    //  var db = new LinqtoSQLDataContext(connection_string);
                    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                    db.CommandTimeout = 0;

                    var q = from tblFBL5Nnewthisperiod in db.tblFBL5Nnewthisperiods
                            where (from tblFBL5Nnew in db.tblFBL5Nnews
                                   select tblFBL5Nnew.Document_Number).Contains(tblFBL5Nnewthisperiod.Document_Number)
                            //Tương đương từ khóa NOT IN trong SQL
                            select tblFBL5Nnewthisperiod;



                    if (q.Count() != 0)
                    {



                        Viewtable viewtbl = new Viewtable(q, db, "Data không close được do có List các document sau đã update lên rồi !", 1, DateTime.Today, DateTime.Today);
                        viewtbl.Visible = false;
                        viewtbl.ShowDialog();
                    }
                    if (q.Count() == 0)
                    {

                        Control_ac ct = new Control_ac();

                        Thread t1 = new Thread(ct.inputthisisperiodtoFBL5nnewTEMP);
                        //   t1.IsBackground = true;
                        t1.Start();


                        Thread t2 = new Thread(showwait);
                        t2.Start();

                        t1.Join();


                        if (t1.ThreadState != ThreadState.Running)
                        {

                            Thread.Sleep(1299);

                            t2.Abort();

                        }





                    }
                    #endregion 





                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }


        }

        private void uPLOADCUSTOMERLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uPLOADCUSTOMERLISTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tblNKACustomer);

            VInputchange inputcdata = new VInputchange("", "LIST MASTER DATA CUSTOMER ", dc, "tblNKACustomer", "tblNKACustomer", typeff, "id", "id");
            inputcdata.Visible = false;
            inputcdata.ShowDialog();
        }

        private void uPLOADCUSTOMERLISTToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NKA NKA = new NKA();
            DialogResult kq1 = MessageBox.Show("Xóa toàn bộ dataCustomer ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //      bool kq;
            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.Yes:

                    // this.uploadCustomerToolStripMenuItem.Enabled = false;

                    // this.reportsToolStripMenuItem.Enabled = false;


                    NKA.deletetblNKACustomer();

                    NKA.NKACustomer_input();



                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.No:

                    NKA.NKACustomer_input();


                    break;
                default:
                    break;
            }
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            NKA md = new NKA();
            var rs = md.NKACustomerselect_all(db);

            //  MessageBox.Show("Data add/ change Customer done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Viewtable viewtbl = new Viewtable(rs, db, "CUSTOMER DATA", 1, DateTime.Today, DateTime.Today);
            //     viewtbl.Show();
        }

        private void vIEWCUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            NKA md = new NKA();
            var rs = md.NKACustomerselect_all(db);

            //  MessageBox.Show("Data add/ change Customer done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Viewtable viewtbl = new Viewtable(rs, db, "CUSTOMER DATA", 1, DateTime.Today, DateTime.Today);
            //     viewtbl.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //var db = new LinqtoSQLDataContext(connection_string);
            //      fRM_AROPTION fromoptiong = new fRM_AROPTION("ARletter.rdlc");
            //     fromoptiong.Show();

            //
            string connection_string = Utils.getConnectionstr();

            var db = new LinqtoSQLDataContext(connection_string);

            Control_ac ctrac = new Control_ac();

            rs1 = ctrac.nkaARletterdataset1(db);
            rs2 = ctrac.nkaARletterdataset2(db);





            if (rs1 != null && rs2 != null)
            {

                //       Utils ut = new Utils();
                var dataset1 = Utils.ToDataTable(db, rs1);
                var dataset2 = Utils.ToDataTable(db, rs2);
                Reportsview rpt = new Reportsview(dataset1, dataset2, "NKAARletter.rdlc");
                rpt.Show();

            }


        }

        private void uPLOADBALANCEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NKAfRM_AROPTION_Upload PrintOption = new NKAfRM_AROPTION_Upload();
            // Control_ac ctrac = new Control_ac();

            PrintOption.ShowDialog();


            DateTime todate = PrintOption.todate;
            DateTime returndate = PrintOption.returndate;

            Boolean choice = PrintOption.choice;

            if (choice)
            {

                NKA NKA = new NKA();

                NKA.deleteNKASumarylist();

                NKA.NKAsumary_input(todate, returndate);

            }


            //  NKAupdateNameletter


            #region update NKAupdateNameletter  namleter
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("NKAupdateNameletter", conn2);
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







            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            NKA md = new NKA();
            var rs = md.NKASumarylistselect_all(db);

            //  MessageBox.Show("Data add/ change Customer done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Viewtable viewtbl = new Viewtable(rs, db, "SUMARY DATA", 1, DateTime.Today, DateTime.Today);

        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            NKA md = new NKA();
            var rs = md.NKASumarylistselect_all(db);

            //  MessageBox.Show("Data add/ change Customer done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Viewtable viewtbl = new Viewtable(rs, db, "SUMARY DATA", 1, DateTime.Today, DateTime.Today);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            NKA md = new NKA();
            var rs = md.NKADetaillistselect_all(db);

            //  MessageBox.Show("Data add/ change Customer done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Viewtable viewtbl = new Viewtable(rs, db, "SUMARY DATA", 1, DateTime.Today, DateTime.Today);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            fromdateandcode fromtochoice = new View.fromdateandcode();
            Control_ac ctrac = new Control_ac();

            fromtochoice.ShowDialog();


            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //      LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            db.CommandTimeout = 0;




            DateTime fromdate = fromtochoice.tungay;
            DateTime todate = fromtochoice.denngay;
            double custcode = fromtochoice.custcode;

            bool choice = fromtochoice.chon;




            if (choice == true)
            {


                #region update EMPTY TO DEPOSTI AMOUNT
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("UploademptyToDepositAmount", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandTimeout = 0;
                    cmd1.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
                    cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
                    cmd1.Parameters.Add("@custcode", SqlDbType.Float).Value = custcode;

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
                MessageBox.Show("Mass balance empty to deposit amount done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #endregion









            }
        }

        private void uPLOADCLEARFREEGLASSESPROGARMEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //  bool kq;
            fREEGALSSES_CTRL md = new fREEGALSSES_CTRL();

            DialogResult kq1 = MessageBox.Show("Update file clear glasses ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:


                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:



                    //this.updateNewAllToolStripMenuItem1.Enabled = false;

                    //this.reportsToolStripMenuItem.Enabled = false;
                    md.clearFeeglasseeinputtemp();


                    // var rs = md.vatsetlect_all();
                    //        Viewtable viewtbl = new Viewtable(rs, "VAT ZFI data uploaded ");

                    string connection_string = Utils.getConnectionstr();

                    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
                    var rs = from FreGlassClear in db.tbl_FreGlassCleartemps
                             select FreGlassClear;


                    Viewtable Viewtable = new Viewtable(rs, db, "Clear FressGlasses Progarme upload ", 11, DateTime.Today, DateTime.Today);











                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }



        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            var rs = from tblFBL5Nnew in db.tblFBL5Nnews
                     where tblFBL5Nnew.Document_Type == "COL"
                     select tblFBL5Nnew;


            Viewtable Viewtable = new Viewtable(rs, db, "List FressGlasses Progarme ", 12, DateTime.Today, DateTime.Today);





        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            fromdateandcode fromtochoice = new View.fromdateandcode();
            Control_ac ctrac = new Control_ac();

            fromtochoice.ShowDialog();


            string connection_string = Utils.getConnectionstr();

            //  var db = new LinqtoSQLDataContext(connection_string);
            //      LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            db.CommandTimeout = 0;




            DateTime fromdate = fromtochoice.tungay;
            DateTime todate = fromtochoice.denngay;
            double custcode = fromtochoice.custcode;

            bool choice = fromtochoice.chon;




            if (choice == true)
            {

                var rs = from tblFBL5Nnew in db.tblFBL5Nnews
                         where tblFBL5Nnew.Posting_Date >= fromdate
                         && tblFBL5Nnew.Posting_Date <= todate
                      && tblFBL5Nnew.Account == custcode
                         select tblFBL5Nnew;


                Viewtable Viewtable = new Viewtable(rs, db, "REdo Deposit veryfy of Close Priod by Click on Adj Amount, Empty Amount to move to Deposit Amount", 13, DateTime.Today, DateTime.Today);

                //    Viewtable.ShowDialog();



            }




        }

        private void deleteWrongClearFreeGalassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  bool kq;
            fREEGALSSES_CTRL md = new fREEGALSSES_CTRL();

            DialogResult kq1 = MessageBox.Show("Delete wrong clear glasses ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:


                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:



                    //this.updateNewAllToolStripMenuItem1.Enabled = false;

                    //this.reportsToolStripMenuItem.Enabled = false;
                    md.deletewrongclearFeeglasseeinput();


                    // var rs = md.vatsetlect_all();
                    //        Viewtable viewtbl = new Viewtable(rs, "VAT ZFI data uploaded ");

                    //string connection_string = Utils.getConnectionstr();

                    //LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
                    //var rs = from FreGlassClear in db.tbl_FreGlassCleartemps
                    //         select FreGlassClear;


                    //Viewtable Viewtable = new Viewtable(rs, db, "Clear FressGlasses Progarme upload ", 11, DateTime.Today, DateTime.Today);











                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            View.DatecodePicker datefrom = new View.DatecodePicker("Select balace date: ");
            datefrom.ShowDialog();
            DateTime balancedate = datefrom.valuedate;
            bool kq = datefrom.kq;
            double custcode = datefrom.code;
            string username = Utils.getusername();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);





            if (kq == true)
            {
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                dc.CommandTimeout = 0;

                if (custcode == 0) // là chạy tất
                {
                    #region  //  tính bảng  tbl_Coldetail tren sql

                    try
                    {

                        conn2 = new SqlConnection(destConnString);
                        conn2.Open();
                        SqlCommand cmd1 = new SqlCommand("insertviewbalanceRpt", conn2);
                        cmd1.CommandType = CommandType.StoredProcedure;

                        //@balancedate datetime,
                        //@username nvarchar(50)

                        cmd1.Parameters.Add("@balancedate", SqlDbType.Date).Value = balancedate;
                        cmd1.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                        cmd1.CommandTimeout = 0;
                        try
                        {
                            rdr1 = cmd1.ExecuteReader();

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("ERRor make: balance view data \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else // là only code
                {

                    #region  //  tính bảng  insertviewbalanceRptOnlycode tren sql

                    try
                    {

                        conn2 = new SqlConnection(destConnString);
                        conn2.Open();
                        SqlCommand cmd1 = new SqlCommand("insertviewbalanceRptOnlycode", conn2);
                        cmd1.CommandType = CommandType.StoredProcedure;

                        //@balancedate datetime,
                        //@username nvarchar(50)
                        cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = custcode;
                        cmd1.Parameters.Add("@balancedate", SqlDbType.Date).Value = balancedate;
                        cmd1.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                        cmd1.CommandTimeout = 0;
                        try
                        {
                            rdr1 = cmd1.ExecuteReader();

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("ERRor make: balance view data \n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // view balance''

                #region  chọn 1 coed

                //var q3 = (from tblEDLP in dc.tblEDLPs
                //          group tblEDLP by tblEDLP.Invoice_Doc_Nr into OD//Tương đương GROUP BY trong SQL
                //          orderby OD.Key
                //          where !(from tblVat in dc.tblVats
                //                  select tblVat.SAP_Invoice_Number).Contains(OD.Key)

                //          select new
                //          {
                //              Document_Number = OD.Key,
                //              Name = OD.Select(m => m.Cust_Name).FirstOrDefault(),
                //              Value_Count = OD.Sum(m => m.Cond_Value)




                //          });


                var rs2 = from p in dc.tblFBL5NnewRptbalances
                          where p.username == username
                          group p by p.Account into h
                          select new
                          {
                              Account = h.Key,

                              Amount_in_local_currency = h.Sum(m => m.Amount_in_local_currency),
                              Payment_amount = h.Sum(m => m.Payment_amount),
                              Adjusted_amount = h.Sum(m => m.Adjusted_amount),
                              Fullgood_amount = h.Sum(m => m.Fullgood_amount),
                              Invoice_Amount = h.Sum(m => m.Invoice_Amount),

                              Deposit_amount = h.Sum(m => m.Deposit_amount),

                              Ketvothuong = h.Sum(m => m.Ketvothuong),
                              paletnhua = h.Sum(m => m.paletnhua),
                              palletgo = h.Sum(m => m.palletgo),

                              Binhpmicc02 = h.Sum(m => m.Binhpmicc02),
                              binhpmix9l = h.Sum(m => m.binhpmix9l),
                              Chaivo1lit = h.Sum(m => m.Chaivo1lit),
                              Chaivothuong = h.Sum(m => m.Chaivothuong),
                              //    Document_Number = h.Sum(m => m.Document_Number),
                              joy20l = h.Sum(m => m.joy20l),
                              Ketvolit = h.Sum(m => m.Ketvolit),
                              Ketnhua1lit = h.Sum(m => m.Ketnhua1lit),
                              Ketnhuathuong = h.Sum(m => m.Ketnhuathuong),





                          };


                #endregion
                Viewtable viewtbl = new Viewtable(rs2, dc, "BALANCE VIEW REPORTS AT: " + balancedate.ToShortDateString(), 100, DateTime.Today, DateTime.Today); //view loại 100 view bình thường là có fromdatetodate







            }






        }
    }


}


