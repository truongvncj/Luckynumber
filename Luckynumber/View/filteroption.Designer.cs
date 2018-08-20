namespace Luckynumber.View
{
    partial class filteroption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(filteroption));
            this.button1 = new System.Windows.Forms.Button();
            this.checkalldata = new System.Windows.Forms.CheckBox();
            this.checkonlymainfiter = new System.Windows.Forms.CheckBox();
            this.cbcode = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbregion = new System.Windows.Forms.ComboBox();
            this.optionlabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thực hiện";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkalldata
            // 
            this.checkalldata.AutoSize = true;
            this.checkalldata.Location = new System.Drawing.Point(19, 19);
            this.checkalldata.Name = "checkalldata";
            this.checkalldata.Size = new System.Drawing.Size(172, 17);
            this.checkalldata.TabIndex = 2;
            this.checkalldata.Text = "Hiển thị toàn bộ dữ liệu kỳ  này";
            this.checkalldata.UseVisualStyleBackColor = true;
            this.checkalldata.CheckedChanged += new System.EventHandler(this.checkalldata_CheckedChanged);
            // 
            // checkonlymainfiter
            // 
            this.checkonlymainfiter.AutoSize = true;
            this.checkonlymainfiter.Location = new System.Drawing.Point(19, 43);
            this.checkonlymainfiter.Name = "checkonlymainfiter";
            this.checkonlymainfiter.Size = new System.Drawing.Size(177, 17);
            this.checkonlymainfiter.TabIndex = 3;
            this.checkonlymainfiter.Text = "Hiển thị riêng code/ GroupCode";
            this.checkonlymainfiter.UseVisualStyleBackColor = true;
            this.checkonlymainfiter.CheckedChanged += new System.EventHandler(this.checkonlymainfiter_CheckedChanged);
            // 
            // cbcode
            // 
            this.cbcode.FormattingEnabled = true;
            this.cbcode.Location = new System.Drawing.Point(131, 69);
            this.cbcode.Name = "cbcode";
            this.cbcode.Size = new System.Drawing.Size(273, 21);
            this.cbcode.TabIndex = 4;
            this.cbcode.TextUpdate += new System.EventHandler(this.cbcode_TextUpdate);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbregion);
            this.groupBox1.Controls.Add(this.optionlabel);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbcode);
            this.groupBox1.Controls.Add(this.checkonlymainfiter);
            this.groupBox1.Controls.Add(this.checkalldata);
            this.groupBox1.Location = new System.Drawing.Point(7, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 162);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Region";
            // 
            // cbregion
            // 
            this.cbregion.FormattingEnabled = true;
            this.cbregion.Location = new System.Drawing.Point(131, 93);
            this.cbregion.Name = "cbregion";
            this.cbregion.Size = new System.Drawing.Size(65, 21);
            this.cbregion.TabIndex = 6;
            // 
            // optionlabel
            // 
            this.optionlabel.AutoSize = true;
            this.optionlabel.Location = new System.Drawing.Point(16, 77);
            this.optionlabel.Name = "optionlabel";
            this.optionlabel.Size = new System.Drawing.Size(97, 13);
            this.optionlabel.TabIndex = 5;
            this.optionlabel.Text = "Code/ Group Code";
            // 
            // filteroption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 159);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "filteroption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter Option";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkalldata;
        private System.Windows.Forms.CheckBox checkonlymainfiter;
        private System.Windows.Forms.ComboBox cbcode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbregion;
        private System.Windows.Forms.Label optionlabel;
    }
}