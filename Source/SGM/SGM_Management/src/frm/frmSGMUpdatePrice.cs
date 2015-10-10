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
    public partial class frmSGMUpdatePrice : Form
    {
        private SGM_Service.ServiceSoapClient m_service = null;

        private SystemAdminDTO m_currentAdminDTO = null;

        public frmSGMUpdatePrice()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
        }

        private void frmSGMUpdatePrice_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";

            if (m_currentAdminDTO != null)
            {
                txtGas92CurrentPrice.Text = m_currentAdminDTO.SysGas92CurrentPrice.ToString();
                txtGas95CurrentPrice.Text = m_currentAdminDTO.SysGas95CurrentPrice.ToString();
                txtGasDOCurrentPrice.Text = m_currentAdminDTO.SysGasDOCurrentPrice.ToString();
            }
        }

        public void SetCurrentAdminDTO(SystemAdminDTO _ad)
        {
            m_currentAdminDTO = _ad;
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
            string jsRequest = JSonHelper.ConvertObjectToJSon(request);

            string response = m_service.SGMManager_UpdateSystemPrice(jsRequest);
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(response);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                MessageBox.Show(dataResponse.ResponseErrorMsg, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(dataResponse.ResponseErrorMsgDetail, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}
