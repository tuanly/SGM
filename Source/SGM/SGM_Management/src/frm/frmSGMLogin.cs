using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGM_Core.DTO;

namespace SGM_Management
{
    public partial class frmSGMLogin : Form
    {
        private SGM_Service.ServiceSoapClient service = new SGM_Service.ServiceSoapClient();

        public frmSGMLogin()
        {
            InitializeComponent();
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
            DataTransfer dataResponse = new DataTransfer(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                this.Hide();
                new frmGasStation().ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show(dataResponse.ResponseErrorMsg);
        }
    }
}
