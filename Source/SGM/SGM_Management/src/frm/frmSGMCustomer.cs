using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SGM_Core.DTO;
using SGM_Core.Utils;

namespace SGM_Management
{
    public partial class frmSGMCustomer : Form
    {
        private SGM_Service.ServiceSoapClient m_service = null;
        private DataSet m_dsCustomer;
        private string m_stSearchValue = null;
        public frmSGMCustomer()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
        }

        private void UpdateStateControls(bool isEditMode)
        {
            txtSearch.Enabled = (!isEditMode && (dgvCusList.RowCount > 0));
            btnSearch.Enabled = (!isEditMode && (dgvCusList.RowCount > 0));
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
            LoadCustomerList();
            UpdateStateControls(false);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateInputFields();
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
                clearInput();            
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
                DataTransfer request = new DataTransfer();
                request.ResponseDataCustomerDTO = cus;
                string jsRequest = JSonHelper.ConvertObjectToJSon(request);
                string response = m_service.SGMManager_AddNewCustomer(jsRequest);
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(response);
                if (dataResponse.ResponseCode != DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    MessageBox.Show(dataResponse.ResponseErrorMsg + "\n" + dataResponse.ResponseErrorMsgDetail);
                    return;
                }
               
                LoadCustomerList();
                SelectCustomeRow(cus.CustomerID);
                UpdateStateControls(false);               
                btnAdd.Text = "&Thêm";
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
            else if (!txtCusID.Text.Trim().Equals(m_stCusIDEdit))
            {
                String jsonResponse = m_service.SGMManager_CheckCustomerExist(txtCusID.Text.Trim());
                DataTransfer response = JSonHelper.ConvertJSonToObject(jsonResponse);
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
            LoadCustomerList();
            UpdateStateControls(false);
        }

        private void LoadCustomerList()
        {

            string jsResponse = m_service.SGMManager_GetCustomer(m_stSearchValue, false);
            DataTransfer response = JSonHelper.ConvertJSonToObject(jsResponse);
            dgvCusList.Rows.Clear();
            m_dsCustomer = response.ResponseDataSet;
            int iOldSelected = m_iCurrentIndex;
            if (m_dsCustomer != null)
            {                
                for (int i = 0; i < m_dsCustomer.Tables[0].Rows.Count; i++)
                {                   
                    dgvCusList.Rows.Add();
                    dgvCusList.Rows[i].Cells[0].Value = (i + 1);
                    dgvCusList.Rows[i].Cells[1].Value = m_dsCustomer.Tables[0].Rows[i]["CUS_NAME"] + " (" + m_dsCustomer.Tables[0].Rows[i]["CUS_ID"] + ")";
                }
                m_iCurrentIndex = iOldSelected;
                if (m_iCurrentIndex >= dgvCusList.Rows.Count)
                    m_iCurrentIndex = -1;
                if (m_iCurrentIndex > 0) 
                    dgvCusList.Rows[m_iCurrentIndex].Selected = true;
            }
            
        }

        private void UpdateInputFields()
        {
            if (m_dsCustomer != null && m_dsCustomer.Tables.Count > 0 && m_dsCustomer.Tables[0].Rows.Count > 0 && dgvCusList.SelectedRows.Count > 0)
            {
                m_iCurrentIndex = dgvCusList.SelectedRows[0].Index;
                if (m_iCurrentIndex < m_dsCustomer.Tables[0].Rows.Count)
                {
                    txtCusID.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentIndex]["CUS_ID"].ToString();
                    txtCusName.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentIndex]["CUS_NAME"].ToString();
                    txtCusBirthday.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentIndex]["CUS_BIRTHDATE"].ToString();
                    txtCusVisa.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentIndex]["CUS_VISA"].ToString();
                    txtCusAddress.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentIndex]["CUS_ADDRESS"].ToString();
                    txtCusPhone.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentIndex]["CUS_PHONE"].ToString();
                    txtNote.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentIndex]["CUS_NOTE"].ToString();
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnBuyCard.Enabled = true;
                }
            }
            else
            {
                clearInput();
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnBuyCard.Enabled = false;
            }
        }
        private void clearInput()
        {
            txtCusID.Text = "";
            txtCusName.Text = "";
            txtCusBirthday.Text = "";
            txtCusVisa.Text = "";
            txtCusAddress.Text = "";
            txtCusPhone.Text = "";
            txtNote.Text = "";
        }
        private void dgvCusList_SelectionChanged(object sender, EventArgs e)
        {
            UpdateInputFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchCustomer();
        }
        private void searchCustomer()
        {
            if (txtSearch.Text.Trim().Equals(""))
            {                
                m_stSearchValue = null;
            }
            else
            {
                m_stSearchValue = txtSearch.Text.Trim();
            }
            LoadCustomerList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchCustomer();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (m_iCurrentIndex > 0)
                {

                    string cusID = m_dsCustomer.Tables[0].Rows[m_iCurrentIndex]["CUS_ID"].ToString();
                    string cusName = m_dsCustomer.Tables[0].Rows[m_iCurrentIndex]["CUS_NAME"].ToString();
                    if (MessageBox.Show(SGMText.CUSTOMER_DEL_CUS_WARNING + "\n" + cusID + " : " + cusName, SGMText.CUSTOMER_DEL_CUS, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string jsResponse = m_service.SGMManager_DelCustomer(cusID);
                        DataTransfer response = JSonHelper.ConvertJSonToObject(jsResponse);
                        if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                        {
                            MessageBox.Show(SGMText.CUSTOMER_DEL_CUS_SUCCESS);
                            LoadCustomerList();
                        }
                        else
                        {
                            MessageBox.Show(response.ResponseErrorMsg + "\n" + response.ResponseErrorMsgDetail);
                        }
                    }                    
                }
                
           
        }
        private string m_stCusIDEdit = "";
        private int m_iCurrentIndex = -1;
        private void btnEdit_Click(object sender, EventArgs e)
        {
           if (m_iCurrentIndex > 0)
                {

                    if (btnEdit.Text.Equals("&Sửa"))
                    {
                        m_stCusIDEdit = m_dsCustomer.Tables[0].Rows[m_iCurrentIndex]["CUS_ID"].ToString();
                        btnEdit.Text = "&Lưu";
                        UpdateStateControls(true);               
                        txtCusID.Focus();
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
                        DataTransfer request = new DataTransfer();
                        request.ResponseDataCustomerDTO = cus;
                        string jsRequest = JSonHelper.ConvertObjectToJSon(request);
                        string response = m_service.SGMManager_UpdateCustomer(jsRequest, m_stCusIDEdit);
                        DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(response);
                        if (dataResponse.ResponseCode != DataTransfer.RESPONSE_CODE_SUCCESS)
                        {
                            MessageBox.Show(dataResponse.ResponseErrorMsg + "\n" + dataResponse.ResponseErrorMsgDetail);
                            return;
                        }
                        m_stCusIDEdit = "";
                        btnEdit.Text = "&Sửa";
                        LoadCustomerList();
                        SelectCustomeRow(cus.CustomerID);
                        UpdateStateControls(false); 
                    }
                }
            
        }

        private void SelectCustomeRow(string id)
        {
            if (m_dsCustomer != null)
            {
                for (int i = 0; i < m_dsCustomer.Tables[0].Rows.Count; i++)
                {
                    string cusID = m_dsCustomer.Tables[0].Rows[i]["CUS_ID"].ToString();
                    if (cusID.Equals(id))
                    {
                        dgvCusList.Rows[i].Selected = true;
                        return;
                    }

                }
            }
        }
    }
}
