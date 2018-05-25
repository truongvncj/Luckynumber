namespace arconfirmationletter.View
{
    partial class inputselectvalue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inputselectvalue));
            this.button1 = new System.Windows.Forms.Button();
            this.cbselect = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttieude = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(222, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Chọn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbselect
            // 
            this.cbselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbselect.FormattingEnabled = true;
            this.cbselect.Location = new System.Drawing.Point(9, 45);
            this.cbselect.Name = "cbselect";
            this.cbselect.Size = new System.Drawing.Size(341, 24);
            this.cbselect.TabIndex = 4;
            this.cbselect.TextUpdate += new System.EventHandler(this.cbcode_TextUpdate);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttieude);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbselect);
            this.groupBox1.Location = new System.Drawing.Point(7, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 123);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // txttieude
            // 
            this.txttieude.AutoSize = true;
            this.txttieude.Location = new System.Drawing.Point(6, 16);
            this.txttieude.Name = "txttieude";
            this.txttieude.Size = new System.Drawing.Size(66, 13);
            this.txttieude.TabIndex = 5;
            this.txttieude.Text = "Select value";
            // 
            // inputselectvalue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 123);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inputselectvalue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn chương trình";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbselect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txttieude;
    }
}