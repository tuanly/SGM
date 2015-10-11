using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SGM_Core.DTO;
using SGM_Core.Utils;

namespace SGM_Management
{
    public partial class frmSGMLogin : Form
    {
        private SGM_Service.ServiceSoapClient service = new SGM_Service.ServiceSoapClient();
        private JSonHelper m_jsHelper;
        public frmSGMLogin()
        {
            InitializeComponent();
            m_jsHelper = new JSonHelper();
        }

        private void frmSGMLogin_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateLoginCode()
        {
            bool check = true;
            if (string.IsNullOrEmpty(txtAdmin.Text))
            {
                errorProvider1.SetError(txtAdmin, "Tên Admin ?");
                check = false;
            }
            else
            {
                errorProvider1.SetError(txtAdmin, null);
            }

            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                errorProvider1.SetError(txtPwd, "Mật khẩu ?");
                check = false;
            }
            else
            {
                errorProvider1.SetError(txtPwd, null);
            }
            return check;
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // validate user input
                Login();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if (ValidateLoginCode() == false)
                return;

            // request server
            string SYS_ADMIN = txtAdmin.Text;
            string SYS_PWD = txtPwd.Text;

            String stResponse = service.SGMManager_ValidateAdminLogin(SYS_ADMIN, SYS_PWD);
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                this.Hide();
                frmSGMUpdateStore a = new frmSGMUpdateStore();
                //frmSGMUpdateAccount a = new frmSGMUpdateAccount();
                a.SetCurrentAdminDTO(dataResponse.ResponseDataSystemAdminDTO);
                a.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show(dataResponse.ResponseErrorMsg);
        }
    }
}
