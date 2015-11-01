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

namespace SGM_SaleGas
{
    public partial class frmSGMCardDetail : Form
    {
        private CardDTO m_dtoCard = null;
        private RechargeDTO m_dtoRecharge = null;
        public frmSGMCardDetail(CardDTO cardDTO, RechargeDTO rechargeDTO)
        {
            InitializeComponent();
            m_dtoCard = cardDTO;
            m_dtoRecharge = rechargeDTO;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSGMCardDetail_Load(object sender, EventArgs e)
        {
            if (m_dtoCard != null)
            {
                txtCardID.Text = m_dtoCard.CardID;
                txtCardMoney.Text = m_dtoCard.CardRemainingMoney.ToString();
                txtCardStatus.Text = (m_dtoCard.CardUnlockState ? SGMText.SALEGAS_CARDINFO_UNLOCK : SGMText.SALEGAS_CARDINFO_LOCK);
            }
            if (m_dtoRecharge != null)
            {
                txtPriceGas92.Text = m_dtoRecharge.RechargeGas92Price.ToString();
                txtPriceGas95.Text = m_dtoRecharge.RechargeGas95Price.ToString();
                txtPriceGasDO.Text = m_dtoRecharge.RechargeGasDOPrice.ToString();
            }
        }
    }
}
