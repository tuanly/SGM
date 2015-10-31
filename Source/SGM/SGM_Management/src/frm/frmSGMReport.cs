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
        private frmSGMMessage frmMsg = null;
        
        private WaitingForm waitingFrmLoadGasList;
        private WaitingForm waitingFrmLoadCusList;
        private WaitingForm waitingFrmGetReport;

        public frmSGMReport()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
            frmMsg = new frmSGMMessage();
            waitingFrmLoadGasList = new WaitingForm(this);
            waitingFrmLoadCusList = new WaitingForm(this);
            waitingFrmGetReport = new WaitingForm(this);
            waitingFrmLoadGasList._bw.DoWork += DoLoadGasStationList;
            waitingFrmLoadGasList._bw.RunWorkerCompleted += DoLoadGasStationListCompleted;
            waitingFrmLoadCusList._bw.DoWork += DoLoadCustomerList;
            waitingFrmLoadCusList._bw.RunWorkerCompleted += DoLoadCustomerListCompleted;
        }

        public frmSGMReport(Form parent)
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
            frmMsg = new frmSGMMessage();
            waitingFrmLoadGasList = new WaitingForm(parent);
            waitingFrmLoadCusList = new WaitingForm(parent);
            waitingFrmGetReport = new WaitingForm(parent);
            waitingFrmLoadGasList._bw.DoWork += DoLoadGasStationList;
            waitingFrmLoadGasList._bw.RunWorkerCompleted += DoLoadGasStationListCompleted;
            waitingFrmLoadCusList._bw.DoWork += DoLoadCustomerList;
            waitingFrmLoadCusList._bw.RunWorkerCompleted += DoLoadCustomerListCompleted;
        }

        private void DoGetSaleGasReport(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            List<Object> list = doWorkEventArgs.Argument as List<Object>;
            String gasStationId = (String)list[0];
            DateTime date_begin = (DateTime)list[1];
            DateTime date_end = (DateTime)list[2];
            doWorkEventArgs.Result = m_service.SGMSaleGas_GetSaleGasReport(gasStationId, date_begin, date_end);
        }

        private void DoGetSaleGasReportCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitingFrmGetReport.HideMe();
            String stResponse = e.Result as String;
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                if (dataResponse.ResponseDataSet != null)
                    dgvSaleGasHistory.DataSource = dataResponse.ResponseDataSet.Tables[0];
                else
                    frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.REPORT_NO_DATA, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                        
            }
            else
            {
                frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);                    
            }
        }
        private void DoRechargeCardReport(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            List<Object> list = doWorkEventArgs.Argument as List<Object>;
            String customerId = (String)list[0];
            DateTime date_begin = (DateTime)list[1];
            DateTime date_end = (DateTime)list[2];
            doWorkEventArgs.Result = m_service.SGMSaleGas_GetCardReport(customerId, date_begin, date_end);
        }

        private void DoRechargeCardReportCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitingFrmGetReport.HideMe();
            String stResponse = e.Result as String;
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                if (dataResponse.ResponseDataSet != null)
                    dgvRechargeCardHistory.DataSource = dataResponse.ResponseDataSet.Tables[0];
                else
                    frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.REPORT_NO_DATA, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
            }
            else
            {
                frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
            }
        }
        private void btnSaleGasView_Click(object sender, EventArgs e)
        {
            if (!ValidateDataSaleGasInput())
            {
                return;
            }
            
            dgvSaleGasHistory.DataSource = null;

            DateTime date_begin = dtpSaleGasBegin.Value;
            DateTime date_end = dtpSaleGasEnd.Value;
            String gasStationId = (cboGasStation.SelectedItem as ComboboxItem).Value.ToString();
            {
                List<Object> args = new List<Object>();
                args.Add(gasStationId);
                args.Add(date_begin);
                args.Add(date_end);

                waitingFrmGetReport._bw.DoWork -= DoGetSaleGasReport;
                waitingFrmGetReport._bw.DoWork -= DoRechargeCardReport;
                waitingFrmGetReport._bw.RunWorkerCompleted -= DoGetSaleGasReportCompleted;
                waitingFrmGetReport._bw.RunWorkerCompleted -= DoRechargeCardReportCompleted;

                waitingFrmGetReport._bw.DoWork += DoGetSaleGasReport;
                waitingFrmGetReport._bw.RunWorkerCompleted += DoGetSaleGasReportCompleted;
                waitingFrmGetReport.ShowMe();
                waitingFrmGetReport._bw.RunWorkerAsync(args);
            }
        }

        private void btnRechargeCardView_Click(object sender, EventArgs e)
        {
            if (!ValidateDataCardInput())
            {
                return;
            }

            dgvRechargeCardHistory.DataSource = null;

            DateTime date_begin = dtpRechargeCardBegin.Value;
            DateTime date_end = dtpRechargeCardEnd.Value;
            String customerId = (cboRechargeCardCustomer.SelectedItem as ComboboxItem).Value.ToString();
            
            List<Object> args = new List<Object>();
            args.Add(customerId);
            args.Add(date_begin);
            args.Add(date_end);

            waitingFrmGetReport._bw.DoWork -= DoGetSaleGasReport;
            waitingFrmGetReport._bw.DoWork -= DoRechargeCardReport;
            waitingFrmGetReport._bw.RunWorkerCompleted -= DoGetSaleGasReportCompleted;
            waitingFrmGetReport._bw.RunWorkerCompleted -= DoRechargeCardReportCompleted;

            waitingFrmGetReport._bw.DoWork += DoRechargeCardReport;
            waitingFrmGetReport._bw.RunWorkerCompleted += DoRechargeCardReportCompleted;
            waitingFrmGetReport.ShowMe();
            waitingFrmGetReport._bw.RunWorkerAsync(args);
            
        }
        private bool ValidateDataSaleGasInput()
        {
            bool validate = true;
            if (dtpSaleGasBegin.Value > dtpSaleGasEnd.Value)
            {                
                frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.REPORT_INPUT_DATE_ERROR, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                validate = false;
            }
            return validate;
        }
        private bool ValidateDataCardInput()
        {
            bool validate = true;
            if (dtpRechargeCardBegin.Value > dtpRechargeCardEnd.Value)
            {
                frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.REPORT_INPUT_DATE_ERROR, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                validate = false;
            }
            return validate;
        }

        private void frmSGMReport_Load(object sender, EventArgs e)
        {
            LoadGasStationList();
            LoadCustomerList();
        }

        private void DoLoadGasStationList(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            doWorkEventArgs.Result = m_service.SGMSaleGas_GetGasStationList();
        }

        private void DoLoadGasStationListCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitingFrmLoadGasList.HideMe();
            String stResponse = e.Result as String;
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
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
                frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);                
            }
        }

        private void LoadGasStationList()
        {
            cboGasStation.Items.Clear();
            waitingFrmLoadGasList.ShowMe();
            waitingFrmLoadGasList._bw.RunWorkerAsync();
        }

        private void DoLoadCustomerList(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            doWorkEventArgs.Result = m_service.SGMSaleGas_GetCustomerList();
        }

        private void DoLoadCustomerListCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitingFrmLoadCusList.HideMe();
            String stResponse = e.Result as String;
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
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
                frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
            }
        }

        private void LoadCustomerList()
        {
            cboRechargeCardCustomer.Items.Clear();
            waitingFrmLoadCusList.ShowMe();
            waitingFrmLoadCusList._bw.RunWorkerAsync();
        }
    }
}
