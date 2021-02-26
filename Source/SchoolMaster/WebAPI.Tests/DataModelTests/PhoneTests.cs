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
        /// Constructor_Fails_IdNegative tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_IdNegative()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("id", () => new Phone(-42, "111", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_IdZero tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_IdZero()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("id", () => new Phone(0, "111", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_AreaCodeNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_AreaCodeNull()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("areaCode", () => new Phone(1, null, "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_AreaCodeEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_AreaCodeEmpty()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("areaCode", () => new Phone(1, string.Empty, "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_AreaCodeWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_AreaCodeWhitespace()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("areaCode", () => new Phone(1, "   ", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_AreaCodeShort tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_AreaCodeShort()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("areaCode", () => new Phone(1, "11", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_AreaCodeLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_AreaCodeLong()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("areaCode", () => new Phone(1, "1111", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_AreaCodeNonNumeric tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_AreaCodeNonNumeric()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("areaCode", () => new Phone(1, "aaa", "222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_ExchangeCodeNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ExchangeCodeNull()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("exchangeCode", () => new Phone(1, "111", null, "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_ExchangeCodeEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ExchangeCodeEmpty()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("exchangeCode", () => new Phone(1, "111", string.Empty, "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_ExchangeCodeWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ExchangeCodeWhitespace()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("exchangeCode", () => new Phone(1, "111", "   ", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_ExchangeCodeShort tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ExchangeCodeShort()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("exchangeCode", () => new Phone(1, "111", "22", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_ExchangeCodeLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ExchangeCodeLong()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("exchangeCode", () => new Phone(1, "111", "2222", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_ExchangeCodeNonNumeric tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ExchangeCodeNonNumeric()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("exchangeCode", () => new Phone(1, "111", "aaa", "3333", 1));
        }

        /// <summary>
        /// Constructor_Fails_SubscriberNumberNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_SubscriberNumberNull()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("subscriberNumber", () => new Phone(1, "111", "222", null, 1));
        }

        /// <summary>
        /// Constructor_Fails_SubscriberNumberEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_SubscriberNumberEmpty()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("subscriberNumber", () => new Phone(1, "111", "222", string.Empty, 1));
        }

        /// <summary>
        /// Constructor_Fails_SubscriberNumberWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_SubscriberNumberWhitespace()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("subscriberNumber", () => new Phone(1, "111", "222", "    ", 1));
        }

        /// <summary>
        /// Constructor_Fails_SubscriberNumberShort tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_SubscriberNumberShort()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("subscriberNumber", () => new Phone(1, "111", "222", "333", 1));
        }

        /// <summary>
        /// Constructor_Fails_SubscriberNumberLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_SubscriberNumberLong()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("subscriberNumber", () => new Phone(1, "111", "222", "33333", 1));
        }

        /// <summary>
        /// Constructor_Fails_SubscriberNumberNonNumeric tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_SubscriberNumberNonNumeric()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("subscriberNumber", () => new Phone(1, "111", "222", "aaaa", 1));
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
        /// Set_AreaCode_Fails_AreaCodeNull tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_AreaCodeNull()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("areaCode", () => (((IPhone)phone).AreaCode = null));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
        }

        /// <summary>
        /// Set_AreaCode_Fails_AreaCodeEmpty tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_AreaCodeEmpty()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("areaCode", () => (((IPhone)phone).AreaCode = string.Empty));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
        }

        /// <summary>
        /// Set_AreaCode_Fails_AreaCodeWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_AreaCodeWhitespace()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("areaCode", () => (((IPhone)phone).AreaCode = "   "));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
        }

        /// <summary>
        /// Set_AreaCode_Fails_AreaCodeShort tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_AreaCodeShort()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("areaCode", () => (((IPhone)phone).AreaCode = "88"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
        }

        /// <summary>
        /// Set_AreaCode_Fails_AreaCodeLong tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_AreaCodeLong()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("areaCode", () => (((IPhone)phone).AreaCode = "8888"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);
        }

        /// <summary>
        /// Set_AreaCode_Fails_AreaCodeNonNumeric tests.
        /// </summary>
        [Fact]
        public void Set_AreaCode_Fails_AreaCodeNonNumeric()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).AreaCode == null);

            Assert.Throws<ArgumentException>("areaCode", () => (((IPhone)phone).AreaCode = "aaa"));

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
        /// Set_ExchangeCode_Fails_ExchangeCodeNull tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_ExchangeCodeNull()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("exchangeCode", () => (((IPhone)phone).ExchangeCode = null));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);
        }

        /// <summary>
        /// Set_ExchangeCode_Fails_ExchangeCodeEmpty tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_ExchangeCodeEmpty()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("exchangeCode", () => (((IPhone)phone).ExchangeCode = string.Empty));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);
        }

        /// <summary>
        /// Set_ExchangeCode_Fails_ExchangeCodeWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_ExchangeCodeWhitespace()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("exchangeCode", () => (((IPhone)phone).ExchangeCode = "   "));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);
        }

        /// <summary>
        /// Set_ExchangeCode_Fails_ExchangeCodeShort tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_ExchangeCodeShort()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("exchangeCode", () => (((IPhone)phone).ExchangeCode = "88"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);
        }

        /// <summary>
        /// Set_ExchangeCode_Fails_ExchangeCodeLong tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_ExchangeCodeLong()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("exchangeCode", () => (((IPhone)phone).ExchangeCode = "8888"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);
        }

        /// <summary>
        /// Set_ExchangeCode_Fails_ExchangeCodeNonNumeric tests.
        /// </summary>
        [Fact]
        public void Set_ExchangeCode_Fails_ExchangeCodeNonNumeric()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).ExchangeCode == null);

            Assert.Throws<ArgumentException>("exchangeCode", () => (((IPhone)phone).ExchangeCode = "aaa"));

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
        /// Set_SubscriberNumber_Fails_SubscriberNumberNull tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_SubscriberNumberNull()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("subscriberNumber", () => (((IPhone)phone).SubscriberNumber = null));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
        }

        /// <summary>
        /// Set_SubscriberNumber_Fails_SubscriberNumberEmpty tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_SubscriberNumberEmpty()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("subscriberNumber", () => (((IPhone)phone).SubscriberNumber = string.Empty));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
        }

        /// <summary>
        /// Set_SubscriberNumber_Fails_SubscriberNumberWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_SubscriberNumberWhitespace()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("subscriberNumber", () => (((IPhone)phone).SubscriberNumber = "    "));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
        }

        /// <summary>
        /// Set_SubscriberNumber_Fails_SubscriberNumberShort tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_SubscriberNumberShort()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("subscriberNumber", () => (((IPhone)phone).SubscriberNumber = "888"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
        }

        /// <summary>
        /// Set_SubscriberNumber_Fails_SubscriberNumberLong tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_SubscriberNumberLong()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("subscriberNumber", () => (((IPhone)phone).SubscriberNumber = "88888"));

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);
        }

        /// <summary>
        /// Set_SubscriberNumber_Fails_SubscriberNumberNonNumeric tests.
        /// </summary>
        [Fact]
        public void Set_SubscriberNumber_Fails_SubscriberNumberNonNumeric()
        {
            // Arrange.

            // Act and Assert.

            Phone phone = new Phone();
            Assert.NotNull(phone);

            Assert.True(phone.Modified == false);
            Assert.True(((IPhone)phone).SubscriberNumber == null);

            Assert.Throws<ArgumentException>("subscriberNumber", () => (((IPhone)phone).SubscriberNumber = "aaaa"));

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
