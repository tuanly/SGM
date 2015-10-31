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
    public partial class frmSGMUpdateAccount : Form
    {
        private SGM_Service.ServiceSoapClient service = new SGM_Service.ServiceSoapClient();

        private SystemAdminDTO m_currentAdminDTO = null;
        private frmSGMMessage frmMsg = null;
        private WaitingForm waitingFrm;

        public frmSGMUpdateAccount()
        {
            InitializeComponent();
            frmMsg = new frmSGMMessage();
            waitingFrm = new WaitingForm(this);
        }

        public void SetCurrentAdminDTO(SystemAdminDTO ad)
        {
            m_currentAdminDTO = ad;
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
            waitingFrm._bw.DoWork += DoUpdate;
            waitingFrm._bw.RunWorkerCompleted += DoUpdateCompleted;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            waitingFrm.ShowMe();
            waitingFrm._bw.RunWorkerAsync();
        }
        private void DoUpdate(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            string SYS_ADMIN = txtAdmin.Text;
            string SYS_PWD = txtPwd.Text;
            doWorkEventArgs.Result = service.SGMManager_UpdateAdminAccount(m_currentAdminDTO.SysAdminAccount, SYS_ADMIN, SYS_PWD);
        }

        private void DoUpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitingFrm.HideMe();
            String stResponse = e.Result as String;
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.SYS_ADMIN_CHANGE_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
            else
                frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
        }
    }
}
