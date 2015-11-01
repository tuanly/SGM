using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGM_SaleGas
{
    public enum SGMMessageType
        {
            SGM_MESSAGE_TYPE_ERROR = 0,
            SGM_MESSAGE_TYPE_WARNING =1,
            SGM_MESSAGE_TYPE_INFO = 2,
            SGM_MESSAGE_TYPE_QUES = 3
        }

    public enum SGMMessageResult
    {
        SGM_MESSAGE_RESULT_OK = 0,
        SGM_MESSAGE_RESULT_NO = 1
    }
    public partial class frmSGMMessage : Form
    {



        private SGMMessageResult m_iMsgResult = 0;
        
       

        public frmSGMMessage()
        {
            InitializeComponent();            
            m_iMsgResult = SGMMessageResult.SGM_MESSAGE_RESULT_OK;
           
        }

        private void frmMessage_Load(object sender, EventArgs e)
        {

        }

        private void updateMsg(SGMMessageType type)
        {
            switch (type)
            {
                case SGMMessageType.SGM_MESSAGE_TYPE_ERROR:
                    btnCenter.Visible = true;
                    btnLeft.Visible = false;
                    btnRight.Visible = false;
                    picIcon.BackgroundImage = new Bitmap(Properties.Resources.sgm_error);
                    break;
                case SGMMessageType.SGM_MESSAGE_TYPE_WARNING:
                    btnCenter.Visible = true;
                    btnLeft.Visible = false;
                    btnRight.Visible = false;
                    picIcon.BackgroundImage = new Bitmap(Properties.Resources.sgm_warning);
                    break;
                case SGMMessageType.SGM_MESSAGE_TYPE_QUES:
                    btnCenter.Visible = false;
                    btnLeft.Visible = true;
                    btnRight.Visible = true;
                    picIcon.BackgroundImage = new Bitmap(Properties.Resources.sgm_question);
                    break;
                case SGMMessageType.SGM_MESSAGE_TYPE_INFO:
                    btnCenter.Visible = true;
                    btnLeft.Visible = false;
                    btnRight.Visible = false;
                    picIcon.BackgroundImage = new Bitmap(Properties.Resources.sgm_info);
                    break;
            }
        }
        public SGMMessageResult ShowMsg(String title, String msg, SGMMessageType type)
        {            
            updateMsg(type);
            this.lblMessage.Text = msg;
            this.Text = title;           
            this.ShowDialog();
            return m_iMsgResult;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            m_iMsgResult = SGMMessageResult.SGM_MESSAGE_RESULT_OK;
            Close();
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
            m_iMsgResult = SGMMessageResult.SGM_MESSAGE_RESULT_OK;
            Close();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            m_iMsgResult = SGMMessageResult.SGM_MESSAGE_RESULT_NO;
            Close();
        }
    }
}
