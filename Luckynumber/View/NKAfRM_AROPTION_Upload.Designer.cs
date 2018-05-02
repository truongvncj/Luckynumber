namespace arconfirmationletter.View
{
    partial class NKAfRM_AROPTION_Upload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NKAfRM_AROPTION_Upload));
            this.label2 = new System.Windows.Forms.Label();
            this.pk_todate = new System.Windows.Forms.DateTimePicker();
            this.bt_okthuchien = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pk_returndate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Công nợ đến ngày";
            // 
            // pk_todate
            // 
            this.pk_todate.CustomFormat = "dd.MM.yyyy";
            this.pk_todate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pk_todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pk_todate.Location = new System.Drawing.Point(195, 49);
            this.pk_todate.Name = "pk_todate";
            this.pk_todate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pk_todate.Size = new System.Drawing.Size(131, 26);
            this.pk_todate.TabIndex = 2;
            this.pk_todate.Value = new System.DateTime(2015, 11, 22, 11, 48, 55, 0);
            this.pk_todate.ValueChanged += new System.EventHandler(this.pk_todate_ValueChanged);
            this.pk_todate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pk_todate_KeyDown);
            // 
            // bt_okthuchien
            // 
            this.bt_okthuchien.Location = new System.Drawing.Point(130, 153);
            this.bt_okthuchien.Name = "bt_okthuchien";
            this.bt_okthuchien.Size = new System.Drawing.Size(97, 27);
            this.bt_okthuchien.TabIndex = 4;
            this.bt_okthuchien.Text = "Thực hiện";
            this.bt_okthuchien.UseVisualStyleBackColor = true;
            this.bt_okthuchien.Click += new System.EventHandler(this.bt_okthuchien_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(105, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "DATA OPTION";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(82, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ngày trả thư";
            // 
            // pk_returndate
            // 
            this.pk_returndate.CustomFormat = "dd.MM.yyyy";
            this.pk_returndate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pk_returndate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pk_returndate.Location = new System.Drawing.Point(195, 84);
            this.pk_returndate.Name = "pk_returndate";
            this.pk_returndate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pk_returndate.Size = new System.Drawing.Size(131, 26);
            this.pk_returndate.TabIndex = 12;
            this.pk_returndate.Value = new System.DateTime(2015, 11, 27, 5, 55, 4, 0);
            this.pk_returndate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datelinePicker1_KeyDown);
            // 
            // NKAfRM_AROPTION_Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(364, 201);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pk_returndate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_okthuchien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pk_todate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NKAfRM_AROPTION_Upload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sumary Upload";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker pk_todate;
        private System.Windows.Forms.Button bt_okthuchien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker pk_returndate;
    }
}