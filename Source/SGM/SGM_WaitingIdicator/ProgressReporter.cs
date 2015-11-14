using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGM_WaitingIdicator
{
    public class ProgressReporter
    {
        //private frmSGMMessage frmMsg = null;

        public ProgressReporter()
        {
            //frmMsg = new frmSGMMessage();
        }

        public Task<TResult> RegisterTask<TResult>(Func<TResult> action)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false)
            {
                MessageBox.Show(SGM_Core.Utils.SGMText.APP_NO_INTERNET_CONNECTION);
                return null;
            }
            SGM_WaitingIdicator.WaitingForm.waitingFrm.ShowMe();
            return Task.Factory.StartNew<TResult>(() => 
            {
                try
                {
                    return action();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());//SGM_Core.Utils.SGMText.APP_SERVICE_TIME_OUT);
                    return default(TResult);
                }
            });
        }

        public Task RegisterContinuation<TResult>(Task<TResult> task, Action action, SynchronizationContext currentContext)
        {
            if (task == null)
                return null;

            return task.ContinueWith(delegate 
            {
                if (task.Result == null)
                {
                    SGM_WaitingIdicator.WaitingForm.waitingFrm.HideMe();
                }
                else
                {
                    if (currentContext == null)
                    {
                        SGM_WaitingIdicator.WaitingForm.waitingFrm.HideMe();
                        action();
                    }
                    else
                    {
                        currentContext.Post(delegate { SGM_WaitingIdicator.WaitingForm.waitingFrm.HideMe(); action(); }, null);
                    }
                }
            }, TaskScheduler.Current);
        }
    }
}
