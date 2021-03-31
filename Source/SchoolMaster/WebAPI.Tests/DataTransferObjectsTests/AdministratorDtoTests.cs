namespace SchoolMaster.WebAPI.Tests.DataTransferObjectsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SchoolMaster.WebAPI.DataTransferObjects;
    using Xunit;

    /// <summary>
    /// AdministratorDto unit tests.
    /// </summary>
    public class AdministratorDtoTests
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
            AdministratorResponseDto adminDto = new AdministratorResponseDto();

            // Assert.

            Assert.NotNull(adminDto);

            Assert.True(adminDto.Id == -1);

            Assert.True(adminDto.Department == null);
            Assert.True(adminDto.Position == null);

            Assert.True(adminDto.LastLoginDate == DateTime.MinValue);
            Assert.True(adminDto.LastPasswordChangedDate == DateTime.MinValue);
            Assert.True(adminDto.CreatedDate == DateTime.MinValue);

            Assert.True(adminDto.Prefix == null);
            Assert.True(adminDto.FirstName == null);
            Assert.True(adminDto.MiddleName == null);
            Assert.True(adminDto.LastName == null);
            Assert.True(adminDto.Suffix == null);
            Assert.True(adminDto.Login == null);
            Assert.True(adminDto.Email == null);

            Assert.NotNull(adminDto.Addresses);
            Assert.True(adminDto.Addresses.Any() == false);
            Assert.NotNull(adminDto.PhoneNumbers);
            Assert.True(adminDto.PhoneNumbers.Any() == false);
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
            string department = "Department";
            string position = "Position";
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string email = "address@email.com";
            List<AddressDto> addresses = new List<AddressDto>
            {
                new AddressDto("10 Street Lane", null, "Boston", "MA", "02124"),
                new AddressDto("20 Street Lane", null, "Boston", "MA", "02124"),
            };
            List<PhoneDto> phoneNumbers = new List<PhoneDto>
            {
                new PhoneDto("111", "111", "1111", 1),
                new PhoneDto("222", "222", "2222", 1),
            };

            // Act.
            AdministratorResponseDto adminDto = new AdministratorResponseDto(id, department, position, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, email, addresses, phoneNumbers);

            List<AddressDto> addressList = adminDto.Addresses.ToList();
            List<PhoneDto> phoneList = adminDto.PhoneNumbers.ToList();

            // Assert.

            Assert.NotNull(adminDto);

            Assert.True(adminDto.Id == id);

            Assert.True(adminDto.Department == department);
            Assert.True(adminDto.Position == position);

            Assert.True(lastLoginDate == adminDto.LastLoginDate);
            Assert.True(lastPasswordChangedDate == adminDto.LastPasswordChangedDate);
            Assert.True(createdDate == adminDto.CreatedDate);
            Assert.True(prefix == adminDto.Prefix);
            Assert.True(firstName == adminDto.FirstName);
            Assert.True(middleName == adminDto.MiddleName);
            Assert.True(lastName == adminDto.LastName);
            Assert.True(suffix == adminDto.Suffix);
            Assert.True(login == adminDto.Login);
            Assert.True(email == adminDto.Email);

            Assert.True(addresses == adminDto.Addresses);
            Assert.True(adminDto.Addresses.Count() == 2);

            Assert.True(addressList[0].Address1 == "10 Street Lane");
            Assert.True(addressList[0].Address2 == null);
            Assert.True(addressList[0].City == "Boston");
            Assert.True(addressList[0].State == "MA");
            Assert.True(addressList[0].Zip == "02124");

            Assert.True(addressList[1].Address1 == "20 Street Lane");
            Assert.True(addressList[1].Address2 == null);
            Assert.True(addressList[1].City == "Boston");
            Assert.True(addressList[1].State == "MA");
            Assert.True(addressList[1].Zip == "02124");

            Assert.True(phoneNumbers == adminDto.PhoneNumbers);
            Assert.True(adminDto.PhoneNumbers.Count() == 2);

            Assert.True(phoneList[0].AreaCode == "111");
            Assert.True(phoneList[0].ExchangeCode == "111");
            Assert.True(phoneList[0].SubscriberNumber == "1111");
            Assert.True(phoneList[0].ContactOrder == 1);

            Assert.True(phoneList[1].AreaCode == "222");
            Assert.True(phoneList[1].ExchangeCode == "222");
            Assert.True(phoneList[1].SubscriberNumber == "2222");
            Assert.True(phoneList[1].ContactOrder == 1);
        }
    }
}
