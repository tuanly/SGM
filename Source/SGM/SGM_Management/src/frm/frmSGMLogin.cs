using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SGM_Core.DTO;
using SGM_Core.Utils;
using SGM_WaitingIdicator;
using System.Threading;
using System.Threading.Tasks;

namespace SGM_Management
{
    public partial class frmSGMLogin : Form
    {
        private SGM_Service.ServiceSoapClient service = new SGM_Service.ServiceSoapClient();
        private JSonHelper m_jsHelper;
        private frmSGMMessage frmMsg = null;

        public frmSGMLogin()
        {
            InitializeComponent();
            m_jsHelper = new JSonHelper();
            frmMsg = new frmSGMMessage();
        }

        private void frmSGMLogin_Load(object sender, EventArgs e)
        {
            SGM_WaitingIdicator.WaitingForm.waitingFrm.SetParentForm(this);
        }

        private bool ValidateLoginCode()
        {
            bool check = true;
            if (string.IsNullOrEmpty(txtAdmin.Text))
            {
                SGMHelper.ShowToolTip(txtAdmin, "Tên Admin ?");
                check = false;
            }
            else
            {
                SGMHelper.HideTooltip(txtAdmin);
            }

            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                SGMHelper.ShowToolTip(txtPwd, "Mật khẩu ?");
                check = false;
            }
            else
            {
                SGMHelper.HideTooltip(txtPwd);
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
            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () => {
                return service.SGMManager_ValidateAdminLogin(SYS_ADMIN, SYS_PWD);
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
                String stResponse = task.Result as String;
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    this.Hide();
                    frmGSMMain.s_currentAdminDTO = dataResponse.ResponseDataSystemAdminDTO;
                    frmGSMMain a = new frmGSMMain();
                    a.ShowDialog();
                    this.Close();
                }
                else
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
            }, SynchronizationContext.Current);
        }
    }
}
