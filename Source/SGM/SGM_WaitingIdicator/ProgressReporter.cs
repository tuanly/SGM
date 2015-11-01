using System;
using System.Threading;
using System.Threading.Tasks;

namespace SGM_WaitingIdicator
{
    public sealed class ProgressReporter
    {
        private readonly TaskScheduler scheduler;

        public ProgressReporter()
        {
            this.scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        public TaskScheduler Scheduler
        {
            get { return this.scheduler; }
        }

        public Task RegisterContinuation(Task task, Action action)
        {
            return task.ContinueWith(_ => action(), CancellationToken.None, TaskContinuationOptions.None, this.scheduler);
        }

        public Task RegisterContinuation<TResult>(Task<TResult> task, Action action)
        {
            return task.ContinueWith(_ => action(), CancellationToken.None, TaskContinuationOptions.None, this.scheduler);
        }
    }
}
