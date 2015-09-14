using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SGM_SaleGas;

namespace SGM_SaleGas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        ServiceReference1.ServiceSoapClient service = new ServiceReference1.ServiceSoapClient();
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty
        && textBox2.Text != string.Empty)
            {
                try
                {
                    int x = Convert.ToInt32(textBox1.Text);
                    int y = Convert.ToInt32(textBox2.Text);
                    textBox3.Text = service.Add(x, y).ToString();
                }
                catch (Exception ex)
                {
                    processException(ex);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty
        && textBox2.Text != string.Empty)
            {
                try
                {
                    int x = Convert.ToInt32(textBox1.Text);
                    int y = Convert.ToInt32(textBox2.Text);
                    textBox3.Text = service.Subtract(x, y).ToString();
                }
                catch (Exception ex)
                {
                    processException(ex);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty
        && textBox2.Text != string.Empty)
            {
                try
                {
                    int x = Convert.ToInt32(textBox1.Text);
                    int y = Convert.ToInt32(textBox2.Text);
                    textBox3.Text = service.Multiply(x, y).ToString();
                }
                catch (Exception ex)
                {
                    processException(ex);
                }
            }
        }

        private void processException(Exception ex)
        {
            richTextBox1.Text = ex.Message;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = service.GetSampleDataDTTest();
            ShowDB();
        }

        private void ShowDB()
        {
            DataSet dsReturn = new DataSet();
            dsReturn = service.ViewDB("SALE_GAS");
            DataTable dt = new DataTable();
            dt = dsReturn.Tables[0];
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = 1;
            string name = "test";
            int salary = 4500;
            
            service.WB_HR_InsertMethod("tuan", false, 10, 20);
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "no errors";

        }
    }
}