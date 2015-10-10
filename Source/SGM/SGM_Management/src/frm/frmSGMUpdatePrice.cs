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
        
        private string m_currentAdName;

        public frmSGMUpdatePrice()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
        }

        private void frmSGMUpdatePrice_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
        }

        public void SetCurrentAccount(string _ad)
        {
            m_currentAdName = _ad;
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
            SystemAdminDTO ad = new SystemAdminDTO();
            ad.SysAdminAccount = m_currentAdName;
            ad.SysApplyDate = dateTimePicker1.Value;
            ad.SysGas92CurrentPrice = ad.SysGas92NewPrice = Int32.Parse(txtGas92NewPrice.Text);
            ad.SysGas95CurrentPrice = ad.SysGas95NewPrice = Int32.Parse(txtGas95NewPrice.Text);
            ad.SysGasDOCurrentPrice = ad.SysGasDONewPrice = Int32.Parse(txtGasDONewPrice.Text);

            DataTransfer request = new DataTransfer();
            request.ResponseDataSystemAdminDTO = ad;
            string jsRequest = JSonHelper.ConvertObjectToJSon(request);

            string response = m_service.SGMManager_UpdateSystemPrice(jsRequest);
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(response);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                MessageBox.Show(dataResponse.ResponseErrorMsg, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(dataResponse.ResponseErrorMsg, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}
