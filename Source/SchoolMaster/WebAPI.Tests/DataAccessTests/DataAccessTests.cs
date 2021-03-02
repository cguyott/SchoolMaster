namespace SchoolMaster.WebAPI.Tests.DataAccessTests
{
    using System;
    using FakeItEasy;
    using Microsoft.Extensions.Logging;
    using SchoolMaster.WebAPI.DataAccess;
    using Xunit;

    /// <summary>
    /// DataAccess unit tests.
    /// </summary>
    public class DataAccessTests
    {
        /// <summary>
        /// Constructor_Works test.
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

            dataAccess.Dispose();   // Calling dispose to get rid of a compiler warning.
        }

        /// <summary>
        /// Constructor_Fails_NullLogger test.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullLogger()
        {
            // Act and Assert
            Assert.Throws<ArgumentNullException>("logger", () => new DataAccess(null, "ConnectionString"));
        }

        /// <summary>
        /// Constructor_Fails_NullConnectionString test.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullConnectionString()
        {
            // Arrange.
            Fake<ILogger<DataAccess>> loggerFake = new Fake<ILogger<DataAccess>>();
            ILogger<DataAccess> logger = loggerFake.FakedObject;

            // Act and Assert
            Assert.Throws<ArgumentException>("sqlConnectionString", () => new DataAccess(logger, null));
        }

        /// <summary>
        /// Constructor_Fails_NullLogger test.
        /// </summary>
        [Fact]
        public void Constructor_Fails_BothNull()
        {
            // Act and Assert
            Assert.Throws<ArgumentNullException>("logger", () => new DataAccess(null, null));
        }

        /// <summary>
        /// Constructor_Fails_EmptyConnectionString test.
        /// </summary>
        [Fact]
        public void Constructor_Fails_EmptyConnectionString()
        {
            // Arrange.
            Fake<ILogger<DataAccess>> loggerFake = new Fake<ILogger<DataAccess>>();
            ILogger<DataAccess> logger = loggerFake.FakedObject;

            // Act and Assert
            Assert.Throws<ArgumentException>("sqlConnectionString", () => new DataAccess(logger, string.Empty));
        }

        /// <summary>
        /// Constructor_Fails_WhiteSpaceConnectionString test.
        /// </summary>
        [Fact]
        public void Constructor_Fails_WhiteSpaceConnectionString()
        {
            // Arrange.
            Fake<ILogger<DataAccess>> loggerFake = new Fake<ILogger<DataAccess>>();
            ILogger<DataAccess> logger = loggerFake.FakedObject;

            // Act and Assert
            Assert.Throws<ArgumentException>("sqlConnectionString", () => new DataAccess(logger, " "));
        }
    }
}
