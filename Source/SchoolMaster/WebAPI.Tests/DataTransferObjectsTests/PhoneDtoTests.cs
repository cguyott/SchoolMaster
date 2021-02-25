namespace SchoolMaster.WebAPI.Tests.DataTransferObjectsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SchoolMaster.WebAPI.DataModel;
    using SchoolMaster.WebAPI.DataTransferObjects;
    using Xunit;

    /// <summary>
    /// AdministratorDto unit tests.
    /// </summary>
    public class PhoneDtoTests
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
            PhoneDto phoneDto = new PhoneDto();

            // Assert.

            Assert.NotNull(phoneDto);

            Assert.True(phoneDto.AreaCode == null);
            Assert.True(phoneDto.ExchangeCode == null);
            Assert.True(phoneDto.SubscriberNumber == null);
            Assert.True(phoneDto.ContactOrder == 0);
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
            string areaCode = "111";
            string exchangeCode = "222";
            string subscriberNumber = "3333";
            int contactOrder = 1;

            // Act.
            PhoneDto phoneDto = new PhoneDto(areaCode, exchangeCode, subscriberNumber, contactOrder);

            // Assert.

            Assert.NotNull(phoneDto);

            Assert.True(phoneDto.AreaCode == areaCode);
            Assert.True(phoneDto.ExchangeCode == exchangeCode);
            Assert.True(phoneDto.SubscriberNumber == subscriberNumber);
            Assert.True(phoneDto.ContactOrder == contactOrder);
        }
    }
}
