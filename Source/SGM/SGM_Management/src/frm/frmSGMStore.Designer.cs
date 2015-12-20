namespace SGM_Management
{
    partial class frmSGMStore
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtMacAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGSDes = new System.Windows.Forms.TextBox();
            this.txtGSAddress = new System.Windows.Forms.TextBox();
            this.txtGSName = new System.Windows.Forms.TextBox();
            this.txtGSCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGSList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGas92 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGas95 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGasDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalGas92 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalGas95 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalGasDO = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGSList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtTotalGasDO);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtTotalGas95);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTotalGas92);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.txtMacAddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtGSDes);
            this.groupBox1.Controls.Add(this.txtGSAddress);
            this.groupBox1.Controls.Add(this.txtGSName);
            this.groupBox1.Controls.Add(this.txtGSCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết:";
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(488, 119);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(92, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "&Xóa Địa Chỉ";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.Enabled = false;
            this.txtMacAddress.Location = new System.Drawing.Point(100, 121);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(382, 20);
            this.txtMacAddress.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "MacAddress:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ghi chú:";
            // 
            // txtGSDes
            // 
            this.txtGSDes.Location = new System.Drawing.Point(100, 186);
            this.txtGSDes.Multiline = true;
            this.txtGSDes.Name = "txtGSDes";
            this.txtGSDes.Size = new System.Drawing.Size(480, 35);
            this.txtGSDes.TabIndex = 6;
            // 
            // txtGSAddress
            // 
            this.txtGSAddress.Location = new System.Drawing.Point(100, 85);
            this.txtGSAddress.Name = "txtGSAddress";
            this.txtGSAddress.Size = new System.Drawing.Size(480, 20);
            this.txtGSAddress.TabIndex = 5;
            // 
            // txtGSName
            // 
            this.txtGSName.Location = new System.Drawing.Point(100, 56);
            this.txtGSName.Name = "txtGSName";
            this.txtGSName.Size = new System.Drawing.Size(480, 20);
            this.txtGSName.TabIndex = 4;
            // 
            // txtGSCode
            // 
            this.txtGSCode.Location = new System.Drawing.Point(100, 26);
            this.txtGSCode.Name = "txtGSCode";
            this.txtGSCode.Size = new System.Drawing.Size(139, 20);
            this.txtGSCode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã số:";
            // 
            // dgvGSList
            // 
            this.dgvGSList.AllowUserToAddRows = false;
            this.dgvGSList.AllowUserToDeleteRows = false;
            this.dgvGSList.AllowUserToResizeRows = false;
            this.dgvGSList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGSList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colGSID,
            this.colName,
            this.colGas92,
            this.colGas95,
            this.colGasDO});
            this.dgvGSList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGSList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGSList.Location = new System.Drawing.Point(0, 233);
            this.dgvGSList.MultiSelect = false;
            this.dgvGSList.Name = "dgvGSList";
            this.dgvGSList.RowHeadersVisible = false;
            this.dgvGSList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGSList.Size = new System.Drawing.Size(621, 225);
            this.dgvGSList.TabIndex = 1;
            this.dgvGSList.SelectionChanged += new System.EventHandler(this.dgvGSList_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 403);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(621, 55);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(195, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "&Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(407, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Bỏ Qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(90, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "&Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(306, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "&Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tổng Kho:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Xăng 92 :";
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 40;
            // 
            // colGSID
            // 
            this.colGSID.HeaderText = "Mã Số";
            this.colGSID.Name = "colGSID";
            // 
            // colName
            // 
            this.colName.FillWeight = 150F;
            this.colName.HeaderText = "Tên Kho Xăng";
            this.colName.Name = "colName";
            this.colName.Width = 150;
            // 
            // colGas92
            // 
            this.colGas92.HeaderText = "Xăng 92 (L)";
            this.colGas92.Name = "colGas92";
            // 
            // colGas95
            // 
            this.colGas95.HeaderText = "Xăng 95 (L)";
            this.colGas95.Name = "colGas95";
            // 
            // colGasDO
            // 
            this.colGasDO.HeaderText = "Dầu DO (L)";
            this.colGasDO.Name = "colGasDO";
            // 
            // txtTotalGas92
            // 
            this.txtTotalGas92.Location = new System.Drawing.Point(147, 154);
            this.txtTotalGas92.Name = "txtTotalGas92";
            this.txtTotalGas92.ReadOnly = true;
            this.txtTotalGas92.Size = new System.Drawing.Size(62, 20);
            this.txtTotalGas92.TabIndex = 13;
            this.txtTotalGas92.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(215, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "(Lít)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(259, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Xăng 95 :";
            // 
            // txtTotalGas95
            // 
            this.txtTotalGas95.Location = new System.Drawing.Point(316, 153);
            this.txtTotalGas95.Name = "txtTotalGas95";
            this.txtTotalGas95.ReadOnly = true;
            this.txtTotalGas95.Size = new System.Drawing.Size(62, 20);
            this.txtTotalGas95.TabIndex = 16;
            this.txtTotalGas95.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(384, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "(Lít)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(553, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "(Lít)";
            // 
            // txtTotalGasDO
            // 
            this.txtTotalGasDO.Location = new System.Drawing.Point(488, 153);
            this.txtTotalGasDO.Name = "txtTotalGasDO";
            this.txtTotalGasDO.ReadOnly = true;
            this.txtTotalGasDO.Size = new System.Drawing.Size(62, 20);
            this.txtTotalGasDO.TabIndex = 19;
            this.txtTotalGasDO.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(431, 157);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Dầu DO :";
            // 
            // frmSGMStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvGSList);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSGMStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SGM - Quản Lý Kho Xăng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGasStore_FormClosing);
            this.Load += new System.EventHandler(this.frmGasStore_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGSList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGSCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGSDes;
        private System.Windows.Forms.TextBox txtGSAddress;
        private System.Windows.Forms.TextBox txtGSName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvGSList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.TextBox txtMacAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalGasDO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalGas95;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalGas92;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGas92;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGas95;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGasDO;
    }
}