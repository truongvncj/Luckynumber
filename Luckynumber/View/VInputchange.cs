
using arconfirmationletter.Control;
using arconfirmationletter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace arconfirmationletter.View
{

    // public partial
    public partial class VInputchange : Form
    {


        public LinqtoSQLDataContext db { get; set; }
        //  public LinqtoSQLDataContext dc { get; set; }
        public string tblnamemain { get; set; }
        public string tblnamesub { get; set; }
        public string IDmain { get; set; }
        public IQueryable rs { get; set; }
        public string IDsub { get; set; }
        public System.Type Typeofftable { get; set; }
        public BindingSource source1;
        public BindingSource source2;


        void Control_KeyPress(object sender, KeyEventArgs e)
        {

            if (this.tblnamesub == "tblCustomer" && e.KeyCode == Keys.F3)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "tblCustomered")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "tblCustomered");
                    sheaching.Show();
                }




            }
            // Reloadedbeginbalance

            if (this.tblnamesub == "tblFBL5beginbalace" && e.KeyCode == Keys.F3)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "tblFBL5beginbalace")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "tblFBL5beginbalace");
                    sheaching.Show();
                }



            }
            }

        public VInputchange(string lbheader, string lbsub, LinqtoSQLDataContext db, string tblnamemain, string tblnamesub, System.Type Typeofftable, String IDmain, String IDsub)
        {
            InitializeComponent();


       //     #region right setup
            this.lbseachedit.Visible = false;
            this.Bt_uploadbegin.Visible = false;
            // this.lbusername.Text = Utils.getusername();

            //int rightnumber = Utils.getrightnumber();

            //if (rightnumber == 0) // không ró quyền/ đóng luôn
            //{
            //    this.Close();



            //}
            //if (rightnumber == 1) // super user
            //{





            //}
            //if (rightnumber == 2) // admin  user
            //{

            //    //  dELETEALLDATABASEEDITToolStripMenuItem.Visible = false;
            //    //   beginingBalanceToolStripMenuItem1.Visible = false;
            //    //      eDITALLDATABASEToolStripMenuItem.Visible = false;

            //    //       systemConfigToolStripMenuItem.Visible = false;
            //    //   uploadCustomerToolStripMenuItem.Visible = false;
            //    //    eDITCUSTOMERDATAToolStripMenuItem.Visible = false;


            //}
            //if (rightnumber == 3) // nomal user
            //{

            //    this.bt_detletedsetlectmain.Visible = false;

            //}
            //if (rightnumber == 4) // display user
            //{

            //    this.bt_detletedsetlectmain.Visible = false;

            //}
            //#endregion




            this.bnt_adddataselected.Visible = false;
            this.Bt_Adddata.Visible = true;
            if (lbheader == "")
            {
                //    this.p
                this.mainpanel.Hide();
                this.Bt_Adddata.Hide();
                this.splitContainer1.Panel2Collapsed = true;

            }


            if (lbsub == "LIST MASTER DATA CUSTOMER ")
            {
                this.lbseachedit.Visible = true;
            }




            if (tblnamemain == "tbl_CustomerneedLetter")
            {

                this.Bt_Adddata.Visible = false;

            }

            this.db = db;
            this.tblnamemain = tblnamemain;
            this.tblnamesub = tblnamesub;
            this.Typeofftable = Typeofftable;
            this.IDmain = IDmain;
            this.IDsub = IDsub;

            this.lb_headermain.Text = lbheader;
            this.lb_headersub.Text = lbsub;


            string slqtext = "select * from " + tblnamemain;

            var results3 = db.ExecuteQuery(Typeofftable, slqtext);


            source2 = new BindingSource();
            source2.AllowNew = true;
            source2.DataSource = results3;
            //  source2.AddNew();

            //source2.AllowNew = true;
            //if (results3 == null)
            //{
            //    source2.AddNew();
            //}
            //    results3




            this.dataGridView2.DataSource = source2;  // view 2 la main view 1 detaik

            this.dataGridView2.AllowUserToAddRows = true;



            if (this.dataGridView2.Columns[IDmain] != null)
            {
                this.dataGridView2.Columns[IDmain].Visible = false;
            }






            slqtext = "select *  from  " + tblnamesub; // EXCEPT (" + IDsub + ") 


            var results2 = db.ExecuteQuery(Typeofftable, slqtext);


            source1 = new BindingSource();
            source1.AllowNew = true;
            //if (results2 == null)
            //{
            //    source1.AddNew();
            //}
            source1.DataSource = results2;

            this.dataGridView1.DataSource = source1;

            this.dataGridView1.AutoGenerateColumns = true;


            #region  // IF NULL   tbl_CustomerGroupTemp
            if (tblnamesub == "tbl_CustomerGroupTemp")
            {

                if (source1.Count == 0)

                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_CustomerGroupTemp in dc.tbl_CustomerGroupTemps
                                       select tbl_CustomerGroupTemp;

                  //  Utils ut = new Utils();
                    dt = Utils.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }

            }

            #endregion




            #region  // IF NULL   tbl_ProductlistTMP
            if (tblnamesub == "tbl_ProductlistTMP")
            {

                if (source1.Count == 0)

                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_ProductlistTMP in dc.tbl_ProductlistTMPs
                                       select tbl_ProductlistTMP;

                //    Utils ut = new Utils();
                    dt = Utils.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }

            }

            #endregion




            #region  // IF NULL   tblCustomerTmp
            if (tblnamesub == "tblCustomerTmp")
            {

                if (source1.Count == 0)

                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tblCustomerTmp in dc.tblCustomerTmps
                                       select tblCustomerTmp;

                 //   Utils ut = new Utils();
                    dt = Utils.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }

            }

            #endregion



            #region  // IF NULL   tbl_Productlist
            if (tblnamesub == "tbl_Productlist")
            {

                if (source1.Count == 0)

                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_Productlist in dc.tbl_Productlists
                                       select tbl_Productlist;

                 //   Utils ut = new Utils();
                    dt = Utils.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }

            }

            #endregion


            #region  // IF NULL   tbl_CustomerGroup
            if (tblnamesub == "tbl_CustomerGroup")
            {

                if (source1.Count == 0)

                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_CustomerGroup in dc.tbl_CustomerGroups
                                       select tbl_CustomerGroup;

                 //   Utils ut = new Utils();
                    dt = Utils.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }

            }

            #endregion



            // IF NULL


            if (this.dataGridView1.Columns[IDsub] != null)
            {
                this.dataGridView1.Columns[IDsub].Visible = false;
            }


            this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            if (lbsub == "LIST PRODUCT AND EMPTY GROUP")
            {

                this.dataGridView1.Columns["tbl_EmptyGroup"].Visible = false;
            }






            if (lbsub == "BEGINNING BALANCE ARCONFIRMATION LETTER")
            {
                //  this.bnt_adddataselected.Visible = true;
                //  this.Bt_Adddata.Visible = false;
                //     tblFBL5beginbalace tb = new tblFBL5beginbalace();
                //tb.codeGroup
                //  this.dataGridView1.Columns["codeGroup"].Visible = false;
                this.Bt_uploadbegin.Visible = true;








            }

            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);
            if (lbsub == "LIST CUSTOMER MAKE REPORTS")
            {

                this.lbseachedit.Visible = true;







            }


            if (tblnamesub == "tblFBL5beginbalace")
            {

                this.lbseachedit.Visible = true;







            }


            //tblCustomer cct = new tblCustomer();
            //cct.Customer = 90;


        }



        public void Reloadeditcustomer(string text)
        {

            #region tblCustomer



            if (tblnamesub == "tblCustomer")
            {
                string slqtext = "select *  from   tblCustomer where  CONVERT(INT, tblCustomer.Customer) like '%" + text + "%'"; // EXCEPT (" + IDsub + ") 


                var results2 = db.ExecuteQuery(Typeofftable, slqtext);
                source1 = new BindingSource();
                source1.DataSource = results2;
                source1.AllowNew = true;

                //   IQueryable results2 = db.ExecuteQuery(Typeofftable, slqtext);
                //   this.rs = results2.AsQueryable();


                //    string slqtext2 = "select * from " + tblnamemain;

                //    IQueryable results3 = db.ExecuteQuery(Typeofftable, slqtext);


                this.dataGridView1.DataSource = source1;

                this.dataGridView1.AutoGenerateColumns = true;
                if (this.dataGridView1.Columns[IDsub] != null)
                {
                    this.dataGridView1.Columns[IDsub].Visible = false;
                }


                this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            }
            #endregion


        }


        public void Reloadedbeginbalance(string text)
        {

            #region tblFBL5beginbalace



            if (tblnamesub == "tblFBL5beginbalace")
            {
                string slqtext = "select *  from   tblFBL5beginbalace where  CONVERT(INT, tblFBL5beginbalace.Account) like '%" + text + "%'"; // EXCEPT (" + IDsub + ") 


                var results2 = db.ExecuteQuery(Typeofftable, slqtext);
                source1 = new BindingSource();
                source1.DataSource = results2;
                source1.AllowNew = true;

                //   IQueryable results2 = db.ExecuteQuery(Typeofftable, slqtext);
                //   this.rs = results2.AsQueryable();


                //    string slqtext2 = "select * from " + tblnamemain;

                //    IQueryable results3 = db.ExecuteQuery(Typeofftable, slqtext);


                this.dataGridView1.DataSource = source1;

                this.dataGridView1.AutoGenerateColumns = true;
                if (this.dataGridView1.Columns[IDsub] != null)
                {
                    this.dataGridView1.Columns[IDsub].Visible = false;
                }


                this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            }
            #endregion


        }


        private void bt_updatedata_Click(object sender, EventArgs e)
        {


            //     bool kqupdate = true;
            source1.EndEdit();

            db.SubmitChanges();








            // deleted cac dong cos tron data khong co trong gridview
            #region   foreach (DataGridViewRow r in dataGridView1.Rows)


            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (r.Cells[IDsub].Value != null)
                {


                    var indexvalue = int.Parse(r.Cells[IDsub].Value.ToString());
                    //      var kq = source1.Find(IDsub, indexvalue);

                    if (indexvalue == 0) //neewu co tron view khong co trong dataa == add vao dat ta
                    {
                        //var bk = new tblEDLP();

                        string stringfield = "";
                        string stringvalue = "";

                        int idculum = this.dataGridView1.ColumnCount;

                        for (int idculumid = 0; idculumid < idculum; idculumid++)
                        {
                            var colheadertext = this.dataGridView1.Columns[idculumid].HeaderText;


                            var valueid = r.Cells[colheadertext].Value;

                            if (valueid != null && colheadertext != IDsub)
                            {

                                var IDType = r.Cells[colheadertext].ValueType;

                                if (colheadertext.Contains("_"))
                                {
                                    colheadertext = colheadertext.Replace("_", " ");
                                    string temp = "[" + colheadertext + "]";
                                    colheadertext = temp;
                                }


                                if (IDType.ToString().Contains("String"))
                                {

                                    valueid = "'" + valueid + "'";
                                }



                                if (IDType.ToString().Contains("Date"))
                                {

                                    valueid = "'" + valueid + "'";
                                }

                                if (stringvalue != "")
                                {

                                    stringvalue = stringvalue + "," + valueid;
                                    stringfield = stringfield + "," + colheadertext;

                                }
                                else
                                {
                                    stringvalue = stringvalue + valueid;

                                    stringfield = stringfield + colheadertext;

                                }



                            }




                        }



                        string StrQuery = "INSERT INTO " + tblnamesub + " ( " + stringfield + " ) VALUES (" + stringvalue + ")"; // + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ", " + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ");";
                        try
                        {


                            var results4 = db.ExecuteQuery(Typeofftable, StrQuery);
                        }
                        catch// (Exception ex)
                        {

                            //this.dataGridView1.Rows[0].Cells["Status"].Value = ex.ToString();
                        }



                        //MessageBox.Show(StrQuery, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }





                }



            }
            #endregion foreach

            #region  1213 // //check data customer code
            if (tblnamesub == "tbl_CustomerGroupTemp")
            {
                #region  xoas dong banl customer
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.Cells["Customercode"].Value == null && !r.IsNewRow)

                    {

                        var gridviewid = int.Parse(r.Cells[IDsub].Value.ToString());


                        var slqtext2 = "delete  from  " + tblnamesub + " where " + IDsub + " = " + gridviewid;
                        try
                        {
                            db.ExecuteQuery(Typeofftable, slqtext2);
                        }
                        catch (Exception)
                        {


                            //  /     //   throw;
                        }



                        this.dataGridView1.Rows.Remove(r);
                        db.SubmitChanges();
                    }





                }
                #endregion  xoas dong banl customer

                #region // updade dong trang group+ name group
                float vCustomergropcode = 0;
                string vGroupName = "";
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {


                    if (r.Cells["Customergropcode"].Value != null && r.Cells["Customergropcode"].Value.ToString() != "")
                    {

                        vCustomergropcode = float.Parse(r.Cells["Customergropcode"].Value.ToString());


                    }
                    if (r.Cells["Group_Name"].Value != null)
                    {

                        vGroupName = r.Cells["Group_Name"].Value.ToString();

                    }





                    if ((r.Cells["Customergropcode"].Value == null || r.Cells["Group_Name"].Value == null) && !r.IsNewRow)

                    {

                        if (vCustomergropcode != 0)

                        {
                            r.Cells["Customergropcode"].Value = vCustomergropcode.ToString();

                        }
                        else
                        {
                            // chay xuong duoi cho den khi data co hoac dong cuoi
                            for (int i = r.Index + 1; i < dataGridView1.Rows.Count; i++)
                            {
                                var check1 = dataGridView1.Rows[i].Cells["Customergropcode"].Value;
                                //     var check2 = dataGridView1.Rows[i].Cells["Group_Name"].Value;

                                if (check1 != null)
                                {

                                    r.Cells["Customergropcode"].Value = check1;
                                    vCustomergropcode = float.Parse(check1.ToString());
                                }



                            }

                            //  // chay xuong duoi cho den khi data co hoac dong cuoi

                        }


                        if (vGroupName != "")
                        {


                            r.Cells["Group_Name"].Value = vGroupName.ToString();
                        }
                        else
                        {


                            // chay xuong duoi cho den khi data co hoac dong cuoi
                            for (int i = r.Index + 1; i < dataGridView1.Rows.Count; i++)
                            {
                                //  var check1 = dataGridView1.Rows[i].Cells["Customergropcode"].Value;
                                var check2 = dataGridView1.Rows[i].Cells["Group_Name"].Value;


                                if (check2 != null)
                                {

                                    r.Cells["Group_Name"].Value = check2.ToString();
                                    vGroupName = check2.ToString();
                                }

                            }

                            //  // chay xuong duoi cho den khi data co hoac dong cuoi
                        }



                    }








                }
                #endregion // updade dong trang group+ name group



            }
            #endregion // check data customer code != nll, ""

            source1.EndEdit();

            db.SubmitChanges();

            // view lại
            string slqtext = "select *  from  " + tblnamesub; // EXCEPT (" + IDsub + ") 
            var results2 = db.ExecuteQuery(Typeofftable, slqtext);
            source1.DataSource = results2;
            this.dataGridView1.DataSource = source1;
            // view lại
            MessageBox.Show("Data update done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            #region  // IF NULL   tbl_CustomerGroupTemp
            if (tblnamesub == "tbl_CustomerGroupTemp")
            {

                if (source1.Count == 0)

                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_CustomerGroupTemp in dc.tbl_CustomerGroupTemps
                                       select tbl_CustomerGroupTemp;

                //    Utils ut = new Utils();
                    dt = Utils.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }

            }

            #endregion




            #region  // IF NULL   tbl_ProductlistTMP
            if (tblnamesub == "tbl_ProductlistTMP")
            {

                if (source1.Count == 0)

                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_ProductlistTMP in dc.tbl_ProductlistTMPs
                                       select tbl_ProductlistTMP;

               //     Utils ut = new Utils();
                    dt = Utils.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }

            }

            #endregion




            #region  // IF NULL   tblCustomerTmp
            if (tblnamesub == "tblCustomerTmp")
            {

                if (source1.Count == 0)

                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tblCustomerTmp in dc.tblCustomerTmps
                                       select tblCustomerTmp;

                 //   Utils ut = new Utils();
                    dt = Utils.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }

            }

            #endregion



            #region  // IF NULL   tbl_Productlist
            if (tblnamesub == "tbl_Productlist")
            {

                if (source1.Count == 0)

                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_Productlist in dc.tbl_Productlists
                                       select tbl_Productlist;

                 //   Utils ut = new Utils();
                    dt = Utils.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }

            }

            #endregion


            #region  // IF NULL   tbl_CustomerGroup
            if (tblnamesub == "tbl_CustomerGroup")
            {

                if (source1.Count == 0)

                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_CustomerGroup in dc.tbl_CustomerGroups
                                       select tbl_CustomerGroup;

                  //  Utils ut = new Utils();
                    dt = Utils.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }

            }

            #endregion

        }



        private void Bt_Deleteddata_Click(object sender, EventArgs e)
        {

            var select = dataGridView1.SelectedRows;

            foreach (var item in select)
            {
                DataGridViewRow select2 = (DataGridViewRow)item;
                if (!select2.IsNewRow)
                {

                    //  select2.ind

                    var gridviewid = int.Parse(dataGridView1.Rows[select2.Index].Cells[IDsub].Value.ToString());


                    var slqtext = "delete  from  " + tblnamesub + " where " + IDsub + " = " + gridviewid;
                    try
                    {
                        db.ExecuteQuery(Typeofftable, slqtext);
                    }
                    catch (Exception)
                    {


                        //  /     //   throw;
                    }



                    this.dataGridView1.Rows.Remove(select2);
                    db.SubmitChanges();
                }

            }

            dataGridView1.Refresh();
            //      dataGridView1.UserDeletedRow;

            //   dataGridView1.RowsRemoved();





            MessageBox.Show("Data deleted done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);






        }

        private void Bt_Adddata_Click(object sender, EventArgs e)
        {
            bool kqupdate = true;
            source1.EndEdit();

            db.SubmitChanges();


            #region  1213 // //check data customer code
            if (tblnamesub == "tbl_CustomerGroupTemp")
            {





                #region  xoas dong trawng kho co du lieu customer
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.Cells["Customercode"].Value == null && !r.IsNewRow)

                    {

                        var gridviewid = int.Parse(r.Cells[IDsub].Value.ToString());


                        var slqtext2 = "delete  from  " + tblnamesub + " where " + IDsub + " = " + gridviewid;
                        try
                        {
                            db.ExecuteQuery(Typeofftable, slqtext2);
                        }
                        catch (Exception)
                        {


                            //  /     //   throw;
                        }



                        this.dataGridView1.Rows.Remove(r);
                        db.SubmitChanges();
                    }





                }
                #endregion  xoas dong banl customer





                #region     // tim code trong master data, neu co tiep tuc, neu khong bao code do khong co trong master

                foreach (DataGridViewRow rx in dataGridView1.Rows)
                {

                    if (rx.Cells["Customercode"].Value != null && rx.IsNewRow == false)
                    {

                        //  dataGridView1.c
                        var vCustomercode = int.Parse(rx.Cells["Customercode"].Value.ToString());
                        if (rx.Cells["Region"].Value != null)
                        {
                            var vRegion = rx.Cells["Region"].Value.ToString();



                            var qr = from tblCustomer in db.tblCustomers
                                     where tblCustomer.Customer == vCustomercode && tblCustomer.SOrg == vRegion
                                     select tblCustomer;

                            if (qr.Count() == 0)
                            {

                                rx.Cells["Group_Name"].Value = "Customer not in Master data ! Please check ??? ";

                                kqupdate = false;


                            }
                        }
                        else
                        {
                            MessageBox.Show("Please update region fields!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    //else
                    //{
                    //    MessageBox.Show("Please update Customercode fields!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                }






                #endregion   // tim code trong master data, neu co tiep tuc, neu khong bao code do khong co trong master

                #region // updade dong trang group+ name group
                float vCustomergropcode = 0;
                string vGroupName = "";
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {


                    if (r.Cells["Customergropcode"].Value != null && r.Cells["Customergropcode"].Value.ToString() != "")
                    {

                        vCustomergropcode = float.Parse(r.Cells["Customergropcode"].Value.ToString());


                    }
                    if (r.Cells["Group_Name"].Value != null)
                    {

                        vGroupName = r.Cells["Group_Name"].Value.ToString();

                    }





                    if ((r.Cells["Customergropcode"].Value == null || r.Cells["Group_Name"].Value == null) && !r.IsNewRow)

                    {

                        if (vCustomergropcode != 0)

                        {
                            r.Cells["Customergropcode"].Value = vCustomergropcode.ToString();

                        }
                        else
                        {
                            // chay xuong duoi cho den khi data co hoac dong cuoi
                            for (int i = r.Index + 1; i < dataGridView1.Rows.Count; i++)
                            {
                                var check1 = dataGridView1.Rows[i].Cells["Customergropcode"].Value;
                                //     var check2 = dataGridView1.Rows[i].Cells["Group_Name"].Value;

                                if (check1 != null)
                                {

                                    r.Cells["Customergropcode"].Value = check1;
                                    vCustomergropcode = float.Parse(check1.ToString());
                                }



                            }

                            //  // chay xuong duoi cho den khi data co hoac dong cuoi

                        }


                        if (vGroupName != "")
                        {


                            r.Cells["Group_Name"].Value = vGroupName.ToString();
                        }
                        else
                        {


                            // chay xuong duoi cho den khi data co hoac dong cuoi
                            for (int i = r.Index + 1; i < dataGridView1.Rows.Count; i++)
                            {
                                //  var check1 = dataGridView1.Rows[i].Cells["Customergropcode"].Value;
                                var check2 = dataGridView1.Rows[i].Cells["Group_Name"].Value;


                                if (check2 != null)
                                {

                                    r.Cells["Group_Name"].Value = check2.ToString();
                                    vGroupName = check2.ToString();
                                }

                            }

                            //  // chay xuong duoi cho den khi data co hoac dong cuoi
                        }



                    }








                }
                #endregion // updade dong trang group+ name group



            }
            #endregion // check data customer code != nll, ""
            source1.EndEdit();

            db.SubmitChanges();


            if (kqupdate || tblnamesub != "tbl_CustomerGroupTemp")
            {





                string fieldtblemain = "";
                string colheadertext = "";
                int idculum = this.dataGridView1.ColumnCount;

                for (int idculumid = 0; idculumid < idculum; idculumid++)
                {


                    colheadertext = this.dataGridView1.Columns[idculumid].HeaderText;

                    if (colheadertext.Contains("_"))
                    {
                        colheadertext = colheadertext.Replace("_", " ");
                        string temp = "[" + colheadertext + "]";
                        colheadertext = temp;
                    }



                    if (colheadertext != IDsub && colheadertext != "Status")
                    {
                        if (fieldtblemain == "")
                        {
                            fieldtblemain = fieldtblemain + colheadertext;
                        }
                        else
                        {
                            fieldtblemain = fieldtblemain + "," + colheadertext;

                        }




                    }



                }






                var slqtext = "insert into " + tblnamemain + " ( " + fieldtblemain + ") select  " + fieldtblemain + " from  " + tblnamesub;
                //   MessageBox.Show(slqtext);

                try
                {
                    db.ExecuteCommand(slqtext);
                    db.CommandTimeout = 100;
                }
                catch // (Exception ex)
                {
                    // this.dataGridView1.Rows[0].Cells["Status"].Value = ex.ToString();
                    //   MessageBox.Show(ex.ToString());
                    //  /     //   throw;
                }

                slqtext = "select * from " + tblnamemain;

                var results = db.ExecuteQuery(Typeofftable, slqtext);

                source2.DataSource = results;


                slqtext = "delete from " + tblnamesub;

                db.ExecuteCommand(slqtext);
                db.SubmitChanges();



                MessageBox.Show("Data add to main data table done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #region  // IF NULL   tbl_CustomerGroupTemp
                if (tblnamesub == "tbl_CustomerGroupTemp")
                {

                    if (source1.Count == 0)

                    {

                        //       MessageBox.Show("ok !!!!!!!!");
                        string connection_string = Utils.getConnectionstr();
                        //      UpdateDatagridview
                        System.Data.DataTable dt = new System.Data.DataTable();
                        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                        var rsthisperiod = from tbl_CustomerGroupTemp in dc.tbl_CustomerGroupTemps
                                           select tbl_CustomerGroupTemp;

                     //   Utils ut = new Utils();
                        dt = Utils.ToDataTable(dc, rsthisperiod);

                        this.dataGridView1.DataSource = dt;


                    }

                }

                #endregion




                #region  // IF NULL   tbl_ProductlistTMP
                if (tblnamesub == "tbl_ProductlistTMP")
                {

                    if (source1.Count == 0)

                    {

                        //       MessageBox.Show("ok !!!!!!!!");
                        string connection_string = Utils.getConnectionstr();
                        //      UpdateDatagridview
                        System.Data.DataTable dt = new System.Data.DataTable();
                        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                        var rsthisperiod = from tbl_ProductlistTMP in dc.tbl_ProductlistTMPs
                                           select tbl_ProductlistTMP;

                 //       Utils ut = new Utils();
                        dt = Utils.ToDataTable(dc, rsthisperiod);

                        this.dataGridView1.DataSource = dt;


                    }

                }

                #endregion




                #region  // IF NULL   tblCustomerTmp
                if (tblnamesub == "tblCustomerTmp")
                {

                    if (source1.Count == 0)

                    {

                        //       MessageBox.Show("ok !!!!!!!!");
                        string connection_string = Utils.getConnectionstr();
                        //      UpdateDatagridview
                        System.Data.DataTable dt = new System.Data.DataTable();
                        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                        var rsthisperiod = from tblCustomerTmp in dc.tblCustomerTmps
                                           select tblCustomerTmp;

                   //     Utils ut = new Utils();
                        dt = Utils.ToDataTable(dc, rsthisperiod);

                        this.dataGridView1.DataSource = dt;


                    }

                }

                #endregion



                #region  // IF NULL   tbl_Productlist
                if (tblnamesub == "tbl_Productlist")
                {

                    if (source1.Count == 0)

                    {

                        //       MessageBox.Show("ok !!!!!!!!");
                        string connection_string = Utils.getConnectionstr();
                        //      UpdateDatagridview
                        System.Data.DataTable dt = new System.Data.DataTable();
                        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                        var rsthisperiod = from tbl_Productlist in dc.tbl_Productlists
                                           select tbl_Productlist;

                      //  Utils ut = new Utils();
                        dt = Utils.ToDataTable(dc, rsthisperiod);

                        this.dataGridView1.DataSource = dt;


                    }

                }

                #endregion


                #region  // IF NULL   tbl_CustomerGroup
                if (tblnamesub == "tbl_CustomerGroup")
                {

                    if (source1.Count == 0)

                    {

                        //       MessageBox.Show("ok !!!!!!!!");
                        string connection_string = Utils.getConnectionstr();
                        //      UpdateDatagridview
                        System.Data.DataTable dt = new System.Data.DataTable();
                        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                        var rsthisperiod = from tbl_CustomerGroup in dc.tbl_CustomerGroups
                                           select tbl_CustomerGroup;

                     //   Utils ut = new Utils();
                        dt = Utils.ToDataTable(dc, rsthisperiod);

                        this.dataGridView1.DataSource = dt;


                    }

                }

                #endregion

                dataGridView1.DataSource = null;
                dataGridView2.Update();
                dataGridView1.Update();


            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bt_detletedsetlectmain_Click(object sender, EventArgs e)
        {
            var select = dataGridView2.SelectedRows;

            foreach (var item in select)
            {
                DataGridViewRow select2 = (DataGridViewRow)item;
                if (!select2.IsNewRow)
                {

                    //  select2.ind

                    var gridviewid = int.Parse(dataGridView2.Rows[select2.Index].Cells[IDsub].Value.ToString());


                    var slqtext = "delete  from  " + tblnamemain + " where " + IDmain + " = " + gridviewid;
                    try
                    {
                        db.ExecuteQuery(Typeofftable, slqtext);
                    }
                    catch (Exception)
                    {


                        //  /     //   throw;
                    }



                    this.dataGridView2.Rows.Remove(select2);
                    db.SubmitChanges();
                }

            }

            dataGridView2.Refresh();
            //      dataGridView1.UserDeletedRow;

            //   dataGridView1.RowsRemoved();





            MessageBox.Show("Data deleted done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        //private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //if user clicked Shift+Ins or Ctrl+V (paste from clipboard)

        //    if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))

        //    {

        //        //  source1.EndEdit();

        //        //     db.SubmitChanges();




        //        char[] rowSplitter = { '\r', '\n' };

        //        char[] columnSplitter = { '\t' };

        //        //get the text from clipboard

        //        IDataObject dataInClipboard = Clipboard.GetDataObject();

        //        string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);

        //        //split it into lines

        //        string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);

        //        //get the row and column of selected cell in grid

        //        int r = dataGridView1.SelectedCells[0].RowIndex;

        //        int c = dataGridView1.SelectedCells[0].ColumnIndex;

        //        //add rows into grid to fit clipboard lines

        //        if (dataGridView1.Rows.Count < (r + rowsInClipboard.Length))

        //        {

        //            ////   uodate trước đã

        //            //source1.EndEdit();

        //            //db.SubmitChanges();

        //            ////// view lại
        //            ////string sql3 = "select *  from  " + tblnamesub; // EXCEPT (" + IDsub + ") 
        //            //var rge = db.ExecuteQuery(Typeofftable, sql3);
        //            //source1.DataSource = rge;
        //            //this.dataGridView1.DataSource = source1;

        //            //uupdate news row trước đã


        //            for (int i = 0; i < r + rowsInClipboard.Length - dataGridView1.Rows.Count + 1; i++)
        //            {

        //                //    #region //   // add new row in datagridvidw by inserinto data base black data
        //                //    string stringfield = "";
        //                //    string stringvalue = "";

        //                //    //   int idculum = this.dataGridView1.ColumnCount;

        //                //    //   for (int idculumid = 0; idculumid < idculum - 1; idculumid++)
        //                //    //    {
        //                //    var colheadertext = this.dataGridView1.Columns[0].HeaderText;


        //                //    var valueid = dataGridView1.Rows[0].Cells[colheadertext].Value;

        //                //    if (valueid != null && colheadertext != IDsub)
        //                //    {

        //                //        var IDType = dataGridView1.Rows[0].Cells[colheadertext].ValueType;

        //                //        if (colheadertext.Contains("_"))
        //                //        {
        //                //            colheadertext = colheadertext.Replace("_", " ");
        //                //            string temp = "[" + colheadertext + "]";
        //                //            colheadertext = temp;
        //                //        }


        //                //        if (IDType.ToString().Contains("String"))
        //                //        {

        //                //            valueid = "'" + " " + "'";
        //                //        }
        //                //        else
        //                //        {
        //                //            if (IDType.ToString().Contains("Date"))
        //                //            {

        //                //                valueid = "'" + "" + "'";
        //                //            }
        //                //            else
        //                //            {
        //                //                valueid = "0";
        //                //            }
        //                //        }

        //                //        if (stringvalue != "")
        //                //        {

        //                //            stringvalue = stringvalue + "," + valueid;
        //                //            stringfield = stringfield + "," + colheadertext;

        //                //        }
        //                //        else
        //                //        {
        //                //            stringvalue = stringvalue + valueid;

        //                //            stringfield = stringfield + colheadertext;

        //                //        }



        //                //    }






        //                //    string StrQuery = "INSERT INTO " + tblnamesub + " ( " + stringfield + " ) VALUES (" + stringvalue + ")"; // + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ", " + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ");";
        //                //    try
        //                //    {


        //                //        var results3 = db.ExecuteQuery(Typeofftable, StrQuery);
        //                //    }
        //                //    catch //(Exception)
        //                //    {

        //                //        //   throw;
        //                //    }


        //                //}


        //                //#endregion//


        //                //    }


        //                //string slqtext = "select *  from  " + tblnamesub; // EXCEPT (" + IDsub + ") 


        //                //var results2 = db.ExecuteQuery(Typeofftable, slqtext);

        //                //source1.DataSource = results2;
        //                //dataGridView1.Refresh();

        //                // loop through the lines, split them into cells and place the values in the corresponding cell.

        //                for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)

        //                {

        //                    //split row into cell values

        //                    string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);

        //                    //cycle through cell values

        //                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)

        //                    {

        //                        //assign cell value, only if it within columns of the grid

        //                        if (dataGridView1.ColumnCount - 1 >= c + iCol)

        //                        {

        //                            dataGridView1.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];


        //                        }

        //                    }

        //                }

        //            }
        //        }

        //    }
        //    }
        //  customerBegibalancelist


        private void Updatechange_Click_1(object sender, EventArgs e)
        {




        }

        private void bt_detletedsetlectmain_Click_1(object sender, EventArgs e)
        {

            var select = dataGridView2.SelectedRows;

            foreach (var item in select)
            {
                DataGridViewRow select2 = (DataGridViewRow)item;
                if (!select2.IsNewRow)
                {

                    //  select2.ind

                    var gridviewid = int.Parse(dataGridView2.Rows[select2.Index].Cells[IDsub].Value.ToString());


                    var slqtext = "delete  from  " + tblnamemain + " where " + IDmain + " = " + gridviewid;
                    try
                    {
                        db.ExecuteQuery(Typeofftable, slqtext);
                    }
                    catch (Exception)
                    {


                        //  /     //   throw;
                    }



                    this.dataGridView2.Rows.Remove(select2);
                    db.SubmitChanges();
                }

            }

            //    dataGridView2.Refresh();


            MessageBox.Show("Data deleted done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);




        }

        private void Bt_uploadbegin_Click(object sender, EventArgs e)
        {

            customerinput_ctrl md = new customerinput_ctrl();
            string connection_string = Utils.getConnectionstr();

            md.customerBegibalancelist();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            var rs = from tblFBL5beginbalace in db.tblFBL5beginbalaces

                     select tblFBL5beginbalace;

            this.dataGridView1.DataSource = rs;
            this.db = db;

            //    this.rs = rs;













        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.tblnamesub == "tbl_ProductlistTMP")
            {
                var rs = from tbl_ProductlistTMP in db.tbl_ProductlistTMPs
                         select tbl_ProductlistTMP;
                this.rs = rs;

            }

            if (this.tblnamesub == "tblCustomerTmp")
            {
                var rs = from tblCustomerTmp in db.tblCustomerTmps
                         select tblCustomerTmp;
                this.rs = rs;

            }

            if (this.tblnamesub == "tblFBL5beginbalaceTemp")
            {
                var rs = from tblFBL5beginbalaceTemp in db.tblFBL5beginbalaceTemps
                         select tblFBL5beginbalaceTemp;
                this.rs = rs;

            }

            if (this.tblnamesub == "tbl_CustomerGroupTemp")
            {
                var rs = from tbl_CustomerGroupTemp in db.tbl_CustomerGroupTemps
                         select tbl_CustomerGroupTemp;
                this.rs = rs;

            }


            if (this.tblnamesub == "tbl_Comboundtemp")
            {
                var rs = from tbl_Comboundtemp in db.tbl_Comboundtemps
                         select tbl_Comboundtemp;
                this.rs = rs;

            }
            if (this.tblnamesub == "tblCustomer")
            {
                var rs = from tblCustomer in db.tblCustomers
                         select tblCustomer;
                this.rs = rs;

            }

            if (this.tblnamesub == "tbl_Productlist")
            {
                var rs = from tbl_Productlist in db.tbl_Productlists
                         select tbl_Productlist;
                this.rs = rs;

            }
            if (this.tblnamesub == "tblFBL5beginbalace")
            {
                var rs = from tblFBL5beginbalace in db.tblFBL5beginbalaces
                         select tblFBL5beginbalace;
                this.rs = rs;

            }

            if (this.tblnamesub == "tblFBL5N")
            {
                var rs = from tblFBL5N in db.tblFBL5Ns
                         select tblFBL5N;
                this.rs = rs;

            }

            if (this.tblnamesub == "tblEDLP")
            {
                var rs = from tblEDLP in db.tblEDLPs
                         select tblEDLP;
                this.rs = rs;

            }

            if (this.tblnamesub == "tblVat")
            {
                var rs = from tblVat in db.tblVats
                         select tblVat;
                this.rs = rs;

            }

            if (this.tblnamesub == "tbl_Remark")
            {
                var rs = from tbl_Remark in db.tbl_Remarks
                         select tbl_Remark;
                this.rs = rs;

            }
            if (this.tblnamesub == "tbl_FreGlass")
            {
                var rs = from tbl_FreGlass in db.tbl_FreGlasses
                         select tbl_FreGlass;
                this.rs = rs;

            }





            if (this.rs != null)
            {
                Control_ac ctrex = new Control_ac();


                ctrex.exportExceldatagridtofile(this.rs, this.db, this.Text);
            }
            else
            {


            }



        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (lbsub == "Update Customer make reports !" && e.KeyCode == Keys.F3)
            //{





            //    FormCollection fc = System.Windows.Forms.Application.OpenForms;

            //    bool kq = false;
            //    foreach (Form frm in fc)
            //    {
            //        if (frm.Text == "Seachcode")
            //        {
            //            kq = true;
            //            frm.Focus();

            //        }
            //    }

            //    if (!kq)
            //    {
            //        Seachcode sheaching = new Seachcode(this, "tblCustomered");
            //        sheaching.Show();
            //    }
            //}
            //}
        }
    }
}
