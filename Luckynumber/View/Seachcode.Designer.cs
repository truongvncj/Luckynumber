namespace Luckynumber.View
{
    partial class Seachcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Seachcode));
            this.label1 = new System.Windows.Forms.Label();
            this.sendingtext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gõ code cần tìm";
            // 
            // sendingtext
            // 
            this.sendingtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendingtext.Location = new System.Drawing.Point(15, 25);
            this.sendingtext.Name = "sendingtext";
            this.sendingtext.Size = new System.Drawing.Size(215, 32);
            this.sendingtext.TabIndex = 1;
            this.sendingtext.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.sendingtext.Enter += new System.EventHandler(this.sendingtext_Enter);
            this.sendingtext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingtext_KeyPress);
            // 
            // Seachcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 79);
            this.Controls.Add(this.sendingtext);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Seachcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seachcode";
            this.Deactivate += new System.EventHandler(this.Seachcode_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Seachcode_FormClosed);
            this.Leave += new System.EventHandler(this.Seachcode_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sendingtext;
    }
}