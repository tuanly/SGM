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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using ReportBuilderEntities;
using DynamicRDLCGenerator;

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
   
        public frmSGMReport()
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
            frmMsg = new frmSGMMessage();
            SGM_WaitingIdicator.WaitingForm.waitingFrm.SetParentForm(this);
        }

        public frmSGMReport(Form parent)
        {
            InitializeComponent();
            m_service = new SGM_Service.ServiceSoapClient();
            frmMsg = new frmSGMMessage();
            SGM_WaitingIdicator.WaitingForm.waitingFrm.SetParentForm(parent);
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
                Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                () =>
                {
                    return m_service.SGMSaleGas_GetSaleGasReport(gasStationId, date_begin, date_end, txtSaleGasCardID.Text.Trim());
                });
                
                SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                {
                    String stResponse = task.Result as String;
                    DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                    if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                    {
                        if (dataResponse.ResponseDataSet != null)
                        {
                            dgvSaleGasHistory.DataSource = dataResponse.ResponseDataSet.Tables[0];
                            
                            salesReportViewer.Reset();
                            String tableName = dataResponse.ResponseDataSet.Tables[0].TableName;
                            DataTable data = dataResponse.ResponseDataSet.Tables[0];
                            salesReportViewer.LocalReport.DataSources.Add(new ReportDataSource(tableName, data));

                            ReportBuilder reportBuilder = new ReportBuilder();
                            reportBuilder.DataSource = dataResponse.ResponseDataSet;
                            reportBuilder.Page = new ReportPage();
                            //ReportSections reportFooter = new ReportSections();
                            //ReportItems reportFooterItems = new ReportItems();
                            //ReportTextBoxControl[] footerTxt = new ReportTextBoxControl[3];
                            //footerTxt[0] = new ReportTextBoxControl() { Name = "txtCopyright", ValueOrExpression = new string[] { string.Format("Copyright {0}", DateTime.Now.Year) } };
                            //footerTxt[1] = new ReportTextBoxControl() { Name = "ExecutionTime", ValueOrExpression = new string[] { "Report Generated On " + DateTime.Now.ToString() } };
                            //footerTxt[2] = new ReportTextBoxControl() { Name = "PageNumber", ValueOrExpression = new string[] { "Page ", ReportGlobalParameters.CurrentPageNumber, " of ", ReportGlobalParameters.TotalPages } };

                            //reportFooterItems.TextBoxControls = footerTxt;
                            //reportFooter.ReportControlItems = reportFooterItems;
                            //reportBuilder.Page.ReportFooter = reportFooter;

                            ReportSections reportHeader = new ReportSections();
                            reportHeader.Size = new ReportScale();
                            reportHeader.Size.Height = 0.1;

                            ReportItems reportHeaderItems = new ReportItems();
                            ReportTextBoxControl[] headerTxt = new ReportTextBoxControl[1];
                            headerTxt[0] = new ReportTextBoxControl() { Name = "txtReportTitle", ValueOrExpression = new string[] { string.Format("Sales Report: {0}", DateTime.Now) } };

                            reportHeaderItems.TextBoxControls = headerTxt;
                            reportHeader.ReportControlItems = reportHeaderItems;
                            reportBuilder.Page.ReportHeader = reportHeader;

                            salesReportViewer.LocalReport.LoadReportDefinition(ReportEngine.GenerateReport(reportBuilder));
                            
                            salesReportViewer.RefreshReport();

                        }
                        else
                            frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.REPORT_NO_DATA, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                        
                    }
                    else
                    {
                        frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);                    
                    }
                }, SynchronizationContext.Current);
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

            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () =>
            {
                return m_service.SGMSaleGas_GetCardReport(customerId, date_begin, date_end, txtRechargeCardID.Text.Trim());
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
                String stResponse = task.Result as String;
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    if (dataResponse.ResponseDataSet != null)
                    {
                        dgvRechargeCardHistory.DataSource = dataResponse.ResponseDataSet.Tables[0];
                        cardReportViewer.Reset();
                        String tableName = dataResponse.ResponseDataSet.Tables[0].TableName;
                        DataTable data = dataResponse.ResponseDataSet.Tables[0];
                        cardReportViewer.LocalReport.DataSources.Add(new ReportDataSource(tableName, data));

                        ReportBuilder reportBuilder = new ReportBuilder();
                        reportBuilder.DataSource = dataResponse.ResponseDataSet;
                        reportBuilder.Page = new ReportPage();
                        

                        ReportSections reportHeader = new ReportSections();
                        reportHeader.Size = new ReportScale();
                        reportHeader.Size.Height = 0.1;

                        ReportItems reportHeaderItems = new ReportItems();
                        ReportTextBoxControl[] headerTxt = new ReportTextBoxControl[1];
                        headerTxt[0] = new ReportTextBoxControl() { Name = "txtReportTitle", ValueOrExpression = new string[] { string.Format("Sales Report: {0}", DateTime.Now) } };

                        reportHeaderItems.TextBoxControls = headerTxt;
                        reportHeader.ReportControlItems = reportHeaderItems;
                        reportBuilder.Page.ReportHeader = reportHeader;

                        cardReportViewer.LocalReport.LoadReportDefinition(ReportEngine.GenerateReport(reportBuilder));

                        cardReportViewer.RefreshReport();
                    }
                    else
                        frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.REPORT_NO_DATA, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                }
                else
                {
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                }
            }, SynchronizationContext.Current);
        }

        private bool ValidateDataSaleGasInput()
        {
            bool validate = true;
            if (dtpSaleGasBegin.Value.Date > dtpSaleGasEnd.Value.Date)
            {                
                frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.REPORT_INPUT_DATE_ERROR, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                validate = false;
            }
            else if (cboGasStation.Items.Count <= 0)
            {
                frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.REPORT_INPUT_GASSTATION_EMPTY, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                validate = false;
            }
            return validate;
        }
        private bool ValidateDataCardInput()
        {
            bool validate = true;
            if (dtpRechargeCardBegin.Value.Date > dtpRechargeCardEnd.Value.Date)
            {
                frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.REPORT_INPUT_DATE_ERROR, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                validate = false;
            }
            else if (cboRechargeCardCustomer.Items.Count <= 0)
            {
                frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.REPORT_INPUT_CUSTOMER_EMPTY, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
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
            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () =>
            {
                return m_service.SGMSaleGas_GetGasStationList();
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
                String stResponse = task.Result as String;
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    DataSet ds = dataResponse.ResponseDataSet;
                    DataTable tblResult = ds.Tables[0];
                    if (tblResult.Rows.Count > 0)
                    {
                        ComboboxItem itemAll = new ComboboxItem();
                        itemAll.Text = SGMText.REPORT_ALL;
                        itemAll.Value = "";
                        cboGasStation.Items.Add(itemAll);
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
            }, SynchronizationContext.Current);
        }

        private void LoadCustomerList()
        {
            cboRechargeCardCustomer.Items.Clear();
            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () =>
            {
                return m_service.SGMSaleGas_GetCustomerList();
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
                String stResponse = task.Result as String;
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    DataSet ds = dataResponse.ResponseDataSet;
                    if (ds != null)
                    {
                        DataTable tblResult = ds.Tables[0];
                        if (tblResult.Rows.Count > 0)
                        {
                            ComboboxItem itemAll = new ComboboxItem();
                            itemAll.Text = SGMText.REPORT_ALL;
                            itemAll.Value = "";
                            cboRechargeCardCustomer.Items.Add(itemAll);
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
                    
                }
                else
                {
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                }
            }, SynchronizationContext.Current);
        }
    }
}
