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
    public partial class frmSGMUpdateAccount : Form
    {
        private SGM_Service.ServiceSoapClient service = new SGM_Service.ServiceSoapClient();

        private frmSGMMessage frmMsg = null;

        public frmSGMUpdateAccount()
        {
            InitializeComponent();
            frmMsg = new frmSGMMessage();
        }

        private bool ValidateInput()
        {
            bool check = true;
            if (txtAdmin.Text == string.Empty)
            {
                check = false;
                SGMHelper.ShowToolTip(txtAdmin, "Tài khoản ?");
            }
            else
                SGMHelper.ShowToolTip(txtAdmin, "");

            if (txtPwd.Text == string.Empty)
            {
                check = false;
                SGMHelper.ShowToolTip(txtPwd, "Mật khẩu ?");
            }
            else
                SGMHelper.ShowToolTip(txtPwd, "");

            if (txtPwdRepeat.Text == string.Empty)
            {
                check = false;
                SGMHelper.ShowToolTip(txtPwdRepeat, "Nhập lại mật khẩu.");
            }
            else
                SGMHelper.ShowToolTip(txtPwdRepeat, "");

            if (txtPwd.Text != txtPwdRepeat.Text)
            {
                check = false;
                SGMHelper.ShowToolTip(txtPwdRepeat, "Mật khẩu không khớp.");
            }
            else
                SGMHelper.ShowToolTip(txtPwdRepeat, "");

            return check;
        }

        private void frmSGMUpdateAccount_Load(object sender, EventArgs e)
        {
            SGM_WaitingIdicator.WaitingForm.waitingFrm.SetParentForm(this);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            
            string SYS_ADMIN = txtAdmin.Text;
            string SYS_PWD = txtPwd.Text;
            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () =>
            {
                return service.SGMManager_UpdateAdminAccount(frmGSMMain.s_currentAdminDTO.SysAdminAccount, SYS_ADMIN, SYS_PWD);
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
                String stResponse = task.Result as String;
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                    frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.SYS_ADMIN_CHANGE_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                else
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
            }, SynchronizationContext.Current);
        }
        
    }
}
