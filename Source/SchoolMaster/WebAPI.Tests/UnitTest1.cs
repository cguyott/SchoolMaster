namespace SchoolMaster.WebAPI.Tests
{
    using System;
    using Xunit;

    /// <summary>
    /// Unit test 1.
    /// </summary>
    public class UnitTest1
    {
        /// <summary>
        /// Passing test.
        /// </summary>
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        /// <summary>
        /// Failing test.
        /// </summary>
        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        private int Add(int x, int y)
        {
            return x + y;
        }
    }
}
