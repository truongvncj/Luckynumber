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
    public partial class fromdateandcode : Form
    {
        public fromdateandcode()
        {
            InitializeComponent();

            lbname.Text = "";

            chon = false;
        }
        public DateTime tungay { get; set; }
        public DateTime denngay { get; set; }
        public bool chon { get; set; }
        public double custcode { get; set; }

   
        private void button1_Click(object sender, EventArgs e)
        {
            custcode = -1;

            tungay = fromdatePicker.Value;
            denngay = TodateTimePicker.Value;

            if (Utils.IsValidnumber(txtcode.Text) )
            {
                custcode = double.Parse(txtcode.Text);
            }
            if (txtcode.Text == "")
            {
                custcode = 0;
            }
            if (custcode == -1)
            {
                MessageBox.Show("Please recheck the customer code !","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


       

            if (tungay <= denngay && custcode != -1)
            {
                chon = true;
                this.Hide();
            }


        }

        private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                fromdatePicker.Focus();


            }





        }

        private void txtcode_Leave(object sender, EventArgs e)
        {
            if (!Utils.IsValidnumber(txtcode.Text) && txtcode.Text != "")
            {
              //  MessageBox.Show("Code khác hàng phải là số !");
                MessageBox.Show("Code khác hàng phải là số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtcode.Text = "";
                return;

            }
            else
            {
                lbname.Text = Model.customerinput_ctrl.getNamecustomer(double.Parse(txtcode.Text));
            }





        }

        private void fromdatePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TodateTimePicker.Focus();


            }
        }

        private void TodateTimePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtcode.Focus();


            }
        }

        private void lbname_Click(object sender, EventArgs e)
        {

        }
    }
}
