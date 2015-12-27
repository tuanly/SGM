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

namespace SGM_Management
{
    public partial class frmSGMUpdatePrice : Form
    {
        private SGM_Service.ServiceSoapClient m_service = null;
        private frmSGMMessage frmMSg = null;
        
        public frmSGMUpdatePrice()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
            frmMSg = new frmSGMMessage();
        }

        private void frmSGMUpdatePrice_Load(object sender, EventArgs e)
        {       

            DataToUIView();
            SGM_WaitingIdicator.WaitingForm.waitingFrm.SetParentForm(this.ParentForm);
        }

        
        private bool ValidateDataInput()
        {
            bool bValidate = true;
            Control[] f = { txtGas92NewPrice, 
                              txtGas95NewPrice,
                              txtGasDONewPrice
                          };
            for (int i = 0; i < f.Length; i++)
            {
                String txt = f[i].Text.Trim();
                SGMHelper.ShowToolTip(f[i], "");
                if (txt.Equals(""))
                {
                    SGMHelper.ShowToolTip(f[i], SGMText.UPDATE_PRICE_INPUT_NULL);
                    bValidate = false;
                    break;
                }
                if (!txt.All(Char.IsDigit) || Int32.Parse(txt) < 0)
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
            if (!ValidateDataInput())
            {
                return;
            }
            frmGSMMain.s_currentAdminDTO.SysApplyDate = dtpNew.Value;
            frmGSMMain.s_currentAdminDTO.SysGas92CurrentPrice = frmGSMMain.s_currentAdminDTO.SysGas92NewPrice = Int32.Parse(txtGas92NewPrice.Text);
            frmGSMMain.s_currentAdminDTO.SysGas95CurrentPrice = frmGSMMain.s_currentAdminDTO.SysGas95NewPrice = Int32.Parse(txtGas95NewPrice.Text);
            frmGSMMain.s_currentAdminDTO.SysGasDOCurrentPrice = frmGSMMain.s_currentAdminDTO.SysGasDONewPrice = Int32.Parse(txtGasDONewPrice.Text);

            DataTransfer request = new DataTransfer();
            request.ResponseDataSystemAdminDTO = frmGSMMain.s_currentAdminDTO;
            String jsRequest = JSonHelper.ConvertObjectToJSon(request);

            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () =>
            {
                return m_service.SGMManager_UpdateSystemPrice(jsRequest);
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
                String stResponse = task.Result as String;
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    frmMSg.ShowMsg(SGMText.SGM_INFO, SGMText.ADMIN_UPDATE_PRICE_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                    DataToUIView();
                }
                else
                {
                    frmMSg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                    frmGSMMain.s_currentAdminDTO.SysGas92CurrentPrice = int.Parse(txtGas92CurrentPrice.Text);
                    frmGSMMain.s_currentAdminDTO.SysGas95CurrentPrice = int.Parse(txtGas95CurrentPrice.Text);
                    frmGSMMain.s_currentAdminDTO.SysGasDOCurrentPrice = int.Parse(txtGasDOCurrentPrice.Text);
                }
            }, SynchronizationContext.Current);
        }

        private void DataToUIView()
        {
            if (frmGSMMain.s_currentAdminDTO != null)
            {
                txtGas92CurrentPrice.Text = frmGSMMain.s_currentAdminDTO.SysGas92CurrentPrice.ToString();
                txtGas95CurrentPrice.Text = frmGSMMain.s_currentAdminDTO.SysGas95CurrentPrice.ToString();
                txtGasDOCurrentPrice.Text = frmGSMMain.s_currentAdminDTO.SysGasDOCurrentPrice.ToString();
                dtpOld.Value = frmGSMMain.s_currentAdminDTO.SysApplyDate;
            }
        }
    }
}
