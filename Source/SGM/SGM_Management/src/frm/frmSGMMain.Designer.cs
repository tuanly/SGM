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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGasStation = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnUpdatePrice = new System.Windows.Forms.Button();
            this.btnUpdateStore = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
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
            this.panelMain.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMain.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // panelMain.Panel2
            // 
            this.panelMain.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMain.Panel2.BackgroundImage")));
            this.panelMain.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMain.Size = new System.Drawing.Size(732, 502);
            this.panelMain.SplitterDistance = 244;
            this.panelMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnGasStation, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnHome, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdatePrice, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdateStore, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCustomer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnConfig, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnAccount, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnReport, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 453);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnExit.Location = new System.Drawing.Point(0, 400);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(244, 50);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Thoát >>";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGasStation
            // 
            this.btnGasStation.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnGasStation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGasStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGasStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGasStation.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnGasStation.Location = new System.Drawing.Point(0, 100);
            this.btnGasStation.Margin = new System.Windows.Forms.Padding(0);
            this.btnGasStation.Name = "btnGasStation";
            this.btnGasStation.Size = new System.Drawing.Size(244, 50);
            this.btnGasStation.TabIndex = 2;
            this.btnGasStation.Text = "Quản Lý Trạm Xăng >>";
            this.btnGasStation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGasStation.UseVisualStyleBackColor = false;
            this.btnGasStation.Click += new System.EventHandler(this.btnGasStation_Click);
            this.btnGasStation.Enter += new System.EventHandler(this.btnGasStation_Enter);
            this.btnGasStation.Leave += new System.EventHandler(this.btnGasStation_Leave);
            this.btnGasStation.MouseLeave += new System.EventHandler(this.btnGasStation_MouseLeave);
            this.btnGasStation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnGasStation_MouseMove);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(244, 50);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "SGM >>";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.button3_Click);
            this.btnHome.Enter += new System.EventHandler(this.btnHome_Enter);
            this.btnHome.Leave += new System.EventHandler(this.btnHome_Leave);
            this.btnHome.MouseLeave += new System.EventHandler(this.btnHome_MouseLeave);
            this.btnHome.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnHome_MouseMove);
            // 
            // btnUpdatePrice
            // 
            this.btnUpdatePrice.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnUpdatePrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdatePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePrice.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnUpdatePrice.Location = new System.Drawing.Point(0, 150);
            this.btnUpdatePrice.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdatePrice.Name = "btnUpdatePrice";
            this.btnUpdatePrice.Size = new System.Drawing.Size(244, 50);
            this.btnUpdatePrice.TabIndex = 3;
            this.btnUpdatePrice.Text = "Cập Nhật Giá Xăng >>";
            this.btnUpdatePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdatePrice.UseVisualStyleBackColor = false;
            this.btnUpdatePrice.Click += new System.EventHandler(this.btnUpdatePrice_Click);
            this.btnUpdatePrice.Enter += new System.EventHandler(this.btnUpdatePrice_Enter);
            this.btnUpdatePrice.Leave += new System.EventHandler(this.btnUpdatePrice_Leave);
            this.btnUpdatePrice.MouseLeave += new System.EventHandler(this.btnUpdatePrice_MouseLeave);
            this.btnUpdatePrice.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnUpdatePrice_MouseMove);
            // 
            // btnUpdateStore
            // 
            this.btnUpdateStore.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnUpdateStore.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdateStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStore.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnUpdateStore.Location = new System.Drawing.Point(0, 200);
            this.btnUpdateStore.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdateStore.Name = "btnUpdateStore";
            this.btnUpdateStore.Size = new System.Drawing.Size(244, 50);
            this.btnUpdateStore.TabIndex = 4;
            this.btnUpdateStore.Text = "Cập Nhật Kho >>";
            this.btnUpdateStore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateStore.UseVisualStyleBackColor = false;
            this.btnUpdateStore.Click += new System.EventHandler(this.btnUpdateStore_Click);
            this.btnUpdateStore.Enter += new System.EventHandler(this.btnUpdateStore_Enter);
            this.btnUpdateStore.Leave += new System.EventHandler(this.btnUpdateStore_Leave);
            this.btnUpdateStore.MouseLeave += new System.EventHandler(this.btnUpdateStore_MouseLeave);
            this.btnUpdateStore.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnUpdateStore_MouseMove);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnCustomer.Location = new System.Drawing.Point(0, 50);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(244, 50);
            this.btnCustomer.TabIndex = 1;
            this.btnCustomer.Text = "Quản Lý Khách Hàng >>";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            this.btnCustomer.Enter += new System.EventHandler(this.btnCustomer_Enter);
            this.btnCustomer.Leave += new System.EventHandler(this.btnCustomer_Leave);
            this.btnCustomer.MouseLeave += new System.EventHandler(this.btnCustomer_MouseLeave);
            this.btnCustomer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCustomer_MouseMove);
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnConfig.Location = new System.Drawing.Point(0, 350);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(244, 50);
            this.btnConfig.TabIndex = 8;
            this.btnConfig.Text = "Cấu Hình >>";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnExit_Click_1);
            this.btnConfig.Enter += new System.EventHandler(this.btnExit_Enter);
            this.btnConfig.Leave += new System.EventHandler(this.btnExit_Leave);
            this.btnConfig.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            this.btnConfig.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExit_MouseMove);
            // 
            // btnAccount
            // 
            this.btnAccount.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAccount.Location = new System.Drawing.Point(0, 300);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(244, 50);
            this.btnAccount.TabIndex = 5;
            this.btnAccount.Text = "Tài Khoản >>";
            this.btnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccount.UseVisualStyleBackColor = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            this.btnAccount.Enter += new System.EventHandler(this.btnAccount_Enter);
            this.btnAccount.Leave += new System.EventHandler(this.btnAccount_Leave);
            this.btnAccount.MouseLeave += new System.EventHandler(this.btnAccount_MouseLeave);
            this.btnAccount.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAccount_MouseMove);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnReport.Location = new System.Drawing.Point(0, 250);
            this.btnReport.Margin = new System.Windows.Forms.Padding(0);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(244, 50);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "Báo Cáo >>";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            this.btnReport.Enter += new System.EventHandler(this.btnReport_Enter);
            this.btnReport.Leave += new System.EventHandler(this.btnReport_Leave);
            this.btnReport.MouseLeave += new System.EventHandler(this.btnReport_MouseLeave);
            this.btnReport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnReport_MouseMove);
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
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnExit;
    }
}