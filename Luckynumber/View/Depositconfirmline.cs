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
