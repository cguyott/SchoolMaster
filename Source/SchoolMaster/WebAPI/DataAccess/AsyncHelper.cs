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
        {
#pragma warning disable CA2008 // Do not create tasks without passing a TaskScheduler
            return s_localTaskFactory
                           .StartNew(func)
#pragma warning restore CA2008 // Do not create tasks without passing a TaskScheduler
                           .Unwrap()
                           .GetAwaiter()
                           .GetResult();
        }

        /// <summary>
        /// Synchronously invoke an asynchronous function.
        /// </summary>
        /// <param name="func">The function to be invoked.</param>
        public static void RunSync(Func<Task> func)
        {
#pragma warning disable CA2008 // Do not create tasks without passing a TaskScheduler
            s_localTaskFactory
                           .StartNew(func)
#pragma warning restore CA2008 // Do not create tasks without passing a TaskScheduler
                           .Unwrap()
                           .GetAwaiter()
                           .GetResult();
        }
    }
}
