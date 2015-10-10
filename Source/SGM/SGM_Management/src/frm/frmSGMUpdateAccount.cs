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
    public partial class frmSGMUpdateAccount : Form
    {
        private SGM_Service.ServiceSoapClient service = new SGM_Service.ServiceSoapClient();

        private string old_admin;
        private JSonHelper m_jsHelper;
        public frmSGMUpdateAccount()
        {
            InitializeComponent();
            m_jsHelper = new JSonHelper();
        }
       
        public void setCurrentAdmin(string name)
        {
            old_admin = name;
        }
        private bool ValidateInput()
        {
            bool check = true;
            if (txtAdmin.Text == string.Empty)
            {
                check = false;
                errorProvider1.SetError(txtAdmin, "Tài khoản ?");
            }
            else
                errorProvider1.SetError(txtAdmin, null);

            if (txtPwd.Text == string.Empty)
            {
                check = false;
                errorProvider1.SetError(txtPwd, "Mật khẩu ?");
            }
            else
                errorProvider1.SetError(txtPwd, null);

            if (txtPwdRepeat.Text == string.Empty)
            {
                check = false;
                errorProvider1.SetError(txtPwdRepeat, "Nhập lại mật khẩu.");
            }
            else
                errorProvider1.SetError(txtPwdRepeat, null);

            if (txtPwd.Text != txtPwdRepeat.Text)
            {
                check = false;
                errorProvider1.SetError(txtPwdRepeat, "Mật khẩu không khớp.");
            }
            else
                errorProvider1.SetError(txtPwdRepeat, null);

            return check;
        }

        private void frmSGMUpdateAccount_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            // request server
            string SYS_ADMIN = txtAdmin.Text;
            string SYS_PWD = txtPwd.Text;

            String stResponse = service.SGMManager_UpdateAdminAccount(old_admin, SYS_ADMIN, SYS_PWD);
            DataTransfer dataResponse = m_jsHelper.ConvertJSonToObject(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                MessageBox.Show(dataResponse.ResponseErrorMsg, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(dataResponse.ResponseErrorMsg, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
