using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGM_WaitingIdicator
{
    public partial class WaitingForm : Form
    {
        private Form _parent;
        public ProgressReporter progressReporter = new ProgressReporter();
        public static WaitingForm waitingFrm = new WaitingForm();

        public void SetParentForm(Form parent)
        {
            _parent = parent;
        }
        public WaitingForm()
        {
            InitializeComponent();
        }

        public void ShowMe()
        {
            _parent.Enabled = false;
            base.Show();
            SetDesktopLocation(_parent.Left + _parent.Width / 2 - Width / 2, _parent.Top + _parent.Height / 2 - Height / 2);
        }

        public void HideMe()
        {
            _parent.Enabled = true;
            base.Hide();
        }

        /*
         * This is template to add waiting idicator
         * 
            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () =>
            {
                return m_service.DoSomethings();
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
	            String stResponse = task.Result as String;
                ...... parse result here ................
            }, SynchronizationContext.Current);
         * 
         * */
    }
}
