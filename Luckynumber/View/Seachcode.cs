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
    public partial class Seachcode : Form
    {
        public Viewtable Fromviewable;

        public VInputchange Fromeditable;
        public string tablename;
        public Seachcode(Viewtable Fromviewable, string tablename)
        {

          
         //   return false;





            InitializeComponent();
            this.Fromviewable = Fromviewable;

            this.tablename = tablename;

        }


        public Seachcode(VInputchange Fromeditable, string tablename)
        {


            //   return false;





            InitializeComponent();
            this.Fromeditable = Fromeditable;

            this.tablename = tablename;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void Seachcode_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (tablename == "tblCustomer")
            //{
            //    Fromviewable.Reloadcustomer("");
            //}
            ////if (tablename == "tblFBL5Nnewthisperiod")
            ////{
            ////    Fromviewable.ReloadtblFBL5Nnewthisperiod("");
            //}



        }

        private void Seachcode_Leave(object sender, EventArgs e)
        {
         
        }

        private void Seachcode_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendingtext_Enter(object sender, EventArgs e)
        {
          
        }

        private void sendingtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                // beginbalance
                //    letterreturn

             
                if (tablename == "tblCustomer")
                    
                  

                    //  tblCustomered

                    if (tablename == "tblCustomered")
                    {


                        Fromeditable.Reloadeditcustomer(this.sendingtext.Text);
                    }

                    //   fbl5nnew
                    if (tablename == "fbl5nnew")
                    {


                        Fromviewable.REloadTotalbycodeFbl5new(this.sendingtext.Text);
                    }

                //   fbl5nnew
            
             

                //   tblFBL5beginbalace
                if (tablename == "tblFBL5beginbalace")
                {


                    Fromeditable.Reloadedbeginbalance(this.sendingtext.Text);
                }


            }
        }
    }
}
