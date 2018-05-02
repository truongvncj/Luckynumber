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
    public partial class DatePicker : Form
    {
        public DateTime valuedate;
        public string field;
        public bool kq;
        public DatePicker(string headcolum)
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
    }
}
