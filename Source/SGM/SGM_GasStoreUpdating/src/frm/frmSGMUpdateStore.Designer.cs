namespace SGM_GasStoreUpdating
{
    partial class frmSGMUpdateStore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSGMUpdateStore));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGas92Current = new System.Windows.Forms.TextBox();
            this.txtGas95Current = new System.Windows.Forms.TextBox();
            this.txtGasDOCurrent = new System.Windows.Forms.TextBox();
            this.txtGasDONew = new System.Windows.Forms.TextBox();
            this.txtGas95New = new System.Windows.Forms.TextBox();
            this.txtGas92New = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGasStoreUpdate = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGasStoreUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hiện tại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Xăng 92";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Xăng 95";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dầu DO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nhập thêm:";
            // 
            // txtGas92Current
            // 
            this.txtGas92Current.Enabled = false;
            this.txtGas92Current.Location = new System.Drawing.Point(84, 90);
            this.txtGas92Current.Name = "txtGas92Current";
            this.txtGas92Current.ReadOnly = true;
            this.txtGas92Current.Size = new System.Drawing.Size(79, 20);
            this.txtGas92Current.TabIndex = 5;
            this.txtGas92Current.Text = "100.0";
            this.txtGas92Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGas95Current
            // 
            this.txtGas95Current.Enabled = false;
            this.txtGas95Current.Location = new System.Drawing.Point(204, 90);
            this.txtGas95Current.Name = "txtGas95Current";
            this.txtGas95Current.ReadOnly = true;
            this.txtGas95Current.Size = new System.Drawing.Size(79, 20);
            this.txtGas95Current.TabIndex = 6;
            this.txtGas95Current.Text = "25.50";
            this.txtGas95Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGasDOCurrent
            // 
            this.txtGasDOCurrent.Enabled = false;
            this.txtGasDOCurrent.Location = new System.Drawing.Point(339, 90);
            this.txtGasDOCurrent.Name = "txtGasDOCurrent";
            this.txtGasDOCurrent.ReadOnly = true;
            this.txtGasDOCurrent.Size = new System.Drawing.Size(79, 20);
            this.txtGasDOCurrent.TabIndex = 7;
            this.txtGasDOCurrent.Text = "100000.15";
            this.txtGasDOCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGasDONew
            // 
            this.txtGasDONew.Location = new System.Drawing.Point(339, 132);
            this.txtGasDONew.Name = "txtGasDONew";
            this.txtGasDONew.Size = new System.Drawing.Size(79, 20);
            this.txtGasDONew.TabIndex = 10;
            this.txtGasDONew.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGas95New
            // 
            this.txtGas95New.Location = new System.Drawing.Point(204, 132);
            this.txtGas95New.Name = "txtGas95New";
            this.txtGas95New.Size = new System.Drawing.Size(79, 20);
            this.txtGas95New.TabIndex = 9;
            this.txtGas95New.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGas92New
            // 
            this.txtGas92New.Location = new System.Drawing.Point(84, 132);
            this.txtGas92New.Name = "txtGas92New";
            this.txtGas92New.Size = new System.Drawing.Size(79, 20);
            this.txtGas92New.TabIndex = 8;
            this.txtGas92New.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "(L)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "(L)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(419, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "(L)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(419, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "(L)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "(L)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(165, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "(L)";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(168, 219);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(112, 24);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Ghi Chú:";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(84, 167);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(334, 40);
            this.txtNote.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGasStoreUpdate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 210);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lịch sử:";
            // 
            // dgvGasStoreUpdate
            // 
            this.dgvGasStoreUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGasStoreUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGasStoreUpdate.Location = new System.Drawing.Point(3, 16);
            this.dgvGasStoreUpdate.Name = "dgvGasStoreUpdate";
            this.dgvGasStoreUpdate.Size = new System.Drawing.Size(454, 191);
            this.dgvGasStoreUpdate.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(460, 65);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "KHO XĂNG DẦU HẬU GIANG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSGMUpdateStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 456);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGasDONew);
            this.Controls.Add(this.txtGas95New);
            this.Controls.Add(this.txtGas92New);
            this.Controls.Add(this.txtGasDOCurrent);
            this.Controls.Add(this.txtGas95Current);
            this.Controls.Add(this.txtGas92Current);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSGMUpdateStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SGM - Cập Nhật Tổng Kho";
            this.Load += new System.EventHandler(this.frmSGMUpdateStore_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGasStoreUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGas92Current;
        private System.Windows.Forms.TextBox txtGas95Current;
        private System.Windows.Forms.TextBox txtGasDOCurrent;
        private System.Windows.Forms.TextBox txtGasDONew;
        private System.Windows.Forms.TextBox txtGas95New;
        private System.Windows.Forms.TextBox txtGas92New;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvGasStoreUpdate;
        private System.Windows.Forms.Label lblTitle;
    }
}