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

namespace SGM_Management
{
    public partial class frmSGMUpdateStore : Form
    {
        private SGM_Service.ServiceSoapClient m_service = null;

        public frmSGMUpdateStore()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
        }

        private SystemAdminDTO m_currentAdminDTO = null;
        public void SetCurrentAdminDTO(SystemAdminDTO _ad)
        {
            m_currentAdminDTO = _ad;
        }

        private void frmSGMUpdateStore_Load(object sender, EventArgs e)
        {
            DataToUIView();
        }

        private void DataToUIView()
        {
            if (m_currentAdminDTO != null)
            {
                txtGas92Current.Text = m_currentAdminDTO.SysGas92Total.ToString();
                txtGas95Current.Text = m_currentAdminDTO.SysGas95Total.ToString();
                txtGasDOCurrent.Text = m_currentAdminDTO.SysGasDOTotal.ToString();
            }
        }

        private bool ValidateDataInput()
        {
            bool bValidate = true;
            errorProvider1.Clear();
            Control[] f = { txtGas92New, 
                              txtGas95New,
                              txtGasDONew
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
            m_currentAdminDTO.SysGas92Total = Int32.Parse(txtGas92Current.Text) + Int32.Parse(txtGas92New.Text);
            m_currentAdminDTO.SysGas95Total = Int32.Parse(txtGas95Current.Text) + Int32.Parse(txtGas95New.Text);
            m_currentAdminDTO.SysGasDOTotal = Int32.Parse(txtGasDOCurrent.Text) + Int32.Parse(txtGasDONew.Text);

            DataTransfer request = new DataTransfer();
            request.ResponseDataSystemAdminDTO = m_currentAdminDTO;
            string jsRequest = JSonHelper.ConvertObjectToJSon(request);

            string response = m_service.SGMManager_UpdateSystemStore(jsRequest);
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(response);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                MessageBox.Show(dataResponse.ResponseErrorMsg, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataToUIView();
            }
            else
            {
                MessageBox.Show(dataResponse.ResponseErrorMsgDetail, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_currentAdminDTO.SysGas92Total = Int32.Parse(txtGas92Current.Text);
                m_currentAdminDTO.SysGas95Total = Int32.Parse(txtGas95Current.Text);
                m_currentAdminDTO.SysGasDOTotal = Int32.Parse(txtGasDOCurrent.Text);
            }
        }
    }
}
