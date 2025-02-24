﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Luckynumber.Control;
using Luckynumber.shared;
using System.Globalization;
using System.Threading;
using Luckynumber.Model;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Luckynumber.View
{

    //   public static DataGridView dataGridView2;// = new DataGridView();

    public partial class Viewtable : Form
    {


        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }


        public IQueryable rs;
        LinqtoSQLDataContext db;

        public List<ComboboxItem> datacolecttionselect;//{ get; private set; }
                                                       //1. Định nghĩa 1 delegate
        public void showwait()
        {
            View.Caculating wat = new View.Caculating();

            wat.ShowDialog();


        }


        class datashowwait
        {

            public View.Caculating wat { get; set; }


        }


        class datatoExport
        {
            public DataGridView dataGrid1 { get; set; }

        }


        public void sumtitleGrid(object inptgridobjiec)
        {

            datatoExport dat = (datatoExport)inptgridobjiec;
            DataGridView dataGrid1 = dat.dataGrid1;


            double tongamount = 0;
            double tongdeposit = 0;
            double fullGoodamount = 0;
            double sumempty = 0;
            double paymentamount = 0;
            try
            {


                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    if (dataGridView1.Rows[i].Cells["FBL5N_amount"].Value != null && Utils.IsValidnumber(dataGridView1.Rows[i].Cells["FBL5N_amount"].Value.ToString()))
                    {

                        tongamount += double.Parse((dataGridView1.Rows[i].Cells["FBL5N_amount"].Value.ToString()));
                    }
                    if (dataGridView1.Rows[i].Cells["Payment_amount"].Value != null && Utils.IsValidnumber(dataGridView1.Rows[i].Cells["Payment_amount"].Value.ToString()))
                    {

                        paymentamount += double.Parse((dataGridView1.Rows[i].Cells["Payment_amount"].Value.ToString()));
                    }

                    if (dataGridView1.Rows[i].Cells["Deposit_amount"].Value != null && Utils.IsValidnumber(dataGridView1.Rows[i].Cells["Deposit_amount"].Value.ToString()))
                    {
                        tongdeposit += double.Parse(dataGridView1.Rows[i].Cells["Deposit_amount"].Value.ToString());
                    }

                    if (dataGridView1.Rows[i].Cells["Empty_Amount"].Value != null && Utils.IsValidnumber(dataGridView1.Rows[i].Cells["Empty_Amount"].Value.ToString()))
                    {
                        sumempty += double.Parse(dataGridView1.Rows[i].Cells["Empty_Amount"].Value.ToString());

                    }


                    if (dataGridView1.Rows[i].Cells["Fullgood_amount"].Value != null && Utils.IsValidnumber(dataGridView1.Rows[i].Cells["Fullgood_amount"].Value.ToString()))
                    {
                        fullGoodamount += double.Parse(dataGridView1.Rows[i].Cells["Fullgood_amount"].Value.ToString());

                    }

                }


                this.lb_tongamount.Invoke(new UpdateTextCallback(this.UpdateText),
                                             new object[] { tongamount.ToString(), tongdeposit.ToString(), fullGoodamount.ToString(), sumempty.ToString(), paymentamount.ToString() });


                this.lb_tongdeposit.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { tongamount.ToString(), tongdeposit.ToString(), fullGoodamount.ToString(), sumempty.ToString(), paymentamount.ToString() });



                this.lb_unmaching.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { tongamount.ToString(), tongdeposit.ToString(), fullGoodamount.ToString(), sumempty.ToString(), paymentamount.ToString() });


                this.lb_sumempty.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { tongamount.ToString(), tongdeposit.ToString(), fullGoodamount.ToString(), sumempty.ToString(), paymentamount.ToString() });


                this.lbpayment.Invoke(new UpdateTextCallback(this.UpdateText),
                                                 new object[] { tongamount.ToString(), tongdeposit.ToString(), fullGoodamount.ToString(), sumempty.ToString(), paymentamount.ToString() });

                //   MyGetData( tongamount,  tongdeposit,  fullGoodamount,  sumempty);
            }
            catch (Exception)
            {
                Thread.CurrentThread.Abort();
                // throw;
            }




        }
        //   string tongamoun , double tongdeposit, double fullGoodamount, double sumempty
        private void UpdateText(string tongamount, string tongdeposit, string fullGoodamount, string sumempty, string paymentamount)
        {


            this.lb_tongamount.Text = double.Parse(tongamount).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_tongdeposit.Text = double.Parse(tongdeposit).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_unmaching.Text = double.Parse(fullGoodamount).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_sumempty.Text = double.Parse(sumempty).ToString("#,#", CultureInfo.InvariantCulture);
            this.lbpayment.Text = double.Parse(paymentamount).ToString("#,#", CultureInfo.InvariantCulture);

            this.Status.Text = "DONE";
            //  this.dataGridView1.Refresh();
        }

        public delegate void UpdateTextCallback(string tongamoun, string tongdeposit, string fullGoodamount, string sumempty, string paymentamount);
        //    In your thread, you can call the Invoke method on m_TextBox, passing the delegate to call, as well as the parameters.





        private void getData(List<ComboboxItem> dataCollection)
        {



            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //var rs = from tbl_Comboundtemp in dc.tbl_Comboundtemps
            //         group tbl_Comboundtemp by tbl_Comboundtemp.Code into grthis
            //         select new

            //         {
            //             Code = grthis.Key,
            //             name = grthis.Select(g => g.name).FirstOrDefault(),



            //         };


            // string drowdowvalue = "";
            //foreach (var item in rs)
            //{


            //    drowdowvalue = item.Code.ToString() + " " + item.name;


            //    ComboboxItem itemcb = new ComboboxItem();
            //    itemcb.Text = drowdowvalue;
            //    itemcb.Value = item.Code.ToString();



            //    dataCollection.Add(itemcb);
            //}



        }

        private void getDatagr(List<ComboboxItem> dataCollection2)
        {




            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //var rs = from tbl_Comboundtemp in dc.tbl_Comboundtemps
            //         group tbl_Comboundtemp by tbl_Comboundtemp.codeGroup into grthis
            //         select new

            //         {
            //             codeGroup = grthis.Key,
            //             name = grthis.Select(g => g.name).FirstOrDefault(),



            //         }




            //         ;

            //string drowdowvalue = "";
            //foreach (var item in rs)
            //{


            //    drowdowvalue = item.codeGroup.ToString() + " " + item.name;


            //    ComboboxItem itemcb = new ComboboxItem();
            //    itemcb.Text = drowdowvalue;
            //    itemcb.Value = item.codeGroup.ToString();



            //    dataCollection2.Add(itemcb);
            //}



        }



        public int viewcode { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }


        public Viewtable(IQueryable rs, LinqtoSQLDataContext db, string fornname, int viewcode, DateTime fromdate, DateTime todate)
        {
            InitializeComponent();

            this.db = db;
            this.fromdate = fromdate;
            this.todate = todate;
            this.viewcode = viewcode;
            this.rs = rs;
            this.lb_seach.Text = "F3 TÌM KIẾM";

          //  this.bt_sendinggroup.Visible = false;
            this.lb_seach.Visible = false;
            this.Pl_endview.Visible = false;

            btCaculmake.Visible = false;

            this.Text = fornname;
         //   this.btAutoUpdatedepo.Visible = false;

        //    this.btSendlistUpdate.Visible = false;
         //   this.bt_listunsend.Visible = false;
        //    btpostclear.Visible = false;
            lb_seach.Visible = false;

            


            this.dataGridView1.DataSource = rs;
            if (fornname == "DANH SÁCH ĐƠN HÀNG TRẢ THIẾU KHUYẾN MẠI")
            {
                this.dataGridView1.Columns["Số_lượng_được_KM"].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns["Số_lượng_KM_trả_thực_tế"].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns["Trả_thiếu"].DefaultCellStyle.Format = "N2";
            }

            if (fornname == "DANH SÁCH ĐƠN HÀNG TRẢ THỪA KHUYẾN MẠI")
            {

                this.dataGridView1.Columns["Số_lượng_được_KM"].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns["Số_lượng_KM_trả_thực_tế"].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns["Trả_thừa"].DefaultCellStyle.Format = "N2";
            }

            if (fornname == "DANH SÁCH ĐƠN HÀNG KHUYẾN MẠI CHƯA PHÂN LOẠI ĐƯỢC MÃ CTKM ")
            {
                btCaculmake.Visible = true;
            }

            if (fornname == "BÁO CÁO CTKM")
            {

                this.dataGridView1.Columns["Số_lượng_hàng_mua"].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns["Số_lượng_được_trả"].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns["Số_lượng_đã_trả"].DefaultCellStyle.Format = "N2";
            }

            lb_totalrecord.Text = dataGridView1.RowCount.ToString();
        }

        private void bt_exporttoex_Click(object sender, EventArgs e)
        {



            Control.Control ctrex = new Control.Control();


            ctrex.exportExceldatagridtofile(this.rs, this.db, this.Text);


        }

        private void Viewtable_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string connection_string = Utils.getConnectionstr();
            //LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);



            //if (this.Text == "Update Customer make reports !" || this.Text == "LIST CUSTOMER MAKE REPORTS")
            //{



            //    if (this.dataGridView1.CurrentRow.Index >= 0 && this.dataGridView1.CurrentRow != null && dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["Reportsend"].Value != null && dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["Reportsend"].Value.ToString() != "")
            //    {
            //        dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["Reportsend"].Value = !(bool)dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["Reportsend"].Value;
            //    }
            //    else
            //    {
            //        dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["Reportsend"].Value = true;
            //    }





            //}


            // update sending status


            if (this.Text == "BẢNG TÔNG HỢP BÁO CÁO THEO CODE KHÁCH HÀNG")   //f11
            {

                //  this.Text = "iNPUT DEPOSIT AMOUNTT !";
                string colheadertext = this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].HeaderText;
                double codeandgroup = (double)this.dataGridView1.CurrentRow.Cells["Account"].Value;




            }



            if (this.viewcode == 12)   //12 là update freegalses view edit
            {

                //  this.Text = "iNPUT DEPOSIT AMOUNTT !";
                string colheadertext = this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].HeaderText.Trim();
                double code = (double)this.dataGridView1.CurrentRow.Cells["Account"].Value;
                int id = (int)this.dataGridView1.CurrentRow.Cells["id"].Value;


                if (colheadertext == "Deposit_amount")
                {
                    //  MessageBox.Show("ok");

                    valueinput valueinput = new valueinput("Plese input new  Deposit amount value: ");

                    valueinput.ShowDialog();
                    string newvalue = valueinput.valuetext;
                    string headfield = valueinput.field;
                    bool kq = valueinput.kq;

                    if (kq)
                    {

                        if (Utils.IsValidnumber(newvalue))
                        {
                            if ((double.Parse(newvalue) % 38000) != 0)
                            {

                                MessageBox.Show("Số tiền update vào phải chia hết cho 38000 VND, please recheck !");
                                return;

                            }
                            dataGridView1.ReadOnly = false;
                            dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["Deposit_amount"].Value = newvalue;
                            dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["Ketvothuong"].Value = (double.Parse(newvalue) / 38000);

                            dataGridView1.ReadOnly = true;


                            //var rs6 = from tblFBL5Nnew in db.tblFBL5Nnews
                            //          where tblFBL5Nnew.id == id // && tblFBL5NthisperiodSum.Region == region
                            //          select tblFBL5Nnew;

                            //foreach (var item in rs6)
                            //{
                            //    item.Deposit_amount = double.Parse(newvalue);
                            //    item.Ketvothuong = int.Parse((double.Parse(newvalue) / 38000).ToString());
                            //    item.userupdate = Utils.getusername();
                            //}

                            //db.SubmitChanges();



                        }
                    }


                }



                if (colheadertext == "Ketvothuong")
                {
                    //  MessageBox.Show("ok");

                    valueinput valueinput = new valueinput("Plese input new số lượng két vỏ thường mới: ");

                    valueinput.ShowDialog();
                    string newvalue = valueinput.valuetext;
                    string headfield = valueinput.field;
                    bool kq = valueinput.kq;

                    if (kq)
                    {

                        if ((double.Parse(newvalue) % 1) != 0)
                        {

                            MessageBox.Show("Số vỏ  phải là số nguyên, please recheck !");
                            return;

                        }
                        if (Utils.IsValidnumber(newvalue))
                        {
                            dataGridView1.ReadOnly = false;
                            dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["Deposit_amount"].Value = (double.Parse(newvalue) * 38000);
                            dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["Ketvothuong"].Value = newvalue;


                            dataGridView1.ReadOnly = true;



                            //var rs6 = from tblFBL5Nnew in db.tblFBL5Nnews
                            //          where tblFBL5Nnew.id == id // && tblFBL5NthisperiodSum.Region == region
                            //          select tblFBL5Nnew;

                            //foreach (var item in rs6)
                            //{
                            //    item.Deposit_amount = (double.Parse(newvalue) * 38000);
                            //    item.Ketvothuong = int.Parse(newvalue);
                            //    item.userupdate = Utils.getusername();
                            //}

                            //db.SubmitChanges();





                        }
                    }

                }
                if (colheadertext == "Remark")
                {
                    //  MessageBox.Show("ok");

                    valueinput valueinput = new valueinput("Plese input new remark ");

                    valueinput.ShowDialog();
                    string newvalue = valueinput.valuetext;
                    string headfield = valueinput.field;
                    bool kq = valueinput.kq;

                    if (kq)
                    {

                        if (newvalue != "")
                        {
                            dataGridView1.ReadOnly = false;
                            dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["Remark"].Value = newvalue;
                            dataGridView1.ReadOnly = true;


                            //var rs6 = from tblFBL5Nnew in db.tblFBL5Nnews
                            //          where tblFBL5Nnew.id == id // && tblFBL5NthisperiodSum.Region == region
                            //          select tblFBL5Nnew;

                            //foreach (var item in rs6)
                            //{
                            //    item.Remark = newvalue.Trim();
                            //    item.userupdate = Utils.getusername();
                            //}

                            //db.SubmitChanges();







                        }
                    }

                }


            }



        }

   
        public void REloadTotalbycodeFbl5new(string codeAccount)
        {
            string line2 = this.Text;
            string[] parts = line2.Split('-');
            // "VIEWLIST DATABASE UPLOADED ON SYSYEM FROM-" + fromdate + " -TO- " + todate

            //        DateTime fromdate;
            //        DateTime todate;

            this.viewcode = viewcode;
            if (parts.Count() >= 4)
            {

                string tableviewtitle = parts[0].Trim();
                //  fromdate = Utils.chageExceldatetoData(parts[1].Trim());
                //todate = Utils.chageExceldatetoData(parts[3].Trim()); //arts[2].Trim();
                this.Text = "SUM DATABASE UPLOADED ON SYSYEM FROM-" + fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year + " REPORTS";
                //   fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year);


                this.lb_seach.Text = "F5-DETAIL/ F12-SUM/ F3-SEACH";

                //#region // show  rieng fileterr all
                //System.Data.DataTable dt = new System.Data.DataTable();



                //string connection_string = Utils.getConnectionstr();
                //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                //var rsthisperiod = from tblFBL5Nnew in dc.tblFBL5Nnews
                //                   where tblFBL5Nnew.Posting_Date >= fromdate && tblFBL5Nnew.Posting_Date <= todate && ((int)tblFBL5Nnew.Account).ToString().Contains(codeAccount)
                //                   group tblFBL5Nnew by tblFBL5Nnew.Account into g
                //                   orderby g.Key
                //                   select new


                //                   {
                //                       //    codeGroup = g.Select(gg=>gg.codeGroup).FirstOrDefault(),
                //                       Account = g.Key,

                //                       Customer_Name = g.Select(gg => gg.name).FirstOrDefault(),//    tblFBL5Nnewthisperiod.name,


                //                       FBL5N_amount = g.Sum(gg => gg.Adjusted_amount.GetValueOrDefault(0)) + g.Sum(gg => gg.Fullgood_amount.GetValueOrDefault(0)) + g.Sum(gg => gg.Payment_amount.GetValueOrDefault(0)) + g.Sum(gg => gg.Deposit_amount.GetValueOrDefault(0)),

                //                       Payment_amount = g.Sum(gg => gg.Payment_amount),
                //                       Adj_amount = g.Sum(gg => gg.Adjusted_amount),//               tblFBL5Nnewthisperiod.Adjusted_amount,

                //                       //         tblFBL5Nnewthisperiod.Invoice_Amount,
                //                       Fullgood_amount = g.Sum(gg => gg.Fullgood_amount), //   tblFBL5Nnewthisperiod.Fullgood_amount,
                //                       Empty_Amount = g.Sum(gg => gg.Empty_Amount), //   tblFBL5Nnewthisperiod.Empty_Amount,
                //                       Deposit_amount = g.Sum(gg => gg.Deposit_amount),//      tblFBL5Nnewthisperiod.Deposit_amount,


                //                       Binhpmicc02 = g.Sum(gg => gg.Binhpmicc02),//        tblFBL5Nnewthisperiod.Binhpmicc02,
                //                       binhpmix9l = g.Sum(gg => gg.binhpmix9l),//     tblFBL5Nnewthisperiod.binhpmix9l,
                //                       Chaivothuong = g.Sum(gg => gg.Chaivothuong),//      tblFBL5Nnewthisperiod.Chaivothuong,
                //                       Chaivo1lit = g.Sum(gg => gg.Chaivo1lit),//     tblFBL5Nnewthisperiod.Chaivo1lit,
                //                       joy20l = g.Sum(gg => gg.joy20l),// tblFBL5Nnewthisperiod.joy20l,
                //                       Ketnhua1lit = g.Sum(gg => gg.Ketnhua1lit),//  tblFBL5Nnewthisperiod.Ketnhua1lit,
                //                       Ketnhuathuong = g.Sum(gg => gg.Ketnhuathuong),//   tblFBL5Nnewthisperiod.Ketnhuathuong,
                //                       Ketvolit = g.Sum(gg => gg.Ketvolit),//    tblFBL5Nnewthisperiod.Ketvolit,
                //                       Ketvothuong = g.Sum(gg => gg.Ketvothuong),//     tblFBL5Nnewthisperiod.Ketvothuong,
                //                       paletnhua = g.Sum(gg => gg.paletnhua),//     tblFBL5Nnewthisperiod.paletnhua,
                //                       palletgo = g.Sum(gg => gg.palletgo),//     tblFBL5Nnewthisperiod.palletgo,


                //                   };
                //if (rsthisperiod.Count() > 0)
                //{
                //    //  Utils ut = new Utils();
                //    dt = Utils.ToDataTable(dc, rsthisperiod);

                //    this.dataGridView1.DataSource = dt;


                //    this.db = dc;

                //    this.rs = rsthisperiod;

                //    dc = new LinqtoSQLDataContext(connection_string);
                //    this.Dtgridview = dataGridView1;
                //    this.Status.Text = "Caculating ...";
                //    Thread tt1 = new Thread(sumtitleGrid);

                //    tt1.IsBackground = true;
                //    tt1.Start(new datatoExport() { dataGrid1 = dataGridView1 });
                //    this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


                //    this.dataGridView1.Columns["Account"].DisplayIndex = 0;
                //    this.dataGridView1.Columns["Customer_Name"].DisplayIndex = 1;
                //    this.dataGridView1.Columns["Payment_amount"].DisplayIndex = 2;
                //    this.dataGridView1.Columns["Adj_amount"].DisplayIndex = 3;
                //    this.dataGridView1.Columns["Fullgood_amount"].DisplayIndex = 4;

                //    this.dataGridView1.Columns["Empty_Amount"].DisplayIndex = 5;
                //    this.dataGridView1.Columns["Deposit_amount"].DisplayIndex = 6;


                //}

                //#endregion // show all





            }







            //  throw new NotImplementedException();
        }


        private void bt_listunsend_Click(object sender, EventArgs e)
        {


            customerinput_ctrl md = new customerinput_ctrl();


            md.customerinputunsendlist();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //var rs = from tblCustomer in db.tblCustomers
            //         where tblCustomer.Reportsend == true
            //         select tblCustomer;

            //this.dataGridView1.DataSource = rs;
            //this.db = db;

            //this.rs = rs;











        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lb_sumempty_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            customerinput_ctrl md = new customerinput_ctrl();


            md.customerinputsendlist();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //var rs = from tblCustomer in db.tblCustomers
            //         where tblCustomer.Reportsend == true
            //         select tblCustomer;

            //this.dataGridView1.DataSource = rs;
            //this.db = db;

            //this.rs = rs;

        }
        void Control_KeyPress(object sender, KeyEventArgs e)
        {


            //#region CHAT TIEU DE BANG
            //string line = this.Text;
            //string[] parts = line.Split('-');
            //// "VIEWLIST DATABASE UPLOADED ON SYSYEM FROM-" + fromdate + " -TO- " + todate

            ////   DateTime fromdate;
            ////     DateTime todate;
            //if (parts.Count() >= 4 && e.KeyCode == Keys.F12)

            //{
            //    string tableviewtitle = parts[0].Trim();
            //    //    fromdate = Utils.chageExceldatetoData(parts[1].Trim());
            //    //      todate = Utils.chageExceldatetoData(parts[3].Trim()); //arts[2].Trim();
            //    this.Text = "DATABASE UPLOADED ON SYSYEM FROM-" + fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year + " REPORTS";
            //    //   fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year);


            //    this.lb_seach.Text = "F5-DETAIL/ F12-SUM/ F3-SEACH";
            //    #region // show  rieng fileterr all
            //    System.Data.DataTable dt = new System.Data.DataTable();



            //    string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //    var rsthisperiod = from tblFBL5Nnew in dc.tblFBL5Nnews
            //                       where tblFBL5Nnew.Posting_Date >= fromdate && tblFBL5Nnew.Posting_Date <= todate
            //                       group tblFBL5Nnew by tblFBL5Nnew.Account into g
            //                       orderby g.Key
            //                       select new


            //                       {
            //                           //    codeGroup = g.Select(gg=>gg.codeGroup).FirstOrDefault(),
            //                           Account = g.Key,

            //                           Customer_Name = g.Select(gg => gg.name).FirstOrDefault(),//    tblFBL5Nnewthisperiod.name,


            //                           FBL5N_amount = g.Sum(gg => gg.Adjusted_amount.GetValueOrDefault(0)) + g.Sum(gg => gg.Fullgood_amount.GetValueOrDefault(0)) + g.Sum(gg => gg.Payment_amount.GetValueOrDefault(0)) + g.Sum(gg => gg.Deposit_amount.GetValueOrDefault(0)),

            //                           Payment_amount = g.Sum(gg => gg.Payment_amount),
            //                           Adj_amount = g.Sum(gg => gg.Adjusted_amount),//               tblFBL5Nnewthisperiod.Adjusted_amount,

            //                           //         tblFBL5Nnewthisperiod.Invoice_Amount,
            //                           Fullgood_amount = g.Sum(gg => gg.Fullgood_amount), //   tblFBL5Nnewthisperiod.Fullgood_amount,
            //                           Empty_Amount = g.Sum(gg => gg.Empty_Amount), //   tblFBL5Nnewthisperiod.Empty_Amount,
            //                           Deposit_amount = g.Sum(gg => gg.Deposit_amount),//      tblFBL5Nnewthisperiod.Deposit_amount,


            //                           //                                       Severity Code    Description Project File    Line
            //                           //Error   CS1503  Argument 2: cannot convert from 'bool' to 'System.Linq.Expressions.Expression<System.Func<bool?, bool>>'    Luckynumber C:\Users\TRUONG\Desktop\Developing product\ARdevelop\Luckynumber\View\Viewtable.cs 2945


            //                           Binhpmicc02 = g.Sum(gg => gg.Binhpmicc02),//        tblFBL5Nnewthisperiod.Binhpmicc02,
            //                           binhpmix9l = g.Sum(gg => gg.binhpmix9l),//     tblFBL5Nnewthisperiod.binhpmix9l,
            //                           Chaivothuong = g.Sum(gg => gg.Chaivothuong),//      tblFBL5Nnewthisperiod.Chaivothuong,
            //                           Chaivo1lit = g.Sum(gg => gg.Chaivo1lit),//     tblFBL5Nnewthisperiod.Chaivo1lit,
            //                           joy20l = g.Sum(gg => gg.joy20l),// tblFBL5Nnewthisperiod.joy20l,
            //                           Ketnhua1lit = g.Sum(gg => gg.Ketnhua1lit),//  tblFBL5Nnewthisperiod.Ketnhua1lit,
            //                           Ketnhuathuong = g.Sum(gg => gg.Ketnhuathuong),//   tblFBL5Nnewthisperiod.Ketnhuathuong,
            //                           Ketvolit = g.Sum(gg => gg.Ketvolit),//    tblFBL5Nnewthisperiod.Ketvolit,
            //                           Ketvothuong = g.Sum(gg => gg.Ketvothuong),//     tblFBL5Nnewthisperiod.Ketvothuong,
            //                           paletnhua = g.Sum(gg => gg.paletnhua),//     tblFBL5Nnewthisperiod.paletnhua,
            //                           palletgo = g.Sum(gg => gg.palletgo),//     tblFBL5Nnewthisperiod.palletgo,


            //                       };
            //    if (rsthisperiod.Count() > 0)
            //    {
            //        //  Utils ut = new Utils();
            //        dt = Utils.ToDataTable(dc, rsthisperiod);

            //        this.dataGridView1.DataSource = dt;


            //        this.db = dc;

            //        this.rs = rsthisperiod;

            //        dc = new LinqtoSQLDataContext(connection_string);
            //        this.Dtgridview = dataGridView1;
            //        this.Status.Text = "Caculating ...";
            //        Thread tt1 = new Thread(sumtitleGrid);

            //        tt1.IsBackground = true;
            //        tt1.Start(new datatoExport() { dataGrid1 = dataGridView1 });
            //        this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Format = "N0";
            //        this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Format = "N0";
            //        this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Format = "N0";
            //        this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Format = "N0";
            //        this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Format = "N0";
            //        this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Format = "N0";
            //        this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //        this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //        this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //        this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //        this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //        this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            //        this.dataGridView1.Columns["Account"].DisplayIndex = 0;
            //        this.dataGridView1.Columns["Customer_Name"].DisplayIndex = 1;
            //        this.dataGridView1.Columns["Payment_amount"].DisplayIndex = 2;
            //        this.dataGridView1.Columns["Adj_amount"].DisplayIndex = 3;
            //        this.dataGridView1.Columns["Fullgood_amount"].DisplayIndex = 4;

            //        this.dataGridView1.Columns["Empty_Amount"].DisplayIndex = 5;
            //        this.dataGridView1.Columns["Deposit_amount"].DisplayIndex = 6;


            //    }

            //    #endregion // show all








            //}
            //if (parts.Count() >= 4 && e.KeyCode == Keys.F5)// view detail
            ////if ((this.Text == "iNPUT DEPOSIT AMOUNTT !" || this.Text == "BẢNG TÔNG HỢP BÁO CÁO THEO CODE KHÁCH HÀNG VẢ REGION") && e.KeyCode == Keys.F12)
            ////{
            //{
            //    string tableviewtitle = parts[0].Trim();
            //    //     fromdate = Utils.chageExceldatetoData(parts[1].Trim());
            //    //      todate = Utils.chageExceldatetoData(parts[3].Trim()); //arts[2].Trim();
            //    this.Text = "DATABASE UPLOADED ON SYSYEM FROM-" + fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year + " DETAIL REPORTS";
            //    this.lb_seach.Text = "F5-DETAIL/ F12-SUM/ F3-SEACH";


            //    #region // show all
            //    System.Data.DataTable dt = new System.Data.DataTable();


            //    string connection_string = Utils.getConnectionstr();
            //    //      UpdateDatagridview

            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //    var rsthisperiod = from tblFBL5Nnew in dc.tblFBL5Nnews
            //                       where tblFBL5Nnew.Posting_Date >= fromdate && tblFBL5Nnew.Posting_Date <= todate
            //                       select new


            //                       {
            //                           tblFBL5Nnew.codeGroup,

            //                           //         check = tblFBL5Nnewthisperiod.Account.ToString(),
            //                           Sorg = tblFBL5Nnew.Business_Area,
            //                           tblFBL5Nnew.Account,
            //                           Customer_Name = tblFBL5Nnew.name,

            //                           //     tblFBL5Nnewthisperiod.COL_value,

            //                           tblFBL5Nnew.Posting_Date,
            //                           tblFBL5Nnew.Assignment,
            //                           tblFBL5Nnew.Document_Number,

            //                           FBL5N_amount = tblFBL5Nnew.Amount_in_local_currency,


            //                           tblFBL5Nnew.Payment_amount,
            //                           Adj_amount = tblFBL5Nnew.Adjusted_amount,

            //                           //    tblFBL5Nnewthisperiod.Invoice_Amount,
            //                           tblFBL5Nnew.Fullgood_amount,
            //                           tblFBL5Nnew.Empty_Amount,
            //                           tblFBL5Nnew.Deposit_amount,


            //                           Invoice_date = tblFBL5Nnew.Formula_invoice_date,
            //                           //       Invoice =   tblFBL5Nnewthisperiod.Invoice_Registration + " " + tblFBL5Nnewthisperiod.Invoice_Number,

            //                           tblFBL5Nnew.Invoice,
            //                           //    tblFBL5Nnewthisperiod.Vat_amount,
            //                           Type = tblFBL5Nnew.Document_Type,
            //                           tblFBL5Nnew.Binhpmicc02,
            //                           tblFBL5Nnew.binhpmix9l,
            //                           tblFBL5Nnew.Chaivothuong,
            //                           tblFBL5Nnew.Chaivo1lit,
            //                           tblFBL5Nnew.joy20l,
            //                           tblFBL5Nnew.Ketnhua1lit,
            //                           tblFBL5Nnew.Ketnhuathuong,
            //                           tblFBL5Nnew.Ketvolit,
            //                           tblFBL5Nnew.Ketvothuong,
            //                           tblFBL5Nnew.paletnhua,
            //                           tblFBL5Nnew.palletgo,
            //                           tblFBL5Nnew.userupdate,
            //                           tblFBL5Nnew.id,
            //                           //   tblFBL5Nnewthisperiod.Empty_Amount_Notmach,


            //                       };

            //    //     Utils ut = new Utils();
            //    dt = Utils.ToDataTable(dc, rsthisperiod);

            //    this.dataGridView1.DataSource = dt;


            //    this.db = dc;

            //    this.rs = rsthisperiod;

            //    dc = new LinqtoSQLDataContext(connection_string);
            //    this.Dtgridview = dataGridView1;
            //    this.Status.Text = "Caculating ...";


            //    //
            //    Thread tt1 = new Thread(sumtitleGrid);

            //    tt1.IsBackground = true;
            //    tt1.Start(new datatoExport() { dataGrid1 = dataGridView1 });

            //    this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //                                                                                                                        //      this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Format = "N0";
            //                                                                                                                        //      this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["codeGroup"].DisplayIndex = 1;
            //    this.dataGridView1.Columns["Sorg"].DisplayIndex = 0;
            //    this.dataGridView1.Columns["Account"].DisplayIndex = 2;
            //    this.dataGridView1.Columns["Customer_Name"].DisplayIndex = 3;
            //    this.dataGridView1.Columns["Document_Number"].DisplayIndex = 4;
            //    this.dataGridView1.Columns["Assignment"].DisplayIndex = 5;
            //    this.dataGridView1.Columns["Posting_Date"].DisplayIndex = 6;
            //    this.dataGridView1.Columns["Invoice_date"].DisplayIndex = 7;
            //    this.dataGridView1.Columns["Invoice"].DisplayIndex = 8;
            //    this.dataGridView1.Columns["Payment_amount"].DisplayIndex = 9;
            //    this.dataGridView1.Columns["Fullgood_amount"].DisplayIndex = 10;
            //    this.dataGridView1.Columns["Adj_amount"].DisplayIndex = 11;
            //    this.dataGridView1.Columns["Empty_Amount"].DisplayIndex = 12;
            //    this.dataGridView1.Columns["Deposit_amount"].DisplayIndex = 13;
            //    this.dataGridView1.Columns["FBL5N_amount"].DisplayIndex = 14;
            //    this.dataGridView1.Columns["Type"].DisplayIndex = 15;


            //    //   }
            //    #endregion // show all








            //}
            ////    Viewtable viewtbl = new Viewtable(rs2, dc, "VIEWLIST DATABASE UPLOADED ON SYSYEM FROM-" + fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year);


            ////        string st4 = parts[3].Trim();


            //// return connection_string;

            //#endregion


            //if (parts.Count() >= 4 && e.KeyCode == Keys.F3)// view detail
            ////if ((this.Text == "iNPUT DEPOSIT AMOUNTT !" || this.Text == "BẢNG TÔNG HỢP BÁO CÁO THEO CODE KHÁCH HÀNG VẢ REGION") && e.KeyCode == Keys.F12)
            ////{
            //{
            //    string tableviewtitle = parts[0].Trim();
            //    //    fromdate = Utils.chageExceldatetoData(parts[1].Trim());
            //    //    todate = Utils.chageExceldatetoData(parts[3].Trim()); //arts[2].Trim();
            //    this.Text = "DATABASE UPLOADED ON SYSYEM FROM-" + fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year + " REPORTS";
            //    this.lb_seach.Text = "F5-DETAIL/ F12-SUM/ F3-SEACH";



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
            //        Seachcode sheaching = new Seachcode(this, "fbl5nnew");
            //        sheaching.Show();
            //    }






            //     }

            //   "LETTER RETURN STATUS UPDATE"

            if (this.Text == "LETTER RETURN STATUS UPDATE" && e.KeyCode == Keys.F3)
            {


                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "Seachcode")
                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "letterreturn");
                    sheaching.Show();
                }






            }

            if (this.Text == "Update Customer make reports !" && e.KeyCode == Keys.F3)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "Seachcode")
                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "tblCustomer");
                    sheaching.Show();
                }







            }

            if (this.Text == "LIST BEGIN BALANCE !" && e.KeyCode == Keys.F3)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "Seachcode")
                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "beginbalance");
                    sheaching.Show();
                }







            }

            if (this.Text == "iNPUT DEPOSIT AMOUNTT !" && e.KeyCode == Keys.F3)
            {

                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "Seachcode")
                    {
                        kq = true;
                        frm.Focus();
                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "tblFBL5Nnewthisperiod");
                    //     form
                    sheaching.Show();
                }





            }

            // show bảng tổng
            // && this.statussum.Text == "Total record: "
            if (this.Text == "BẢNG TÔNG HỢP BÁO CÁO THEO CODE KHÁCH HÀNG" && e.KeyCode == Keys.F3)
            {

                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "Seachcode")
                    {
                        kq = true;
                        frm.Focus();
                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "tblbangtonghoptheocodekhachhangchung");
                    //     form
                    sheaching.Show();
                }




            }





            if (this.Text == "iNPUT DEPOSIT AMOUNTT !" && e.KeyCode == Keys.F11)
            {
                //  this.statussum.Text = "Data Sum";
                this.Text = "BẢNG TÔNG HỢP BÁO CÁO THEO CODE KHÁCH HÀNG";
                this.lb_seach.Text = "F5-DETAIL/ F11-SUM/ F3-SEACH/ CLICK ON REPORTSEND MAKE SEND OR NOT ";



                //  updatetblFBL5NTempRPtview

                //#region    updatetblFBL5NTempRPtview tinh tong va so du luon

                //SqlConnection conn2 = null;
                //SqlDataReader rdr1 = null;
                //string destConnString = Utils.getConnectionstr();
                //try
                //{

                //    conn2 = new SqlConnection(destConnString);
                //    conn2.Open();
                //    SqlCommand cmd1 = new SqlCommand("insertFbl5nthisfromFBL5nSumRpt", conn2);
                //    cmd1.CommandTimeout = 0;
                //    cmd1.CommandType = CommandType.StoredProcedure;
                //    //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

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
                ////    xóa trên tblFBL5Nnewthisperiod


                //#region // show  rieng fileterr all
                //System.Data.DataTable dt = new System.Data.DataTable();




                //string connection_string = Utils.getConnectionstr();
                //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //var rsthisperiod = from tblFBL5NthisperiodSum in dc.tblFBL5NthisperiodSums
                //                   orderby tblFBL5NthisperiodSum.Account
                //                   select new
                //                   {

                //                       #region  //  CUOI KY ----------------
                //                       Account = tblFBL5NthisperiodSum.Account,
                //                       Customer_Name = tblFBL5NthisperiodSum.Customer_Name,


                //                       FBL5N_amount = tblFBL5NthisperiodSum.FBL5N_amount.GetValueOrDefault(0),
                //                       Payment_amount = tblFBL5NthisperiodSum.Payment_amount.GetValueOrDefault(0),
                //                       Adj_amount = tblFBL5NthisperiodSum.Adj_amount.GetValueOrDefault(0),
                //                       Fullgood_amount = tblFBL5NthisperiodSum.Fullgood_amount.GetValueOrDefault(0),
                //                       RealBalance = tblFBL5NthisperiodSum.RealBalance.GetValueOrDefault(0),
                //                       tblFBL5NthisperiodSum.Reportsend,
                //                       Deposit_amount = tblFBL5NthisperiodSum.Deposit_amount.GetValueOrDefault(0),

                //                       Empty_Amount = tblFBL5NthisperiodSum.Empty_Amount.GetValueOrDefault(0),

                //                       Binhpmicc02 = tblFBL5NthisperiodSum.Binhpmicc02.GetValueOrDefault(0),
                //                       binhpmix9l = tblFBL5NthisperiodSum.binhpmix9l.GetValueOrDefault(0),
                //                       Chaivothuong = tblFBL5NthisperiodSum.Chaivothuong.GetValueOrDefault(0),
                //                       Chaivo1lit = tblFBL5NthisperiodSum.Chaivo1lit.GetValueOrDefault(0),
                //                       joy20l = tblFBL5NthisperiodSum.joy20l.GetValueOrDefault(0),


                //                       Ketnhua1lit = tblFBL5NthisperiodSum.Ketnhua1lit.GetValueOrDefault(0),

                //                       Ketnhuathuong = tblFBL5NthisperiodSum.Ketnhuathuong.GetValueOrDefault(0),
                //                       Ketvolit = tblFBL5NthisperiodSum.Ketvolit.GetValueOrDefault(0),

                //                       Ketvothuong = tblFBL5NthisperiodSum.Ketvothuong.GetValueOrDefault(0),

                //                       paletnhua = tblFBL5NthisperiodSum.paletnhua.GetValueOrDefault(0),

                //                       palletgo = tblFBL5NthisperiodSum.palletgo.GetValueOrDefault(0),
                //                       #endregion    //  CUOI KY ----------------


                //                       #region  //  pAHT SINH,
                //                       // Customer_Name = tblFBL5NthisperiodSum.Customer_Name,
                //                       //   FBL5N_amount = tblFBL5NthisperiodSum.FBL5N_amount,
                //                       Payment_amountps = tblFBL5NthisperiodSum.Payment_amountps.GetValueOrDefault(0),
                //                       Adj_amountps = tblFBL5NthisperiodSum.Adj_amountps.GetValueOrDefault(0),
                //                       Fullgood_amountps = tblFBL5NthisperiodSum.Fullgood_amountps.GetValueOrDefault(0),
                //                       FBL5N_amountps = tblFBL5NthisperiodSum.FBL5N_amountps.GetValueOrDefault(0),
                //                       Deposit_amountps = tblFBL5NthisperiodSum.Deposit_amountps.GetValueOrDefault(0),

                //                       Empty_Amountps = tblFBL5NthisperiodSum.Empty_Amountps.GetValueOrDefault(0),

                //                       Binhpmicc02ps = tblFBL5NthisperiodSum.Binhpmicc02ps.GetValueOrDefault(0),
                //                       binhpmix9lps = tblFBL5NthisperiodSum.binhpmix9lps.GetValueOrDefault(0),
                //                       Chaivothuongps = tblFBL5NthisperiodSum.Chaivothuongps.GetValueOrDefault(0),
                //                       Chaivo1litps = tblFBL5NthisperiodSum.Chaivo1litps.GetValueOrDefault(0),
                //                       joy20lps = tblFBL5NthisperiodSum.joy20lps.GetValueOrDefault(0),


                //                       Ketnhua1litps = tblFBL5NthisperiodSum.Ketnhua1litps.GetValueOrDefault(0),

                //                       Ketnhuathuongps = tblFBL5NthisperiodSum.Ketnhuathuongps.GetValueOrDefault(0),
                //                       Ketvolitps = tblFBL5NthisperiodSum.Ketvolitps.GetValueOrDefault(0),

                //                       Ketvothuongps = tblFBL5NthisperiodSum.Ketvothuongps.GetValueOrDefault(0),

                //                       paletnhuaps = tblFBL5NthisperiodSum.paletnhuaps.GetValueOrDefault(0),

                //                       palletgops = tblFBL5NthisperiodSum.palletgops.GetValueOrDefault(0),
                //                       #endregion    // PHAT SINH


                //                       #region  //  dau ky 
                //                       // Customer_Name = tblFBL5NthisperiodSum.Customer_Name,
                //                       FBL5N_amountdk = tblFBL5NthisperiodSum.FBL5N_amountdk.GetValueOrDefault(0),
                //                       Payment_amountdk = tblFBL5NthisperiodSum.Payment_amountdk.GetValueOrDefault(0),
                //                       Adj_amountdk = tblFBL5NthisperiodSum.Adj_amountdk.GetValueOrDefault(0),
                //                       Fullgood_amountdk = tblFBL5NthisperiodSum.Fullgood_amountdk.GetValueOrDefault(0),
                //                       //  RealBalancedk = tblFBL5NthisperiodSum.RealBalancedk,
                //                       Deposit_amountdk = tblFBL5NthisperiodSum.Deposit_amountdk.GetValueOrDefault(0),

                //                       Empty_Amountdk = tblFBL5NthisperiodSum.Empty_Amountdk.GetValueOrDefault(0),

                //                       Binhpmicc02dk = tblFBL5NthisperiodSum.Binhpmicc02dk.GetValueOrDefault(0),
                //                       binhpmix9ldk = tblFBL5NthisperiodSum.binhpmix9ldk.GetValueOrDefault(0),
                //                       Chaivothuongdk = tblFBL5NthisperiodSum.Chaivothuongdk.GetValueOrDefault(0),
                //                       Chaivo1litdk = tblFBL5NthisperiodSum.Chaivo1litdk.GetValueOrDefault(0),
                //                       joy20ldk = tblFBL5NthisperiodSum.joy20ldk.GetValueOrDefault(0),


                //                       Ketnhua1litdk = tblFBL5NthisperiodSum.Ketnhua1litdk.GetValueOrDefault(0),

                //                       Ketnhuathuongdk = tblFBL5NthisperiodSum.Ketnhuathuongdk.GetValueOrDefault(0),
                //                       Ketvolitdk = tblFBL5NthisperiodSum.Ketvolitdk.GetValueOrDefault(0),

                //                       Ketvothuongdk = tblFBL5NthisperiodSum.Ketvothuongdk.GetValueOrDefault(0),

                //                       paletnhuadk = tblFBL5NthisperiodSum.paletnhuadk.GetValueOrDefault(0),

                //                       palletgodk = tblFBL5NthisperiodSum.palletgodk.GetValueOrDefault(0),
                //                       #endregion    // PHAT SINH





                //                   };



                //if (rsthisperiod.Count() > 0)
                //{
                //    //   Utils ut = new Utils();
                //    dt = Utils.ToDataTable(dc, rsthisperiod);

                //    this.dataGridView1.DataSource = dt;


                //    this.db = dc;

                //    this.rs = rsthisperiod;

                //    //    dc = new LinqtoSQLDataContext(connection_string);
                //    this.Dtgridview = dataGridView1;
                //    this.Status.Text = "Caculating ...";
                //    Thread tt1 = new Thread(sumtitleGrid);

                //    tt1.IsBackground = true;
                //    tt1.Start(new datatoExport() { dataGrid1 = dataGridView1 });


                //    //tblFBL5NthisperiodSum tb = new tblFBL5NthisperiodSum();

                //    //    tb.id



                //    this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["RealBalance"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Format = "N0";



                //    this.dataGridView1.Columns["Payment_amountps"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Adj_amountps"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Fullgood_amountps"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["FBL5N_amountps"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Payment_amountdk"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Empty_Amountps"].DefaultCellStyle.Format = "N0";


                //    this.dataGridView1.Columns["FBL5N_amountdk"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Payment_amountdk"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Adj_amountdk"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Fullgood_amountdk"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Deposit_amountdk"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Payment_amountdk"].DefaultCellStyle.Format = "N0";
                //    this.dataGridView1.Columns["Empty_Amountdk"].DefaultCellStyle.Format = "N0";


                //    //    this.dataGridView1.Columns["RealBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //    //    this.dataGridView1.Columns["Deposit_amountdk"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["Adj_amountdk"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["Fullgood_amountdk"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["FBL5N_amountdk"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["Payment_amountdk"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    ////    this.dataGridView1.Columns["Empty_Amountdk"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


                //    //    this.dataGridView1.Columns["Deposit_amountps"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["Adj_amountps"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["Fullgood_amountps"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["FBL5N_amountps"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["Payment_amountps"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["Empty_Amountps"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


                //    //    this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //    //    this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";





                //}

                //#endregion // show all




            }


            //



            //   Show chi tiết bẳng f5  hoặc nháy đps vafoc co khác hàng bảng tổng

            if ((this.Text == "BẢNG TÔNG HỢP BÁO CÁO THEO CODE KHÁCH HÀNG" || this.Text == "iNPUT DEPOSIT AMOUNTT !") && e.KeyCode == Keys.F5)
            {

                this.Text = "iNPUT DEPOSIT AMOUNTT !";
                this.lb_seach.Text = "F5-DETAIL/ F11-SUM/ F3-SEACH";


                //#region // show all
                //System.Data.DataTable dt = new System.Data.DataTable();


                //string connection_string = Utils.getConnectionstr();
                ////      UpdateDatagridview

                //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                //var rsthisperiod = from tblFBL5Nnewthisperiod in dc.tblFBL5Nnewthisperiods

                //                   select new


                //                   {
                //                       tblFBL5Nnewthisperiod.codeGroup,

                //                       //         check = tblFBL5Nnewthisperiod.Account.ToString(),
                //                       Sorg = tblFBL5Nnewthisperiod.Business_Area,
                //                       tblFBL5Nnewthisperiod.Account,
                //                       Customer_Name = tblFBL5Nnewthisperiod.name,

                //                       //     tblFBL5Nnewthisperiod.COL_value,

                //                       tblFBL5Nnewthisperiod.Posting_Date,
                //                       tblFBL5Nnewthisperiod.Assignment,
                //                       tblFBL5Nnewthisperiod.Document_Number,

                //                       FBL5N_amount = tblFBL5Nnewthisperiod.Amount_in_local_currency,


                //                       tblFBL5Nnewthisperiod.Payment_amount,
                //                       Adj_amount = tblFBL5Nnewthisperiod.Adjusted_amount,

                //                       //    tblFBL5Nnewthisperiod.Invoice_Amount,
                //                       tblFBL5Nnewthisperiod.Fullgood_amount,
                //                       tblFBL5Nnewthisperiod.Empty_Amount,
                //                       tblFBL5Nnewthisperiod.Deposit_amount,


                //                       Invoice_date = tblFBL5Nnewthisperiod.Formula_invoice_date,
                //                       //       Invoice =   tblFBL5Nnewthisperiod.Invoice_Registration + " " + tblFBL5Nnewthisperiod.Invoice_Number,

                //                       tblFBL5Nnewthisperiod.Invoice,
                //                       //    tblFBL5Nnewthisperiod.Vat_amount,
                //                       Type = tblFBL5Nnewthisperiod.Document_Type,
                //                       tblFBL5Nnewthisperiod.Binhpmicc02,
                //                       tblFBL5Nnewthisperiod.binhpmix9l,
                //                       tblFBL5Nnewthisperiod.Chaivothuong,
                //                       tblFBL5Nnewthisperiod.Chaivo1lit,
                //                       tblFBL5Nnewthisperiod.joy20l,
                //                       tblFBL5Nnewthisperiod.Ketnhua1lit,
                //                       tblFBL5Nnewthisperiod.Ketnhuathuong,
                //                       tblFBL5Nnewthisperiod.Ketvolit,
                //                       tblFBL5Nnewthisperiod.Ketvothuong,
                //                       tblFBL5Nnewthisperiod.paletnhua,
                //                       tblFBL5Nnewthisperiod.palletgo,
                //                       tblFBL5Nnewthisperiod.userupdate,
                //                       tblFBL5Nnewthisperiod.id,
                //                       //   tblFBL5Nnewthisperiod.Empty_Amount_Notmach,


                //                   };

                ////   Utils ut = new Utils();
                //dt = Utils.ToDataTable(dc, rsthisperiod);

                //this.dataGridView1.DataSource = dt;


                //this.db = dc;

                //this.rs = rsthisperiod;

                ////      dc = new LinqtoSQLDataContext(connection_string);
                //this.Dtgridview = dataGridView1;
                //this.Status.Text = "Caculating ...";


                ////
                //Thread tt1 = new Thread(sumtitleGrid);

                //tt1.IsBackground = true;
                //tt1.Start(new datatoExport() { dataGrid1 = dataGridView1 });

                //this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


                //this.dataGridView1.Columns["codeGroup"].DisplayIndex = 1;
                //this.dataGridView1.Columns["Sorg"].DisplayIndex = 0;
                //this.dataGridView1.Columns["Account"].DisplayIndex = 2;
                //this.dataGridView1.Columns["Customer_Name"].DisplayIndex = 3;
                //this.dataGridView1.Columns["Document_Number"].DisplayIndex = 4;
                //this.dataGridView1.Columns["Assignment"].DisplayIndex = 5;
                //this.dataGridView1.Columns["Posting_Date"].DisplayIndex = 6;
                //this.dataGridView1.Columns["Invoice_date"].DisplayIndex = 7;
                //this.dataGridView1.Columns["Invoice"].DisplayIndex = 8;
                //this.dataGridView1.Columns["Payment_amount"].DisplayIndex = 9;
                //this.dataGridView1.Columns["Fullgood_amount"].DisplayIndex = 10;
                //this.dataGridView1.Columns["Adj_amount"].DisplayIndex = 11;
                //this.dataGridView1.Columns["Empty_Amount"].DisplayIndex = 12;
                //this.dataGridView1.Columns["Deposit_amount"].DisplayIndex = 13;
                //this.dataGridView1.Columns["FBL5N_amount"].DisplayIndex = 14;
                //this.dataGridView1.Columns["Type"].DisplayIndex = 15;


                ////   }
                //#endregion // show all


            }



        }

        private void Viewtable_FormClosed(object sender, FormClosedEventArgs e)
        {


        }

        private void Viewtable_FormClosing(object sender, FormClosingEventArgs e)
        {




        }

        private void Viewtable_Activated(object sender, EventArgs e)
        {

            //     fc =  Form.f.
            //FormCollection fc = System.Windows.Forms.Application.OpenForms;
            //bool kq = false;
            //foreach (Form frm in fc)
            //{
            //    if (frm.Text == "Seachcode")
            //    {
            //        kq = true;
            //      //  frm.Hide();
            //        frm.Close();
            //    }
            //}
        }

        private void bt_sendinggroup_Click(object sender, EventArgs e)
        {

            customerinput_ctrl md = new customerinput_ctrl();


            md.customerinputGroupsending();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //var rs = from tblCustomer in db.tblCustomers
            //         where tblCustomer.Reportsend == true
            //         select tblCustomer;

            //this.dataGridView1.DataSource = rs;
            //this.db = db;

            //this.rs = rs;
        }

        private void btAutoUpdatedepo_Click(object sender, EventArgs e)
        {



            // btAutoUpdatedepo
            string connection_string = Utils.getConnectionstr();
            //   LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //#region  autoupdatedepositthismonth ra TREN SQL dang viet 
            //SqlConnection conn2 = null;
            //SqlDataReader rdr1 = null;

            ////   string destConnString = Utils.getConnectionstr();
            //try
            //{

            //    conn2 = new SqlConnection(connection_string);
            //    conn2.Open();
            //    SqlCommand cmd1 = new SqlCommand("autoupdatedepositthismonth", conn2);
            //    cmd1.CommandType = CommandType.StoredProcedure;
            //    //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
            //    try
            //    {
            //        rdr1 = cmd1.ExecuteReader();
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("Can not auto update deposit \n" + ex.ToString(), "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //        return;

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

            MessageBox.Show("Auto update deposit done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //#region // show all
            //System.Data.DataTable dt = new System.Data.DataTable();


            ////      string connection_string = Utils.getConnectionstr();

            ////      LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //var rsthisperiod = from tblFBL5Nnewthisperiod in db.tblFBL5Nnewthisperiods

            //                   select new


            //                   {

            //                       tblFBL5Nnewthisperiod.codeGroup,
            //                       Sorg = tblFBL5Nnewthisperiod.Business_Area,
            //                       tblFBL5Nnewthisperiod.Account,
            //                       Customer_Name = tblFBL5Nnewthisperiod.name,

            //                       //     tblFBL5Nnewthisperiod.COL_value,

            //                       tblFBL5Nnewthisperiod.Posting_Date,
            //                       tblFBL5Nnewthisperiod.Assignment,
            //                       tblFBL5Nnewthisperiod.Document_Number,

            //                       FBL5N_amount = tblFBL5Nnewthisperiod.Amount_in_local_currency,


            //                       tblFBL5Nnewthisperiod.Payment_amount,
            //                       Adj_amount = tblFBL5Nnewthisperiod.Adjusted_amount,

            //                       //       tblFBL5Nnewthisperiod.Invoice_Amount,
            //                       tblFBL5Nnewthisperiod.Fullgood_amount,
            //                       tblFBL5Nnewthisperiod.Empty_Amount,
            //                       tblFBL5Nnewthisperiod.Deposit_amount,


            //                       Invoice_date = tblFBL5Nnewthisperiod.Formula_invoice_date,
            //                       //   Invoice = tblFBL5Nnewthisperiod.Invoice_Registration + " " + tblFBL5Nnewthisperiod.Invoice_Number,
            //                       tblFBL5Nnewthisperiod.Invoice,

            //                       //    tblFBL5Nnewthisperiod.Vat_amount,
            //                       Type = tblFBL5Nnewthisperiod.Document_Type,
            //                       tblFBL5Nnewthisperiod.Binhpmicc02,
            //                       tblFBL5Nnewthisperiod.binhpmix9l,
            //                       tblFBL5Nnewthisperiod.Chaivothuong,
            //                       tblFBL5Nnewthisperiod.Chaivo1lit,
            //                       tblFBL5Nnewthisperiod.joy20l,
            //                       tblFBL5Nnewthisperiod.Ketnhua1lit,
            //                       tblFBL5Nnewthisperiod.Ketnhuathuong,
            //                       tblFBL5Nnewthisperiod.Ketvolit,
            //                       tblFBL5Nnewthisperiod.Ketvothuong,
            //                       tblFBL5Nnewthisperiod.paletnhua,
            //                       tblFBL5Nnewthisperiod.palletgo,
            //                       tblFBL5Nnewthisperiod.userupdate,
            //                       tblFBL5Nnewthisperiod.id,
            //                       //      tblFBL5Nnewthisperiod.Empty_Amount_Notmach,


            //                   };

            ////  Utils ut = new Utils();
            //dt = Utils.ToDataTable(db, rsthisperiod);

            //this.dataGridView1.DataSource = dt;


            ////    this.db = dc;

            //this.rs = rsthisperiod;

            ////   dc = new LinqtoSQLDataContext(connection_string);
            //this.Dtgridview = dataGridView1;
            //this.Status.Text = "Caculating ...";
            //Thread tt1 = new Thread(sumtitleGrid);

            //tt1.IsBackground = true;
            //tt1.Start(new datatoExport() { dataGrid1 = dataGridView1 });
            //#endregion // show all

            this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Format = "N0";
            this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Format = "N0";
            this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Format = "N0";
            this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Format = "N0";
            this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Format = "N0";
            this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Format = "N0";
            //      this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Format = "N0";

            this.dataGridView1.Columns["Payment_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridView1.Columns["Adj_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridView1.Columns["Deposit_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridView1.Columns["FBL5N_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridView1.Columns["Empty_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridView1.Columns["Fullgood_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            this.dataGridView1.Columns["codeGroup"].DisplayIndex = 1;
            this.dataGridView1.Columns["Sorg"].DisplayIndex = 0;
            this.dataGridView1.Columns["Account"].DisplayIndex = 2;
            this.dataGridView1.Columns["Customer_Name"].DisplayIndex = 3;
            this.dataGridView1.Columns["Document_Number"].DisplayIndex = 4;
            this.dataGridView1.Columns["Assignment"].DisplayIndex = 5;
            this.dataGridView1.Columns["Posting_Date"].DisplayIndex = 6;
            this.dataGridView1.Columns["Invoice_date"].DisplayIndex = 7;
            this.dataGridView1.Columns["Invoice"].DisplayIndex = 8;
            this.dataGridView1.Columns["Payment_amount"].DisplayIndex = 9;
            this.dataGridView1.Columns["Fullgood_amount"].DisplayIndex = 10;
            this.dataGridView1.Columns["Adj_amount"].DisplayIndex = 11;
            this.dataGridView1.Columns["Empty_Amount"].DisplayIndex = 12;
            this.dataGridView1.Columns["Deposit_amount"].DisplayIndex = 13;
            this.dataGridView1.Columns["FBL5N_amount"].DisplayIndex = 14;
            this.dataGridView1.Columns["Type"].DisplayIndex = 15;


            //shoall
            //   }


        }

        private void btpostclear_Click(object sender, EventArgs e)
        {
            View.DatePicker datefrom = new View.DatePicker("Select posting date: ");
            datefrom.ShowDialog();
            DateTime postingdate = datefrom.valuedate;
            bool kq = datefrom.kq;
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            // xxx

            //#region q List các document só tieefn và so vo khac nhau
            ////---
            //var q = from tbl_FreGlassCleartemp in dc.tbl_FreGlassCleartemps
            //        where tbl_FreGlassCleartemp.COL_Amount / tbl_FreGlassCleartemp.COL_Quantity != 38000
            //        //Tương đương từ khóa NOT IN trong SQL
            //        select tbl_FreGlassCleartemp;



            //if (q.Count() != 0)
            //{

            //    Viewtable viewtbl = new Viewtable(q, dc, "List các document số cOL amount / COL Quantity khác 38000, please recheck ! Upload không thành công ! ", 1, DateTime.Today, DateTime.Today);
            //    return;
            //}

            //#endregion q "List các document có trong bảng VAT không có trong bảng FBL5N !



            if (kq == true)
            {


                //#region  autoupdatedepositthismonth ra TREN SQL dang viet 
                //SqlConnection conn2 = null;
                //SqlDataReader rdr1 = null;
                //string username = Utils.getusername().Trim();
                ////   string destConnString = Utils.getConnectionstr();
                //try
                //{

                //    conn2 = new SqlConnection(connection_string);
                //    conn2.Open();
                //    SqlCommand cmd1 = new SqlCommand("UpdateClearGlasses", conn2);
                //    cmd1.CommandType = CommandType.StoredProcedure;
                //    cmd1.Parameters.Add("@postingdate", SqlDbType.DateTime).Value = postingdate;
                //    cmd1.Parameters.Add("@name", SqlDbType.NVarChar).Value = username;



                //    try
                //    {
                //        rdr1 = cmd1.ExecuteReader();
                //    }
                //    catch (Exception ex)
                //    {

                //        MessageBox.Show("Can Not Upload clear Glasses  \n" + ex.ToString(), "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //        return;

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

                MessageBox.Show("Auto update deposit done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //    string connection_string = Utils.getConnectionstr();

                //LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
                //var rs = from FreGlassClear in db.tbl_FreGlassCleartemps
                //         select FreGlassClear;


                //this.dataGridView1.DataSource = rs;


            }



        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

            foreach (var c in dataGridView1.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {



        }

        private void btCaculationProgr_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            var db = new LinqtoSQLDataContext(connection_string);
            string enduser = Utils.getusername();


            //#region cehck xem da lam cai review chua
            //var rscheck = from pm in db.tbl_SalesFreeOrders
            //              where pm.enduser == enduser
            //              where pm.ma_CTKM == ""
            //              select pm;


            //if (rscheck.Count() > 0)
            //{
            //    MessageBox.Show("Please finish all the review khuyến mại và message first !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //#endregion  cehck xem da lam cai review chua




            #region  tính đơn hàng mua từ đơn hàng khuyến mại


         //   tbl_SalesOrderFromFree newsales = new tbl_SalesOrderFromFree();

            Thread t1 = new Thread(Model.Lucky.caculationOrderfromfree); // gồm cả updaet mã khkm mà só lương ctkm
            t1.IsBackground = true;
            t1.Start();
            View.Caculating wat = new View.Caculating();
            Thread t2 = new Thread(showwait);
            t2.Start(new datashowwait() { wat = wat });
           // t2.Start();

            t1.Join();
            if (t1.ThreadState != ThreadState.Running)
            {


                wat.Invoke(wat.myDelegate);



            }









            #endregion





        }
    }
}
