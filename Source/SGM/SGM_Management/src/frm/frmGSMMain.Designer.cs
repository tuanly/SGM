namespace SGM_Management
{
    partial class frmGSMMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGSMMain));
            this.panelMain = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGasStation = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnUpdatePrice = new System.Windows.Forms.Button();
            this.btnUpdateStore = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.Panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelMain.IsSplitterFixed = true;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            // 
            // panelMain.Panel1
            // 
            this.panelMain.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.panelMain.Size = new System.Drawing.Size(732, 502);
            this.panelMain.SplitterDistance = 244;
            this.panelMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnGasStation, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnHome, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdatePrice, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdateStore, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCustomer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnAccount, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnReport, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 474);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnGasStation
            // 
            this.btnGasStation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGasStation.Location = new System.Drawing.Point(0, 100);
            this.btnGasStation.Margin = new System.Windows.Forms.Padding(0);
            this.btnGasStation.Name = "btnGasStation";
            this.btnGasStation.Size = new System.Drawing.Size(244, 50);
            this.btnGasStation.TabIndex = 2;
            this.btnGasStation.Text = "Quản Lý Trạm Xăng";
            this.btnGasStation.UseVisualStyleBackColor = true;
            this.btnGasStation.Click += new System.EventHandler(this.btnGasStation_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(244, 50);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "SGM";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUpdatePrice
            // 
            this.btnUpdatePrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdatePrice.Location = new System.Drawing.Point(0, 150);
            this.btnUpdatePrice.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdatePrice.Name = "btnUpdatePrice";
            this.btnUpdatePrice.Size = new System.Drawing.Size(244, 50);
            this.btnUpdatePrice.TabIndex = 3;
            this.btnUpdatePrice.Text = "Cập Nhật Giá Xăng";
            this.btnUpdatePrice.UseVisualStyleBackColor = true;
            this.btnUpdatePrice.Click += new System.EventHandler(this.btnUpdatePrice_Click);
            // 
            // btnUpdateStore
            // 
            this.btnUpdateStore.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdateStore.Location = new System.Drawing.Point(0, 200);
            this.btnUpdateStore.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdateStore.Name = "btnUpdateStore";
            this.btnUpdateStore.Size = new System.Drawing.Size(244, 50);
            this.btnUpdateStore.TabIndex = 4;
            this.btnUpdateStore.Text = "Cập Nhật Kho";
            this.btnUpdateStore.UseVisualStyleBackColor = true;
            this.btnUpdateStore.Click += new System.EventHandler(this.btnUpdateStore_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccount.Location = new System.Drawing.Point(0, 300);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(244, 50);
            this.btnAccount.TabIndex = 5;
            this.btnAccount.Text = "Tài Khoản";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.Location = new System.Drawing.Point(0, 50);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(244, 50);
            this.btnCustomer.TabIndex = 1;
            this.btnCustomer.Text = "Quản Lý Khách Hàng";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.Location = new System.Drawing.Point(0, 350);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(244, 44);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.Location = new System.Drawing.Point(0, 250);
            this.btnReport.Margin = new System.Windows.Forms.Padding(0);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(244, 50);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "Báo Cáo";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmGSMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 502);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGSMMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Quản Lý Xăng";
            this.Load += new System.EventHandler(this.frmGSMMain_Load);
            this.ResizeBegin += new System.EventHandler(this.frmGSMMain_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.frmGSMMain_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.frmGSMMain_SizeChanged);
            this.panelMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer panelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnGasStation;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnUpdatePrice;
        private System.Windows.Forms.Button btnUpdateStore;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReport;
    }
}