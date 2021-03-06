﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGM_Core.DTO;
using SGM_Core.Utils;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace SGM_Management
{
    public partial class frmSGMStore : Form
    {
        private SGM_Service.ServiceSoapClient m_service = null;
        private DataSet m_dsGasStore;
        private int m_iCurrentGSIndex = -1;
        private string m_stGSIDEdit = "";
		private frmSGMMessage frmMsg = null;
        private SerialDataReceivedEventHandler serialDatahandler = null;
        public frmSGMStore()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
			frmMsg = new frmSGMMessage();
            serialDatahandler = new SerialDataReceivedEventHandler(CardReaderReceivedHandler);
            RFIDReader.RegistryReaderListener(Program.ReaderPort, serialDatahandler);
        }

        private void UpdateStateControls(bool isEditMode)
        {          
            dgvGSList.Enabled = !isEditMode;          
            txtGSCode.Enabled = isEditMode;
            txtGSName.Enabled = isEditMode;
            txtGSDes.Enabled = isEditMode;
            txtGSAddress.Enabled = isEditMode;           
            btnCancel.Enabled = isEditMode;
            btnDelete.Enabled = (!isEditMode && (dgvGSList.RowCount > 0));
            btnAdd.Enabled = (!isEditMode || btnAdd.Text.Equals("&Lưu"));
            btnEdit.Enabled = ((!isEditMode && (dgvGSList.RowCount > 0)) || (isEditMode && btnEdit.Text.Equals("&Lưu")));
            errProvider.Clear();
        }
        private void frmGasStore_Load(object sender, EventArgs e)
        {
            LoadGasStoreList();
            UpdateStateControls(false);
        }

        private void LoadGasStoreList()
        {
            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () =>
            {
                return m_service.SGMManager_GetGasStore(null);
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
	            String stResponse = task.Result as String;
                DataTransfer response = JSonHelper.ConvertJSonToObject(stResponse);
                dgvGSList.Rows.Clear();
                m_dsGasStore = response.ResponseDataSet;
                int iOldSelected = m_iCurrentGSIndex;
                if (m_dsGasStore != null && dgvGSList.ColumnCount > 0)
                {
                    for (int i = 0; i < m_dsGasStore.Tables[0].Rows.Count; i++)
                    {
                        dgvGSList.Rows.Add();
                        dgvGSList.Rows[i].Cells[0].Value = (i + 1);
                        dgvGSList.Rows[i].Cells[1].Value = m_dsGasStore.Tables[0].Rows[i]["GASSTORE_ID"];
                        dgvGSList.Rows[i].Cells[2].Value = m_dsGasStore.Tables[0].Rows[i]["GASSTORE_NAME"];
                        dgvGSList.Rows[i].Cells[3].Value = m_dsGasStore.Tables[0].Rows[i]["GASSTORE_GAS92_TOTAL"];
                        dgvGSList.Rows[i].Cells[4].Value = m_dsGasStore.Tables[0].Rows[i]["GASSTORE_GAS95_TOTAL"];
                        dgvGSList.Rows[i].Cells[5].Value = m_dsGasStore.Tables[0].Rows[i]["GASSTORE_GASDO_TOTAL"];
                    
                    }
                    if (iOldSelected >= 0)
                        m_iCurrentGSIndex = iOldSelected;
                    if (m_iCurrentGSIndex >= dgvGSList.Rows.Count)
                        m_iCurrentGSIndex = -1;
                    if (m_iCurrentGSIndex >= 0)
                        dgvGSList.Rows[m_iCurrentGSIndex].Selected = true;

                }    
            }, SynchronizationContext.Current);
        }
        private bool ValidateDataInput()
        {
            bool bValidate = true;
            errProvider.Clear();
            if (txtGSCode.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtGSCode, SGMText.GASSTORE_DATA_INPUT_GS_ID_ERR);
                bValidate = false;
            }
            else if (!txtGSCode.Text.Trim().Equals(m_stGSIDEdit))
            {
                Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                () =>
                {
                    return m_service.SGMManager_CheckGasStoreExist(txtGSCode.Text.Trim());
                });
                SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                {
	                String stResponse = task.Result as String;
                    DataTransfer response = JSonHelper.ConvertJSonToObject(stResponse);
                    if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                    {
                        if (response.ResponseDataBool)
                        {
                            errProvider.SetError(txtGSCode, SGMText.GASSTORE_DATA_INPUT_EXIST_GS_ID_ERR);
                            bValidate = false;
                        }
                    }
                    else
                    {
                        errProvider.SetError(txtGSCode, SGMText.GASSTORE_GET_GS_ERR);                    
					    frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.CUSTOMER_GET_CUS_ERR + "\n" + response.ResponseErrorMsg + ":\n" + response.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                        bValidate = false;
                    }
                }, SynchronizationContext.Current);
                
            }
            if (txtGSName.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtGSName, SGMText.GASSTORE_DATA_INPUT_GS_NAME_ERR);
                bValidate = false;
            }
            if (txtGSAddress.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtGSAddress, SGMText.GASSTORE_DATA_INPUT_GS_ADDRESS_ERR);
                bValidate = false;
            }
           
            return bValidate;
        }
        private void UpdateInputFields()
        {
            if (m_dsGasStore != null && m_dsGasStore.Tables.Count > 0 && m_dsGasStore.Tables[0].Rows.Count > 0 && dgvGSList.SelectedRows.Count > 0)
            {
                m_iCurrentGSIndex = dgvGSList.SelectedRows[0].Index;
                if (m_iCurrentGSIndex < m_dsGasStore.Tables[0].Rows.Count)
                {
                    txtGSCode.Text = m_dsGasStore.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_ID"].ToString();
                    txtGSName.Text = m_dsGasStore.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_NAME"].ToString();
                    txtGSAddress.Text = m_dsGasStore.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_ADDRESS"].ToString();
                    txtGSDes.Text = m_dsGasStore.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_DESCRIPTION"].ToString();
                    txtMacAddress.Text = m_dsGasStore.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_MACADDRESS"].ToString();
                    txtTotalGas92.Text = m_dsGasStore.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_GAS92_TOTAL"].ToString();
                    txtTotalGas95.Text = m_dsGasStore.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_GAS95_TOTAL"].ToString();
                    txtTotalGasDO.Text = m_dsGasStore.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_GASDO_TOTAL"].ToString();
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;                   
                }
            }
            else
            {
                clearInput();
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false; 
            }

        }

        private void clearInput()
        {
            txtGSCode.Text = "";
            txtGSName.Text = "";
            txtGSAddress.Text = "";
            txtGSDes.Text = "";
            txtMacAddress.Text = "";
            txtTotalGas92.Text = "";
            txtTotalGas95.Text = "";
            txtTotalGasDO.Text = "";
        }

        private void dgvGSList_SelectionChanged(object sender, EventArgs e)
        {
            UpdateInputFields();           
            UpdateStateControls(false);
        }

        private void SelectGSRow(string id)
        {
            if (m_dsGasStore != null)
            {
                for (int i = 0; i < m_dsGasStore.Tables[0].Rows.Count; i++)
                {
                    string gsID = m_dsGasStore.Tables[0].Rows[i]["GASSTORE_ID"].ToString();
                    if (gsID.Equals(id))
                    {
                        dgvGSList.Rows[i].Selected = true;
                        return;
                    }

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text.Equals("&Thêm"))
            {
                
                btnAdd.Text = "&Lưu";
                UpdateStateControls(true);
                clearInput();
                txtGSCode.Focus();
            }
            else
            {
                if (!ValidateDataInput())
                {
                    return;
                }
                GasStoreDTO gas = new GasStoreDTO();
                gas.GasStoreID = txtGSCode.Text.Trim();
                gas.GasStoreName = txtGSName.Text.Trim();
                gas.GasStoreAddress = txtGSAddress.Text.Trim();
                gas.GasStoreDescription = txtGSDes.Text.Trim();
                gas.GasStoreGas92Total = 0;
                gas.GasStoreGas95Total = 0;
                gas.GasStoreGasDOTotal = 0;
               
                DataTransfer request = new DataTransfer();
                request.ResponseDataGasStoreDTO = gas;
                string jsRequest = JSonHelper.ConvertObjectToJSon(request);
                Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                () =>
                {
                    return m_service.SGMManager_AddNewGasStore(jsRequest);
                });
                SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                {
	                String stResponse = task.Result as String;
                    DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                    if (dataResponse.ResponseCode != DataTransfer.RESPONSE_CODE_SUCCESS)
                    {                    
					    frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg + "\n" + dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                        return;
                    }
                    btnAdd.Text = "&Thêm";
                    LoadGasStoreList();
                    SelectGSRow(gas.GasStoreID);
                    UpdateStateControls(false);
                    
                }, SynchronizationContext.Current);
                

                
            } 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "&Thêm";
            btnEdit.Text = "&Sửa";
            LoadGasStoreList();
            UpdateStateControls(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (m_iCurrentGSIndex >= 0)
            {

                string gasID = m_dsGasStore.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_ID"].ToString();
                string gasName = m_dsGasStore.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_NAME"].ToString();
				
                if (frmMsg.ShowMsg(SGMText.SGM_WARNING, SGMText.CUSTOMER_DEL_CUS_WARNING + "\n" + gasID + " : " + gasName, SGMMessageType.SGM_MESSAGE_TYPE_QUES) == SGMMessageResult.SGM_MESSAGE_RESULT_OK)
                {
                    Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                    () =>
                    {
                        return m_service.SGMManager_DelGasStore(gasID);
                    });
                    SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                    {
	                    String stResponse = task.Result as String;
                        DataTransfer response = JSonHelper.ConvertJSonToObject(stResponse);
                        if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                        {                        
                            frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.GASSTORE_DEL_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                            if (m_iCurrentGSIndex == dgvGSList.RowCount - 1)
                                m_iCurrentGSIndex--;
                            LoadGasStoreList();
                        }
                        else
                        {                        
                            frmMsg.ShowMsg(SGMText.SGM_ERROR, response.ResponseErrorMsg + "\n" + response.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                        }
                    }, SynchronizationContext.Current);
                    
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (m_iCurrentGSIndex >= 0)
            {

                if (btnEdit.Text.Equals("&Sửa"))
                {
                    m_stGSIDEdit = m_dsGasStore.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_ID"].ToString();
                    btnEdit.Text = "&Lưu";
                    UpdateStateControls(true);
                    btnReset.Enabled = true;
                    txtGSCode.Focus();
                }
                else
                {
                    if (!ValidateDataInput())
                    {
                        return;
                    }
                    GasStoreDTO gas = new GasStoreDTO();
                    gas.GasStoreID = txtGSCode.Text.Trim();
                    gas.GasStoreName = txtGSName.Text.Trim();
                    gas.GasStoreAddress = txtGSAddress.Text.Trim();
                    gas.GasStoreDescription = txtGSDes.Text.Trim();
                    gas.GasStoreMacAddress = txtMacAddress.Text.Trim();
                    gas.GasStoreGas92Total = float.Parse(txtTotalGas92.Text);
                    gas.GasStoreGas95Total = float.Parse(txtTotalGas95.Text);
                    gas.GasStoreGasDOTotal = float.Parse(txtTotalGasDO.Text);
                    DataTransfer request = new DataTransfer();
                    request.ResponseDataGasStoreDTO = gas;
                    string jsRequest = JSonHelper.ConvertObjectToJSon(request);
                    Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                    () =>
                    {
                        return m_service.SGMManager_UpdateGasStore(jsRequest, m_stGSIDEdit);
                    });
                    SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                    {
	                    String stResponse = task.Result as String;
                        DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                        if (dataResponse.ResponseCode != DataTransfer.RESPONSE_CODE_SUCCESS)
                        {                        
                            frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg + "\n" + dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                            return;
                        }
                        m_stGSIDEdit = "";
                        btnEdit.Text = "&Sửa";
                        btnReset.Enabled = false;
                        LoadGasStoreList();
                        SelectGSRow(gas.GasStoreID);
                        UpdateStateControls(false);
                    }, SynchronizationContext.Current);
                    
                   
                }
            }
        }
        private void CardReaderReceivedHandler(
                       object sender,
                       SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
		        String data = sp.ReadLine();
                if (txtGSCode.Enabled == true)
                {
		            if (data != null && data.Length > 1)
                    	txtGSCode.Invoke(new MethodInvoker(delegate { txtGSCode.Text = data.Substring(0, data.Length - 1); }));
                }
            }
            catch (TimeoutException)
            {
            }



        }

        private void frmGasStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            RFIDReader.UnRegistryReaderListener(Program.ReaderPort, serialDatahandler);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMacAddress.Text = "";
        }
    }
}
