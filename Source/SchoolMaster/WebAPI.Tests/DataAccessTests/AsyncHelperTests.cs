namespace SchoolMaster.WebAPI.Tests.DataAccessTests
{
    using System;
    using System.Threading.Tasks;
    using Microservice.Data.Sql;
    using Xunit;

    /// <summary>
    /// AsyncHelper unit tests.
    /// </summary>
    public class AsyncHelperTests
    {
        /// <summary>
        /// Tests the asynchronous helper with void task.
        /// </summary>
        [Fact]
        public void TestAsyncHelperWithVoidTask()
        {
            AsyncHelper.RunSync(DoNothing);
        }

        /// <summary>
        /// Tests the asynchronous helper with string task.
        /// </summary>
        [Fact]
        public void TestAsyncHelperWithStringTask()
        {
            AsyncHelper.RunSync(DoNothingWithString);
        }

        private async Task DoNothing()
        {
            // No operation
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        private async Task<string> DoNothingWithString()
        {
            // No operation
            await Task.Delay(TimeSpan.FromSeconds(1));

            return string.Empty;
        }
    }
}
