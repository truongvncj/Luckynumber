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
    public partial class Caculating : Form
    {

        //   public delegate void CloseFormDelegate();
        //  public CloseFormDelegate myDelegate;
        public void CloseMyForm()
        {
            this.Close();
        }
        public delegate void CloseFormDelegate();
        public CloseFormDelegate myDelegate;

     

        public Caculating()
        {
            InitializeComponent();

            myDelegate = new CloseFormDelegate(CloseMyForm);

        }


        //    this.Invoke(this.myDelegate);



        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }

        private void Caculating_Load(object sender, EventArgs e)
        {
         //   myDelegate new CloseFormDelegate(closeMyFrom);

        }

      
    }
}
