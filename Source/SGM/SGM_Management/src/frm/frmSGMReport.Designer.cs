﻿namespace SGM_Management
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
            this.crvSaleGas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaleGasView = new System.Windows.Forms.Button();
            this.txtSaleGasCardID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpSaleGasEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSaleGasBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboGasStation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subTabSGMRechargeCard = new System.Windows.Forms.TabPage();
            this.cardReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dgvRechargeCardHistory = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRechargeCardView = new System.Windows.Forms.Button();
            this.txtRechargeCardID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpRechargeCardEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpRechargeCardBegin = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cboRechargeCardCustomer = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboGasStore = new System.Windows.Forms.ComboBox();
            this.tabSGMHistory.SuspendLayout();
            this.subTabSGMSaleGas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.subTabSGMRechargeCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechargeCardHistory)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.tabSGMHistory.Size = new System.Drawing.Size(761, 659);
            this.tabSGMHistory.TabIndex = 0;
            // 
            // subTabSGMSaleGas
            // 
            this.subTabSGMSaleGas.Controls.Add(this.crvSaleGas);
            this.subTabSGMSaleGas.Controls.Add(this.groupBox1);
            this.subTabSGMSaleGas.Location = new System.Drawing.Point(4, 22);
            this.subTabSGMSaleGas.Name = "subTabSGMSaleGas";
            this.subTabSGMSaleGas.Padding = new System.Windows.Forms.Padding(3);
            this.subTabSGMSaleGas.Size = new System.Drawing.Size(753, 633);
            this.subTabSGMSaleGas.TabIndex = 0;
            this.subTabSGMSaleGas.Text = "Bán Xăng";
            this.subTabSGMSaleGas.UseVisualStyleBackColor = true;
            // 
            // crvSaleGas
            // 
            this.crvSaleGas.ActiveViewIndex = -1;
            this.crvSaleGas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSaleGas.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvSaleGas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvSaleGas.Location = new System.Drawing.Point(3, 206);
            this.crvSaleGas.Name = "crvSaleGas";
            this.crvSaleGas.ReuseParameterValuesOnRefresh = true;
            this.crvSaleGas.ShowGroupTreeButton = false;
            this.crvSaleGas.ShowLogo = false;
            this.crvSaleGas.ShowParameterPanelButton = false;
            this.crvSaleGas.ShowRefreshButton = false;
            this.crvSaleGas.Size = new System.Drawing.Size(747, 424);
            this.crvSaleGas.TabIndex = 1;
            this.crvSaleGas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboGasStore);
            this.groupBox1.Controls.Add(this.label9);
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
            this.groupBox1.Size = new System.Drawing.Size(747, 203);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xem giao dịch: ";
            // 
            // btnSaleGasView
            // 
            this.btnSaleGasView.Location = new System.Drawing.Point(336, 165);
            this.btnSaleGasView.Name = "btnSaleGasView";
            this.btnSaleGasView.Size = new System.Drawing.Size(75, 23);
            this.btnSaleGasView.TabIndex = 8;
            this.btnSaleGasView.Text = "Xem";
            this.btnSaleGasView.UseVisualStyleBackColor = true;
            this.btnSaleGasView.Click += new System.EventHandler(this.btnSaleGasView_Click);
            // 
            // txtSaleGasCardID
            // 
            this.txtSaleGasCardID.Location = new System.Drawing.Point(90, 133);
            this.txtSaleGasCardID.Name = "txtSaleGasCardID";
            this.txtSaleGasCardID.Size = new System.Drawing.Size(264, 20);
            this.txtSaleGasCardID.TabIndex = 7;
            this.txtSaleGasCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã thẻ:";
            // 
            // dtpSaleGasEnd
            // 
            this.dtpSaleGasEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpSaleGasEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSaleGasEnd.Location = new System.Drawing.Point(256, 100);
            this.dtpSaleGasEnd.Name = "dtpSaleGasEnd";
            this.dtpSaleGasEnd.Size = new System.Drawing.Size(98, 20);
            this.dtpSaleGasEnd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đến ngày:";
            // 
            // dtpSaleGasBegin
            // 
            this.dtpSaleGasBegin.CustomFormat = "dd/MM/yyyy";
            this.dtpSaleGasBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSaleGasBegin.Location = new System.Drawing.Point(90, 100);
            this.dtpSaleGasBegin.Name = "dtpSaleGasBegin";
            this.dtpSaleGasBegin.Size = new System.Drawing.Size(98, 20);
            this.dtpSaleGasBegin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ ngày:";
            // 
            // cboGasStation
            // 
            this.cboGasStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGasStation.FormattingEnabled = true;
            this.cboGasStation.Location = new System.Drawing.Point(90, 62);
            this.cboGasStation.Name = "cboGasStation";
            this.cboGasStation.Size = new System.Drawing.Size(639, 21);
            this.cboGasStation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trạm Xăng:";
            // 
            // subTabSGMRechargeCard
            // 
            this.subTabSGMRechargeCard.Controls.Add(this.cardReportViewer);
            this.subTabSGMRechargeCard.Controls.Add(this.dgvRechargeCardHistory);
            this.subTabSGMRechargeCard.Controls.Add(this.groupBox2);
            this.subTabSGMRechargeCard.Location = new System.Drawing.Point(4, 22);
            this.subTabSGMRechargeCard.Name = "subTabSGMRechargeCard";
            this.subTabSGMRechargeCard.Padding = new System.Windows.Forms.Padding(3);
            this.subTabSGMRechargeCard.Size = new System.Drawing.Size(753, 633);
            this.subTabSGMRechargeCard.TabIndex = 1;
            this.subTabSGMRechargeCard.Text = "Bán Thẻ";
            this.subTabSGMRechargeCard.UseVisualStyleBackColor = true;
            // 
            // cardReportViewer
            // 
            this.cardReportViewer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cardReportViewer.Location = new System.Drawing.Point(3, 384);
            this.cardReportViewer.Name = "cardReportViewer";
            this.cardReportViewer.Size = new System.Drawing.Size(747, 246);
            this.cardReportViewer.TabIndex = 3;
            // 
            // dgvRechargeCardHistory
            // 
            this.dgvRechargeCardHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRechargeCardHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRechargeCardHistory.Location = new System.Drawing.Point(3, 164);
            this.dgvRechargeCardHistory.Name = "dgvRechargeCardHistory";
            this.dgvRechargeCardHistory.Size = new System.Drawing.Size(747, 466);
            this.dgvRechargeCardHistory.TabIndex = 2;
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
            this.groupBox2.Controls.Add(this.cboRechargeCardCustomer);
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
            this.btnRechargeCardView.Location = new System.Drawing.Point(336, 126);
            this.btnRechargeCardView.Name = "btnRechargeCardView";
            this.btnRechargeCardView.Size = new System.Drawing.Size(75, 23);
            this.btnRechargeCardView.TabIndex = 8;
            this.btnRechargeCardView.Text = "Xem";
            this.btnRechargeCardView.UseVisualStyleBackColor = true;
            this.btnRechargeCardView.Click += new System.EventHandler(this.btnRechargeCardView_Click);
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
            // cboRechargeCardCustomer
            // 
            this.cboRechargeCardCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRechargeCardCustomer.FormattingEnabled = true;
            this.cboRechargeCardCustomer.Location = new System.Drawing.Point(90, 23);
            this.cboRechargeCardCustomer.Name = "cboRechargeCardCustomer";
            this.cboRechargeCardCustomer.Size = new System.Drawing.Size(382, 21);
            this.cboRechargeCardCustomer.TabIndex = 1;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Kho :";
            // 
            // cboGasStore
            // 
            this.cboGasStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGasStore.FormattingEnabled = true;
            this.cboGasStore.Location = new System.Drawing.Point(89, 27);
            this.cboGasStore.Name = "cboGasStore";
            this.cboGasStore.Size = new System.Drawing.Size(639, 21);
            this.cboGasStore.TabIndex = 10;
            this.cboGasStore.SelectedIndexChanged += new System.EventHandler(this.cboGasStore_SelectedIndexChanged);
            // 
            // frmSGMReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 659);
            this.Controls.Add(this.tabSGMHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSGMReport";
            this.Text = "SGM - Lịch Sử Giao Dịch";
            this.Load += new System.EventHandler(this.frmSGMReport_Load);
            this.tabSGMHistory.ResumeLayout(false);
            this.subTabSGMSaleGas.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.subTabSGMRechargeCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechargeCardHistory)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSGMHistory;
        private System.Windows.Forms.TabPage subTabSGMSaleGas;
        private System.Windows.Forms.TabPage subTabSGMRechargeCard;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.ComboBox cboRechargeCardCustomer;
        private System.Windows.Forms.Label label8;
        private Microsoft.Reporting.WinForms.ReportViewer cardReportViewer;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSaleGas;
        private System.Windows.Forms.ComboBox cboGasStore;
        private System.Windows.Forms.Label label9;
    }
}