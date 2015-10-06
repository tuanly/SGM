using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SGM_Core.DTO;

namespace SGM_Management
{
    public partial class frmSGMCustomer : Form
    {
        private SGM_Service.ServiceSoapClient m_service = null;
        public frmSGMCustomer()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
        }

        private void UpdateStateControls(bool isEditMode)
        {
            txtSearch.Enabled = (!isEditMode && (dgvCardList.RowCount > 0));
            btnSearch.Enabled = (!isEditMode && (dgvCardList.RowCount > 0));
            dgvCusList.Enabled = !isEditMode;
            txtCusID.Enabled = isEditMode;
            txtCusName.Enabled = isEditMode;
            txtCusBirthday.Enabled = isEditMode;
            txtCusVisa.Enabled = isEditMode;
            txtCusPhone.Enabled = isEditMode;
            txtCusAddress.Enabled = isEditMode;
            txtNote.Enabled = isEditMode;
            btnBuyCard.Enabled = (!isEditMode && (dgvCusList.RowCount > 0));
            dgvCardList.Enabled = !isEditMode;
            btnCancel.Enabled = isEditMode;
            btnDelete.Enabled = (!isEditMode && (dgvCusList.RowCount > 0));
            btnAdd.Enabled = (!isEditMode || btnAdd.Text.Equals("&Lưu"));
            btnEdit.Enabled = ((!isEditMode && (dgvCusList.RowCount > 0)) || (isEditMode && btnEdit.Text.Equals("&Lưu")));
            errProvider.Clear();
        }
        private void frmSGMCustomer_Load(object sender, EventArgs e)
        {
            UpdateStateControls(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dgvCardList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuyCard_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text.Equals("&Thêm"))
            {
                txtCusID.Focus();
                btnAdd.Text = "&Lưu";
                UpdateStateControls(true);
          
            }
            else
            {
                if (!ValidateDataInput())
                {
                    return;
                }
                CustomerDTO cus = new CustomerDTO();
                cus.CustomerID = txtCusID.Text.Trim();
                cus.CustomerName = txtCusName.Text.Trim();
                cus.CustomerPhone = txtCusPhone.Text.Trim();
                cus.CustomerBirthDate = txtCusBirthday.Text.Trim();
                cus.CustomerVisa = txtCusVisa.Text.Trim();
                cus.CustomerAddress = txtCusAddress.Text.Trim();
                cus.CustomerNote = txtCusAddress.Text.Trim();

               // DataTransfer response = new DataTransfer(m_service.SGMManager_AddNewCustomer(cus));

                btnAdd.Text = "&Thêm";

                UpdateStateControls(false);
            }           
        }

        private bool ValidateDataInput()
        {
            bool bValidate = true;
            errProvider.Clear();
            if (txtCusID.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtCusID, SGMText.CUSTOMER_DATA_INPUT_CUS_ID_ERR);
                bValidate = false;
            }
            DataTransfer response = new DataTransfer(m_service.SGMManager_CheckCustomerExist(txtCusID.Text.Trim()));
            if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                if (response.ResponseDataBool)
                {
                    errProvider.SetError(txtCusID, SGMText.CUSTOMER_DATA_INPUT_EXIST_CUS_ID_ERR);
                    bValidate = false;
                }
            }
            else
            {
                errProvider.SetError(txtCusName, SGMText.CUSTOMER_GET_CUS_ERR);
                MessageBox.Show(SGMText.CUSTOMER_GET_CUS_ERR + "\n" + response.ResponseErrorMsg + ":\n" + response.ResponseErrorMsgDetail);
                bValidate = false;
            }
            if (txtCusName.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtCusName, SGMText.CUSTOMER_DATA_INPUT_CUS_NAME_ERR);
                bValidate = false;
            }
            if (txtCusBirthday.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtCusBirthday, SGMText.CUSTOMER_DATA_INPUT_CUS_BIRTHDAY_ERR);
                bValidate = false;
            }
            if (txtCusVisa.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtCusVisa, SGMText.CUSTOMER_DATA_INPUT_CUS_VISA_ERR);
                bValidate = false;
            }
            return bValidate;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "&Thêm";
            btnEdit.Text = "&Sửa";
            UpdateStateControls(false);
        }
    }
}
