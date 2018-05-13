namespace arconfirmationletter.View
{
    using arconfirmationletter;
    using System.Windows.Forms;

    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 
       
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inputDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewProductsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userAndRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_user = new System.Windows.Forms.Label();
            this.lbusername = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lblocate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cUSTOMERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uPLOADCUSTOMERDATAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITCUSTOMERLISTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRDERBUYLISTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fREECASESORDERLISTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTORDERLOSTFREECASEPAYMENTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTORDERHAVEOVERFREECASEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTORDERWRONGMESSAGEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.oRDEROVERTIMEOFPROGARMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.oRDERWRONGSKILLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRDERENTRYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(5, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 419);
            this.panel1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = global::arconfirmationletter.Properties.Resources.coca_anim_48;
            this.pictureBox1.Image = global::arconfirmationletter.Properties.Resources.coca_anim_48;
            this.pictureBox1.InitialImage = global::arconfirmationletter.Properties.Resources.coca_anim_48;
            this.pictureBox1.Location = new System.Drawing.Point(191, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(456, 408);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputDataToolStripMenuItem,
            this.masterDataToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.systemConfigToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1048, 28);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // inputDataToolStripMenuItem
            // 
            this.inputDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem,
            this.cUSTOMERToolStripMenuItem});
            this.inputDataToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputDataToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inputDataToolStripMenuItem.Image")));
            this.inputDataToolStripMenuItem.Name = "inputDataToolStripMenuItem";
            this.inputDataToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.inputDataToolStripMenuItem.Text = "MASTER DATA";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewProductsListToolStripMenuItem,
            this.productCodeToolStripMenuItem});
            this.productToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.productToolStripMenuItem.Text = "PRODUCT";
            // 
            // viewProductsListToolStripMenuItem
            // 
            this.viewProductsListToolStripMenuItem.Name = "viewProductsListToolStripMenuItem";
            this.viewProductsListToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.viewProductsListToolStripMenuItem.Text = "VIEW PRODUCTS LIST";
            this.viewProductsListToolStripMenuItem.Click += new System.EventHandler(this.viewProductsListToolStripMenuItem_Click);
            // 
            // productCodeToolStripMenuItem
            // 
            this.productCodeToolStripMenuItem.Name = "productCodeToolStripMenuItem";
            this.productCodeToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.productCodeToolStripMenuItem.Text = "EDIT PRODUCTS LIST";
            this.productCodeToolStripMenuItem.Click += new System.EventHandler(this.productCodeToolStripMenuItem_Click);
            // 
            // masterDataToolStripMenuItem
            // 
            this.masterDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.dataCheckToolStripMenuItem,
            this.oRDERENTRYToolStripMenuItem});
            this.masterDataToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masterDataToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("masterDataToolStripMenuItem.Image")));
            this.masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            this.masterDataToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.masterDataToolStripMenuItem.Text = "DATA INPUT";
            this.masterDataToolStripMenuItem.Click += new System.EventHandler(this.masterDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // dataCheckToolStripMenuItem
            // 
            this.dataCheckToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dataCheckToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oRDERBUYLISTToolStripMenuItem,
            this.fREECASESORDERLISTToolStripMenuItem});
            this.dataCheckToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCheckToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dataCheckToolStripMenuItem.Image")));
            this.dataCheckToolStripMenuItem.Name = "dataCheckToolStripMenuItem";
            this.dataCheckToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.dataCheckToolStripMenuItem.Text = "UPLOAD VA05";
            this.dataCheckToolStripMenuItem.Click += new System.EventHandler(this.dataCheckToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.lISTORDERLOSTFREECASEPAYMENTToolStripMenuItem,
            this.lISTORDERHAVEOVERFREECASEToolStripMenuItem,
            this.lISTORDERWRONGMESSAGEToolStripMenuItem,
            this.toolStripSeparator2,
            this.oRDEROVERTIMEOFPROGARMEToolStripMenuItem,
            this.oRDERWRONGSKILLToolStripMenuItem});
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportsToolStripMenuItem.Image")));
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.reportsToolStripMenuItem.Text = "REPORTS";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // systemConfigToolStripMenuItem
            // 
            this.systemConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverNameToolStripMenuItem,
            this.userAndRightToolStripMenuItem});
            this.systemConfigToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemConfigToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemConfigToolStripMenuItem.Image")));
            this.systemConfigToolStripMenuItem.Name = "systemConfigToolStripMenuItem";
            this.systemConfigToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.systemConfigToolStripMenuItem.Text = "SYSTEM";
            this.systemConfigToolStripMenuItem.Click += new System.EventHandler(this.systemConfigToolStripMenuItem_Click);
            // 
            // serverNameToolStripMenuItem
            // 
            this.serverNameToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverNameToolStripMenuItem.Name = "serverNameToolStripMenuItem";
            this.serverNameToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.serverNameToolStripMenuItem.Text = "SERVER CONFIG";
            this.serverNameToolStripMenuItem.Click += new System.EventHandler(this.serverNameToolStripMenuItem_Click);
            // 
            // userAndRightToolStripMenuItem
            // 
            this.userAndRightToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAndRightToolStripMenuItem.Name = "userAndRightToolStripMenuItem";
            this.userAndRightToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.userAndRightToolStripMenuItem.Text = "USER && PASSWORD";
            this.userAndRightToolStripMenuItem.Click += new System.EventHandler(this.userAndRightToolStripMenuItem_Click);
            // 
            // lb_user
            // 
            this.lb_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_user.AutoSize = true;
            this.lb_user.Location = new System.Drawing.Point(9, 450);
            this.lb_user.Name = "lb_user";
            this.lb_user.Size = new System.Drawing.Size(58, 13);
            this.lb_user.TabIndex = 23;
            this.lb_user.Text = "User name";
            // 
            // lbusername
            // 
            this.lbusername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbusername.AutoSize = true;
            this.lbusername.ForeColor = System.Drawing.Color.Red;
            this.lbusername.Location = new System.Drawing.Point(73, 450);
            this.lbusername.Name = "lbusername";
            this.lbusername.Size = new System.Drawing.Size(35, 13);
            this.lbusername.TabIndex = 24;
            this.lbusername.Text = "label1";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(831, 31);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(205, 419);
            this.webBrowser1.TabIndex = 25;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.Url = new System.Uri("https://sites.google.com/site/advcocacolagogle/", System.UriKind.Absolute);
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // lblocate
            // 
            this.lblocate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblocate.AutoSize = true;
            this.lblocate.ForeColor = System.Drawing.Color.Red;
            this.lblocate.Location = new System.Drawing.Point(268, 453);
            this.lblocate.Name = "lblocate";
            this.lblocate.Size = new System.Drawing.Size(23, 13);
            this.lblocate.TabIndex = 27;
            this.lblocate.Text = "HN";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Region: ";
            // 
            // cUSTOMERToolStripMenuItem
            // 
            this.cUSTOMERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uPLOADCUSTOMERDATAToolStripMenuItem,
            this.eDITCUSTOMERLISTToolStripMenuItem});
            this.cUSTOMERToolStripMenuItem.Name = "cUSTOMERToolStripMenuItem";
            this.cUSTOMERToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.cUSTOMERToolStripMenuItem.Text = "CUSTOMER";
            // 
            // uPLOADCUSTOMERDATAToolStripMenuItem
            // 
            this.uPLOADCUSTOMERDATAToolStripMenuItem.Name = "uPLOADCUSTOMERDATAToolStripMenuItem";
            this.uPLOADCUSTOMERDATAToolStripMenuItem.Size = new System.Drawing.Size(238, 24);
            this.uPLOADCUSTOMERDATAToolStripMenuItem.Text = "UPLOAD CUSTOMER LIST";
            // 
            // eDITCUSTOMERLISTToolStripMenuItem
            // 
            this.eDITCUSTOMERLISTToolStripMenuItem.Name = "eDITCUSTOMERLISTToolStripMenuItem";
            this.eDITCUSTOMERLISTToolStripMenuItem.Size = new System.Drawing.Size(238, 24);
            this.eDITCUSTOMERLISTToolStripMenuItem.Text = "eDIT CUSTOMER LIST";
            // 
            // oRDERBUYLISTToolStripMenuItem
            // 
            this.oRDERBUYLISTToolStripMenuItem.Name = "oRDERBUYLISTToolStripMenuItem";
            this.oRDERBUYLISTToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.oRDERBUYLISTToolStripMenuItem.Text = "ORDER  BUY LIST";
            // 
            // fREECASESORDERLISTToolStripMenuItem
            // 
            this.fREECASESORDERLISTToolStripMenuItem.Name = "fREECASESORDERLISTToolStripMenuItem";
            this.fREECASESORDERLISTToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.fREECASESORDERLISTToolStripMenuItem.Text = "FREECASES ORDER LIST";
            // 
            // lISTORDERLOSTFREECASEPAYMENTToolStripMenuItem
            // 
            this.lISTORDERLOSTFREECASEPAYMENTToolStripMenuItem.Name = "lISTORDERLOSTFREECASEPAYMENTToolStripMenuItem";
            this.lISTORDERLOSTFREECASEPAYMENTToolStripMenuItem.Size = new System.Drawing.Size(297, 24);
            this.lISTORDERLOSTFREECASEPAYMENTToolStripMenuItem.Text = "ORDER LOST FREECASE ";
            // 
            // lISTORDERHAVEOVERFREECASEToolStripMenuItem
            // 
            this.lISTORDERHAVEOVERFREECASEToolStripMenuItem.Name = "lISTORDERHAVEOVERFREECASEToolStripMenuItem";
            this.lISTORDERHAVEOVERFREECASEToolStripMenuItem.Size = new System.Drawing.Size(297, 24);
            this.lISTORDERHAVEOVERFREECASEToolStripMenuItem.Text = "ORDER HAVE OVER BUGET";
            // 
            // lISTORDERWRONGMESSAGEToolStripMenuItem
            // 
            this.lISTORDERWRONGMESSAGEToolStripMenuItem.Name = "lISTORDERWRONGMESSAGEToolStripMenuItem";
            this.lISTORDERWRONGMESSAGEToolStripMenuItem.Size = new System.Drawing.Size(297, 24);
            this.lISTORDERWRONGMESSAGEToolStripMenuItem.Text = "ORDER WRONG MESSAGE";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(294, 6);
            // 
            // oRDEROVERTIMEOFPROGARMEToolStripMenuItem
            // 
            this.oRDEROVERTIMEOFPROGARMEToolStripMenuItem.Name = "oRDEROVERTIMEOFPROGARMEToolStripMenuItem";
            this.oRDEROVERTIMEOFPROGARMEToolStripMenuItem.Size = new System.Drawing.Size(297, 24);
            this.oRDEROVERTIMEOFPROGARMEToolStripMenuItem.Text = "ORDER OVERTIME OF PROGARME";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(294, 6);
            // 
            // oRDERWRONGSKILLToolStripMenuItem
            // 
            this.oRDERWRONGSKILLToolStripMenuItem.Name = "oRDERWRONGSKILLToolStripMenuItem";
            this.oRDERWRONGSKILLToolStripMenuItem.Size = new System.Drawing.Size(297, 24);
            this.oRDERWRONGSKILLToolStripMenuItem.Text = "ORDER WRONG SCHEME";
            // 
            // oRDERENTRYToolStripMenuItem
            // 
            this.oRDERENTRYToolStripMenuItem.Name = "oRDERENTRYToolStripMenuItem";
            this.oRDERENTRYToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.oRDERENTRYToolStripMenuItem.Text = "ORDER ENTRY";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 471);
            this.Controls.Add(this.lblocate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.lbusername);
            this.Controls.Add(this.lb_user);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lucky number";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userAndRightToolStripMenuItem;
        private System.Windows.Forms.Label lb_user;
        private System.Windows.Forms.ToolStripMenuItem dataCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem viewProductsListToolStripMenuItem;
        private PictureBox pictureBox1;
        private Label lbusername;
        private WebBrowser webBrowser1;
        private Label lblocate;
        private Label label2;
        private ToolStripMenuItem cUSTOMERToolStripMenuItem;
        private ToolStripMenuItem uPLOADCUSTOMERDATAToolStripMenuItem;
        private ToolStripMenuItem eDITCUSTOMERLISTToolStripMenuItem;
        private ToolStripMenuItem oRDERBUYLISTToolStripMenuItem;
        private ToolStripMenuItem fREECASESORDERLISTToolStripMenuItem;
        private ToolStripMenuItem oRDERENTRYToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem lISTORDERLOSTFREECASEPAYMENTToolStripMenuItem;
        private ToolStripMenuItem lISTORDERHAVEOVERFREECASEToolStripMenuItem;
        private ToolStripMenuItem lISTORDERWRONGMESSAGEToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem oRDEROVERTIMEOFPROGARMEToolStripMenuItem;
        private ToolStripMenuItem oRDERWRONGSKILLToolStripMenuItem;
    }
}

