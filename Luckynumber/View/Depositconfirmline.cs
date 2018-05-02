using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace arconfirmationletter.View
{

    // public static 
    public partial class Depositconfirmline : Form
    {

        public int idindex { get; set; }
        public double psepmptyam { get; set; } //= int.Parse(this.lb_uncofirm.Text.ToString());
        public double psdeposiamount { get; set; }// = int.Parse(this.txconfimr.Text.ToString()); //deposiamount + deposiamount

        public double psunconfirm { get; set; } //= int.Parse(this.lb_uncofirm.Text.ToString());

        public int viewcode { get; set; } //= int.Parse(this.lb_uncofirm.Text.ToString());

        public string header { get; set; }
        public Depositconfirmline(int idindex, string header, int viewcode)
        {

            InitializeComponent();
            this.header = header;
            this.viewcode = viewcode;
            this.idindex = idindex;

            if (viewcode == 1)
            {
                #region

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                var rsthisperiod = (from tblFBL5Nnewthisperiod in dc.tblFBL5Nnewthisperiods
                                    where tblFBL5Nnewthisperiod.id == idindex
                                    select new

                                    {

                                        tblFBL5Nnewthisperiod.Document_Number,
                                        tblFBL5Nnewthisperiod.Amount_in_local_currency,
                                        tblFBL5Nnewthisperiod.Adjusted_amount,
                                        tblFBL5Nnewthisperiod.Payment_amount,
                                        tblFBL5Nnewthisperiod.Empty_Amount,
                                        tblFBL5Nnewthisperiod.Fullgood_amount,

                                        tblFBL5Nnewthisperiod.Deposit_amount,
                                        tblFBL5Nnewthisperiod.Empty_Amount_Notmach,

                                    }).First();

                if (header == "Empty_Amount")// nêu là em pty amount 
                {

                    #region/ nêu là em pty amount 



                    if (rsthisperiod.Document_Number != null)
                    {

                        this.lb_Docno.Text = rsthisperiod.Document_Number.ToString();


                    }


                    this.lb_uncofirm.Text = "0";
                    if (rsthisperiod.Empty_Amount != null)
                    {


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Empty_Amount.ToString();
                        }
                        else
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Empty_Amount.ToString();
                        }


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.txconfimr.Text = rsthisperiod.Empty_Amount.ToString();
                            //     this.lb_uncofirm.Text = (rsthisperiod.Empty_Amount + rsthisperiod.Deposit_amount).ToString();

                        }
                        else
                        {
                            this.txconfimr.Text = rsthisperiod.Empty_Amount.ToString();

                            //this.lb_uncofirm.Text = "0";

                        }



                    }







                    #endregion
                }

                if (header == "Payment_amount")// nêu là em pty amount 
                {



                    #region/ nêu là pay ment amount


                    this.lbtextamount.Text = "Payment Amount";

                    if (rsthisperiod.Document_Number != null)
                    {

                        this.lb_Docno.Text = rsthisperiod.Document_Number.ToString();


                    }


                    this.lb_uncofirm.Text = "0";
                    if (rsthisperiod.Payment_amount != null)
                    {


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Payment_amount.ToString();
                        }
                        else
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Payment_amount.ToString();
                        }


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.txconfimr.Text = rsthisperiod.Payment_amount.ToString();

                        }
                        else
                        {
                            this.txconfimr.Text = "0";

                        }



                    }





                    this.lb_uncofirm.Text = "0";

                    #endregion
                }
                //  this.txconfimr.TabIndex = 1;    Adj_amount


                if (header == "Adj_amount")// nêu là em pty amount 
                {



                    #region/ nêu là pay ment amount


                    this.lbtextamount.Text = "Adj Amount";

                    if (rsthisperiod.Document_Number != null)
                    {

                        this.lb_Docno.Text = rsthisperiod.Document_Number.ToString();


                    }


                    this.lb_uncofirm.Text = "0";
                    if (rsthisperiod.Adjusted_amount != null)
                    {


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Adjusted_amount.ToString();
                        }
                        else
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Adjusted_amount.ToString();
                        }


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.txconfimr.Text = rsthisperiod.Adjusted_amount.ToString();

                        }
                        else
                        {
                            this.txconfimr.Text = "0";

                        }



                    }





                    this.lb_uncofirm.Text = "0";

                    #endregion
                }
                #endregion
            }


            if (viewcode == 2)
            {
                #region

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                var rsthisperiod = (from tblFBL5Nnew in dc.tblFBL5Nnews
                                    where tblFBL5Nnew.id == idindex
                                    select new

                                    {

                                        tblFBL5Nnew.Document_Number,
                                        tblFBL5Nnew.Amount_in_local_currency,
                                        tblFBL5Nnew.Adjusted_amount,
                                        tblFBL5Nnew.Payment_amount,
                                        tblFBL5Nnew.Empty_Amount,
                                        tblFBL5Nnew.Fullgood_amount,

                                        tblFBL5Nnew.Deposit_amount,
                                        tblFBL5Nnew.Empty_Amount_Notmach,

                                    }).First();

                if (header == "Empty_Amount")// nêu là em pty amount 
                {

                    #region/ nêu là em pty amount 



                    if (rsthisperiod.Document_Number != null)
                    {

                        this.lb_Docno.Text = rsthisperiod.Document_Number.ToString();


                    }


                    this.lb_uncofirm.Text = "0";
                    if (rsthisperiod.Empty_Amount != null)
                    {


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Empty_Amount.ToString();
                        }
                        else
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Empty_Amount.ToString();
                        }


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.txconfimr.Text = rsthisperiod.Empty_Amount.ToString();
                            //     this.lb_uncofirm.Text = (rsthisperiod.Empty_Amount + rsthisperiod.Deposit_amount).ToString();

                        }
                        else
                        {
                            this.txconfimr.Text = rsthisperiod.Empty_Amount.ToString();

                            //this.lb_uncofirm.Text = "0";

                        }



                    }







                    #endregion
                }

                if (header == "Payment_amount")// nêu là em pty amount 
                {



                    #region/ nêu là pay ment amount


                    this.lbtextamount.Text = "Payment Amount";

                    if (rsthisperiod.Document_Number != null)
                    {

                        this.lb_Docno.Text = rsthisperiod.Document_Number.ToString();


                    }


                    this.lb_uncofirm.Text = "0";
                    if (rsthisperiod.Payment_amount != null)
                    {


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Payment_amount.ToString();
                        }
                        else
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Payment_amount.ToString();
                        }


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.txconfimr.Text = rsthisperiod.Payment_amount.ToString();

                        }
                        else
                        {
                            this.txconfimr.Text = "0";

                        }



                    }





                    this.lb_uncofirm.Text = "0";

                    #endregion
                }
                //  this.txconfimr.TabIndex = 1;    Adj_amount


                if (header == "Adj_amount")// nêu là em pty amount 
                {



                    #region/ nêu là pay ment amount


                    this.lbtextamount.Text = "Adj Amount";

                    if (rsthisperiod.Document_Number != null)
                    {

                        this.lb_Docno.Text = rsthisperiod.Document_Number.ToString();


                    }


                    this.lb_uncofirm.Text = "0";
                    if (rsthisperiod.Adjusted_amount != null)
                    {


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Adjusted_amount.ToString();
                        }
                        else
                        {
                            this.lb_emptyrtamount.Text = rsthisperiod.Adjusted_amount.ToString();
                        }


                        if (rsthisperiod.Deposit_amount != null)
                        {
                            this.txconfimr.Text = rsthisperiod.Adjusted_amount.ToString();

                        }
                        else
                        {
                            this.txconfimr.Text = "0";

                        }



                    }





                    this.lb_uncofirm.Text = "0";

                    #endregion
                }
                #endregion
            }

            this.txconfimr.Focus();

        }

        private void label4_Click(object sender, EventArgs e)
        {


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {





        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (viewcode == 1)
            {
                #region
                bool kq = Utils.IsValidnumber(this.txconfimr.Text.ToString());
                if (kq == true)
                {

                    double valuetc = double.Parse((this.txconfimr.Text).ToString());


                    if ((valuetc >= double.Parse((this.lb_emptyrtamount.Text)) && (valuetc <= 0)) || (valuetc <= double.Parse((this.lb_emptyrtamount.Text)) && (valuetc >= 0)))
                    {

                        #region tacts vu


                        if (this.header == "Empty_Amount" && Utils.IsValidnumber(this.txconfimr.Text.ToString()))
                        {




                            #region  == "Empty_Amount")



                            int Docno = int.Parse(this.lb_Docno.Text.ToString());

                            psepmptyam = int.Parse(this.lb_uncofirm.Text.ToString());

                            if (this.txconfimr.Text.ToString() != null && this.txconfimr.Text.ToString() != "")
                            {

                                psdeposiamount = -int.Parse(this.txconfimr.Text.ToString());


                            }


                            psunconfirm = int.Parse(this.lb_uncofirm.Text.ToString());


                            //   if (psdeposiamount != null)
                            // {

                            string connection_string = Utils.getConnectionstr();
                            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                            var item = (from tblFBL5Nnewthisperiod in dc.tblFBL5Nnewthisperiods
                                        where tblFBL5Nnewthisperiod.id == this.idindex

                                        select tblFBL5Nnewthisperiod).First();


                            item.Deposit_amount = -psdeposiamount;



                            //    item.Empty_Amount = psepmptyam;
                            item.Empty_Amount_Notmach = psunconfirm;
                            //  item.Deposit_amount = deposiamount;

                            dc.SubmitChanges();

                            //}

                            #endregion



                        }
                        //data


                        if (this.header == "Payment_amount" && Utils.IsValidnumber(this.txconfimr.Text.ToString()))
                        {

                            #region  == "Payment_amount")



                            int Docno = int.Parse(this.lb_Docno.Text.ToString());

                            psepmptyam = int.Parse(this.lb_uncofirm.Text.ToString());

                            if (this.txconfimr.Text.ToString() != null && this.txconfimr.Text.ToString() != "")
                            {
                                psdeposiamount = int.Parse(this.txconfimr.Text.ToString());
                            }


                            psunconfirm = int.Parse(this.lb_uncofirm.Text.ToString());

                            //     if (psdeposiamount != null)
                            //   {
                            string connection_string = Utils.getConnectionstr();

                            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                            var item = (from tblFBL5Nnewthisperiod in dc.tblFBL5Nnewthisperiods
                                        where tblFBL5Nnewthisperiod.id == this.idindex

                                        select tblFBL5Nnewthisperiod).First();


                            item.Deposit_amount = -psdeposiamount;



                            //     item.Fullgood_amount = psunconfirm;
                            //    item.Empty_Amount_Notmach = psunconfirm;
                            //  item.Deposit_amount = deposiamount;

                            dc.SubmitChanges();

                            // }

                            #endregion

                        }
                        //data

                        if (this.header == "Adj_amount" && Utils.IsValidnumber(this.txconfimr.Text.ToString()))
                        {

                            #region  == "Adj_amount")



                            int Docno = int.Parse(this.lb_Docno.Text.ToString());

                            psepmptyam = int.Parse(this.lb_uncofirm.Text.ToString());

                            if (this.txconfimr.Text.ToString() != null && this.txconfimr.Text.ToString() != "")
                            {
                                psdeposiamount = int.Parse(this.txconfimr.Text.ToString());
                            }


                            psunconfirm = int.Parse(this.lb_uncofirm.Text.ToString());

                            //       if (psdeposiamount != null)
                            //     {
                            string connection_string = Utils.getConnectionstr();

                            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                            var item = (from tblFBL5Nnewthisperiod in dc.tblFBL5Nnewthisperiods
                                        where tblFBL5Nnewthisperiod.id == this.idindex

                                        select tblFBL5Nnewthisperiod).First();


                            item.Deposit_amount = -psdeposiamount;
                            //   item.Fullgood_amount = item.Fullgood_amount - psdeposiamount;


                            //     item.Fullgood_amount = psunconfirm;
                            //    item.Empty_Amount_Notmach = psunconfirm;
                            //  item.Deposit_amount = deposiamount;

                            dc.SubmitChanges();

                            //   }

                            #endregion

                        }
                        //data


                        this.Hide();
                        #endregion tác vụ
                    }
                    else
                    {

                        MessageBox.Show("Deposit amount cần là số nằm trong khoảng số tiền vỏ/ tiền nôp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txconfimr.Focus();
                    }






                }
                else
                {

                    MessageBox.Show("Deposit amount gõ vào phải là số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txconfimr.Focus();
                }


                #endregion
            }








            if (viewcode == 2)
            {
                #region
                bool kq = Utils.IsValidnumber(this.txconfimr.Text.ToString());
                if (kq == true)
                {

                    double valuetc = double.Parse((this.txconfimr.Text).ToString());


                    if ((valuetc >= double.Parse((this.lb_emptyrtamount.Text)) && (valuetc <= 0)) || (valuetc <= double.Parse((this.lb_emptyrtamount.Text)) && (valuetc >= 0)))
                    {

                        #region tacts vu





                        if (this.header == "Empty_Amount" && Utils.IsValidnumber(this.txconfimr.Text.ToString()))
                        {




                            #region  == "Empty_Amount")



                            int Docno = int.Parse(this.lb_Docno.Text.ToString());

                            psepmptyam = double.Parse(this.lb_uncofirm.Text.ToString());

                            if (this.txconfimr.Text.ToString() != null && this.txconfimr.Text.ToString() != "")
                            {

                                psdeposiamount = -double.Parse(this.txconfimr.Text.ToString());


                            }


                            psunconfirm = double.Parse(this.lb_uncofirm.Text.ToString());


                            //      if (psdeposiamount != null)
                            //    {

                            string connection_string = Utils.getConnectionstr();
                            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                            var item = (from tblFBL5Nnew in dc.tblFBL5Nnews
                                        where tblFBL5Nnew.id == this.idindex

                                        select tblFBL5Nnew).First();


                            item.Deposit_amount = -psdeposiamount;


                            //       item.Deposit_amount = psdeposiamount;
                            item.Empty_Amount = psepmptyam;


                            //    item.Empty_Amount = psepmptyam;
                            item.Empty_Amount_Notmach = psunconfirm;
                            //  item.Deposit_amount = deposiamount;

                            dc.SubmitChanges();

                            //   }

                            #endregion



                        }
                        //data


                        if (this.header == "Payment_amount" && Utils.IsValidnumber(this.txconfimr.Text.ToString()))
                        {

                            #region  == "Payment_amount")



                            int Docno = int.Parse(this.lb_Docno.Text.ToString());

                            psepmptyam = double.Parse(this.lb_uncofirm.Text.ToString());

                            if (this.txconfimr.Text.ToString() != null && this.txconfimr.Text.ToString() != "")
                            {
                                psdeposiamount = double.Parse(this.txconfimr.Text.ToString());
                            }


                            psunconfirm = double.Parse(this.lb_uncofirm.Text.ToString());

                            //  if (psdeposiamount != null)
                            //    {
                            string connection_string = Utils.getConnectionstr();

                            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                            var item = (from tblFBL5Nnew in dc.tblFBL5Nnews
                                        where tblFBL5Nnew.id == this.idindex

                                        select tblFBL5Nnew).First();


                            item.Deposit_amount = -psdeposiamount;

                     //       item.Deposit_amount = psdeposiamount;
                            item.Payment_amount = psepmptyam;


                            //     item.Fullgood_amount = psunconfirm;
                            //    item.Empty_Amount_Notmach = psunconfirm;
                            //  item.Deposit_amount = deposiamount;

                            dc.SubmitChanges();

                            // }

                            #endregion

                        }
                        //data

                        if (this.header == "Adj_amount" && Utils.IsValidnumber(this.txconfimr.Text.ToString()))
                        {

                            #region  == "Adj_amount")



                            int Docno = int.Parse(this.lb_Docno.Text.ToString());

                            psepmptyam = double.Parse(this.lb_uncofirm.Text.ToString());

                            if (this.txconfimr.Text.ToString() != null && this.txconfimr.Text.ToString() != "")
                            {
                                psdeposiamount = double.Parse(this.txconfimr.Text.ToString());
                            }


                            psunconfirm = double.Parse(this.lb_uncofirm.Text.ToString());

                            //  if (psdeposiamount != null)
                            //{
                            string connection_string = Utils.getConnectionstr();

                            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                            var item = (from tblFBL5Nnew in dc.tblFBL5Nnews
                                        where tblFBL5Nnew.id == this.idindex

                                        select tblFBL5Nnew).First();


                            item.Deposit_amount = psdeposiamount;
                            item.Adjusted_amount = psepmptyam;


                            //     item.Fullgood_amount = psunconfirm;
                            //    item.Empty_Amount_Notmach = psunconfirm;
                            //  item.Deposit_amount = deposiamount;

                            dc.SubmitChanges();

                            //}

                            #endregion

                        }
                        //data




                        this.Hide();
                        #endregion tác vụ
                    }
                    else
                    {

                        MessageBox.Show("Deposit amount cần là số nằm trong khoảng số tiền vỏ/ tiền nôp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txconfimr.Focus();
                    }




                }
                else
                {

                    MessageBox.Show("Deposit amount gõ vào phải là số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txconfimr.Focus();
                }


                #endregion
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {




            this.txconfimr.Text = ((trackBar1.Value * double.Parse((this.lb_emptyrtamount.Text))) / 10).ToString();
            this.lb_uncofirm.Text = (double.Parse(this.lb_emptyrtamount.Text) - double.Parse(this.txconfimr.Text)).ToString();   // - 







        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void txconfimr_TextChanged(object sender, EventArgs e)
        {

            if (this.txconfimr.Text != null && this.txconfimr.Text != "")
            {



                double valuetc;

                bool kq = Utils.IsValidnumber(this.txconfimr.Text.ToString());
                if (kq)
                {

                    valuetc = double.Parse((this.txconfimr.Text).ToString());



                    //            this.txconfimr.cur

                    //        this.txconfimr.Text = valuetc.ToString();

                    this.lb_uncofirm.Text = (double.Parse((this.lb_emptyrtamount.Text).ToString()) - valuetc).ToString();





                }




            }








        }

        private void txconfimr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double totalamount = double.Parse((this.lb_emptyrtamount.Text).ToString());
                    double confirmamount = double.Parse((this.txconfimr.Text).ToString());
                    if (totalamount * confirmamount < 0)
                    {
                        string txtpsdeposiamount = (double.Parse(this.txconfimr.Text.ToString()) * (-1)).ToString();

                        this.txconfimr.Text = txtpsdeposiamount;


                    }


                }
                catch (Exception)
                {

                    //   throw;
                }




                this.button1.Focus();
            }
        }
    }
}
