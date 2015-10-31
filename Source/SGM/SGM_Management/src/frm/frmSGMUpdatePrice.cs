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


namespace SGM_Management
{
    public partial class frmSGMUpdatePrice : Form
    {
        private SGM_Service.ServiceSoapClient m_service = null;
        private frmSGMMessage frmMSg = null;
        private WaitingForm waitingFrm;

        private SystemAdminDTO m_currentAdminDTO = null;
        public void SetCurrentAdminDTO(SystemAdminDTO _ad)
        {
            m_currentAdminDTO = _ad;
        }

        public frmSGMUpdatePrice()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
            frmMSg = new frmSGMMessage();
            waitingFrm = new WaitingForm(this);
        }

        private void frmSGMUpdatePrice_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";

            DataToUIView();
            waitingFrm._bw.DoWork += DoUpdate;
            waitingFrm._bw.RunWorkerCompleted += DoUpdateCompleted;
        }

        
        private bool ValidateDataInput()
        {
            bool bValidate = true;
            errorProvider1.Clear();
            Control[] f = { txtGas92NewPrice, 
                              txtGas95NewPrice,
                              txtGasDONewPrice
                          };
            for (int i = 0; i < f.Length; i++)
            {
                String txt = f[i].Text.Trim();
                if (txt.Equals(""))
                {
                    errorProvider1.SetError(f[i], SGMText.UPDATE_PRICE_INPUT_NULL);
                    bValidate = false;
                    break;
                }
                if (!txt.All(Char.IsDigit) || Int32.Parse(txt) < 0)
                {
                    errorProvider1.SetError(f[i], SGMText.UPDATE_PRICE_INPUT_ERR);
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
            m_currentAdminDTO.SysApplyDate = dateTimePicker1.Value;
            m_currentAdminDTO.SysGas92CurrentPrice = m_currentAdminDTO.SysGas92NewPrice = Int32.Parse(txtGas92NewPrice.Text);
            m_currentAdminDTO.SysGas95CurrentPrice = m_currentAdminDTO.SysGas95NewPrice = Int32.Parse(txtGas95NewPrice.Text);
            m_currentAdminDTO.SysGasDOCurrentPrice = m_currentAdminDTO.SysGasDONewPrice = Int32.Parse(txtGasDONewPrice.Text);

            DataTransfer request = new DataTransfer();
            request.ResponseDataSystemAdminDTO = m_currentAdminDTO;
            String jsRequest = JSonHelper.ConvertObjectToJSon(request);

            waitingFrm.ShowMe();
            waitingFrm._bw.RunWorkerAsync(jsRequest);
        }

        private void DoUpdate(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            String jsRequest = (String)doWorkEventArgs.Argument;
            doWorkEventArgs.Result = m_service.SGMManager_UpdateSystemPrice(jsRequest);
        }

        private void DoUpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitingFrm.HideMe();
            String stResponse = e.Result as String;
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                frmMSg.ShowMsg(SGMText.SGM_INFO, SGMText.ADMIN_UPDATE_PRICE_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                DataToUIView();
            }
            else
            {
                frmMSg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                m_currentAdminDTO.SysGas92CurrentPrice = int.Parse(txtGas92CurrentPrice.Text);
                m_currentAdminDTO.SysGas95CurrentPrice = int.Parse(txtGas95CurrentPrice.Text);
                m_currentAdminDTO.SysGasDOCurrentPrice = int.Parse(txtGasDOCurrentPrice.Text);
            }
        }

        private void DataToUIView()
        {
            if (m_currentAdminDTO != null)
            {
                txtGas92CurrentPrice.Text = m_currentAdminDTO.SysGas92CurrentPrice.ToString();
                txtGas95CurrentPrice.Text = m_currentAdminDTO.SysGas95CurrentPrice.ToString();
                txtGasDOCurrentPrice.Text = m_currentAdminDTO.SysGasDOCurrentPrice.ToString();
            }
        }
    }
}
