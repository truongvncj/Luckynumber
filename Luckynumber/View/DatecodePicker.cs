using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Luckynumber.View
{
    public partial class DatecodePicker : Form
    {
        public DateTime valuedate;
        public string field;
        public bool kq;
        public double code;
        public DatecodePicker(string headcolum)
        {
            InitializeComponent();
            this.kq = false;
            this.field = headcolum;
            lbtext.Text = headcolum;
            dateTimePicker1.Value = DateTime.Today;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.valuedate = dateTimePicker1.Value;
            this.kq = true;

            if (Utils.IsValidnumber(txtcode.Text))
            {
                this.code = double.Parse(txtcode.Text);
            }
            else
            {
                this.code = 0;
            }
         
            //   this.field = this.label1.Text;
            this.Hide();

        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {
         
        }

     

     

        private void button2_Click(object sender, EventArgs e)
        {
          //  this.valuedate = DateTime..;
            this.kq = false;
            //   this.field = this.label1.Text;
            this.Hide();
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.Focus();
            }
        }

        private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dateTimePicker1.Focus();


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
              
               
            }



        }
    }
}
