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





    public partial class fRM_AROPTION : Form
    {

        public List<Viewtable.ComboboxItem> Getcomboudata()
        {




            List<Viewtable.ComboboxItem> dataCollection = new List<Viewtable.ComboboxItem>();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = from tblCustomer in dc.tblCustomers
                     where tblCustomer.Reportsend == true
                     select tblCustomer;


            string drowdowvalue = "";
            if (rs.Count() > 0)
            {


                foreach (var item in rs)
                {


                    drowdowvalue = item.Customer.ToString() + " " + item.Name_1;


                    Viewtable.ComboboxItem itemcb = new Viewtable.ComboboxItem();
                    itemcb.Text = drowdowvalue;
                    itemcb.Value = item.Customer.ToString();



                    dataCollection.Add(itemcb);

                }

                return dataCollection;
            }
            return null;

        }


        public DateTime returndate { get; set; }
        public DateTime fromdate { get; set; }

        public DateTime todate { get; set; }
        public bool choice { get; set; }
        public bool byregion { get; set; }
        public double custcode { get; set; }

        
        //   public bool onlycheckbook { get; set; }
        //   public double  onlycode { get; set; }
        public fRM_AROPTION()//(string rptname)
        {
            InitializeComponent();
            this.pik_fromdate.Value = DateTime.Today;
            this.pk_todate.Value = DateTime.Today;
            this.datelinePicker1.Value = DateTime.Today.AddDays(15);

            this.returndate = this.datelinePicker1.Value;
            this.fromdate = this.pik_fromdate.Value;
            this.todate = this.pk_todate.Value;
        //    var Check = CheckState.Checked;
            //    this.onlycode = -1;
            this.choice = false;
            this.custcode = 0;

            this.byregion = false;





        }




        private void bt_okthuchien_Click(object sender, EventArgs e)
        {



            if (this.pik_fromdate.Value <= this.pk_todate.Value)
            {

                this.choice = true;
                this.fromdate = this.pik_fromdate.Value;
                this.todate = this.pk_todate.Value;
                this.returndate = this.datelinePicker1.Value;

                //     var Check = CheckState.Checked;

                if (Utils.IsValidnumber(txtcode.Text.ToString()))
                {
                    this.custcode = double.Parse(txtcode.Text.ToString());

                }
                else
                {
                    this.custcode = 0;
                }

                this.byregion = false;






                this.Hide();
            }
            else
            {
                this.choice = false;


                MessageBox.Show("From_date must before Todate !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                datelinePicker1.Focus();
            }
        }

        private void datelinePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                pik_fromdate.Focus();
            }
        }

        private void txtcode_Leave(object sender, EventArgs e)
        {
            if (!Utils.IsValidnumber(txtcode.Text))
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

        private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                pik_fromdate.Focus();


            }


        }
    }
}
