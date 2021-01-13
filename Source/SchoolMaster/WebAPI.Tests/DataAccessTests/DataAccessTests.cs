namespace SchoolMaster.WebAPI.Tests.DataAccessTests
{
    using FakeItEasy;
    using Microservice.Data.Sql;
    using Microsoft.Extensions.Logging;
    using Xunit;

    /// <summary>
    /// DataAccess unit tests.
    /// </summary>
    public class DataAccessTests
    {
        /// <summary>
        /// Test constructor.
        /// </summary>
        [Fact]
        public void Constructor_Works()
        {
            // Arrange.
            Fake<ILogger<DataAccess>> loggerFake = new Fake<ILogger<DataAccess>>();
            ILogger<DataAccess> logger = loggerFake.FakedObject;

            // Act.
            DataAccess dataAccess = new DataAccess(logger, "ConnectionString");

            // Assert.
            Assert.NotNull(dataAccess);
        }
    }
}
