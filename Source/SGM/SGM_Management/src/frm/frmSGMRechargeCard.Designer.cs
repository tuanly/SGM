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
            this.txtRechargeMoney = new System.Windows.Forms.TextBox();
            this.dtpRechargeDate = new System.Windows.Forms.DateTimePicker();
            this.txtCardMoney = new System.Windows.Forms.TextBox();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCardLocked = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRechargeNote);
            this.groupBox1.Controls.Add(this.txtRechargeGasPrice);
            this.groupBox1.Controls.Add(this.txtRechargeMoney);
            this.groupBox1.Controls.Add(this.dtpRechargeDate);
            this.groupBox1.Controls.Add(this.txtCardMoney);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbCardLocked);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 218);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thẻ:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtRechargeNote
            // 
            this.txtRechargeNote.Location = new System.Drawing.Point(82, 156);
            this.txtRechargeNote.Multiline = true;
            this.txtRechargeNote.Name = "txtRechargeNote";
            this.txtRechargeNote.Size = new System.Drawing.Size(496, 49);
            this.txtRechargeNote.TabIndex = 13;
            // 
            // txtRechargeGasPrice
            // 
            this.txtRechargeGasPrice.Enabled = false;
            this.txtRechargeGasPrice.Location = new System.Drawing.Point(125, 119);
            this.txtRechargeGasPrice.Name = "txtRechargeGasPrice";
            this.txtRechargeGasPrice.Size = new System.Drawing.Size(453, 20);
            this.txtRechargeGasPrice.TabIndex = 12;
            // 
            // txtRechargeMoney
            // 
            this.txtRechargeMoney.Location = new System.Drawing.Point(76, 90);
            this.txtRechargeMoney.Name = "txtRechargeMoney";
            this.txtRechargeMoney.Size = new System.Drawing.Size(133, 20);
            this.txtRechargeMoney.TabIndex = 11;
            // 
            // dtpRechargeDate
            // 
            this.dtpRechargeDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRechargeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRechargeDate.Location = new System.Drawing.Point(314, 56);
            this.dtpRechargeDate.Name = "dtpRechargeDate";
            this.dtpRechargeDate.Size = new System.Drawing.Size(101, 20);
            this.dtpRechargeDate.TabIndex = 10;
            // 
            // txtCardMoney
            // 
            this.txtCardMoney.Location = new System.Drawing.Point(76, 56);
            this.txtCardMoney.Name = "txtCardMoney";
            this.txtCardMoney.Size = new System.Drawing.Size(133, 20);
            this.txtCardMoney.TabIndex = 9;
            // 
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(76, 23);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(133, 20);
            this.txtCardID.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ghi Chú:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Giá xăng khi mua:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ngày mua/nạp:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giá mua:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số tiền:";
            // 
            // cbCardLocked
            // 
            this.cbCardLocked.AutoSize = true;
            this.cbCardLocked.Location = new System.Drawing.Point(288, 25);
            this.cbCardLocked.Name = "cbCardLocked";
            this.cbCardLocked.Size = new System.Drawing.Size(51, 17);
            this.cbCardLocked.TabIndex = 2;
            this.cbCardLocked.Text = "Khóa";
            this.cbCardLocked.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trạng thái";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cập nhật";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmSGMRechargeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 267);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmSGMRechargeCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SGM - Mua/Nạp Thẻ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbCardLocked;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpRechargeDate;
        private System.Windows.Forms.TextBox txtCardMoney;
        private System.Windows.Forms.TextBox txtRechargeMoney;
        private System.Windows.Forms.TextBox txtRechargeNote;
        private System.Windows.Forms.TextBox txtRechargeGasPrice;
        private System.Windows.Forms.Button button1;
    }
}