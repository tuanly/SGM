namespace SGM_Management
{
    partial class frmSGMCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSGMCustomer));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelCard = new System.Windows.Forms.Button();
            this.btnLockCard = new System.Windows.Forms.Button();
            this.btnRecharge = new System.Windows.Forms.Button();
            this.btnBuyCard = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtCusAddress = new System.Windows.Forms.TextBox();
            this.txtCusPhone = new System.Windows.Forms.TextBox();
            this.txtCusVisa = new System.Windows.Forms.TextBox();
            this.txtCusBirthday = new System.Windows.Forms.TextBox();
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.txtCusID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvCardList = new System.Windows.Forms.DataGridView();
            this.colCardSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardRechargeMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardRechargeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardState = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvCusList = new System.Windows.Forms.DataGridView();
            this.colCusIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusList)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelCard);
            this.groupBox2.Controls.Add(this.btnLockCard);
            this.groupBox2.Controls.Add(this.btnRecharge);
            this.groupBox2.Controls.Add(this.btnBuyCard);
            this.groupBox2.Controls.Add(this.txtNote);
            this.groupBox2.Controls.Add(this.txtCusAddress);
            this.groupBox2.Controls.Add(this.txtCusPhone);
            this.groupBox2.Controls.Add(this.txtCusVisa);
            this.groupBox2.Controls.Add(this.txtCusBirthday);
            this.groupBox2.Controls.Add(this.txtCusName);
            this.groupBox2.Controls.Add(this.txtCusID);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(287, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 252);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin Khách Hàng:";
            // 
            // btnDelCard
            // 
            this.btnDelCard.Enabled = false;
            this.btnDelCard.Location = new System.Drawing.Point(412, 221);
            this.btnDelCard.Name = "btnDelCard";
            this.btnDelCard.Size = new System.Drawing.Size(79, 23);
            this.btnDelCard.TabIndex = 16;
            this.btnDelCard.Text = "Hủy Thẻ";
            this.btnDelCard.UseVisualStyleBackColor = true;
            // 
            // btnLockCard
            // 
            this.btnLockCard.Location = new System.Drawing.Point(322, 221);
            this.btnLockCard.Name = "btnLockCard";
            this.btnLockCard.Size = new System.Drawing.Size(79, 23);
            this.btnLockCard.TabIndex = 15;
            this.btnLockCard.Text = "&Khóa Thẻ";
            this.btnLockCard.UseVisualStyleBackColor = true;
            this.btnLockCard.Click += new System.EventHandler(this.btnLockCard_Click);
            // 
            // btnRecharge
            // 
            this.btnRecharge.Location = new System.Drawing.Point(235, 221);
            this.btnRecharge.Name = "btnRecharge";
            this.btnRecharge.Size = new System.Drawing.Size(79, 23);
            this.btnRecharge.TabIndex = 14;
            this.btnRecharge.Text = "Nạp Tiền";
            this.btnRecharge.UseVisualStyleBackColor = true;
            this.btnRecharge.Click += new System.EventHandler(this.btnRecharge_Click);
            // 
            // btnBuyCard
            // 
            this.btnBuyCard.Location = new System.Drawing.Point(148, 221);
            this.btnBuyCard.Name = "btnBuyCard";
            this.btnBuyCard.Size = new System.Drawing.Size(79, 23);
            this.btnBuyCard.TabIndex = 2;
            this.btnBuyCard.Text = "Mua Thẻ";
            this.btnBuyCard.UseVisualStyleBackColor = true;
            this.btnBuyCard.Click += new System.EventHandler(this.btnBuyCard_Click);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(82, 170);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(514, 45);
            this.txtNote.TabIndex = 13;
            // 
            // txtCusAddress
            // 
            this.txtCusAddress.Location = new System.Drawing.Point(82, 133);
            this.txtCusAddress.Name = "txtCusAddress";
            this.txtCusAddress.Size = new System.Drawing.Size(514, 20);
            this.txtCusAddress.TabIndex = 12;
            // 
            // txtCusPhone
            // 
            this.txtCusPhone.Location = new System.Drawing.Point(82, 100);
            this.txtCusPhone.MaxLength = 20;
            this.txtCusPhone.Name = "txtCusPhone";
            this.txtCusPhone.Size = new System.Drawing.Size(151, 20);
            this.txtCusPhone.TabIndex = 11;
            // 
            // txtCusVisa
            // 
            this.txtCusVisa.Location = new System.Drawing.Point(310, 64);
            this.txtCusVisa.MaxLength = 20;
            this.txtCusVisa.Name = "txtCusVisa";
            this.txtCusVisa.Size = new System.Drawing.Size(286, 20);
            this.txtCusVisa.TabIndex = 10;
            // 
            // txtCusBirthday
            // 
            this.txtCusBirthday.Location = new System.Drawing.Point(82, 64);
            this.txtCusBirthday.MaxLength = 20;
            this.txtCusBirthday.Name = "txtCusBirthday";
            this.txtCusBirthday.Size = new System.Drawing.Size(151, 20);
            this.txtCusBirthday.TabIndex = 9;
            // 
            // txtCusName
            // 
            this.txtCusName.Location = new System.Drawing.Point(310, 29);
            this.txtCusName.MaxLength = 50;
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.Size = new System.Drawing.Size(286, 20);
            this.txtCusName.TabIndex = 8;
            // 
            // txtCusID
            // 
            this.txtCusID.Location = new System.Drawing.Point(82, 29);
            this.txtCusID.MaxLength = 20;
            this.txtCusID.Name = "txtCusID";
            this.txtCusID.Size = new System.Drawing.Size(151, 20);
            this.txtCusID.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ghi Chú:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Địa Chỉ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số ĐT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "CMND:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày Sinh:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ && Tên KH:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã KH:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.dgvCardList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(287, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(701, 239);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách Thẻ:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(3, 157);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(695, 79);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnEdit);
            this.groupBox4.Controls.Add(this.btnCancel);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(689, 60);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(231, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "&Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(412, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Bỏ Qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(144, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "&Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(321, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "&Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvCardList
            // 
            this.dgvCardList.AllowUserToAddRows = false;
            this.dgvCardList.AllowUserToDeleteRows = false;
            this.dgvCardList.AllowUserToResizeRows = false;
            this.dgvCardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCardSTT,
            this.colCardID,
            this.colCardMoney,
            this.colCardRechargeMoney,
            this.colCardDate,
            this.colCardRechargeDate,
            this.colCardState});
            this.dgvCardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCardList.Location = new System.Drawing.Point(3, 16);
            this.dgvCardList.MultiSelect = false;
            this.dgvCardList.Name = "dgvCardList";
            this.dgvCardList.RowHeadersVisible = false;
            this.dgvCardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCardList.Size = new System.Drawing.Size(695, 220);
            this.dgvCardList.TabIndex = 0;
            this.dgvCardList.SelectionChanged += new System.EventHandler(this.dgvCardList_SelectionChanged);
            this.dgvCardList.DoubleClick += new System.EventHandler(this.dgvCardList_DoubleClick);
            // 
            // colCardSTT
            // 
            this.colCardSTT.HeaderText = "STT";
            this.colCardSTT.Name = "colCardSTT";
            // 
            // colCardID
            // 
            this.colCardID.HeaderText = "Mã Thẻ";
            this.colCardID.Name = "colCardID";
            // 
            // colCardMoney
            // 
            this.colCardMoney.HeaderText = "Tiền trên thẻ";
            this.colCardMoney.Name = "colCardMoney";
            // 
            // colCardRechargeMoney
            // 
            this.colCardRechargeMoney.HeaderText = "Giá mua";
            this.colCardRechargeMoney.Name = "colCardRechargeMoney";
            // 
            // colCardDate
            // 
            this.colCardDate.HeaderText = "Ngày mua";
            this.colCardDate.Name = "colCardDate";
            // 
            // colCardRechargeDate
            // 
            this.colCardRechargeDate.HeaderText = "Ngày nạp";
            this.colCardRechargeDate.Name = "colCardRechargeDate";
            // 
            // colCardState
            // 
            this.colCardState.HeaderText = "Thẻ bị khóa";
            this.colCardState.Name = "colCardState";
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // dgvCusList
            // 
            this.dgvCusList.AllowUserToAddRows = false;
            this.dgvCusList.AllowUserToDeleteRows = false;
            this.dgvCusList.AllowUserToResizeRows = false;
            this.dgvCusList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCusList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCusIndex,
            this.colCusName});
            this.dgvCusList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCusList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCusList.Location = new System.Drawing.Point(0, 0);
            this.dgvCusList.MultiSelect = false;
            this.dgvCusList.Name = "dgvCusList";
            this.dgvCusList.RowHeadersVisible = false;
            this.dgvCusList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCusList.Size = new System.Drawing.Size(281, 417);
            this.dgvCusList.TabIndex = 0;
            this.dgvCusList.SelectionChanged += new System.EventHandler(this.dgvCusList_SelectionChanged);
            // 
            // colCusIndex
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCusIndex.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCusIndex.HeaderText = " STT";
            this.colCusIndex.Name = "colCusIndex";
            this.colCusIndex.ReadOnly = true;
            this.colCusIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCusIndex.Width = 50;
            // 
            // colCusName
            // 
            this.colCusName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCusName.HeaderText = "                Khách Hàng";
            this.colCusName.Name = "colCusName";
            this.colCusName.ReadOnly = true;
            this.colCusName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnSearch);
            this.groupBox6.Controls.Add(this.txtSearch);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(281, 55);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tìm kiếm:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(231, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(44, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(84, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(141, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tên/Mã KH:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 491);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách Khách Hàng";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCusList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 417);
            this.panel1.TabIndex = 2;
            // 
            // frmSGMCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 491);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSGMCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SGM - Quản lý Khách Hàng";
            this.Load += new System.EventHandler(this.frmSGMCustomer_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusList)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCardList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCusID;
        private System.Windows.Forms.TextBox txtCusBirthday;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtCusAddress;
        private System.Windows.Forms.TextBox txtCusPhone;
        private System.Windows.Forms.TextBox txtCusVisa;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnBuyCard;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvCusList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusName;
        private System.Windows.Forms.Button btnLockCard;
        private System.Windows.Forms.Button btnRecharge;
        private System.Windows.Forms.Button btnDelCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardRechargeMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardRechargeDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCardState;
    }
}