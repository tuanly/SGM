using System;
using System.Threading;
using System.Threading.Tasks;

namespace SGM_WaitingIdicator
{
    public class ProgressReporter
    {
        public ProgressReporter()
        {
        }

        public Task<TResult> RegisterTask<TResult>(Func<TResult> action)
        {
            SGM_WaitingIdicator.WaitingForm.waitingFrm.ShowMe();
            return Task.Factory.StartNew<TResult>(() => { return action(); });
        }

        public Task RegisterContinuation<TResult>(Task<TResult> task, Action action, SynchronizationContext currentContext)
        {
            return task.ContinueWith(delegate 
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
            }, TaskScheduler.Current);
        }
    }
}
