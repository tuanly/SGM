namespace SGM_SaleGas
{
    partial class frmSGMSaleGas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSGMSaleGas));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCurrentPrice = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCardName = new System.Windows.Forms.TextBox();
            this.btnCardDetail = new System.Windows.Forms.Button();
            this.txtCardMoney = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.rbGasDO = new System.Windows.Forms.RadioButton();
            this.rbGas95 = new System.Windows.Forms.RadioButton();
            this.rbGas92 = new System.Windows.Forms.RadioButton();
            this.grBill = new System.Windows.Forms.GroupBox();
            this.txtMoneyBefore = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGasType = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGasBuying = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMoneyAfter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMoneyBuying = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timeCardReader = new System.Windows.Forms.Timer(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.timeMain = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Green;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(818, 65);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TRẠM XĂNG DẦU HAMACO";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPrice
            // 
            this.lblCurrentPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCurrentPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPrice.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentPrice.Location = new System.Drawing.Point(0, 662);
            this.lblCurrentPrice.Name = "lblCurrentPrice";
            this.lblCurrentPrice.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.lblCurrentPrice.Size = new System.Drawing.Size(818, 35);
            this.lblCurrentPrice.TabIndex = 1;
            this.lblCurrentPrice.Text = "Giá xăng hiện tại: DO : 25 000, X92: 23 000, X95: 27 000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCardName);
            this.groupBox1.Controls.Add(this.btnCardDetail);
            this.groupBox1.Controls.Add(this.txtCardMoney);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 103);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thẻ:";
            // 
            // txtCardName
            // 
            this.txtCardName.Enabled = false;
            this.txtCardName.ForeColor = System.Drawing.Color.Teal;
            this.txtCardName.Location = new System.Drawing.Point(123, 46);
            this.txtCardName.Name = "txtCardName";
            this.txtCardName.ReadOnly = true;
            this.txtCardName.Size = new System.Drawing.Size(236, 35);
            this.txtCardName.TabIndex = 5;
            this.txtCardName.Text = "N/A";
            this.txtCardName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCardDetail
            // 
            this.btnCardDetail.Location = new System.Drawing.Point(365, 47);
            this.btnCardDetail.Name = "btnCardDetail";
            this.btnCardDetail.Size = new System.Drawing.Size(42, 33);
            this.btnCardDetail.TabIndex = 0;
            this.btnCardDetail.Text = "+";
            this.btnCardDetail.UseVisualStyleBackColor = true;
            this.btnCardDetail.Click += new System.EventHandler(this.btnCardDetail_Click);
            // 
            // txtCardMoney
            // 
            this.txtCardMoney.Enabled = false;
            this.txtCardMoney.ForeColor = System.Drawing.Color.Teal;
            this.txtCardMoney.Location = new System.Drawing.Point(510, 44);
            this.txtCardMoney.Name = "txtCardMoney";
            this.txtCardMoney.ReadOnly = true;
            this.txtCardMoney.Size = new System.Drawing.Size(269, 35);
            this.txtCardMoney.TabIndex = 4;
            this.txtCardMoney.Text = "0,000";
            this.txtCardMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số tiền:";
            // 
            // txtCardID
            // 
            this.txtCardID.Enabled = false;
            this.txtCardID.ForeColor = System.Drawing.Color.Teal;
            this.txtCardID.Location = new System.Drawing.Point(122, 46);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.ReadOnly = true;
            this.txtCardID.Size = new System.Drawing.Size(189, 35);
            this.txtCardID.TabIndex = 2;
            this.txtCardID.Text = "N/A";
            this.txtCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chủ thẻ :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuy);
            this.groupBox2.Controls.Add(this.txtMoney);
            this.groupBox2.Controls.Add(this.rbGasDO);
            this.groupBox2.Controls.Add(this.rbGas95);
            this.groupBox2.Controls.Add(this.rbGas92);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(12, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 246);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giao dịch:";
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(318, 195);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(158, 40);
            this.btnBuy.TabIndex = 4;
            this.btnBuy.Text = "Mua";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // txtMoney
            // 
            this.txtMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoney.Location = new System.Drawing.Point(62, 80);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(673, 98);
            this.txtMoney.TabIndex = 3;
            this.txtMoney.Text = "20,000";
            this.txtMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMoney.TextChanged += new System.EventHandler(this.txtMoney_TextChanged);
            this.txtMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoney_KeyPress);
            // 
            // rbGasDO
            // 
            this.rbGasDO.AutoSize = true;
            this.rbGasDO.Location = new System.Drawing.Point(482, 33);
            this.rbGasDO.Name = "rbGasDO";
            this.rbGasDO.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbGasDO.Size = new System.Drawing.Size(116, 33);
            this.rbGasDO.TabIndex = 2;
            this.rbGasDO.Text = "Dầu DO";
            this.rbGasDO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbGasDO.UseVisualStyleBackColor = true;
            this.rbGasDO.CheckedChanged += new System.EventHandler(this.rbGasDO_CheckedChanged);
            // 
            // rbGas95
            // 
            this.rbGas95.AutoSize = true;
            this.rbGas95.Location = new System.Drawing.Point(332, 33);
            this.rbGas95.Name = "rbGas95";
            this.rbGas95.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbGas95.Size = new System.Drawing.Size(120, 33);
            this.rbGas95.TabIndex = 1;
            this.rbGas95.Text = "Xăng 95";
            this.rbGas95.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.rbGas95.UseVisualStyleBackColor = true;
            this.rbGas95.CheckedChanged += new System.EventHandler(this.rbGas95_CheckedChanged);
            // 
            // rbGas92
            // 
            this.rbGas92.AutoSize = true;
            this.rbGas92.Checked = true;
            this.rbGas92.Location = new System.Drawing.Point(196, 33);
            this.rbGas92.Name = "rbGas92";
            this.rbGas92.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbGas92.Size = new System.Drawing.Size(120, 33);
            this.rbGas92.TabIndex = 0;
            this.rbGas92.TabStop = true;
            this.rbGas92.Text = "Xăng 92";
            this.rbGas92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbGas92.UseVisualStyleBackColor = true;
            this.rbGas92.CheckedChanged += new System.EventHandler(this.rbGas92_CheckedChanged);
            // 
            // grBill
            // 
            this.grBill.Controls.Add(this.txtMoneyBefore);
            this.grBill.Controls.Add(this.label9);
            this.grBill.Controls.Add(this.txtPrice);
            this.grBill.Controls.Add(this.label4);
            this.grBill.Controls.Add(this.txtGasType);
            this.grBill.Controls.Add(this.label8);
            this.grBill.Controls.Add(this.txtGasBuying);
            this.grBill.Controls.Add(this.label7);
            this.grBill.Controls.Add(this.txtMoneyAfter);
            this.grBill.Controls.Add(this.label6);
            this.grBill.Controls.Add(this.txtMoneyBuying);
            this.grBill.Controls.Add(this.label5);
            this.grBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBill.ForeColor = System.Drawing.Color.Maroon;
            this.grBill.Location = new System.Drawing.Point(12, 440);
            this.grBill.Name = "grBill";
            this.grBill.Size = new System.Drawing.Size(794, 217);
            this.grBill.TabIndex = 4;
            this.grBill.TabStop = false;
            this.grBill.Text = "Thanh toán cho thẻ:";
            // 
            // txtMoneyBefore
            // 
            this.txtMoneyBefore.Enabled = false;
            this.txtMoneyBefore.Location = new System.Drawing.Point(148, 112);
            this.txtMoneyBefore.Name = "txtMoneyBefore";
            this.txtMoneyBefore.ReadOnly = true;
            this.txtMoneyBefore.Size = new System.Drawing.Size(304, 35);
            this.txtMoneyBefore.TabIndex = 17;
            this.txtMoneyBefore.Text = "20. 000";
            this.txtMoneyBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 29);
            this.label9.TabIndex = 16;
            this.label9.Text = "Ban đầu:";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(525, 54);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(243, 35);
            this.txtPrice.TabIndex = 15;
            this.txtPrice.Text = "50. 000";
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 29);
            this.label4.TabIndex = 14;
            this.label4.Text = "Giá:";
            // 
            // txtGasType
            // 
            this.txtGasType.Enabled = false;
            this.txtGasType.Location = new System.Drawing.Point(314, 54);
            this.txtGasType.Name = "txtGasType";
            this.txtGasType.ReadOnly = true;
            this.txtGasType.Size = new System.Drawing.Size(136, 35);
            this.txtGasType.TabIndex = 13;
            this.txtGasType.Text = "Xăng 92";
            this.txtGasType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGasType.TextChanged += new System.EventHandler(this.txtGasType_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 29);
            this.label8.TabIndex = 12;
            this.label8.Text = "Loại:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtGasBuying
            // 
            this.txtGasBuying.Enabled = false;
            this.txtGasBuying.Location = new System.Drawing.Point(148, 54);
            this.txtGasBuying.Name = "txtGasBuying";
            this.txtGasBuying.ReadOnly = true;
            this.txtGasBuying.Size = new System.Drawing.Size(98, 35);
            this.txtGasBuying.TabIndex = 11;
            this.txtGasBuying.Text = "5.5";
            this.txtGasBuying.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 29);
            this.label7.TabIndex = 10;
            this.label7.Text = "Số lít:";
            // 
            // txtMoneyAfter
            // 
            this.txtMoneyAfter.Enabled = false;
            this.txtMoneyAfter.Location = new System.Drawing.Point(148, 165);
            this.txtMoneyAfter.Name = "txtMoneyAfter";
            this.txtMoneyAfter.ReadOnly = true;
            this.txtMoneyAfter.Size = new System.Drawing.Size(620, 35);
            this.txtMoneyAfter.TabIndex = 9;
            this.txtMoneyAfter.Text = "30. 000";
            this.txtMoneyAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "Còn lại:";
            // 
            // txtMoneyBuying
            // 
            this.txtMoneyBuying.Enabled = false;
            this.txtMoneyBuying.Location = new System.Drawing.Point(525, 113);
            this.txtMoneyBuying.Name = "txtMoneyBuying";
            this.txtMoneyBuying.ReadOnly = true;
            this.txtMoneyBuying.Size = new System.Drawing.Size(243, 35);
            this.txtMoneyBuying.TabIndex = 7;
            this.txtMoneyBuying.Text = "20. 000";
            this.txtMoneyBuying.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "Trừ:";
            // 
            // timeCardReader
            // 
            this.timeCardReader.Enabled = true;
            this.timeCardReader.Interval = 500;
            this.timeCardReader.Tick += new System.EventHandler(this.timeCardReader_Tick);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // timeMain
            // 
            this.timeMain.Enabled = true;
            this.timeMain.Interval = 500;
            this.timeMain.Tick += new System.EventHandler(this.timeMain_Tick);
            // 
            // frmSGMSaleGas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 697);
            this.Controls.Add(this.grBill);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCurrentPrice);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSGMSaleGas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SGM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSGMSaleGas_FormClosing);
            this.Load += new System.EventHandler(this.frmSGMSaleGas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grBill.ResumeLayout(false);
            this.grBill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCardMoney;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCardDetail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbGasDO;
        private System.Windows.Forms.RadioButton rbGas95;
        private System.Windows.Forms.RadioButton rbGas92;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.GroupBox grBill;
        private System.Windows.Forms.TextBox txtGasType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGasBuying;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMoneyAfter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMoneyBuying;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMoneyBefore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timeCardReader;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Timer timeMain;
        private System.Windows.Forms.TextBox txtCardName;
    }
}