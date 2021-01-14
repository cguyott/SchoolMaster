namespace SchoolMaster.WebAPI.Tests.DataModelTests
{
    using System;
    using SchoolMaster.WebAPI.DataModel;
    using Xunit;

    /// <summary>
    /// Phone unit tests.
    /// </summary>
    public class PhoneTests
    {
        /// <summary>
        /// Default_Constructor_Works test.
        /// </summary>
        [Fact]
        public void Default_Constructor_Works()
        {
            // Arrange.

            // Act.
            Phone phone = new Phone();

            // Assert.
            Assert.NotNull(phone);
        }

        /// <summary>
        /// Constructor_Works test.
        /// </summary>
        [Fact]
        public void Constructor_Works()
        {
            // Arrange.
            int id = 1;
            bool modified = false;
            string areaCode = "111";
            string exchangeCode = "222";
            string subscriberNumber = "3333";
            int contactOrder = 1;

            // Act.
            Phone phone = new Phone(id, areaCode, exchangeCode, subscriberNumber, contactOrder);

            // Assert.
            Assert.NotNull(phone);
            Assert.True(id == phone.Id);
            Assert.True(modified == phone.Modified);
            Assert.True(areaCode == ((IPhone)phone).AreaCode);
            Assert.True(exchangeCode == ((IPhone)phone).ExchangeCode);
            Assert.True(subscriberNumber == ((IPhone)phone).SubscriberNumber);
            Assert.True(contactOrder == ((IPhone)phone).ContactOrder);
        }

        /// <summary>
        /// Constructor_Fails_InvalidId1 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidId1()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("id", () => new Phone(-42, "111", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidId2 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidId2()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("id", () => new Phone(0, "111", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidAreaCode1 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidAreaCode1()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, null, "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidAreaCode2 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidAreaCode2()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, string.Empty, "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidAreaCode3 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidAreaCode3()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, "   ", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidAreaCode4 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidAreaCode4()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, "11", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidAreaCode5 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidAreaCode5()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, "1111", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidAreaCode6 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidAreaCode6()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, "aaa", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidExchangeCode1 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidExchangeCode1()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", null, "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidExchangeCode2 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidExchangeCode2()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", string.Empty, "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidExchangeCode3 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidExchangeCode3()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", "   ", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidExchangeCode4 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidExchangeCode4()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", "22", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidExchangeCode5 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidExchangeCode5()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", "2222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidExchangeCode6 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidExchangeCode6()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", "aaa", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidSubscriberNumber1 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidSubscriberNumber1()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", null, 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidSubscriberNumber2 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidSubscriberNumber2()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", string.Empty, 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidSubscriberNumber3 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidSubscriberNumber3()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", "    ", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidSubscriberNumber4 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidSubscriberNumber4()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", "333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidSubscriberNumber5 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidSubscriberNumber5()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", "33333", 1));
        }

        /// <summary>
        /// Constructor_Fails_InvalidSubscriberNumber6 tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_InvalidSubscriberNumber6()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", "aaaa", 1));
        }
    }
}
