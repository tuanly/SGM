namespace SGM_Management
{
    partial class frmSGMReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSGMReport));
            this.tabSGMHistory = new System.Windows.Forms.TabControl();
            this.subTabSGMSaleGas = new System.Windows.Forms.TabPage();
            this.subTabSGMRechargeCard = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGasStation = new System.Windows.Forms.ComboBox();
            this.dgvSaleGasHistory = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpSaleGasBegin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSaleGasEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaleGasCardID = new System.Windows.Forms.TextBox();
            this.btnSaleGasView = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRechargeCardView = new System.Windows.Forms.Button();
            this.txtRechargeCardID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpRechargeCardEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpRechargeCardBegin = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dboRechargeCardCustomer = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvRechargeCardHistory = new System.Windows.Forms.DataGridView();
            this.tabSGMHistory.SuspendLayout();
            this.subTabSGMSaleGas.SuspendLayout();
            this.subTabSGMRechargeCard.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleGasHistory)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechargeCardHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSGMHistory
            // 
            this.tabSGMHistory.Controls.Add(this.subTabSGMSaleGas);
            this.tabSGMHistory.Controls.Add(this.subTabSGMRechargeCard);
            this.tabSGMHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSGMHistory.Location = new System.Drawing.Point(0, 0);
            this.tabSGMHistory.Name = "tabSGMHistory";
            this.tabSGMHistory.SelectedIndex = 0;
            this.tabSGMHistory.Size = new System.Drawing.Size(761, 485);
            this.tabSGMHistory.TabIndex = 0;
            // 
            // subTabSGMSaleGas
            // 
            this.subTabSGMSaleGas.Controls.Add(this.dgvSaleGasHistory);
            this.subTabSGMSaleGas.Controls.Add(this.groupBox1);
            this.subTabSGMSaleGas.Location = new System.Drawing.Point(4, 22);
            this.subTabSGMSaleGas.Name = "subTabSGMSaleGas";
            this.subTabSGMSaleGas.Padding = new System.Windows.Forms.Padding(3);
            this.subTabSGMSaleGas.Size = new System.Drawing.Size(753, 459);
            this.subTabSGMSaleGas.TabIndex = 0;
            this.subTabSGMSaleGas.Text = "Bán Xăng";
            this.subTabSGMSaleGas.UseVisualStyleBackColor = true;
            // 
            // subTabSGMRechargeCard
            // 
            this.subTabSGMRechargeCard.Controls.Add(this.dgvRechargeCardHistory);
            this.subTabSGMRechargeCard.Controls.Add(this.groupBox2);
            this.subTabSGMRechargeCard.Location = new System.Drawing.Point(4, 22);
            this.subTabSGMRechargeCard.Name = "subTabSGMRechargeCard";
            this.subTabSGMRechargeCard.Padding = new System.Windows.Forms.Padding(3);
            this.subTabSGMRechargeCard.Size = new System.Drawing.Size(753, 459);
            this.subTabSGMRechargeCard.TabIndex = 1;
            this.subTabSGMRechargeCard.Text = "Bán Thẻ";
            this.subTabSGMRechargeCard.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaleGasView);
            this.groupBox1.Controls.Add(this.txtSaleGasCardID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpSaleGasEnd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpSaleGasBegin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboGasStation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xem giao dịch: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trạm Xăng:";
            // 
            // cboGasStation
            // 
            this.cboGasStation.FormattingEnabled = true;
            this.cboGasStation.Location = new System.Drawing.Point(90, 23);
            this.cboGasStation.Name = "cboGasStation";
            this.cboGasStation.Size = new System.Drawing.Size(639, 21);
            this.cboGasStation.TabIndex = 1;
            // 
            // dgvSaleGasHistory
            // 
            this.dgvSaleGasHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleGasHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSaleGasHistory.Location = new System.Drawing.Point(3, 164);
            this.dgvSaleGasHistory.Name = "dgvSaleGasHistory";
            this.dgvSaleGasHistory.Size = new System.Drawing.Size(747, 292);
            this.dgvSaleGasHistory.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ ngày:";
            // 
            // dtpSaleGasBegin
            // 
            this.dtpSaleGasBegin.CustomFormat = "dd/MM/yyyy";
            this.dtpSaleGasBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSaleGasBegin.Location = new System.Drawing.Point(90, 61);
            this.dtpSaleGasBegin.Name = "dtpSaleGasBegin";
            this.dtpSaleGasBegin.Size = new System.Drawing.Size(98, 20);
            this.dtpSaleGasBegin.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đến ngày:";
            // 
            // dtpSaleGasEnd
            // 
            this.dtpSaleGasEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpSaleGasEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSaleGasEnd.Location = new System.Drawing.Point(256, 61);
            this.dtpSaleGasEnd.Name = "dtpSaleGasEnd";
            this.dtpSaleGasEnd.Size = new System.Drawing.Size(98, 20);
            this.dtpSaleGasEnd.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã thẻ:";
            // 
            // txtSaleGasCardID
            // 
            this.txtSaleGasCardID.Location = new System.Drawing.Point(90, 94);
            this.txtSaleGasCardID.Name = "txtSaleGasCardID";
            this.txtSaleGasCardID.Size = new System.Drawing.Size(264, 20);
            this.txtSaleGasCardID.TabIndex = 7;
            this.txtSaleGasCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSaleGasView
            // 
            this.btnSaleGasView.Location = new System.Drawing.Point(336, 126);
            this.btnSaleGasView.Name = "btnSaleGasView";
            this.btnSaleGasView.Size = new System.Drawing.Size(75, 23);
            this.btnSaleGasView.TabIndex = 8;
            this.btnSaleGasView.Text = "Xem";
            this.btnSaleGasView.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRechargeCardView);
            this.groupBox2.Controls.Add(this.txtRechargeCardID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpRechargeCardEnd);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpRechargeCardBegin);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dboRechargeCardCustomer);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(747, 161);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Xem giao dịch: ";
            // 
            // btnRechargeCardView
            // 
            this.btnRechargeCardView.Location = new System.Drawing.Point(207, 126);
            this.btnRechargeCardView.Name = "btnRechargeCardView";
            this.btnRechargeCardView.Size = new System.Drawing.Size(75, 23);
            this.btnRechargeCardView.TabIndex = 8;
            this.btnRechargeCardView.Text = "Xem";
            this.btnRechargeCardView.UseVisualStyleBackColor = true;
            // 
            // txtRechargeCardID
            // 
            this.txtRechargeCardID.Location = new System.Drawing.Point(90, 94);
            this.txtRechargeCardID.Name = "txtRechargeCardID";
            this.txtRechargeCardID.Size = new System.Drawing.Size(264, 20);
            this.txtRechargeCardID.TabIndex = 7;
            this.txtRechargeCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mã thẻ:";
            // 
            // dtpRechargeCardEnd
            // 
            this.dtpRechargeCardEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpRechargeCardEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRechargeCardEnd.Location = new System.Drawing.Point(256, 61);
            this.dtpRechargeCardEnd.Name = "dtpRechargeCardEnd";
            this.dtpRechargeCardEnd.Size = new System.Drawing.Size(98, 20);
            this.dtpRechargeCardEnd.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Đến ngày:";
            // 
            // dtpRechargeCardBegin
            // 
            this.dtpRechargeCardBegin.CustomFormat = "dd/MM/yyyy";
            this.dtpRechargeCardBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRechargeCardBegin.Location = new System.Drawing.Point(90, 61);
            this.dtpRechargeCardBegin.Name = "dtpRechargeCardBegin";
            this.dtpRechargeCardBegin.Size = new System.Drawing.Size(98, 20);
            this.dtpRechargeCardBegin.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Từ ngày:";
            // 
            // dboRechargeCardCustomer
            // 
            this.dboRechargeCardCustomer.FormattingEnabled = true;
            this.dboRechargeCardCustomer.Location = new System.Drawing.Point(90, 23);
            this.dboRechargeCardCustomer.Name = "dboRechargeCardCustomer";
            this.dboRechargeCardCustomer.Size = new System.Drawing.Size(382, 21);
            this.dboRechargeCardCustomer.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Khách hàng:";
            // 
            // dgvRechargeCardHistory
            // 
            this.dgvRechargeCardHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRechargeCardHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRechargeCardHistory.Location = new System.Drawing.Point(3, 164);
            this.dgvRechargeCardHistory.Name = "dgvRechargeCardHistory";
            this.dgvRechargeCardHistory.Size = new System.Drawing.Size(747, 292);
            this.dgvRechargeCardHistory.TabIndex = 2;
            // 
            // frmSGMReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 485);
            this.Controls.Add(this.tabSGMHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSGMReport";
            this.Text = "SGM - Lịch Sử Giao Dịch";
            this.tabSGMHistory.ResumeLayout(false);
            this.subTabSGMSaleGas.ResumeLayout(false);
            this.subTabSGMRechargeCard.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleGasHistory)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechargeCardHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSGMHistory;
        private System.Windows.Forms.TabPage subTabSGMSaleGas;
        private System.Windows.Forms.TabPage subTabSGMRechargeCard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSaleGasHistory;
        private System.Windows.Forms.ComboBox cboGasStation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSaleGasCardID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpSaleGasEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpSaleGasBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaleGasView;
        private System.Windows.Forms.DataGridView dgvRechargeCardHistory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRechargeCardView;
        private System.Windows.Forms.TextBox txtRechargeCardID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpRechargeCardEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpRechargeCardBegin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox dboRechargeCardCustomer;
        private System.Windows.Forms.Label label8;
    }
}