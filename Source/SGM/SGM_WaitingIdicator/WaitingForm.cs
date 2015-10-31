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
        public readonly BackgroundWorker _bw = new BackgroundWorker();

        public WaitingForm(Form parent)
        {
            InitializeComponent();
            _parent = parent;
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
    }
}
