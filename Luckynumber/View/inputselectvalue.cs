using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Luckynumber.shared;

namespace Luckynumber.View
{
    public partial class inputselectvalue : Form
    {
        //  public DateTime fromdate { get; set; }
        // public DateTime todate { get; set; }
        // public bool choice { get; set; }
        // public bool byregion { get; set; }


        //  public string mactkm;
        //   public bool selectall;
        public string selecttext;
        public string selectvalue;
        public bool kq;

        public inputselectvalue(string fitername,  List<Viewtable.ComboboxItem> dataCollection)
        {
            InitializeComponent();



            this.kq = false;
         //   cbselect
            if (fitername == "555")  // là setlec progarme
            {
                this.txttieude.Text = "Chọn chương trình khuyến mại đúng :";

                int i = -1;
                foreach (var item in dataCollection)
                {

                    cbselect.Items.Add(item);
                    i = i + 1;
                    if (item.Value.ToString() == cbselect.Text)
                    {
                        cbselect.SelectedIndex = i;

                    }
                }






            }

      
            
       


        }


        private void checkalldata_CheckedChanged(object sender, EventArgs e)
        {

          


        }

        private void checkonlymainfiter_CheckedChanged(object sender, EventArgs e)
        {

        //    checkalldata.Checked = !checkonlymainfiter.Checked;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        

            if ( cbselect.SelectedIndex >= 0 && cbselect.SelectedIndex >= 0)
            {
                this.selectvalue = (cbselect.SelectedItem as Viewtable.ComboboxItem).Value.ToString();
                this.selecttext = (cbselect.SelectedItem as Viewtable.ComboboxItem).Text.ToString();
                this.kq = true;
                this.Hide();
                //    MessageBox.Show((cbcode.SelectedItem as Viewtable.ComboboxItem).Value.ToString());

            }


            //      MessageBox.Show((cbcode.SelectedItem as Viewtable.ComboboxItem).Value.ToString());






        }

        private void cbcode_SelectionChangeCommitted(object sender, EventArgs e)
        {
          //  cbselect.Text = cbselect.Text.Right(7);
        }

        private void cbcode_TextUpdate(object sender, EventArgs e)
        {


        }
    }
}
