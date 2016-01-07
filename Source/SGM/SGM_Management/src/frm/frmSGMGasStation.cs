using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SGM_Core.DTO;
using SGM_Core.Utils;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace SGM_Management
{
    public partial class frmGasStation : Form
    {
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        private SGM_Service.ServiceSoapClient m_service = null;
        private DataSet m_dsGasStation;
        private int m_iCurrentGSIndex = -1;
        private string m_stGSIDEdit = "";
		private frmSGMMessage frmMsg = null;
        private SerialDataReceivedEventHandler serialDatahandler = null;
        public frmGasStation()
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
            //cboGasStore.Enabled = isEditMode;
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
        private void frmGasStation_Load(object sender, EventArgs e)
        {
            LoadGasStoreList();
            
            UpdateStateControls(false);
        }
        private void LoadGasStoreList()
        {
            cboGasStore.Items.Clear();
            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () =>
            {
                return m_service.SGMManager_GetGasStoreList();
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
                String stResponse = task.Result as String;
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    DataSet ds = dataResponse.ResponseDataSet;
                    DataTable tblResult = ds.Tables[0];
                    if (tblResult.Rows.Count > 0)
                    {
                        //ComboboxItem itemAll = new ComboboxItem();
                        //itemAll.Text = SGMText.SGM_ALL;
                        //itemAll.Value = "";
                        //cboGasStore.Items.Add(itemAll);
                        foreach (DataRow dr in tblResult.Rows)
                        {
                            ComboboxItem item = new ComboboxItem();
                            item.Text = dr["GASSTORE_NAME"].ToString();
                            item.Value = dr["GASSTORE_ID"].ToString();
                            cboGasStore.Items.Add(item);
                            
                        }
                        if (cboGasStore.Items.Count > 0)
                        {
                            cboGasStore.SelectedIndex = 0;
                           
                            
                        }
                    }
                }
                else
                {
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                }
            }, SynchronizationContext.Current);
        }
        private void LoadGasStationList()
        {
            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () =>
            {
                //if (m_stGasStoreID.Equals(""))
                //    return m_service.SGMManager_GetGasStation(null, null);
                //else
                    return m_service.SGMManager_GetGasStation(null, m_stGasStoreID);
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
	            String stResponse = task.Result as String;
                DataTransfer response = JSonHelper.ConvertJSonToObject(stResponse);
                dgvGSList.Rows.Clear();
                m_dsGasStation = response.ResponseDataSet;
                int iOldSelected = m_iCurrentGSIndex;
                if (m_dsGasStation != null && dgvGSList.ColumnCount > 0)
                {
                    for (int i = 0; i < m_dsGasStation.Tables[0].Rows.Count; i++)
                    {
                        dgvGSList.Rows.Add();
                        dgvGSList.Rows[i].Cells[0].Value = (i + 1);
                        dgvGSList.Rows[i].Cells[1].Value = m_dsGasStation.Tables[0].Rows[i]["GASSTATION_ID"];
                        dgvGSList.Rows[i].Cells[2].Value = m_dsGasStation.Tables[0].Rows[i]["GASSTATION_NAME"];
                        dgvGSList.Rows[i].Cells[3].Value = m_dsGasStation.Tables[0].Rows[i]["GASSTATION_ADDRESS"];
                    
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
                errProvider.SetError(txtGSCode, SGMText.GASSTATION_DATA_INPUT_GS_ID_ERR);
                bValidate = false;
            }            
            else if (!txtGSCode.Text.Trim().Equals(m_stGSIDEdit))
            {
                Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                () =>
                {
                    return m_service.SGMManager_CheckGasStationExist(txtGSCode.Text.Trim());
                });
                SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                {
                    String stResponse = task.Result as String;
                    DataTransfer response = JSonHelper.ConvertJSonToObject(stResponse);
                    if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                    {
                        if (response.ResponseDataBool)
                        {
                            errProvider.SetError(txtGSCode, SGMText.GASSTATION_DATA_INPUT_EXIST_GS_ID_ERR);
                            bValidate = false;
                        }
                    }
                    else
                    {
                        errProvider.SetError(txtGSCode, SGMText.GASSTATION_GET_GS_ERR);
                        frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.CUSTOMER_GET_CUS_ERR + "\n" + response.ResponseErrorMsg + ":\n" + response.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                        bValidate = false;
                    }
                }, SynchronizationContext.Current);

            }
            if (cboGasStore.Items.Count <= 0)
            {
                errProvider.SetError(cboGasStore, SGMText.GASSTATION_DATA_INPUT_GS_GASTORE_ERR);
                bValidate = false;
            }
            if (txtGSName.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtGSName, SGMText.GASSTATION_DATA_INPUT_GS_NAME_ERR);
                bValidate = false;
            }
            if (txtGSAddress.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtGSAddress, SGMText.GASSTATION_DATA_INPUT_GS_ADDRESS_ERR);
                bValidate = false;
            }
           
            return bValidate;
        }
        private void UpdateInputFields()
        {
            if (m_dsGasStation != null && m_dsGasStation.Tables.Count > 0 && m_dsGasStation.Tables[0].Rows.Count > 0 && dgvGSList.SelectedRows.Count > 0)
            {
                m_iCurrentGSIndex = dgvGSList.SelectedRows[0].Index;
                if (m_iCurrentGSIndex < m_dsGasStation.Tables[0].Rows.Count)
                {
                    //updateComboBox(cboGasStore , m_dsGasStation.Tables[0].Rows[m_iCurrentGSIndex]["GASSTORE_ID"].ToString());
                    txtGSCode.Text = m_dsGasStation.Tables[0].Rows[m_iCurrentGSIndex]["GASSTATION_ID"].ToString();
                    txtGSName.Text = m_dsGasStation.Tables[0].Rows[m_iCurrentGSIndex]["GASSTATION_NAME"].ToString();
                    txtGSAddress.Text = m_dsGasStation.Tables[0].Rows[m_iCurrentGSIndex]["GASSTATION_ADDRESS"].ToString();
                    txtGSDes.Text = m_dsGasStation.Tables[0].Rows[m_iCurrentGSIndex]["GASSTATION_DESCRIPTION"].ToString();
                    txtMacAddress.Text = m_dsGasStation.Tables[0].Rows[m_iCurrentGSIndex]["GASSTATION_MACADDRESS"].ToString();
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

        private void updateComboBox(ComboBox cbo, string value)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                ComboboxItem item = (ComboboxItem)cbo.Items[i];
                if (item.Value.Equals(value))
                {
                    cbo.SelectedIndex = i;
                    break;
                }
            }
        }
        private void clearInput()
        {
            txtGSCode.Text = "";
            txtGSName.Text = "";
            txtGSAddress.Text = "";
            txtGSDes.Text = "";
            txtMacAddress.Text = "";
            //if (cboGasStore.Items.Count > 0)
            //    cboGasStore.SelectedIndex = 0;
        }

        private void dgvGSList_SelectionChanged(object sender, EventArgs e)
        {
            UpdateInputFields();           
            UpdateStateControls(false);
        }

        private void SelectGSRow(string id)
        {
            if (m_dsGasStation != null)
            {
                for (int i = 0; i < m_dsGasStation.Tables[0].Rows.Count; i++)
                {
                    string gsID = m_dsGasStation.Tables[0].Rows[i]["GASSTATION_ID"].ToString();
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
                GasStationDTO gas = new GasStationDTO();
                gas.GasStationID = txtGSCode.Text.Trim();
                gas.GasStationName = txtGSName.Text.Trim();
                gas.GasStationAddress = txtGSAddress.Text.Trim();
                gas.GasStationDescription = txtGSDes.Text.Trim();
                gas.GasStoreID = ((ComboboxItem)cboGasStore.SelectedItem).Value.ToString();

                DataTransfer request = new DataTransfer();
                request.ResponseDataGasStationDTO = gas;
                string jsRequest = JSonHelper.ConvertObjectToJSon(request);
                Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                () =>
                {
                    return m_service.SGMManager_AddNewGasStaion(jsRequest);
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
                    LoadGasStationList();
                    SelectGSRow(gas.GasStationID);
                    UpdateStateControls(false);
                    
                }, SynchronizationContext.Current);
                

                
            } 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "&Thêm";
            btnEdit.Text = "&Sửa";
            LoadGasStationList();
            UpdateStateControls(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (m_iCurrentGSIndex >= 0)
            {

                string gasID = m_dsGasStation.Tables[0].Rows[m_iCurrentGSIndex]["GASSTATION_ID"].ToString();
                string gasName = m_dsGasStation.Tables[0].Rows[m_iCurrentGSIndex]["GASSTATION_NAME"].ToString();
				
                if (frmMsg.ShowMsg(SGMText.SGM_WARNING, SGMText.CUSTOMER_DEL_CUS_WARNING + "\n" + gasID + " : " + gasName, SGMMessageType.SGM_MESSAGE_TYPE_QUES) == SGMMessageResult.SGM_MESSAGE_RESULT_OK)
                {
                    Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                    () =>
                    {
                        return m_service.SGMManager_DelGasStation(gasID);
                    });
                    SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                    {
	                    String stResponse = task.Result as String;
                        DataTransfer response = JSonHelper.ConvertJSonToObject(stResponse);
                        if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                        {                        
                            frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.GASSTATION_DEL_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                            if (m_iCurrentGSIndex == dgvGSList.RowCount - 1)
                                m_iCurrentGSIndex--;
                            LoadGasStationList();
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
                    m_stGSIDEdit = m_dsGasStation.Tables[0].Rows[m_iCurrentGSIndex]["GASSTATION_ID"].ToString();
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
                    GasStationDTO gas = new GasStationDTO();
                    gas.GasStationID = txtGSCode.Text.Trim();
                    gas.GasStationName = txtGSName.Text.Trim();
                    gas.GasStationAddress = txtGSAddress.Text.Trim();
                    gas.GasStationDescription = txtGSDes.Text.Trim();
                    gas.GasStationMacAddress = txtMacAddress.Text.Trim();
                    gas.GasStoreID = ((ComboboxItem)cboGasStore.SelectedItem).Value.ToString();

                    DataTransfer request = new DataTransfer();
                    request.ResponseDataGasStationDTO = gas;
                    string jsRequest = JSonHelper.ConvertObjectToJSon(request);
                    Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                    () =>
                    {
                        return m_service.SGMManager_UpdateGasStation(jsRequest, m_stGSIDEdit);
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
                        LoadGasStationList();
                        SelectGSRow(gas.GasStationID);
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

        private void frmGasStation_FormClosing(object sender, FormClosingEventArgs e)
        {
            RFIDReader.UnRegistryReaderListener(Program.ReaderPort, serialDatahandler);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMacAddress.Text = "";
        }

        private void txtGSAddress_TextChanged(object sender, EventArgs e)
        {

        }
        private string m_stGasStoreID = "";
        private void cboGasStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_stGasStoreID = ((ComboboxItem)cboGasStore.SelectedItem).Value.ToString();
            if (!btnCancel.Enabled)
            {
                
                LoadGasStationList();
            }
        }
    }
}
