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
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private SGM_Service.ServiceSoapClient m_service = null;

        public frmSGMReport()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
        }

        private void btnSaleGasView_Click(object sender, EventArgs e)
        {
            if (tabSGMHistory.SelectedTab == subTabSGMRechargeCard)
            {
                string customerId = (cboRechargeCardCustomer.SelectedItem as ComboboxItem).Value.ToString();
            }
            else if (tabSGMHistory.SelectedTab == subTabSGMSaleGas)
            {
                if (!ValidateDataSaleGasInput())
                {
                    return;
                }

                string gasStationId = (cboGasStation.SelectedItem as ComboboxItem).Value.ToString();
                string date_begin = dtpSaleGasBegin.Text;
                string date_end = dtpSaleGasEnd.Text;

                string response = m_service.SGMSaleGas_GetSaleGasReport(gasStationId, date_begin, date_end);
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(response);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    dgvSaleGasHistory.DataSource = dataResponse.ResponseDataSet;
                }
                else
                {
                    MessageBox.Show(dataResponse.ResponseErrorMsgDetail, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateDataSaleGasInput()
        {
            bool validate = true;
            if (dtpSaleGasBegin.Value > dtpSaleGasEnd.Value)
            {
                MessageBox.Show("Chọn khoảng thời gian ko hợp lệ !");
                validate = false;
            }
            return validate;
        }

        private void frmSGMReport_Load(object sender, EventArgs e)
        {
            LoadGasStationList();
            LoadCustomerList();
        }

        private void LoadGasStationList()
        {
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
                        ComboboxItem item = new ComboboxItem();
                        item.Text = dr["GASSTATION_NAME"].ToString();
                        item.Value = dr["GASSTATION_ID"].ToString();
                        cboGasStation.Items.Add(item);
                    }
                    cboGasStation.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show(dataResponse.ResponseErrorMsgDetail, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomerList()
        {
            cboRechargeCardCustomer.Items.Clear();

            string response = m_service.SGMSaleGas_GetCustomerList();
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(response);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                DataSet ds = dataResponse.ResponseDataSet;
                DataTable tblResult = ds.Tables[0];
                if (tblResult.Rows.Count > 0)
                {
                    foreach (DataRow dr in tblResult.Rows)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = dr["CUS_NAME"].ToString();
                        item.Value = dr["CUS_ID"].ToString();
                        cboRechargeCardCustomer.Items.Add(item);
                    }
                    cboRechargeCardCustomer.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show(dataResponse.ResponseErrorMsgDetail, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
