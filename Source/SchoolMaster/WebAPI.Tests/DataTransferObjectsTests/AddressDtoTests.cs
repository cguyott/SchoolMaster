namespace SchoolMaster.WebAPI.Tests.DataTransferObjectsTests
{
    using SchoolMaster.WebAPI.DataTransferObjects;
    using Xunit;

    /// <summary>
    /// AddressDtoTests unit tests.
    /// </summary>
    public class AddressDtoTests
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
            AddressDto addressDto = new AddressDto();

            // Assert.

            Assert.NotNull(addressDto);

            Assert.True(addressDto.Address1 == null);
            Assert.True(addressDto.Address2 == null);
            Assert.True(addressDto.City == null);
            Assert.True(addressDto.State == null);
            Assert.True(addressDto.Zip == null);
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
            string address1 = "10 Street Lane";
            string address2 = null;
            string city = "Boston";
            string state = "MA";
            string zip = "02124";

            // Act.
            AddressDto addressDto = new AddressDto(address1, address2, city, state, zip);

            // Assert.

            Assert.NotNull(addressDto);

            Assert.True(address1 == addressDto.Address1);
            Assert.True(addressDto.Address2 == null);

            Assert.True(city == addressDto.City);
            Assert.True(state == addressDto.State);
            Assert.True(zip == addressDto.Zip);
        }
    }
}
