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
    public partial class frmSGMSaleGas : Form
    {
        private ServiceReference1.ServiceSoapClient service = new ServiceReference1.ServiceSoapClient();

        public frmSGMSaleGas()
        {
            InitializeComponent();
        }

        private void frmSGMSaleGas_Load(object sender, EventArgs e)
        {

        }

        private void rbGas95_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbGas92_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtGasType_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbGasDO_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCardDetail_Click(object sender, EventArgs e)
        {
            string CARD_ID = txtCardID.Text;

            String stResponse = service.ValidateCardId(CARD_ID);
            DataTransfer dataResponse = new DataTransfer(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                using (DataSet ds = dataResponse.ResponseDataSet)
                {
                    String strResult = "";
                    DataTable tblCard = ds.Tables[0];
                    if (tblCard.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tblCard.Rows)
                        {
                            String strCardInfo = dr["CARD_ID"].ToString(); ;
                            strCardInfo += Boolean.Parse(dr["CARD_STATE"].ToString());
                            strCardInfo += Int32.Parse(dr["CARD_MONEY"].ToString());
                            strCardInfo += DateTime.Parse(dr["CARD_BUY_DATE"].ToString());
                            strCardInfo += dr["RECHARGE_ID"].ToString();
                            strResult += strCardInfo + "\n";
                        }
                    }

                    DataTable tblRecharge = ds.Tables[1];
                    if (tblRecharge.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tblRecharge.Rows)
                        {
                            String strRechargeInfo = dr["RECHARGE_ID"].ToString();
                            strRechargeInfo += dr["RECHARGE_DATE"].ToString();
                            strRechargeInfo += (dr["RECHARGE_GAS92_PRICE"].ToString());
                            strRechargeInfo += (dr["RECHARGE_GAS95_PRICE"].ToString());
                            strRechargeInfo += (dr["RECHARGE_GASDO_PRICE"].ToString());
                            strRechargeInfo += (dr["RECHARGE_MONEY"].ToString());
                            strRechargeInfo += dr["RECHARGE_MONEY"].ToString();
                            strResult += strRechargeInfo;
                        }
                    }
                    MessageBox.Show("Res : " + strResult, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Lỗi : " + dataResponse.ResponseErrorMsg, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
