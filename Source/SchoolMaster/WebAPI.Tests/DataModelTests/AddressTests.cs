namespace SchoolMaster.WebAPI.Tests.DataModelTests
{
    using System;
    using SchoolMaster.WebAPI.DataModel;
    using Xunit;

    /// <summary>
    /// Address unit tests.
    /// </summary>
    public class AddressTests
    {
        // 96 characters long.
        private const string c_veryLongAddress = "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345";

        // 51 characters long.
        private const string c_veryLongCity = "012345678901234567890123456789012345678901234567890";

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
            Address address = new Address();

            // Assert.

            Assert.NotNull(address);

            Assert.True(address.Id == -1);
            Assert.True(address.Modified == false);

            Assert.True(((IAddress)address).Address1 == null);
            Assert.True(((IAddress)address).Address2 == null);

            Assert.True(((IAddress)address).City == null);
            Assert.True(((IAddress)address).State == null);
            Assert.True(((IAddress)address).Zip == null);
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
            string address1 = "10 Street Lane";
            string address2 = string.Empty;
            string city = "Boston";
            string state = "MA";
            string zip = "02124";

            // Act.
            Address address = new Address(id, address1, address2, city, state, zip);

            // Assert.

            Assert.NotNull(address);
            Assert.True(id == address.Id);

            Assert.True(address.Modified == false);

            Assert.True(address1 == ((IAddress)address).Address1);
            Assert.True(((IAddress)address).Address2 == null);

            Assert.True(city == ((IAddress)address).City);
            Assert.True(state == ((IAddress)address).State);
            Assert.True(zip == ((IAddress)address).Zip);
        }

        /// <summary>
        /// Constructor_Fails_IdLessThanOne tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_IdLessThanOne()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("id", () => new Address(0, "10 Street Lane", null, "Boston", "MA", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_Address1Null tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_Address1Null()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("address1", () => new Address(1, null, null, "Boston", "MA", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_Address1Empty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_Address1Empty()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("address1", () => new Address(1, string.Empty, null, "Boston", "MA", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_Address1WhiteSpace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_Address1WhiteSpace()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("address1", () => new Address(1, "    ", null, "Boston", "MA", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_Address1Long tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_Address1Long()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("address1", () => new Address(1, c_veryLongAddress, null, "Boston", "MA", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_Address2Long tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_Address2Long()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("address2", () => new Address(1, "10 Street Lane", c_veryLongAddress, "Boston", "MA", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_CityNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_CityNull()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("city", () => new Address(1, "10 Street Lane", null, null, "MA", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_CityEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_CityEmpty()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("city", () => new Address(1, "10 Street Lane", null, string.Empty, "MA", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_CityWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_CityWhitespace()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("city", () => new Address(1, "10 Street Lane", null, "     ", "MA", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_CityWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_CityLong()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("city", () => new Address(1, "10 Street Lane", null, c_veryLongCity, "MA", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_StateNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_StateNull()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("state", () => new Address(1, "10 Street Lane", null, "Boston", null, "02124"));
        }

        /// <summary>
        /// Constructor_Fails_StateEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_StateEmpty()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("state", () => new Address(1, "10 Street Lane", null, "Boston", string.Empty, "02124"));
        }

        /// <summary>
        /// Constructor_Fails_StateWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_StateWhitespace()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("state", () => new Address(1, "10 Street Lane", null, "Boston", "  ", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_StateShort tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_StateShort()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("state", () => new Address(1, "10 Street Lane", null, "Boston", "M", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_StateLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_StateLong()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("state", () => new Address(1, "10 Street Lane", null, "Boston", "MAA", "02124"));
        }

        /// <summary>
        /// Constructor_Fails_ZipNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ZipNull()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("zip", () => new Address(1, "10 Street Lane", null, "Boston", "MA", null));
        }

        /// <summary>
        /// Constructor_Fails_ZipEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ZipEmpty()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("zip", () => new Address(1, "10 Street Lane", null, "Boston", "MA", string.Empty));
        }

        /// <summary>
        /// Constructor_Fails_ZipWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ZipWhitespace()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("zip", () => new Address(1, "10 Street Lane", null, "Boston", "MA", "     "));
        }

        /// <summary>
        /// Constructor_Fails_ZipWrongLength tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ZipWrongLength()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("zip", () => new Address(1, "10 Street Lane", null, "Boston", "MA", "02124-0"));
        }

        /// <summary>
        /// Constructor_Fails_ZipNonNumeric tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ZipNonNumeric()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("zip", () => new Address(1, "10 Street Lane", null, "Boston", "MA", "0212a"));
        }

        /// <summary>
        /// Constructor_Fails_ZipNonNumericExceptHyphen tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ZipNonNumericWithHyphen()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("zip", () => new Address(1, "10 Street Lane", null, "Boston", "MA", "0212a-0123"));
        }

        /// <summary>
        /// Constructor_Fails_ZipTenDigitNoHyphen tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_ZipTenDigitNoHyphen()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("zip", () => new Address(1, "10 Street Lane", null, "Boston", "MA", "0212440123"));
        }

        /// <summary>
        /// Set_Address1_Works tests.
        /// </summary>
        [Fact]
        public void Set_Address1_Works()
        {
            // Arrange.
            string address1 = "10 Street Lane";

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address1 == null);

            ((IAddress)address).Address1 = address1;

            Assert.True(address.Modified == true);
            Assert.True(((IAddress)address).Address1 == address1);
        }

        /// <summary>
        /// Set_Address1_Fails_Address1Null tests.
        /// </summary>
        [Fact]
        public void Set_Address1_Fails_Address1Null()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address1 == null);

            Assert.Throws<ArgumentException>("address1", () => (((IAddress)address).Address1 = null));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address1 == null);
        }

        /// <summary>
        /// Set_Address1_Fails_Address1Empty tests.
        /// </summary>
        [Fact]
        public void Set_Address1_Fails_Address1Empty()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address1 == null);

            Assert.Throws<ArgumentException>("address1", () => (((IAddress)address).Address1 = string.Empty));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address1 == null);
        }

        /// <summary>
        /// Set_Address1_Fails_Address1Whitespace tests.
        /// </summary>
        [Fact]
        public void Set_Address1_Fails_Address1Whitespace()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address1 == null);

            Assert.Throws<ArgumentException>("address1", () => (((IAddress)address).Address1 = "      "));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address1 == null);
        }

        /// <summary>
        /// Set_Address1_Fails_Address1Long tests.
        /// </summary>
        [Fact]
        public void Set_Address1_Fails_Address1Long()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address1 == null);

            Assert.Throws<ArgumentException>("address1", () => (((IAddress)address).Address1 = c_veryLongAddress));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address1 == null);
        }

        /// <summary>
        /// Set_Address2_Works tests.
        /// </summary>
        [Fact]
        public void Set_Address2_Works()
        {
            // Arrange.
            string address2 = "10 Street Lane";

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address2 == null);

            ((IAddress)address).Address2 = address2;

            Assert.True(address.Modified == true);
            Assert.True(((IAddress)address).Address2 == address2);
        }

        /// <summary>
        /// Set_Address2_Fails_Address2Long tests.
        /// </summary>
        [Fact]
        public void Set_Address2_Fails_Address2Long()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address2 == null);

            Assert.Throws<ArgumentException>("address2", () => (((IAddress)address).Address2 = c_veryLongAddress));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Address2 == null);
        }

        /// <summary>
        /// Set_City_Works tests.
        /// </summary>
        [Fact]
        public void Set_City_Works()
        {
            // Arrange.
            string city = "Boston";

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).City == null);

            ((IAddress)address).City = city;

            Assert.True(address.Modified == true);
            Assert.True(((IAddress)address).City == city);
        }

        /// <summary>
        /// Set_City_Fails_CityNull tests.
        /// </summary>
        [Fact]
        public void Set_City_Fails_CityNull()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).City == null);

            Assert.Throws<ArgumentException>("city", () => (((IAddress)address).City = null));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).City == null);
        }

        /// <summary>
        /// Set_City_Fails_CityEmpty tests.
        /// </summary>
        [Fact]
        public void Set_City_Fails_CityEmpty()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).City == null);

            Assert.Throws<ArgumentException>("city", () => (((IAddress)address).City = string.Empty));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).City == null);
        }

        /// <summary>
        /// Set_City_Fails_CityWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_City_Fails_CityWhitespace()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).City == null);

            Assert.Throws<ArgumentException>("city", () => (((IAddress)address).City = "      "));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).City == null);
        }

        /// <summary>
        /// Set_City_Fails_CityLong tests.
        /// </summary>
        [Fact]
        public void Set_City_Fails_CityLong()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).City == null);

            Assert.Throws<ArgumentException>("city", () => (((IAddress)address).City = c_veryLongCity));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).City == null);
        }

        /// <summary>
        /// Set_State_Works tests.
        /// </summary>
        [Fact]
        public void Set_State_Works()
        {
            // Arrange.
            string state = "MA";

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).State == null);

            ((IAddress)address).State = state;

            Assert.True(address.Modified == true);
            Assert.True(((IAddress)address).State == state);
        }

        /// <summary>
        /// Set_State_Fails_StateNull tests.
        /// </summary>
        [Fact]
        public void Set_State_Fails_StateNull()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).State == null);

            Assert.Throws<ArgumentException>("state", () => (((IAddress)address).State = null));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).State == null);
        }

        /// <summary>
        /// Set_State_Fails_StateEmpty tests.
        /// </summary>
        [Fact]
        public void Set_State_Fails_StateEmpty()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).State == null);

            Assert.Throws<ArgumentException>("state", () => (((IAddress)address).State = string.Empty));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).State == null);
        }

        /// <summary>
        /// Set_State_Fails_StateWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_State_Fails_StateWhitespace()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).State == null);

            Assert.Throws<ArgumentException>("state", () => (((IAddress)address).State = "  "));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).State == null);
        }

        /// <summary>
        /// Set_State_Fails_StateShort tests.
        /// </summary>
        [Fact]
        public void Set_State_Fails_StateShort()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).State == null);

            Assert.Throws<ArgumentException>("state", () => (((IAddress)address).State = "M"));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).State == null);
        }

        /// <summary>
        /// Set_State_Fails_StateLong tests.
        /// </summary>
        [Fact]
        public void Set_State_Fails_StateLong()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).State == null);

            Assert.Throws<ArgumentException>("state", () => (((IAddress)address).State = "MAA"));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).State == null);
        }

        /// <summary>
        /// Set_Zip_Works tests.
        /// </summary>
        [Fact]
        public void Set_Zip_Works()
        {
            // Arrange.
            // Testing 5 digit in constructor test, 10 digit here.
            string zip = "02124-0123";

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);

            ((IAddress)address).Zip = zip;

            Assert.True(address.Modified == true);
            Assert.True(((IAddress)address).Zip == zip);
        }

        /// <summary>
        /// Set_Zip_Fails_ZipNull tests.
        /// </summary>
        [Fact]
        public void Set_Zip_Fails_ZipNull()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);

            Assert.Throws<ArgumentException>("zip", () => (((IAddress)address).Zip = null));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);
        }

        /// <summary>
        /// Set_Zip_Fails_ZipEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Zip_Fails_ZipEmpty()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);

            Assert.Throws<ArgumentException>("zip", () => (((IAddress)address).Zip = string.Empty));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);
        }

        /// <summary>
        /// Set_Zip_Fails_ZipWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Zip_Fails_ZipWhitespace()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);

            Assert.Throws<ArgumentException>("zip", () => (((IAddress)address).Zip = "     "));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);
        }

        /// <summary>
        /// Set_Zip_Fails_ZipWrongLength tests.
        /// </summary>
        [Fact]
        public void Set_Zip_Fails_ZipWrongLength()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);

            Assert.Throws<ArgumentException>("zip", () => (((IAddress)address).Zip = "02124-0"));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);
        }

        /// <summary>
        /// Set_Zip_Fails_ZipNonNumeric tests.
        /// </summary>
        [Fact]
        public void Set_Zip_Fails_ZipNonNumeric()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);

            Assert.Throws<ArgumentException>("zip", () => (((IAddress)address).Zip = "0212a"));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);
        }

        /// <summary>
        /// Set_Zip_Fails_ZipNonNumericWithHyphen tests.
        /// </summary>
        [Fact]
        public void Set_Zip_Fails_ZipNonNumericWithHyphen()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);

            Assert.Throws<ArgumentException>("zip", () => (((IAddress)address).Zip = "0212a-0123"));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);
        }

        /// <summary>
        /// Set_Zip_Fails_ZipTenDigitNoHyphen tests.
        /// </summary>
        [Fact]
        public void Set_Zip_Fails_ZipTenDigitNoHyphen()
        {
            // Arrange.

            // Act and assert.

            Address address = new Address();
            Assert.NotNull(address);

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);

            Assert.Throws<ArgumentException>("zip", () => (((IAddress)address).Zip = "0212440123"));

            Assert.True(address.Modified == false);
            Assert.True(((IAddress)address).Zip == null);
        }
    }
}
