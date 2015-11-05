using System;
using System.Threading;
using System.Threading.Tasks;

namespace SGM_WaitingIdicator
{
    public sealed class ProgressReporter
    {
        public ProgressReporter()
        {
        }

        public Task RegisterContinuation<TResult>(Task<TResult> task, Action action, SynchronizationContext currentContext)
        {
            return task.ContinueWith(delegate 
            {
                if (currentContext == null)
                    action();
                else
                    currentContext.Post(delegate { action(); }, null);
            }, TaskScheduler.Current);
        }
    }
}
