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
        private Form mCurrentForm;
        private Boolean bFromResizing;
        public frmGSMMain()
        {
            InitializeComponent();
            bFromResizing = false;
        }


        private void frmGSMMain_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            showFrom(new frmSGMCustomer());
        }

        private void showFrom(Form frm)
        {
            this.mCurrentForm = frm;
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
            if (mCurrentForm != null)
            {
                this.panelMain.Panel2.Controls.Clear();
                this.panelMain.Panel2.Controls.Add(mCurrentForm);
            }
            bFromResizing = false;
        }

        private void frmGSMMain_ResizeBegin(object sender, EventArgs e)
        {
            bFromResizing = true;
        }

        private void frmGSMMain_SizeChanged(object sender, EventArgs e)
        {
            if (mCurrentForm != null && !bFromResizing)
            {
                this.panelMain.Panel2.Controls.Clear();
                this.panelMain.Panel2.Controls.Add(mCurrentForm);
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            showFrom(new frmSGMCustomer());
        }

        private void btnGasStation_Click(object sender, EventArgs e)
        {
            showFrom(new frmGasStation());
        }

        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            showFrom(new frmSGMUpdatePrice());
        }

        private void btnUpdateStore_Click(object sender, EventArgs e)
        {
            showFrom(new frmSGMUpdateStore());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            showFrom(new frmSGMUpdateAccount());
        }

        

        private void btnReport_Click(object sender, EventArgs e)
        {
            showFrom(new frmSGMReport());
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}