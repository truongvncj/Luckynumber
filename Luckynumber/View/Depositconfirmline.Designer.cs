namespace Luckynumber.View
{
    partial class Depositconfirmline
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Depositconfirmline));
            this.button1 = new System.Windows.Forms.Button();
            this.lb_doc = new System.Windows.Forms.Label();
            this.lbtextamount = new System.Windows.Forms.Label();
            this.lbuntextamount = new System.Windows.Forms.Label();
            this.txconfimr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_Docno = new System.Windows.Forms.Label();
            this.lb_emptyrtamount = new System.Windows.Forms.Label();
            this.lb_uncofirm = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(222, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_doc
            // 
            this.lb_doc.AutoSize = true;
            this.lb_doc.Location = new System.Drawing.Point(12, 20);
            this.lb_doc.Name = "lb_doc";
            this.lb_doc.Size = new System.Drawing.Size(76, 13);
            this.lb_doc.TabIndex = 12;
            this.lb_doc.Text = "Document No.";
            // 
            // lbtextamount
            // 
            this.lbtextamount.AutoSize = true;
            this.lbtextamount.Location = new System.Drawing.Point(12, 46);
            this.lbtextamount.Name = "lbtextamount";
            this.lbtextamount.Size = new System.Drawing.Size(113, 13);
            this.lbtextamount.TabIndex = 14;
            this.lbtextamount.Text = "Empty Return Amount.";
            // 
            // lbuntextamount
            // 
            this.lbuntextamount.AutoSize = true;
            this.lbuntextamount.Location = new System.Drawing.Point(12, 73);
            this.lbuntextamount.Name = "lbuntextamount";
            this.lbuntextamount.Size = new System.Drawing.Size(97, 13);
            this.lbuntextamount.TabIndex = 16;
            this.lbuntextamount.Text = "Unconfirm Amount.";
            // 
            // txconfimr
            // 
            this.txconfimr.Location = new System.Drawing.Point(160, 121);
            this.txconfimr.Name = "txconfimr";
            this.txconfimr.Size = new System.Drawing.Size(169, 20);
            this.txconfimr.TabIndex = 1;
            this.txconfimr.TextChanged += new System.EventHandler(this.txconfimr_TextChanged);
            this.txconfimr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txconfimr_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Deposit Confirm Amount.";
            // 
            // lb_Docno
            // 
            this.lb_Docno.AutoSize = true;
            this.lb_Docno.Location = new System.Drawing.Point(162, 17);
            this.lb_Docno.Name = "lb_Docno";
            this.lb_Docno.Size = new System.Drawing.Size(35, 13);
            this.lb_Docno.TabIndex = 21;
            this.lb_Docno.Text = "label1";
            // 
            // lb_emptyrtamount
            // 
            this.lb_emptyrtamount.AutoSize = true;
            this.lb_emptyrtamount.Location = new System.Drawing.Point(162, 46);
            this.lb_emptyrtamount.Name = "lb_emptyrtamount";
            this.lb_emptyrtamount.Size = new System.Drawing.Size(35, 13);
            this.lb_emptyrtamount.TabIndex = 22;
            this.lb_emptyrtamount.Text = "label5";
            // 
            // lb_uncofirm
            // 
            this.lb_uncofirm.AutoSize = true;
            this.lb_uncofirm.Location = new System.Drawing.Point(162, 73);
            this.lb_uncofirm.Name = "lb_uncofirm";
            this.lb_uncofirm.Size = new System.Drawing.Size(35, 13);
            this.lb_uncofirm.TabIndex = 23;
            this.lb_uncofirm.Text = "label6";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lb_uncofirm);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbuntextamount);
            this.panel1.Controls.Add(this.txconfimr);
            this.panel1.Controls.Add(this.lb_emptyrtamount);
            this.panel1.Controls.Add(this.lb_doc);
            this.panel1.Controls.Add(this.lb_Docno);
            this.panel1.Controls.Add(this.lbtextamount);
            this.panel1.Location = new System.Drawing.Point(5, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 217);
            this.panel1.TabIndex = 24;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.White;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(6, 167);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(166, 45);
            this.trackBar1.TabIndex = 24;
            this.trackBar1.TabStop = false;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // Depositconfirmline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Depositconfirmline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deposit Confirm Line";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_doc;
        private System.Windows.Forms.Label lbtextamount;
        private System.Windows.Forms.Label lbuntextamount;
        private System.Windows.Forms.TextBox txconfimr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_Docno;
        private System.Windows.Forms.Label lb_emptyrtamount;
        private System.Windows.Forms.Label lb_uncofirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}