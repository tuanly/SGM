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
    public partial class frmGSMMain : Form
    {
        private Form m_frmCurrentForm;
        private Boolean bFromResizing;
        private Color BUTTON_COLOR_FOCUS = Color.PowderBlue;
        private Color BUTTON_COLOR_NORMAL = Color.DarkSeaGreen;
        private Color BUTTON_COLOR_SELECTED = Color.SpringGreen;
        private Form m_frmCurrent = null;

        
        public static SystemAdminDTO s_currentAdminDTO = null;

        public frmGSMMain()
        {
            InitializeComponent();
            bFromResizing = false;
            frmSGMMessage msg = new frmSGMMessage();
            //SGMMessageResult a = msg.ShowMsg("test title", "test msg", SGMMessageType.SGM_MESSAGE_TYPE_WARNING);
           
        }


        private void frmGSMMain_Load(object sender, EventArgs e)
        {
            frmSGMConfig frmConfig = new frmSGMConfig();
            showFrom(frmConfig);
            if (frmSGMConfig.IsReaderConnected)
            {
                frmConfig.Close();
            }
            SGM_WaitingIdicator.WaitingForm.waitingFrm.SetParentForm(this);
            
        }

        private void showFrom(Form frm)
        {
            if (m_frmCurrent != null)
                m_frmCurrent.Close();
            m_frmCurrent = frm;
            this.m_frmCurrentForm = frm;
            this.panelMain.Panel2.AutoScroll = true;
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            frm.Dock = DockStyle.Fill;


            this.panelMain.Panel2.Controls.Clear();
            this.panelMain.Panel2.BackgroundImage = null;
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
       
        private void mainMenu_Click(object sender, OutlookStyleControls.OutlookBar.ButtonClickEventArgs e)
        {
            int idx = mainMenu.Buttons.IndexOf(e.SelectedButton);
            switch (idx)
            {
                case 0: // home
                    //ShowPanes("show contacts options here", "show sheet with contacts here");
                    if (m_frmCurrentForm != null)
                    {
                        m_frmCurrentForm.Close();
                        this.panelMain.Panel2.Controls.Clear();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGSMMain));
                        this.panelMain.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMain.Panel2.BackgroundImage")));
                    }
                    break;
                case 1: // quan ly kho
                    showFrom(new frmSGMStore());
                    break;
                case 2: // quan ly tram xang
                    showFrom(new frmGasStation());
                    break;
                case 3: // quan ly khach hang
                    showFrom(new frmSGMCustomer());
                    break;
                case 4: // cap nhat gia xang
                    showFrom(new frmSGMUpdatePrice());
                    break;
                case 5: // bao cao
                    showFrom(new frmSGMReport(this));
                    break;
                case 6: // tai khoan
                    showFrom(new frmSGMUpdateAccount());
                    break;
                case 7: // cau hinh
                    showFrom(new frmSGMConfig());
                    break;
                case 8: // thoat
                    this.Close();
                    break;

                default:
                    break;
            }   
        }

        private void mainMenu_Click_1(object sender, OutlookStyleControls.OutlookBar.ButtonClickEventArgs e)
        {

        }
        
    }
}