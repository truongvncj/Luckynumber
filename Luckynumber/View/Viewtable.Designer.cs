using System;

namespace Luckynumber.View
{
    partial class Viewtable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewtable));
            this.panel1 = new System.Windows.Forms.Panel();
            this.statussum = new System.Windows.Forms.Label();
            this.lb_totalrecord = new System.Windows.Forms.Label();
            this.Pl_endview = new System.Windows.Forms.Panel();
            this.lbpayment = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_unmaching = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_sumempty = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_tongdeposit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_tongamount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lb_seach = new System.Windows.Forms.Label();
            this.bt_exporttoex = new System.Windows.Forms.Button();
            this.btCaculmake = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.Pl_endview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.statussum);
            this.panel1.Controls.Add(this.lb_totalrecord);
            this.panel1.Controls.Add(this.Pl_endview);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(4, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1348, 428);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // statussum
            // 
            this.statussum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statussum.AutoSize = true;
            this.statussum.Location = new System.Drawing.Point(0, 409);
            this.statussum.Name = "statussum";
            this.statussum.Size = new System.Drawing.Size(70, 13);
            this.statussum.TabIndex = 1;
            this.statussum.Text = "Total record: ";
            // 
            // lb_totalrecord
            // 
            this.lb_totalrecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_totalrecord.AutoSize = true;
            this.lb_totalrecord.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalrecord.ForeColor = System.Drawing.Color.Red;
            this.lb_totalrecord.Location = new System.Drawing.Point(67, 409);
            this.lb_totalrecord.Name = "lb_totalrecord";
            this.lb_totalrecord.Size = new System.Drawing.Size(13, 14);
            this.lb_totalrecord.TabIndex = 2;
            this.lb_totalrecord.Text = "0";
            // 
            // Pl_endview
            // 
            this.Pl_endview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pl_endview.BackColor = System.Drawing.Color.Transparent;
            this.Pl_endview.Controls.Add(this.lbpayment);
            this.Pl_endview.Controls.Add(this.label4);
            this.Pl_endview.Controls.Add(this.lb_unmaching);
            this.Pl_endview.Controls.Add(this.Status);
            this.Pl_endview.Controls.Add(this.label7);
            this.Pl_endview.Controls.Add(this.lb_sumempty);
            this.Pl_endview.Controls.Add(this.label5);
            this.Pl_endview.Controls.Add(this.lb_tongdeposit);
            this.Pl_endview.Controls.Add(this.label3);
            this.Pl_endview.Controls.Add(this.lb_tongamount);
            this.Pl_endview.Controls.Add(this.label1);
            this.Pl_endview.ForeColor = System.Drawing.Color.Black;
            this.Pl_endview.Location = new System.Drawing.Point(158, 406);
            this.Pl_endview.Name = "Pl_endview";
            this.Pl_endview.Size = new System.Drawing.Size(1180, 19);
            this.Pl_endview.TabIndex = 1;
            // 
            // lbpayment
            // 
            this.lbpayment.AutoSize = true;
            this.lbpayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpayment.Location = new System.Drawing.Point(997, 4);
            this.lbpayment.Name = "lbpayment";
            this.lbpayment.Size = new System.Drawing.Size(13, 13);
            this.lbpayment.TabIndex = 10;
            this.lbpayment.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(904, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Payment_Amount";
            // 
            // lb_unmaching
            // 
            this.lb_unmaching.AutoSize = true;
            this.lb_unmaching.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_unmaching.Location = new System.Drawing.Point(345, 3);
            this.lb_unmaching.Name = "lb_unmaching";
            this.lb_unmaching.Size = new System.Drawing.Size(13, 13);
            this.lb_unmaching.TabIndex = 7;
            this.lb_unmaching.Text = "0";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.ForeColor = System.Drawing.Color.Red;
            this.Status.Location = new System.Drawing.Point(1173, 4);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(22, 13);
            this.Status.TabIndex = 8;
            this.Status.Text = "OK";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(252, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "FullGood_Amount:";
            // 
            // lb_sumempty
            // 
            this.lb_sumempty.AutoSize = true;
            this.lb_sumempty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sumempty.Location = new System.Drawing.Point(752, 3);
            this.lb_sumempty.Name = "lb_sumempty";
            this.lb_sumempty.Size = new System.Drawing.Size(13, 13);
            this.lb_sumempty.TabIndex = 5;
            this.lb_sumempty.Text = "0";
            this.lb_sumempty.Click += new System.EventHandler(this.lb_sumempty_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(671, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Empty_Amount:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lb_tongdeposit
            // 
            this.lb_tongdeposit.AutoSize = true;
            this.lb_tongdeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tongdeposit.Location = new System.Drawing.Point(534, 3);
            this.lb_tongdeposit.Name = "lb_tongdeposit";
            this.lb_tongdeposit.Size = new System.Drawing.Size(13, 13);
            this.lb_tongdeposit.TabIndex = 3;
            this.lb_tongdeposit.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(489, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Deposit:";
            // 
            // lb_tongamount
            // 
            this.lb_tongamount.AutoSize = true;
            this.lb_tongamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tongamount.Location = new System.Drawing.Point(93, 2);
            this.lb_tongamount.Name = "lb_tongamount";
            this.lb_tongamount.Size = new System.Drawing.Size(13, 13);
            this.lb_tongamount.TabIndex = 1;
            this.lb_tongamount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FBL5n_Amount:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(2, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.Size = new System.Drawing.Size(1342, 397);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // lb_seach
            // 
            this.lb_seach.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_seach.AutoSize = true;
            this.lb_seach.Font = new System.Drawing.Font("Perpetua Titling MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_seach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lb_seach.Location = new System.Drawing.Point(623, 12);
            this.lb_seach.Name = "lb_seach";
            this.lb_seach.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_seach.Size = new System.Drawing.Size(117, 16);
            this.lb_seach.TabIndex = 6;
            this.lb_seach.Text = "F3: Seach Code";
            this.lb_seach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bt_exporttoex
            // 
            this.bt_exporttoex.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bt_exporttoex.Location = new System.Drawing.Point(11, 11);
            this.bt_exporttoex.Name = "bt_exporttoex";
            this.bt_exporttoex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bt_exporttoex.Size = new System.Drawing.Size(114, 20);
            this.bt_exporttoex.TabIndex = 3;
            this.bt_exporttoex.Text = "Export to Excel";
            this.bt_exporttoex.UseVisualStyleBackColor = true;
            this.bt_exporttoex.Click += new System.EventHandler(this.bt_exporttoex_Click);
            // 
            // btCaculmake
            // 
            this.btCaculmake.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btCaculmake.Location = new System.Drawing.Point(131, 10);
            this.btCaculmake.Name = "btCaculmake";
            this.btCaculmake.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btCaculmake.Size = new System.Drawing.Size(143, 21);
            this.btCaculmake.TabIndex = 10;
            this.btCaculmake.Text = "Make Caculation ";
            this.btCaculmake.UseVisualStyleBackColor = true;
            this.btCaculmake.Click += new System.EventHandler(this.btCaculationProgr_Click);
            // 
            // Viewtable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 481);
            this.Controls.Add(this.btCaculmake);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_seach);
            this.Controls.Add(this.bt_exporttoex);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Viewtable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Viewtable_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Viewtable_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewtable_FormClosed);
            this.Load += new System.EventHandler(this.Viewtable_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Pl_endview.ResumeLayout(false);
            this.Pl_endview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     



        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label statussum;
        private System.Windows.Forms.Label lb_totalrecord;
        private System.Windows.Forms.Button bt_exporttoex;
        private System.Windows.Forms.Panel Pl_endview;
        private System.Windows.Forms.Label lb_unmaching;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_sumempty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_tongdeposit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_tongamount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label lbpayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_seach;
        private System.Windows.Forms.Button btCaculmake;
    }
}