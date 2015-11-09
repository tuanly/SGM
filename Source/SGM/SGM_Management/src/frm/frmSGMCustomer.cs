﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SGM_Core.DTO;
using SGM_Core.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace SGM_Management
{
    public partial class frmSGMCustomer : Form
    {
        private SGM_Service.ServiceSoapClient m_service = null;
        private DataSet m_dsCustomer;
        private DataSet m_dsCard;
        private string m_stSearchValue = null;

        private string m_stCusIDEdit = "";
        private int m_iCurrentCustomerIndex = -1;

        private int m_iCurrentCardIndex = -1;
        private frmSGMMessage frmMSg = null;
        public frmSGMCustomer()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
            frmMSg = new frmSGMMessage();
        }

        private void UpdateStateControls(bool isEditMode)
        {
            txtSearch.Enabled = (!isEditMode && (dgvCusList.RowCount > 0));
            btnSearch.Enabled = (!isEditMode && (dgvCusList.RowCount > 0));
            dgvCusList.Enabled = !isEditMode;
            dgvCardList.Enabled = !isEditMode;
            txtCusID.Enabled = isEditMode;
            txtCusName.Enabled = isEditMode;
            txtCusBirthday.Enabled = isEditMode;
            txtCusVisa.Enabled = isEditMode;
            txtCusPhone.Enabled = isEditMode;
            txtCusAddress.Enabled = isEditMode;
            txtNote.Enabled = isEditMode;
            btnBuyCard.Enabled = (!isEditMode && (dgvCusList.RowCount > 0));
            btnLockCard.Enabled = (!isEditMode && (dgvCardList.RowCount > 0));
            btnRecharge.Enabled = (!isEditMode && (dgvCardList.RowCount > 0));
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

        

        private void btnBuyCard_Click(object sender, EventArgs e)
        {
            frmSGMRechargeCard frmRechard = new frmSGMRechargeCard();
            frmRechard.StateRecharge = false;
            frmRechard.CusID = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_ID"].ToString();
            frmRechard.ShowDialog();
            LoadCardList();
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
                Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                () =>
                {
                    return m_service.SGMManager_AddNewCustomer(jsRequest);
                });
                SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                {
	                String stResponse = task.Result as String;
                    DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                    if (dataResponse.ResponseCode != DataTransfer.RESPONSE_CODE_SUCCESS)
                    {                    
                        frmMSg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg + "\n" + dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                        return;
                    }
                }, SynchronizationContext.Current);
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
                Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                () =>
                {
                    return m_service.SGMManager_CheckCustomerExist(txtCusID.Text.Trim());
                });
                SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                {
	                String stResponse = task.Result as String;
                    DataTransfer response = JSonHelper.ConvertJSonToObject(stResponse);
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
                        errProvider.SetError(txtCusID, SGMText.CUSTOMER_GET_CUS_ERR);                  
                        frmMSg.ShowMsg(SGMText.SGM_ERROR, SGMText.CUSTOMER_GET_CUS_ERR + "\n" + response.ResponseErrorMsg + ":\n" + response.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                        bValidate = false;
                    }
                }, SynchronizationContext.Current);
                
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
            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () =>
            {
                return m_service.SGMManager_GetCustomer(m_stSearchValue, false);
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
	            String stResponse = task.Result as String;
                DataTransfer response = JSonHelper.ConvertJSonToObject(stResponse);
                dgvCusList.Rows.Clear();
                m_dsCustomer = response.ResponseDataSet;
                int iOldSelected = m_iCurrentCustomerIndex;
                if (m_dsCustomer != null)
                {                
                    for (int i = 0; i < m_dsCustomer.Tables[0].Rows.Count; i++)
                    {                   
                        dgvCusList.Rows.Add();
                        dgvCusList.Rows[i].Cells[0].Value = (i + 1);
                        dgvCusList.Rows[i].Cells[1].Value = m_dsCustomer.Tables[0].Rows[i]["CUS_NAME"] + " (" + m_dsCustomer.Tables[0].Rows[i]["CUS_ID"] + ")";
                    }
                    if (iOldSelected >= 0)
                        m_iCurrentCustomerIndex = iOldSelected;
                    if (m_iCurrentCustomerIndex >= dgvCusList.Rows.Count)
                        m_iCurrentCustomerIndex = -1;
                    if (m_iCurrentCustomerIndex >= 0)
                        dgvCusList.Rows[m_iCurrentCustomerIndex].Selected = true;
                
                }    
            }, SynchronizationContext.Current);
            
        }

        private void LoadCardList()
        {
            if (m_iCurrentCustomerIndex >= 0)
            {
                Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                () =>
                {
                    return m_service.SGMManager_GetCardsOfCustomer(m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_ID"].ToString());
                });
                SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                {
	                String stResponse = task.Result as String;
                    DataTransfer response = JSonHelper.ConvertJSonToObject(stResponse);
                    dgvCardList.Rows.Clear();
                    m_dsCard = response.ResponseDataSet;
                    int iOldSelected = m_iCurrentCardIndex;
                    if (m_dsCard != null)
                    {
                        for (int i = 0; i < m_dsCard.Tables[0].Rows.Count; i++)
                        {
                            dgvCardList.Rows.Add();
                            dgvCardList.Rows[i].Cells[0].Value = (i + 1);
                            dgvCardList.Rows[i].Cells[1].Value = m_dsCard.Tables[0].Rows[i]["CARD_ID"] ;
                            dgvCardList.Rows[i].Cells[2].Value = m_dsCard.Tables[0].Rows[i]["CARD_MONEY"];
                            dgvCardList.Rows[i].Cells[3].Value = m_dsCard.Tables[0].Rows[i]["RECHARGE_MONEY"];
                            dgvCardList.Rows[i].Cells[4].Value = m_dsCard.Tables[0].Rows[i]["CARD_BUY_DATE"];
                            dgvCardList.Rows[i].Cells[5].Value = m_dsCard.Tables[0].Rows[i]["RECHARGE_DATE"];
                            dgvCardList.Rows[i].Cells[6].Value = !Boolean.Parse(m_dsCard.Tables[0].Rows[i]["CARD_STATE"].ToString());
                        }
                        if (iOldSelected >= 0)
                            m_iCurrentCardIndex = iOldSelected;
                        if (m_iCurrentCardIndex >= dgvCusList.Rows.Count)
                            m_iCurrentCardIndex = -1;
                        if (m_iCurrentCardIndex >= 0)
                            dgvCardList.Rows[m_iCurrentCardIndex].Selected = true;
                    }
                }, SynchronizationContext.Current);
                
            }
        }

        private void UpdateInputFields()
        {
            if (m_dsCustomer != null && m_dsCustomer.Tables.Count > 0 && m_dsCustomer.Tables[0].Rows.Count > 0 && dgvCusList.SelectedRows.Count > 0)
            {
                m_iCurrentCustomerIndex = dgvCusList.SelectedRows[0].Index;
                if (m_iCurrentCustomerIndex < m_dsCustomer.Tables[0].Rows.Count)
                {
                    txtCusID.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_ID"].ToString();
                    txtCusName.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_NAME"].ToString();
                    txtCusBirthday.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_BIRTHDATE"].ToString();
                    txtCusVisa.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_VISA"].ToString();
                    txtCusAddress.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_ADDRESS"].ToString();
                    txtCusPhone.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_PHONE"].ToString();
                    txtNote.Text = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_NOTE"].ToString();
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
            LoadCardList();
            UpdateStateControls(false);
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
            if (m_iCurrentCustomerIndex >= 0)
                {

                    string cusID = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_ID"].ToString();
                    string cusName = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_NAME"].ToString();

                    if ((frmMSg.ShowMsg(SGMText.SGM_WARNING, SGMText.CUSTOMER_DEL_CUS_WARNING + "\n" + cusID + " : " + cusName, SGMMessageType.SGM_MESSAGE_TYPE_QUES) == SGMMessageResult.SGM_MESSAGE_RESULT_OK))
                    {
                        Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                        () =>
                        {
                            return m_service.SGMManager_DelCustomer(cusID);
                        });
                        SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                        {
	                        String stResponse = task.Result as String;
                            DataTransfer response = JSonHelper.ConvertJSonToObject(stResponse);
                            if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                            {
                                frmMSg.ShowMsg(SGMText.SGM_INFO, SGMText.CUSTOMER_DEL_CUS_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                                LoadCustomerList();
                            }
                            else
                            {
                                frmMSg.ShowMsg(SGMText.SGM_ERROR, response.ResponseErrorMsg + "\n" + response.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                            }
                        }, SynchronizationContext.Current);
                    }                    
                }
                
           
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (m_iCurrentCustomerIndex >= 0)
            {

                if (btnEdit.Text.Equals("&Sửa"))
                {
                    m_stCusIDEdit = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_ID"].ToString();
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
                    Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                    () =>
                    {
                        return m_service.SGMManager_UpdateCustomer(jsRequest, m_stCusIDEdit);
                    });
                    SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                    {
	                    String stResponse = task.Result as String;
                        DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                        if (dataResponse.ResponseCode != DataTransfer.RESPONSE_CODE_SUCCESS)
                        {
                            frmMSg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg + "\n" + dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                            return;
                        }
                    }, SynchronizationContext.Current);
                    
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

        private void btnRecharge_Click(object sender, EventArgs e)
        {
            frmSGMRechargeCard frmRechard = new frmSGMRechargeCard();
            frmRechard.StateRecharge = true;
            frmRechard.CardID = m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["CARD_ID"].ToString();
            frmRechard.CurrentCardMoney = Int32.Parse(m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["CARD_MONEY"].ToString());
            frmRechard.CusID = m_dsCustomer.Tables[0].Rows[m_iCurrentCustomerIndex]["CUS_ID"].ToString();
            frmRechard.ShowDialog();
            LoadCardList();
        }

        private void dgvCardList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCardList.SelectedRows.Count > 0)
            {
                m_iCurrentCardIndex = dgvCardList.SelectedRows[0].Index;
                bool bUnLock = Boolean.Parse(m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["CARD_STATE"].ToString());
                if (bUnLock)
                {
                    
                    btnRecharge.Enabled = true;
                    btnLockCard.Text = "&Khóa Thẻ";
                }
                else
                {
                   
                    btnRecharge.Enabled = false;
                    btnLockCard.Text = "&Mở khóa Thẻ";
                }
            }
        }

        private void btnLockCard_Click(object sender, EventArgs e)
        {
            if (m_iCurrentCardIndex >= 0)
            {
                bool bUnLock = Boolean.Parse(m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["CARD_STATE"].ToString());
                bUnLock = !bUnLock;
                string stCardID = m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["CARD_ID"].ToString();
                Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                () =>
                {
                    return m_service.SGMManager_UpdateCardState(stCardID, bUnLock);
                });
                SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                {
	                String stResponse = task.Result as String;
                    DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                    if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                    {
                   
                    LoadCardList();
                    }
                    else
                    {
                    frmMSg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg + " :  " + dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                    }
                }, SynchronizationContext.Current);
            }
        }

        private void dgvCardList_DoubleClick(object sender, EventArgs e)
        {
            if (m_iCurrentCardIndex >= 0)
            {
                bool bUnLock = Boolean.Parse(m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["CARD_STATE"].ToString());
                string logInfo = "Thông tin chi tiết thẻ: \n" +
                                 "- Mã thẻ :" + m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["CARD_ID"] + "\n" +
                                 "- Trạng thái :" + (bUnLock ? "Đang sử dụng" : "Đã khóa") + "\n" +
                                 "- Ngày mua thẻ :" + m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["CARD_BUY_DATE"] + "\n" +
                                 "- Số tiền trên thẻ :" + m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["CARD_MONEY"] + "\n" +
                                 "- Ngày nạp tiền :" + m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["RECHARGE_DATE"] + "\n" +
                                 "- Số tiền nạp :" + m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["RECHARGE_MONEY"] + "\n" +
                                 "- Giá xăng tại thời điểm nạp tiền: \n" +
                                 "    + Xăng 92 : " + m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["RECHARGE_GAS92_PRICE"] + "\n" +
                                 "    + Xăng 95 : " + m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["RECHARGE_GAS95_PRICE"] + "\n" +
                                 "    + Dầu DO : " + m_dsCard.Tables[0].Rows[m_iCurrentCardIndex]["RECHARGE_GASDO_PRICE"] + "\n";
                frmMSg.ShowMsg(SGMText.SGM_INFO, logInfo, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
            }
        }

        private void btnDelCard_Click(object sender, EventArgs e)
        {

        }
    }
}
