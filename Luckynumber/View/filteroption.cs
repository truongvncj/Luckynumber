using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using arconfirmationletter.shared;

namespace arconfirmationletter.View
{
    public partial class filteroption : Form
    {
        //  public DateTime fromdate { get; set; }
        // public DateTime todate { get; set; }
        // public bool choice { get; set; }
        // public bool byregion { get; set; }


        public string filtercode;
        public bool selectall;
        public string region;
        public bool kq;

        public filteroption(string fitername, DataGridView Dtgridview, List<Viewtable.ComboboxItem> dataCollection)
        {
            InitializeComponent();



            //   this.selectall = true;
            checkonlymainfiter.Checked = true;
            this.selectall = true;
            this.kq = false;

            if (fitername == "Account")
            {
                this.optionlabel.Text = "Account";

                //this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].HeaderText;

                //  cbcode.Text = this.dataGridView1. "";
                cbcode.Text = Dtgridview.Rows[Dtgridview.CurrentCell.RowIndex].Cells["Account"].Value.ToString();
                cbregion.Text = Dtgridview.Rows[Dtgridview.CurrentCell.RowIndex].Cells["Sorg"].Value.ToString();
                cbcode.DropDownStyle = ComboBoxStyle.DropDown;
                cbregion.DropDownStyle = ComboBoxStyle.DropDown;
                //    List<ComboboxItem> dataCollection = new List<ComboboxItem>();
                // getData(dataCollection);
                int i = -1;
                foreach (var item in dataCollection)
                {

                    cbcode.Items.Add(item);
                    i = i + 1;
                    if (item.Value.ToString() == cbcode.Text)
                    {
                        cbcode.SelectedIndex = i;

                    }
                }




                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                //var rs2 = from tbl_Comboundtemp in dc.tbl_Comboundtemps
                //          group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
                //          select grthis2;

                //string drowdownshow = "";

                //foreach (var item in rs2)
                //{
                    
                //    if (item.Key.ToString() != "")
                //    {

                
                //    if (item.Key.ToString().Trim() !="")
                //    {
                //        drowdownshow = item.Key.ToString();
                //        cbregion.Items.Add(drowdownshow);

                //    }

                //    }
                //}
                //cbregion.Items.Add("ALL");
                ////    i = -1;
                //   i = i + 1;

                for (int ii = 0; ii < cbregion.Items.Count-1; ii++)
                {
                    if ((string)cbregion.Items[ii].ToString().Trim() == cbregion.Text)
                    {
                        cbregion.SelectedIndex = ii;
                    }
                }





            }

            if (fitername == "codeGroup")
            {


                this.optionlabel.Text = "Code Group";

                cbcode.Text = Dtgridview.Rows[Dtgridview.CurrentCell.RowIndex].Cells["codeGroup"].Value.ToString();
                cbregion.Text = Dtgridview.Rows[Dtgridview.CurrentCell.RowIndex].Cells["Sorg"].Value.ToString();

                cbcode.DropDownStyle = ComboBoxStyle.DropDown;
                cbregion.DropDownStyle = ComboBoxStyle.DropDown;

                int i = -1;
                foreach (var item in dataCollection)
                {
                    cbcode.Items.Add(item);
                    i = i + 1;
                    if (item.Value.ToString() == cbcode.Text.ToString())
                    {
                        cbcode.SelectedIndex = i;

                    }
                }

                //       cbcode.SelectedIndex = 0;
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                //var rs2 = from tbl_Comboundtemp in dc.tbl_Comboundtemps
                //          group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
                //          select grthis2;

                //string drowdownshow = "";
             
                //foreach (var item in rs2)
                //{
                //    drowdownshow = item.Key.ToString();
                //    cbregion.Items.Add(drowdownshow);

                 
                //}
                //cbregion.Items.Add("ALL");
            //    i = -1;
             //   i = i + 1;

                for (int ii = 0; ii < cbregion.Items.Count-1; ii++)
                {
                    if ((string)cbregion.Items[ii].ToString().Trim() == cbregion.Text)
                    {
                        cbregion.SelectedIndex = ii;
                    }
                }
               
            }



        }


        private void checkalldata_CheckedChanged(object sender, EventArgs e)
        {

            checkonlymainfiter.Checked = !checkalldata.Checked;



        }

        private void checkonlymainfiter_CheckedChanged(object sender, EventArgs e)
        {

            checkalldata.Checked = !checkonlymainfiter.Checked;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkalldata.Checked == true)
            {
                this.selectall = true;
                this.kq = true;
                this.Hide();
            }
            else
            {
                this.selectall = false;
            }

            if (this.selectall == false && cbcode.SelectedIndex >= 0 && cbregion.SelectedIndex >= 0)
            {
                this.filtercode = (cbcode.SelectedItem as Viewtable.ComboboxItem).Value.ToString();
                this.region = cbregion.SelectedItem.ToString();//.ToString();

                //      public bool selectall;
                //     public string region;
                this.kq = true;
                this.Hide();
                //    MessageBox.Show((cbcode.SelectedItem as Viewtable.ComboboxItem).Value.ToString());

            }


            //      MessageBox.Show((cbcode.SelectedItem as Viewtable.ComboboxItem).Value.ToString());






        }

        private void cbcode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbcode.Text = cbcode.Text.Right(7);
        }

        private void cbcode_TextUpdate(object sender, EventArgs e)
        {


        }
    }
}
