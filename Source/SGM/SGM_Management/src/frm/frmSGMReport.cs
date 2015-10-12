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
    public partial class frmSGMReport : Form
    {
        private SGM_Service.ServiceSoapClient m_service = null;

        public frmSGMReport()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
        }

        private void btnSaleGasView_Click(object sender, EventArgs e)
        {

        }

        private void frmSGMReport_Load(object sender, EventArgs e)
        {
            // load tram xang
            cboGasStation.Items.Clear();

             string response = m_service.SGMSaleGas_GetGasStationList();
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(response);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                DataSet ds = dataResponse.ResponseDataSet;
                DataTable tblResult = ds.Tables[0];
                if (tblResult.Rows.Count > 0)
                {
                    foreach (DataRow dr in tblResult.Rows)
                    {
                        int i = cboGasStation.Items.Add(dr["GASSTATION_NAME"].ToString());
                        //cboGasStation.Items[i].Value = dr["GASSTATION_ID"].ToString();
                    }
                    cboGasStation.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show(dataResponse.ResponseErrorMsgDetail, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
