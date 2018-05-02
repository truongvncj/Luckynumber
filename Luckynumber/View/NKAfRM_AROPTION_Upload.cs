using arconfirmationletter.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using arconfirmationletter.Control;

namespace arconfirmationletter.View
{



   
  
    public partial class NKAfRM_AROPTION_Upload : Form
    {


        public DateTime returndate { get; set; }
  
        public DateTime todate { get; set; }
        public bool choice { get; set; }
   
    public NKAfRM_AROPTION_Upload()//(string rptname)
        {
            InitializeComponent();
       //     this.pik_fromdate.Value = DateTime.Today;
            this.pk_todate.Value = DateTime.Today;
            this.pk_returndate.Value = DateTime.Today.AddDays(15);

            this.returndate = this.pk_returndate.Value;
            this.choice = false;
         


        }
    
      


        private void bt_okthuchien_Click(object sender, EventArgs e)
        {



            if (this.pk_todate.Value <= this.pk_returndate.Value)
            {

                this.choice = true;

                this.todate = this.pk_todate.Value;
                this.returndate = this.pk_returndate.Value;






                this.Hide();
            }
            else
            {
                this.choice = false;


                MessageBox.Show("From date must before Return date !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pik_fromdate_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pik_fromdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                pk_todate.Focus();
            }
        }

        private void pk_todate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pk_todate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                pk_returndate.Focus();
            }
        }

        private void datelinePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{

            //    pik_fromdate.Focus();
            //}
        }
    }
}
