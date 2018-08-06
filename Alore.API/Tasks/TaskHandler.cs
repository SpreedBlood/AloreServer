namespace Alore.API.Tasks
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;

    public static class TaskHandler
    {
        /// <summary>
        /// Submit a task to run asynchronously.
        /// </summary>
        /// <param name="task">The task operation.</param>
        /// <returns>The task upon completion.</returns>
        public static async Task RunTaskAsync(ITask task) => await Task.Run(() => task.Run());

        /// <summary>
        /// Submit a task to run asynchronously with a delay.
        /// </summary>
        /// <param name="task">The task operation.</param>
        /// <param name="delay">The delay until execution (milliseconds).</param>
        /// <returns>The task upon completion.</returns>
        public static async Task RunTaskAsyncWithDelay(ITask task, int delay)
        {
            await Task.Run(async delegate
            {
                await Task.Delay(delay);
                task.Run();
            });
        }

        /// <summary>
        /// Starts a periodic task with delay that gets cancelled using cancellation tokens.
        /// To start the task: PeriodictaskWithDelay(action, token, delay).Post(DateTimeOffset.Now);
        /// </summary>
        /// <param name="action">The work to perform.</param>
        /// <param name="cancellationToken">The cancellation token to stop the loop.</param>
        /// <param name="delay">The delay between each execution (milliseconds)</param>
        /// <returns>The target action block.</returns>
        public static ActionBlock<DateTimeOffset> PeriodicTaskWithDelay(
            Action<DateTimeOffset> action, CancellationToken cancellationToken, int delay)
        {
            ActionBlock<DateTimeOffset> block = null;
            block = new ActionBlock<DateTimeOffset>(async now => {
                action(now);
                await Task.Delay(TimeSpan.FromMilliseconds(delay), cancellationToken).
                    ConfigureAwait(false);
                block.Post(DateTimeOffset.Now);
            }, new ExecutionDataflowBlockOptions
            {
                CancellationToken = cancellationToken
            });
            
            return block;
        }
    }
}
