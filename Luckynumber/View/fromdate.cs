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
    public partial class fromdate : Form
    {
        public fromdate()
        {
            InitializeComponent();


            chon = false;
        }
                public DateTime tungay {get; set;}
                 public DateTime denngay {get; set;}
      public      bool chon { get; set; }
private void button1_Click(object sender, EventArgs e)
        {
           
            
            tungay = fromdatePicker.Value;
            denngay = TodateTimePicker.Value;

            if (tungay <= denngay)
            {
                chon = true;
                this.Hide();
            }
            

        }
    }
}
