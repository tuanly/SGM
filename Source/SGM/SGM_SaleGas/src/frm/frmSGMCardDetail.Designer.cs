namespace SGM_SaleGas
{
    partial class frmSGMCardDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSGMCardDetail));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.txtCardStatus = new System.Windows.Forms.TextBox();
            this.txtCardMoney = new System.Windows.Forms.TextBox();
            this.txtPriceGas92 = new System.Windows.Forms.TextBox();
            this.txtPriceGas95 = new System.Windows.Forms.TextBox();
            this.txtPriceGasDO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(32, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã thẻ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(32, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trạng thái:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(35, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số tiền:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(32, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Giá xăng khi mua:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(95, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "+ Xăng 92:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(95, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "+ Xăng 95:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(96, 333);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 29);
            this.label7.TabIndex = 8;
            this.label7.Text = "+ Dầu DO:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Teal;
            this.btnClose.Location = new System.Drawing.Point(229, 387);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(158, 40);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // txtCardID
            // 
            this.txtCardID.Enabled = false;
            this.txtCardID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardID.ForeColor = System.Drawing.Color.Teal;
            this.txtCardID.Location = new System.Drawing.Point(170, 31);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.ReadOnly = true;
            this.txtCardID.Size = new System.Drawing.Size(384, 35);
            this.txtCardID.TabIndex = 10;
            this.txtCardID.Text = "N/A";
            this.txtCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCardStatus
            // 
            this.txtCardStatus.Enabled = false;
            this.txtCardStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardStatus.ForeColor = System.Drawing.Color.Teal;
            this.txtCardStatus.Location = new System.Drawing.Point(170, 82);
            this.txtCardStatus.Name = "txtCardStatus";
            this.txtCardStatus.ReadOnly = true;
            this.txtCardStatus.Size = new System.Drawing.Size(384, 35);
            this.txtCardStatus.TabIndex = 11;
            this.txtCardStatus.Text = "N/A";
            this.txtCardStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCardMoney
            // 
            this.txtCardMoney.Enabled = false;
            this.txtCardMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardMoney.ForeColor = System.Drawing.Color.Teal;
            this.txtCardMoney.Location = new System.Drawing.Point(170, 135);
            this.txtCardMoney.Name = "txtCardMoney";
            this.txtCardMoney.ReadOnly = true;
            this.txtCardMoney.Size = new System.Drawing.Size(384, 35);
            this.txtCardMoney.TabIndex = 12;
            this.txtCardMoney.Text = "N/A";
            this.txtCardMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPriceGas92
            // 
            this.txtPriceGas92.Enabled = false;
            this.txtPriceGas92.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceGas92.ForeColor = System.Drawing.Color.Teal;
            this.txtPriceGas92.Location = new System.Drawing.Point(229, 226);
            this.txtPriceGas92.Name = "txtPriceGas92";
            this.txtPriceGas92.ReadOnly = true;
            this.txtPriceGas92.Size = new System.Drawing.Size(325, 35);
            this.txtPriceGas92.TabIndex = 13;
            this.txtPriceGas92.Text = "N/A";
            this.txtPriceGas92.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPriceGas95
            // 
            this.txtPriceGas95.Enabled = false;
            this.txtPriceGas95.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceGas95.ForeColor = System.Drawing.Color.Teal;
            this.txtPriceGas95.Location = new System.Drawing.Point(229, 277);
            this.txtPriceGas95.Name = "txtPriceGas95";
            this.txtPriceGas95.ReadOnly = true;
            this.txtPriceGas95.Size = new System.Drawing.Size(325, 35);
            this.txtPriceGas95.TabIndex = 14;
            this.txtPriceGas95.Text = "N/A";
            this.txtPriceGas95.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPriceGasDO
            // 
            this.txtPriceGasDO.Enabled = false;
            this.txtPriceGasDO.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceGasDO.ForeColor = System.Drawing.Color.Teal;
            this.txtPriceGasDO.Location = new System.Drawing.Point(229, 331);
            this.txtPriceGasDO.Name = "txtPriceGasDO";
            this.txtPriceGasDO.ReadOnly = true;
            this.txtPriceGasDO.Size = new System.Drawing.Size(325, 35);
            this.txtPriceGasDO.TabIndex = 15;
            this.txtPriceGasDO.Text = "N/A";
            this.txtPriceGasDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmSGMCardDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 442);
            this.Controls.Add(this.txtPriceGasDO);
            this.Controls.Add(this.txtPriceGas95);
            this.Controls.Add(this.txtPriceGas92);
            this.Controls.Add(this.txtCardMoney);
            this.Controls.Add(this.txtCardStatus);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSGMCardDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SGM - Thông Tin Thẻ";
            this.Load += new System.EventHandler(this.frmSGMCardDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.TextBox txtCardStatus;
        private System.Windows.Forms.TextBox txtCardMoney;
        private System.Windows.Forms.TextBox txtPriceGas92;
        private System.Windows.Forms.TextBox txtPriceGas95;
        private System.Windows.Forms.TextBox txtPriceGasDO;
    }
}