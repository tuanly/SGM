namespace SGM_Management
{
    partial class frmSGMRechargeCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSGMRechargeCard));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRechargeNote = new System.Windows.Forms.TextBox();
            this.txtRechargeGasPrice = new System.Windows.Forms.TextBox();
            this.txtExMoney = new System.Windows.Forms.TextBox();
            this.dtpRechargeDate = new System.Windows.Forms.DateTimePicker();
            this.txtCardMoney = new System.Windows.Forms.TextBox();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateCard = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRechargeNote);
            this.groupBox1.Controls.Add(this.txtRechargeGasPrice);
            this.groupBox1.Controls.Add(this.txtExMoney);
            this.groupBox1.Controls.Add(this.dtpRechargeDate);
            this.groupBox1.Controls.Add(this.txtCardMoney);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 218);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thẻ:";
            // 
            // txtRechargeNote
            // 
            this.txtRechargeNote.Location = new System.Drawing.Point(82, 133);
            this.txtRechargeNote.Multiline = true;
            this.txtRechargeNote.Name = "txtRechargeNote";
            this.txtRechargeNote.Size = new System.Drawing.Size(496, 72);
            this.txtRechargeNote.TabIndex = 4;
            // 
            // txtRechargeGasPrice
            // 
            this.txtRechargeGasPrice.Enabled = false;
            this.txtRechargeGasPrice.Location = new System.Drawing.Point(125, 95);
            this.txtRechargeGasPrice.Name = "txtRechargeGasPrice";
            this.txtRechargeGasPrice.Size = new System.Drawing.Size(453, 20);
            this.txtRechargeGasPrice.TabIndex = 3;
            // 
            // txtExMoney
            // 
            this.txtExMoney.Enabled = false;
            this.txtExMoney.Location = new System.Drawing.Point(402, 59);
            this.txtExMoney.Name = "txtExMoney";
            this.txtExMoney.Size = new System.Drawing.Size(175, 20);
            this.txtExMoney.TabIndex = 2;
            this.txtExMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRechargeMoney_KeyPress);
            // 
            // dtpRechargeDate
            // 
            this.dtpRechargeDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRechargeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRechargeDate.Location = new System.Drawing.Point(402, 21);
            this.dtpRechargeDate.Name = "dtpRechargeDate";
            this.dtpRechargeDate.Size = new System.Drawing.Size(175, 20);
            this.dtpRechargeDate.TabIndex = 6;
            // 
            // txtCardMoney
            // 
            this.txtCardMoney.Location = new System.Drawing.Point(125, 59);
            this.txtCardMoney.Name = "txtCardMoney";
            this.txtCardMoney.Size = new System.Drawing.Size(176, 20);
            this.txtCardMoney.TabIndex = 1;
            this.txtCardMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardMoney_KeyPress);
            // 
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(125, 23);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(176, 20);
            this.txtCardID.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ghi Chú:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Giá xăng khi mua:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ngày mua/nạp:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Số tiền tích lũy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số tiền nạp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã thẻ:";
            // 
            // btnUpdateCard
            // 
            this.btnUpdateCard.Location = new System.Drawing.Point(267, 231);
            this.btnUpdateCard.Name = "btnUpdateCard";
            this.btnUpdateCard.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateCard.TabIndex = 7;
            this.btnUpdateCard.Text = "Cập nhật";
            this.btnUpdateCard.UseVisualStyleBackColor = true;
            this.btnUpdateCard.Click += new System.EventHandler(this.btnUpdateCard_Click);
            // 
            // frmSGMRechargeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 267);
            this.Controls.Add(this.btnUpdateCard);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmSGMRechargeCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SGM - Mua/Nạp Thẻ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSGMRechargeCard_FormClosing);
            this.Load += new System.EventHandler(this.frmSGMRechargeCard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpRechargeDate;
        private System.Windows.Forms.TextBox txtCardMoney;
        private System.Windows.Forms.TextBox txtExMoney;
        private System.Windows.Forms.TextBox txtRechargeNote;
        private System.Windows.Forms.TextBox txtRechargeGasPrice;
        private System.Windows.Forms.Button btnUpdateCard;
    }
}