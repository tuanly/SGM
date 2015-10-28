using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGM_Management
{
    public partial class frmGSMMain : Form
    {
        private Form m_frmCurrentForm;
        private Boolean bFromResizing;
        private Color BUTTON_COLOR_FOCUS = Color.PowderBlue;
        private Color BUTTON_COLOR_NORMAL = Color.DarkSeaGreen;
        private Color BUTTON_COLOR_SELECTED = Color.SpringGreen;
        private Button m_btnCurrenButton;
        public frmGSMMain()
        {
            InitializeComponent();
            bFromResizing = false;
            frmSGMMessage msg = new frmSGMMessage();
            //SGMMessageResult a = msg.ShowMsg("test title", "test msg", SGMMessageType.SGM_MESSAGE_TYPE_WARNING);
           
        }


        private void frmGSMMain_Load(object sender, EventArgs e)
        {
            m_btnCurrenButton = btnHome;
            m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_btnCurrenButton.BackColor = BUTTON_COLOR_NORMAL;
            m_btnCurrenButton = btnHome;
            m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
            if (m_frmCurrentForm != null)
            {
                m_frmCurrentForm.Close();
                this.panelMain.Panel2.Controls.Clear();
            }
        }

        private void showFrom(Form frm)
        {
            this.m_frmCurrentForm = frm;
            this.panelMain.Panel2.AutoScroll = true;
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            frm.Dock = DockStyle.Fill;
            this.panelMain.Panel2.Controls.Clear();
            this.panelMain.Panel2.Controls.Add(frm);
            frm.Show();
        }


        private void frmGSMMain_ResizeEnd(object sender, EventArgs e)
        {
            if (m_frmCurrentForm != null)
            {
                this.panelMain.Panel2.Controls.Clear();
                this.panelMain.Panel2.Controls.Add(m_frmCurrentForm);
            }
            bFromResizing = false;
        }

        private void frmGSMMain_ResizeBegin(object sender, EventArgs e)
        {
            bFromResizing = true;
        }

        private void frmGSMMain_SizeChanged(object sender, EventArgs e)
        {
            if (m_frmCurrentForm != null && !bFromResizing)
            {
                this.panelMain.Panel2.Controls.Clear();
                this.panelMain.Panel2.Controls.Add(m_frmCurrentForm);
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            m_btnCurrenButton.BackColor = BUTTON_COLOR_NORMAL;
            m_btnCurrenButton = btnCustomer;
            m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
            showFrom(new frmSGMCustomer());
        }

        private void btnGasStation_Click(object sender, EventArgs e)
        {
            m_btnCurrenButton.BackColor = BUTTON_COLOR_NORMAL;
            m_btnCurrenButton = btnGasStation;
            m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
            showFrom(new frmGasStation());
        }

        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            m_btnCurrenButton.BackColor = BUTTON_COLOR_NORMAL;
            m_btnCurrenButton = btnUpdatePrice;
            m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
            showFrom(new frmSGMUpdatePrice());
        }

        private void btnUpdateStore_Click(object sender, EventArgs e)
        {
            m_btnCurrenButton.BackColor = BUTTON_COLOR_NORMAL;
            m_btnCurrenButton = btnUpdateStore;
            m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
            showFrom(new frmSGMUpdateStore());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            m_btnCurrenButton.BackColor = BUTTON_COLOR_NORMAL;
            m_btnCurrenButton = btnAccount;
            m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
            showFrom(new frmSGMUpdateAccount());
        }

        

        private void btnReport_Click(object sender, EventArgs e)
        {
            m_btnCurrenButton.BackColor = BUTTON_COLOR_NORMAL;
            m_btnCurrenButton = btnReport;
            m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
            showFrom(new frmSGMReport());
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            m_btnCurrenButton.BackColor = BUTTON_COLOR_NORMAL;
            m_btnCurrenButton = btnExit;
            m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
            this.Close();
        }

        private void btnGasStation_Enter(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnGasStation)
                btnGasStation.BackColor = BUTTON_COLOR_FOCUS;
        }

        private void btnGasStation_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_btnCurrenButton != btnGasStation)
                btnGasStation.BackColor = BUTTON_COLOR_FOCUS;
        }

        private void btnGasStation_MouseLeave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnGasStation)
                btnGasStation.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnGasStation_Leave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnGasStation)
                btnGasStation.BackColor = BUTTON_COLOR_NORMAL;
        //    m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnHome)
                btnHome.BackColor = BUTTON_COLOR_NORMAL;
         //   m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnHome_Leave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnHome)
                btnHome.BackColor = BUTTON_COLOR_NORMAL;
           // m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnHome_Enter(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnHome)
                btnHome.BackColor = BUTTON_COLOR_FOCUS;
           // m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnHome_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_btnCurrenButton != btnHome)
                btnHome.BackColor = BUTTON_COLOR_FOCUS;
           // m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnCustomer_Enter(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnCustomer)
                btnCustomer.BackColor = BUTTON_COLOR_FOCUS;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnCustomer_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_btnCurrenButton != btnCustomer)
                btnCustomer.BackColor = BUTTON_COLOR_FOCUS;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnCustomer_MouseLeave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnCustomer)
                btnCustomer.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnCustomer_Leave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnCustomer)
                btnCustomer.BackColor = BUTTON_COLOR_NORMAL;
           // m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnUpdatePrice_Enter(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnUpdatePrice)
                btnUpdatePrice.BackColor = BUTTON_COLOR_FOCUS;
        }

        private void btnUpdatePrice_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_btnCurrenButton != btnUpdatePrice)
                btnUpdatePrice.BackColor = BUTTON_COLOR_FOCUS;
        }

        private void btnUpdatePrice_Leave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnUpdatePrice)
                btnUpdatePrice.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnUpdatePrice_MouseLeave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnUpdatePrice)
                btnUpdatePrice.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnUpdateStore_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_btnCurrenButton != btnUpdateStore)
                btnUpdateStore.BackColor = BUTTON_COLOR_FOCUS;
        }

        private void btnUpdateStore_Leave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnUpdateStore)
                btnUpdateStore.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnUpdateStore_Enter(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnUpdateStore) 
                btnUpdateStore.BackColor = BUTTON_COLOR_FOCUS;
        }

        private void btnUpdateStore_MouseLeave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnUpdateStore)
                btnUpdateStore.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnReport_Enter(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnReport)
                btnReport.BackColor = BUTTON_COLOR_FOCUS;
        }

        private void btnReport_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_btnCurrenButton != btnReport)
                btnReport.BackColor = BUTTON_COLOR_FOCUS;
        }

        private void btnReport_MouseLeave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnReport)
                btnReport.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnReport_Leave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnReport)
                btnReport.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnAccount_Leave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnAccount)
                btnAccount.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnAccount_MouseLeave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnAccount)
                btnAccount.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnAccount_Enter(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnAccount)
                btnAccount.BackColor = BUTTON_COLOR_FOCUS;
        }

        private void btnAccount_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_btnCurrenButton != btnAccount)
                btnAccount.BackColor = BUTTON_COLOR_FOCUS;
        }

        private void btnExit_Leave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnExit)
                btnExit.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnExit)
                btnExit.BackColor = BUTTON_COLOR_NORMAL;
            //m_btnCurrenButton.BackColor = BUTTON_COLOR_SELECTED;
        }

        private void btnExit_Enter(object sender, EventArgs e)
        {
            if (m_btnCurrenButton != btnExit)
                btnExit.BackColor = BUTTON_COLOR_FOCUS;
        }

        private void btnExit_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_btnCurrenButton != btnExit)
                btnExit.BackColor = BUTTON_COLOR_FOCUS;
        }
        
    }
}