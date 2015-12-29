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

        public frmSGMUpdateStore()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
            frmMsg = new frmSGMMessage();
        }

        private void frmSGMUpdateStore_Load(object sender, EventArgs e)
        {
            DataToUIView();
            SGM_WaitingIdicator.WaitingForm.waitingFrm.SetParentForm(this);
        }

        private void DataToUIView()
        {
            //if (frmGSMMain.s_currentAdminDTO != null)
            //{
            //    txtGas92Current.Text = frmGSMMain.s_currentAdminDTO.SysGas92Total.ToString();
            //    txtGas95Current.Text = frmGSMMain.s_currentAdminDTO.SysGas95Total.ToString();
            //    txtGasDOCurrent.Text = frmGSMMain.s_currentAdminDTO.SysGasDOTotal.ToString();
            //}
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
                    SGMHelper.ShowToolTip(f[i], SGMText.UPDATE_PRICE_INPUT_NULL);
                    bValidate = false;
                    break;
                }
                float tmp;
                if (float.TryParse(txt, out tmp) == false || tmp < 0)
                {
                    SGMHelper.ShowToolTip(f[i], SGMText.UPDATE_PRICE_INPUT_ERR);
                    bValidate = false;
                    break;
                }
            }
            return bValidate;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (!ValidateDataInput())
            //{
            //    return;
            //}
            //frmGSMMain.s_currentAdminDTO.SysGas92Total = float.Parse(txtGas92Current.Text) + float.Parse(txtGas92New.Text);
            //frmGSMMain.s_currentAdminDTO.SysGas95Total = float.Parse(txtGas95Current.Text) + float.Parse(txtGas95New.Text);
            //frmGSMMain.s_currentAdminDTO.SysGasDOTotal = float.Parse(txtGasDOCurrent.Text) + float.Parse(txtGasDONew.Text);

            //DataTransfer request = new DataTransfer();
            //request.ResponseDataSystemAdminDTO = frmGSMMain.s_currentAdminDTO;
            //string jsRequest = JSonHelper.ConvertObjectToJSon(request);
            //Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            //() =>
            //{
            //    return m_service.SGMManager_UpdateSystemStore(jsRequest);
            //});
            //SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            //{
            //    String stResponse = task.Result as String;
            //    DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
            //    if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            //    {
            //        frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.ADMIN_UPDATE_TOTAL_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
            //        DataToUIView();
            //    }
            //    else
            //    {
            //        frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
            //        frmGSMMain.s_currentAdminDTO.SysGas92Total = float.Parse(txtGas92Current.Text);
            //        frmGSMMain.s_currentAdminDTO.SysGas95Total = float.Parse(txtGas95Current.Text);
            //        frmGSMMain.s_currentAdminDTO.SysGasDOTotal = float.Parse(txtGasDOCurrent.Text);
            //    }
            //}, SynchronizationContext.Current);
        }
    }
}
