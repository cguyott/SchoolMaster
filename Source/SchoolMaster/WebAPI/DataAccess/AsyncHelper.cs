namespace SchoolMaster.WebAPI.DataAccess
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Code obtained from: https://cpratt.co/async-tips-tricks/.
    /// </summary>
    public static class AsyncHelper
    {
        private static readonly TaskFactory s_localTaskFactory = new
            TaskFactory(
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        /// <summary>
        /// Synchronously invoke an asynchronous function.
        /// </summary>
        /// <typeparam name="TResult">The value returned by the function being invoked.</typeparam>
        /// <param name="func">The function to be invoked.</param>
        /// <returns>The data returned by the asynchronous function upon completion.</returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
            => s_localTaskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        /// <summary>
        /// Synchronously invoke an asynchronous function.
        /// </summary>
        /// <param name="func">The function to be invoked.</param>
        public static void RunSync(Func<Task> func)
            => s_localTaskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}
