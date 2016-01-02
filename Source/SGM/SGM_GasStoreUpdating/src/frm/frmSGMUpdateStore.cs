using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGM_Core.DTO;
using SGM_Core.Utils;
using SGM_WaitingIdicator;
using System.Threading;
using System.Threading.Tasks;

namespace SGM_GasStoreUpdating
{
    public partial class frmSGMUpdateStore : Form
    {
        private SGM_Service.ServiceSoapClient m_service = null;
        private frmSGMMessage frmMsg = null;

        GasStoreDTO _storeDTO = null;

        public frmSGMUpdateStore(GasStoreDTO dto)
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
            frmMsg = new frmSGMMessage();
            _storeDTO = dto;
        }

        private void frmSGMUpdateStore_Load(object sender, EventArgs e)
        {
            DataToUIView();
            SGM_WaitingIdicator.WaitingForm.waitingFrm.SetParentForm(this);
        }

        private void DataToUIView()
        {
            if (_storeDTO == null)
                return;

            lblTitle.Text = "KHO XĂNG DẦU " + _storeDTO.GasStoreName;
            txtGas92Current.Text = _storeDTO.GasStoreGas92Total.ToString();
            txtGas95Current.Text = _storeDTO.GasStoreGas95Total.ToString();
            txtGasDOCurrent.Text = _storeDTO.GasStoreGasDOTotal.ToString();

            txtGas92New.Text = "";
            txtGas95New.Text = "";
            txtGasDONew.Text = "";

            txtNote.Text = "";
        }

        private bool ValidateDataInput()
        {
            bool bValidate = true;
            Control[] f = { txtGas92New, 
                              txtGas95New,
                              txtGasDONew
                          };
            for (int i = 0; i < f.Length; i++)
            {
                SGMHelper.ShowToolTip(f[i], "");
                String txt = f[i].Text.Trim();
                if (txt.Equals(""))
                {
                    SGMHelper.ShowToolTip(f[i], SGMText.UPDATE_TOTAL_INPUT_NULL);
                    bValidate = false;
                    break;
                }
                float tmp;
                if (float.TryParse(txt, out tmp) == false || tmp < 0)
                {
                    SGMHelper.ShowToolTip(f[i], SGMText.UPDATE_TOTAL_INPUT_ERR);
                    bValidate = false;
                    break;
                }
            }
            return bValidate;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_storeDTO == null)
            {
                //frmMsg.ShowMsg(SGMText.SGM_ERROR, "DTO NULL", SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                return;
            }
            if (!ValidateDataInput())
            {
                return;
            }
            
            float gas92Add = float.Parse(txtGas92New.Text);
            float gas95Add = float.Parse(txtGas95New.Text);
            float gasDOAdd = float.Parse(txtGasDONew.Text);

            DataTransfer request = new DataTransfer();
            
            GasStoreDTO cloneStoreDTO = new GasStoreDTO(_storeDTO);
            cloneStoreDTO.GasStoreGas92Total = _storeDTO.GasStoreGas92Total + gas92Add;
            cloneStoreDTO.GasStoreGas95Total = _storeDTO.GasStoreGas95Total + gas95Add;
            cloneStoreDTO.GasStoreGasDOTotal = _storeDTO.GasStoreGasDOTotal + gasDOAdd;
                        
            request.ResponseDataGasStoreDTO = cloneStoreDTO;
            string jsRequest = JSonHelper.ConvertObjectToJSon(request);
            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () =>
            {
                return m_service.SGMManager_UpdateGasStore(jsRequest, cloneStoreDTO.GasStoreID);
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
                String stResponse = task.Result as String;
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    DataTransfer request2 = new DataTransfer();
                    GasStoreUpdateDTO dto = new GasStoreUpdateDTO();
                    dto.GasStoreID = _storeDTO.GasStoreID;
                    dto.GSUpdateDate = DateTime.Now;
                    dto.GSUpdateDescription = txtNote.Text;
                    dto.GSUpdateGas92Add = gas92Add;
                    dto.GSUpdateGas95Add = gas95Add;
                    dto.GSUpdateGasDOAdd = gasDOAdd;
                    dto.GSUpdateGas92Total = _storeDTO.GasStoreGas92Total;
                    dto.GSUpdateGas95Total = _storeDTO.GasStoreGas95Total;
                    dto.GSUpdateGasDOTotal = _storeDTO.GasStoreGasDOTotal;
                    request2.ResponseDataGasStoreUpdateDTO = dto;
                    string jsRequest2 = JSonHelper.ConvertObjectToJSon(request2);
                    Task<String> task2 = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                    () =>
                    {
                        return m_service.SGMManager_AddNewGasStoreUpdate(jsRequest2);
                    });
                    SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task2, () =>
                    {
                        String stResponse2 = task2.Result as String;
                        DataTransfer dataResponse2 = JSonHelper.ConvertJSonToObject(stResponse);
                        if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                        {
                            frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.ADMIN_UPDATE_TOTAL_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                            _storeDTO.GasStoreGas92Total = _storeDTO.GasStoreGas92Total + gas92Add;
                            _storeDTO.GasStoreGas95Total = _storeDTO.GasStoreGas95Total + gas95Add;
                            _storeDTO.GasStoreGasDOTotal = _storeDTO.GasStoreGasDOTotal + gasDOAdd;
                            DataToUIView();
                        }
                        else
                        {
                            frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                        }
                    }, SynchronizationContext.Current);
                }
                else
                {
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                }
            }, SynchronizationContext.Current);
        }
    }
}
