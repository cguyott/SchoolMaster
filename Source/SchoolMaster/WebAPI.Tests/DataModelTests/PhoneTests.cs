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
        ///
        /// This unit test also tests all of the property getters.
        /// </summary>
        [Fact]
        public void Default_Constructor_Works()
        {
            // Arrange.

            // Act.
            Phone phone = new Phone();

            // Assert.
            Assert.NotNull(phone);
            Assert.True(phone.Id == -1);
            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
            Assert.True(((IPhone)phone).ExchangeCode == null);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
            Assert.True(((IPhone)phone).ContactOrder == 0);
        }

        /// <summary>
        /// Constructor_Works test.
        ///
        /// This unit test also tests all of the property getters.
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
        /// Constructor_Fails_NegativeId tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NegativeId()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("id", () => new Phone(-42, "111", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_ZeroId tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ZeroId()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("id", () => new Phone(0, "111", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_NullAreaCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullAreaCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, null, "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_EmptyAreaCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_EmptyAreaCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, string.Empty, "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_WhitespaceAreaCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_WhitespaceAreaCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, "   ", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_ShortAreaCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ShortAreaCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, "11", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_LongAreaCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LongAreaCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, "1111", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_NonNumericAreaCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NonNumericAreaCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("AreaCode", () => new Phone(1, "aaa", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_NullExchangeCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullExchangeCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", null, "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_EmptyExchangeCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_EmptyExchangeCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", string.Empty, "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_WhitespaceExchangeCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_WhitespaceExchangeCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", "   ", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_ShortExchangeCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ShortExchangeCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", "22", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_LongExchangeCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LongExchangeCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", "2222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_NonNumericExchangeCode tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NonNumericExchangeCode()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("ExchangeCode", () => new Phone(1, "111", "aaa", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_NullSubscriberNumber tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullSubscriberNumber()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", null, 1));
        }

        /// <summary>
        /// Constructor_Fails_EmptySubscriberNumber tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_EmptySubscriberNumber()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", string.Empty, 1));
        }

        /// <summary>
        /// Constructor_Fails_WhitespaceSubscriberNumber tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_WhitespaceSubscriberNumber()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", "    ", 1));
        }

        /// <summary>
        /// Constructor_Fails_ShortSubscriberNumber tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ShortSubscriberNumber()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", "333", 1));
        }

        /// <summary>
        /// Constructor_Fails_LongSubscriberNumber tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LongSubscriberNumber()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", "33333", 1));
        }

        /// <summary>
        /// Constructor_Fails_NonNumericSubscriberNumber tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NonNumericSubscriberNumber()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("SubscriberNumber", () => new Phone(1, "111", "222", "aaaa", 1));
        }

        /// <summary>
        /// Set_AreaCode_Works tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Works()
        {
            // Arrange.
            string areaCode = "888";

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            ((IPhone)phone).AreaCode = areaCode;

            Assert.True(phone.Modified == true);
            Assert.True(((IPhone)phone).AreaCode == areaCode);
        }

        /// <summary>
        /// Set_AreaCode_Fails_NullAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_NullAreaCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("AreaCode", () => (((IPhone)phone).AreaCode = null));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
        }

        /// <summary>
        /// Set_AreaCode_Fails_EmptyAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_EmptyAreaCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("AreaCode", () => (((IPhone)phone).AreaCode = string.Empty));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
        }

        /// <summary>
        /// Set_AreaCode_Fails_WhitespaceAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_WhitespaceAreaCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("AreaCode", () => (((IPhone)phone).AreaCode = "   "));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
        }

        /// <summary>
        /// Set_AreaCode_Fails_ShortAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_ShortAreaCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("AreaCode", () => (((IPhone)phone).AreaCode = "88"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
        }

        /// <summary>
        /// Set_AreaCode_Fails_LongAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_LongAreaCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("AreaCode", () => (((IPhone)phone).AreaCode = "8888"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
        }

        /// <summary>
        /// Set_AreaCode_Fails_NonNumericAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_NonNumericAreaCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("AreaCode", () => (((IPhone)phone).AreaCode = "aaa"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
        }

        /// <summary>
        /// Set_ExchangeCode_Works tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Works()
        {
            // Arrange.
            string exchangeCode = "888";

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            ((IPhone)phone).ExchangeCode = exchangeCode;

            Assert.True(phone.Modified == true);
            Assert.True(((IPhone)phone).ExchangeCode == exchangeCode);
        }

        /// <summary>
        /// Set_ExchangeCode_Fails_NullAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_NullExchangeCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("ExchangeCode", () => (((IPhone)phone).ExchangeCode = null));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);
        }

        /// <summary>
        /// Set_ExchangeCode_Fails_EmptyAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_EmptyExchangeCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("ExchangeCode", () => (((IPhone)phone).ExchangeCode = string.Empty));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);
        }

        /// <summary>
        /// Set_ExchangeCode_Fails_WhitespaceAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_WhitespaceExchangeCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("ExchangeCode", () => (((IPhone)phone).ExchangeCode = "   "));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);
        }

        /// <summary>
        /// Set_ExchangeCode_Fails_ShortAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_ShortExchangeCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("ExchangeCode", () => (((IPhone)phone).ExchangeCode = "88"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);
        }

        /// <summary>
        /// Set_ExchangeCode_Fails_LongAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_LongExchangeCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("ExchangeCode", () => (((IPhone)phone).ExchangeCode = "8888"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);
        }

        /// <summary>
        /// Set_ExchangeCode_Fails_NonNumericAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_NonNumericExchangeCode()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("ExchangeCode", () => (((IPhone)phone).ExchangeCode = "aaa"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);
        }

        /// <summary>
        /// Set_SubscriberNumber_Works tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Works()
        {
            // Arrange.
            string subscriberNumber = "8888";

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            ((IPhone)phone).SubscriberNumber = subscriberNumber;

            Assert.True(phone.Modified == true);
            Assert.True(((IPhone)phone).SubscriberNumber == subscriberNumber);
        }

        /// <summary>
        /// Set_SubscriberNumber_Fails_NullSubscriberNumber tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_NullSubscriberNumber()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("SubscriberNumber", () => (((IPhone)phone).SubscriberNumber = null));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
        }

        /// <summary>
        /// Set_SubscriberNumber_Fails_EmptySubscriberNumber tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_EmptySubscriberNumber()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("SubscriberNumber", () => (((IPhone)phone).SubscriberNumber = string.Empty));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
        }

        /// <summary>
        /// Set_SubscriberNumber_Fails_WhitespaceSubscriberNumber tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_WhitespaceSubscriberNumber()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("SubscriberNumber", () => (((IPhone)phone).SubscriberNumber = "    "));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
        }

        /// <summary>
        /// Set_SubscriberNumber_Fails_ShortSubscriberNumber tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_ShortSubscriberNumber()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("SubscriberNumber", () => (((IPhone)phone).SubscriberNumber = "888"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
        }

        /// <summary>
        /// Set_SubscriberNumber_Fails_LongAreaCode tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_LongSubscriberNumber()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("SubscriberNumber", () => (((IPhone)phone).SubscriberNumber = "88888"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
        }

        /// <summary>
        /// Set_SubscriberNumber_Fails_NonNumericSubscriberNumber tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_NonNumericSubscriberNumber()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("SubscriberNumber", () => (((IPhone)phone).SubscriberNumber = "aaaa"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
        }

        /// <summary>
        /// Set_ContactOrder_Works tests.
        /// </summary>
        [Fact]
        public void Set_ContactOrder_Works()
        {
            // Arrange.
            int contactOrder = 1;

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ContactOrder == 0);

            ((IPhone)phone).ContactOrder = contactOrder;

            Assert.True(phone.Modified == true);
            Assert.True(((IPhone)phone).ContactOrder == contactOrder);
        }
    }
}
