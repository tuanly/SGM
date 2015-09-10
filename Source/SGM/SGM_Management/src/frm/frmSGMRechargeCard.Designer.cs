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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCardLocked = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.txtCardMoney = new System.Windows.Forms.TextBox();
            this.dtpRechargeDate = new System.Windows.Forms.DateTimePicker();
            this.txtRechargeMoney = new System.Windows.Forms.TextBox();
            this.txtRechargeGasPrice = new System.Windows.Forms.TextBox();
            this.txtRechargeNote = new System.Windows.Forms.TextBox();
            this.dgvCardList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ngày mua:";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Giá xăng khi mua:";
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
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(76, 23);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(133, 20);
            this.txtCardID.TabIndex = 8;
            // 
            // txtCardMoney
            // 
            this.txtCardMoney.Location = new System.Drawing.Point(76, 56);
            this.txtCardMoney.Name = "txtCardMoney";
            this.txtCardMoney.Size = new System.Drawing.Size(133, 20);
            this.txtCardMoney.TabIndex = 9;
            // 
            // dtpRechargeDate
            // 
            this.dtpRechargeDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRechargeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRechargeDate.Location = new System.Drawing.Point(288, 56);
            this.dtpRechargeDate.Name = "dtpRechargeDate";
            this.dtpRechargeDate.Size = new System.Drawing.Size(101, 20);
            this.dtpRechargeDate.TabIndex = 10;
            // 
            // txtRechargeMoney
            // 
            this.txtRechargeMoney.Location = new System.Drawing.Point(76, 90);
            this.txtRechargeMoney.Name = "txtRechargeMoney";
            this.txtRechargeMoney.Size = new System.Drawing.Size(133, 20);
            this.txtRechargeMoney.TabIndex = 11;
            // 
            // txtRechargeGasPrice
            // 
            this.txtRechargeGasPrice.Enabled = false;
            this.txtRechargeGasPrice.Location = new System.Drawing.Point(125, 119);
            this.txtRechargeGasPrice.Name = "txtRechargeGasPrice";
            this.txtRechargeGasPrice.Size = new System.Drawing.Size(453, 20);
            this.txtRechargeGasPrice.TabIndex = 12;
            // 
            // txtRechargeNote
            // 
            this.txtRechargeNote.Location = new System.Drawing.Point(82, 156);
            this.txtRechargeNote.Multiline = true;
            this.txtRechargeNote.Name = "txtRechargeNote";
            this.txtRechargeNote.Size = new System.Drawing.Size(496, 49);
            this.txtRechargeNote.TabIndex = 13;
            // 
            // dgvCardList
            // 
            this.dgvCardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardList.Location = new System.Drawing.Point(7, 231);
            this.dgvCardList.Name = "dgvCardList";
            this.dgvCardList.Size = new System.Drawing.Size(595, 150);
            this.dgvCardList.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Location = new System.Drawing.Point(179, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 55);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(121, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(333, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Bỏ Qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(232, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(7, 393);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 49);
            this.panel2.TabIndex = 10;
            // 
            // frmSGMRechargeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 448);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvCardList);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmSGMRechargeCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SGM - Mua Thẻ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).EndInit();
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dgvCardList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel2;
    }
}