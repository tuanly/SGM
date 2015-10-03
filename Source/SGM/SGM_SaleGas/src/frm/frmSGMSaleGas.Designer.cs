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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSGMSaleGas));
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCardMoney = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCardDetail = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.rbGasDO = new System.Windows.Forms.RadioButton();
            this.rbGas95 = new System.Windows.Forms.RadioButton();
            this.rbGas92 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 693);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(818, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Giá xăng hiện tại: DO : 25 000, X92: 23 000, X95: 27 000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCardMoney);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCardDetail);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 121);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thẻ:";
            // 
            // txtCardMoney
            // 
            this.txtCardMoney.Enabled = false;
            this.txtCardMoney.ForeColor = System.Drawing.Color.Teal;
            this.txtCardMoney.Location = new System.Drawing.Point(460, 50);
            this.txtCardMoney.Name = "txtCardMoney";
            this.txtCardMoney.ReadOnly = true;
            this.txtCardMoney.Size = new System.Drawing.Size(275, 35);
            this.txtCardMoney.TabIndex = 4;
            this.txtCardMoney.Text = "300. 000";
            this.txtCardMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số tiền:";
            // 
            // txtCardID
            // 
            this.txtCardID.Enabled = false;
            this.txtCardID.ForeColor = System.Drawing.Color.Teal;
            this.txtCardID.Location = new System.Drawing.Point(133, 52);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.ReadOnly = true;
            this.txtCardID.Size = new System.Drawing.Size(181, 35);
            this.txtCardID.TabIndex = 2;
            this.txtCardID.Text = "card0001";
            this.txtCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thẻ :";
            // 
            // btnCardDetail
            // 
            this.btnCardDetail.Location = new System.Drawing.Point(747, 88);
            this.btnCardDetail.Name = "btnCardDetail";
            this.btnCardDetail.Size = new System.Drawing.Size(47, 33);
            this.btnCardDetail.TabIndex = 0;
            this.btnCardDetail.Text = "+";
            this.btnCardDetail.UseVisualStyleBackColor = true;
            this.btnCardDetail.Click += new System.EventHandler(this.btnCardDetail_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 265);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giao dịch:";
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(318, 208);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(158, 40);
            this.btnBuy.TabIndex = 4;
            this.btnBuy.Text = "Mua";
            this.btnBuy.UseVisualStyleBackColor = true;
            // 
            // txtMoney
            // 
            this.txtMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoney.Location = new System.Drawing.Point(62, 93);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(673, 98);
            this.txtMoney.TabIndex = 3;
            this.txtMoney.Text = "20. 000";
            this.txtMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbGasDO
            // 
            this.rbGasDO.AutoSize = true;
            this.rbGasDO.Location = new System.Drawing.Point(482, 46);
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
            this.rbGas95.Location = new System.Drawing.Point(332, 46);
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
            this.rbGas92.Location = new System.Drawing.Point(196, 46);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPrice);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtGasType);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtGasBuying);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtMoneyAfter);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtMoneyBuying);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(12, 468);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(794, 217);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thanh toán:";
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
            this.txtGasBuying.Location = new System.Drawing.Point(133, 54);
            this.txtGasBuying.Name = "txtGasBuying";
            this.txtGasBuying.ReadOnly = true;
            this.txtGasBuying.Size = new System.Drawing.Size(109, 35);
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
            this.txtMoneyAfter.Location = new System.Drawing.Point(134, 165);
            this.txtMoneyAfter.Name = "txtMoneyAfter";
            this.txtMoneyAfter.ReadOnly = true;
            this.txtMoneyAfter.Size = new System.Drawing.Size(634, 35);
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
            this.txtMoneyBuying.Location = new System.Drawing.Point(134, 113);
            this.txtMoneyBuying.Name = "txtMoneyBuying";
            this.txtMoneyBuying.ReadOnly = true;
            this.txtMoneyBuying.Size = new System.Drawing.Size(634, 35);
            this.txtMoneyBuying.TabIndex = 7;
            this.txtMoneyBuying.Text = "20. 000";
            this.txtMoneyBuying.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "Trừ:";
            // 
            // frmSGMSaleGas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 734);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSGMSaleGas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SGM";
            this.Load += new System.EventHandler(this.frmSGMSaleGas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.GroupBox groupBox3;
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
    }
}