namespace SchoolMaster.WebAPI.Tests.DataModelTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SchoolMaster.WebAPI.DataModel;
    using Xunit;

    /// <summary>
    /// Administrator unit tests.
    /// </summary>
    public class AdministratorTests
    {
        // 129 characters long.
        private const string c_veryLongString = "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678";

        // c_veryLongName is assigned a string of 51 characters.
        private const string c_veryLongName = "012345678901234567890123456789012345678901234567890";

        // c_veryLongLogin is assigned a string of 65 characters.
        private const string c_veryLongLogin = "01234567890123456789012345678901234567890123456789012345678901234";

        // c_veryLongPrefix is assigned a string of 7 characters.
        private const string c_veryLongPrefix = "0123456";

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
            Administrator admin = new Administrator();

            // Assert.

            Assert.NotNull(admin);

            Assert.True(admin.AdminId == -1);
            Assert.True(admin.Modified == false);

            Assert.True(((IAdministrator)admin).Department == null);
            Assert.True(((IAdministrator)admin).Position == null);

            Assert.True(admin.Modified == false);

            Assert.True(admin.PersonId == -1);
            Assert.True(admin.Role == Role.Administrator);
            Assert.True(admin.LastLoginDate == DateTime.MinValue);
            Assert.True(admin.LastPasswordChangedDate == DateTime.MinValue);
            Assert.True(admin.CreatedDate == DateTime.MinValue);

            Assert.True(admin.Prefix == null);
            Assert.True(admin.FirstName == null);
            Assert.True(admin.MiddleName == null);
            Assert.True(admin.LastName == null);
            Assert.True(admin.Suffix == null);
            Assert.True(admin.Login == null);
            Assert.NotNull(((IAdministrator)admin).Email);

            Assert.NotNull(((IAdministrator)admin).Addresses);
            Assert.True(((IAdministrator)admin).Addresses.Any() == false);
            Assert.NotNull(((IAdministrator)admin).PhoneNumbers);
            Assert.True(((IAdministrator)admin).PhoneNumbers.Any() == false);
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
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>
            {
                new Address(1, "10 Street Lane", null, "Boston", "MA", "02124"),
                new Address(2, "20 Street Lane", null, "Boston", "MA", "02124"),
            };
            List<Phone> phoneNumbers = new List<Phone>
            {
                new Phone(1, "111", "111", "1111", 1),
                new Phone(2, "222", "222", "2222", 1),
            };

            // Act.
            Administrator admin = new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers);

            List<Address> addressList = ((IAdministrator)admin).Addresses.ToList();
            List<Phone> phoneList = ((IAdministrator)admin).PhoneNumbers.ToList();

            // Assert.

            Assert.NotNull(admin);

            Assert.True(admin.AdminId == id);
            Assert.True(admin.Modified == false);

            Assert.True(((IAdministrator)admin).Department == department);
            Assert.True(((IAdministrator)admin).Position == position);

            Assert.True(id == admin.PersonId);
            Assert.True(admin.Role == Role.Administrator);
            Assert.True(lastLoginDate == ((IAdministrator)admin).LastLoginDate);
            Assert.True(lastPasswordChangedDate == ((IAdministrator)admin).LastPasswordChangedDate);
            Assert.True(createdDate == ((IAdministrator)admin).CreatedDate);
            Assert.True(prefix == ((IAdministrator)admin).Prefix);
            Assert.True(firstName == ((IAdministrator)admin).FirstName);
            Assert.True(middleName == ((IAdministrator)admin).MiddleName);
            Assert.True(lastName == ((IAdministrator)admin).LastName);
            Assert.True(suffix == ((IAdministrator)admin).Suffix);
            Assert.True(login == ((IAdministrator)admin).Login);
            Assert.True(email == ((IAdministrator)admin).Email);

            Assert.True(addresses == ((IAdministrator)admin).Addresses);
            Assert.True(((IAdministrator)admin).Addresses.Count() == 2);

            Assert.True(addressList[0].Id == 1);
            Assert.True(((IAddress)addressList[0]).Address1 == "10 Street Lane");
            Assert.True(((IAddress)addressList[0]).Address2 == null);
            Assert.True(((IAddress)addressList[0]).City == "Boston");
            Assert.True(((IAddress)addressList[0]).State == "MA");
            Assert.True(((IAddress)addressList[0]).Zip == "02124");

            Assert.True(addressList[1].Id == 2);
            Assert.True(((IAddress)addressList[1]).Address1 == "20 Street Lane");
            Assert.True(((IAddress)addressList[1]).Address2 == null);
            Assert.True(((IAddress)addressList[1]).City == "Boston");
            Assert.True(((IAddress)addressList[1]).State == "MA");
            Assert.True(((IAddress)addressList[1]).Zip == "02124");

            Assert.True(phoneNumbers == ((IAdministrator)admin).PhoneNumbers);
            Assert.True(((IAdministrator)admin).PhoneNumbers.Count() == 2);

            Assert.True(phoneList[0].Id == 1);
            Assert.True(((IPhone)phoneList[0]).AreaCode == "111");
            Assert.True(((IPhone)phoneList[0]).ExchangeCode == "111");
            Assert.True(((IPhone)phoneList[0]).SubscriberNumber == "1111");
            Assert.True(((IPhone)phoneList[0]).ContactOrder == 1);

            Assert.True(phoneList[1].Id == 2);
            Assert.True(((IPhone)phoneList[1]).AreaCode == "222");
            Assert.True(((IPhone)phoneList[1]).ExchangeCode == "222");
            Assert.True(((IPhone)phoneList[1]).SubscriberNumber == "2222");
            Assert.True(((IPhone)phoneList[1]).ContactOrder == 1);
        }

        /// <summary>
        /// Constructor_Works_MinData test.
        ///
        /// This unit test also tests all of the property getters.
        /// </summary>
        [Fact]
        public void Constructor_Works_MinData()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act.
            Administrator admin = new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers);

            // Assert.

            Assert.NotNull(admin);

            Assert.True(admin.AdminId == id);
            Assert.True(admin.Modified == false);

            Assert.True(((IAdministrator)admin).Department == department);
            Assert.True(((IAdministrator)admin).Position == position);

            Assert.True(id == admin.PersonId);
            Assert.True(admin.Role == Role.Administrator);
            Assert.True(lastLoginDate == ((IAdministrator)admin).LastLoginDate);
            Assert.True(lastPasswordChangedDate == ((IAdministrator)admin).LastPasswordChangedDate);
            Assert.True(createdDate == ((IAdministrator)admin).CreatedDate);
            Assert.True(prefix == ((IAdministrator)admin).Prefix);
            Assert.True(firstName == ((IAdministrator)admin).FirstName);
            Assert.True(middleName == ((IAdministrator)admin).MiddleName);
            Assert.True(lastName == ((IAdministrator)admin).LastName);
            Assert.True(suffix == ((IAdministrator)admin).Suffix);
            Assert.True(login == ((IAdministrator)admin).Login);
            Assert.True(email == ((IAdministrator)admin).Email);
            Assert.True(addresses == ((IAdministrator)admin).Addresses);
            Assert.True(phoneNumbers == ((IAdministrator)admin).PhoneNumbers);
        }

        /// <summary>
        /// Constructor_Fails_NullEmail tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullEmail()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = null;
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentNullException>("email", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_NullAddresses tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullAddresses()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = null;
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentNullException>("addresses", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_NullPhoneNumbers tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullPhoneNumbers()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = null;

            // Act and Assert.
            Assert.Throws<ArgumentNullException>("phoneNumbers", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_IdLessThanOne tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_IdLessThanOne()
        {
            // Arrange.
            int id = 0;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("id", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Set_Department_Works tests.
        /// </summary>
        [Fact]
        public void Set_Department_Works()
        {
            // Arrange.
            string department = "Department";

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Department == null);

            ((IAdministrator)admin).Department = department;

            Assert.True(admin.Modified == true);
            Assert.True(((IAdministrator)admin).Department == department);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentNull tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentNull()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Department == null);

            Assert.Throws<ArgumentException>("department", () => (((IAdministrator)admin).Department = null));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Department == null);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentEmpty()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Department == null);

            Assert.Throws<ArgumentException>("department", () => (((IAdministrator)admin).Department = string.Empty));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Department == null);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentWhitespace()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Department == null);

            Assert.Throws<ArgumentException>("department", () => (((IAdministrator)admin).Department = "       "));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Department == null);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentLong tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentLong()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Department == null);

            Assert.Throws<ArgumentException>("department", () => (((IAdministrator)admin).Department = c_veryLongString));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Department == null);
        }

        /// <summary>
        /// Set_Position_Works tests.
        /// </summary>
        [Fact]
        public void Set_Position_Works()
        {
            // Arrange.
            string position = "Position";

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Position == null);

            ((IAdministrator)admin).Position = position;

            Assert.True(admin.Modified == true);
            Assert.True(((IAdministrator)admin).Position == position);
        }

        /// <summary>
        /// Set_Position_Fails_PositionNull tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionNull()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Position == null);

            Assert.Throws<ArgumentException>("position", () => (((IAdministrator)admin).Position = null));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Position == null);
        }

        /// <summary>
        /// Set_Position_Fails_PositionEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionEmpty()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Position == null);

            Assert.Throws<ArgumentException>("position", () => (((IAdministrator)admin).Position = string.Empty));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Position == null);
        }

        /// <summary>
        /// Set_Department_Fails_PositionWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionWhitespace()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Position == null);

            Assert.Throws<ArgumentException>("position", () => (((IAdministrator)admin).Position = "       "));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Position == null);
        }

        /// <summary>
        /// Set_Position_Fails_PositionLong tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionLong()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Position == null);

            Assert.Throws<ArgumentException>("position", () => (((IAdministrator)admin).Position = c_veryLongString));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Position == null);
        }

        #region Base Class Tests

        /// <summary>
        /// Constructor_Fails_PersonIdLessThanOne tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_PersonIdLessThanOne()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 0;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("personId", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_PrefixLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_PrefixLong()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = c_veryLongPrefix;
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>
            {
                new Address(),
                new Address(),
            };
            List<Phone> phoneNumbers = new List<Phone>
            {
                new Phone(),
                new Phone(),
            };

            // Act and Assert.
            Assert.Throws<ArgumentException>("prefix", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameNull()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = null;
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("firstName", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameEmpty()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = string.Empty;
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("firstName", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameWhitespace()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "      ";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("firstName", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameLong()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = c_veryLongName;
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("firstName", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_MiddleNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_MiddleNameLong()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = c_veryLongName;
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("middleName", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameNull()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = null;
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("lastName", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameEmpty()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = string.Empty;
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("lastName", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameWhitespace()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "   ";
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("lastName", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameLong()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = c_veryLongName;
            string suffix = "Sr.";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("lastName", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_SuffixLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_SuffixLong()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "thisSuffixIsTooLong";
            string login = "JDoe";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("suffix", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginNull()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = null;
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("login", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginEmpty()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = string.Empty;
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("login", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginWhitespace()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = "    ";
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("login", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginLong()
        {
            // Arrange.
            int id = 1;
            string department = "Department";
            string position = "Position";
            int personId = 1;
            DateTime lastLoginDate = DateTime.UtcNow;
            DateTime lastPasswordChangedDate = DateTime.UtcNow;
            DateTime createdDate = DateTime.UtcNow;
            string prefix = "Mr.";
            string firstName = "John";
            string middleName = "Joseph";
            string lastName = "Doe";
            string suffix = "Sr.";
            string login = c_veryLongLogin;
            string passwordHash = "passwordHash";
            string passwordSalt = "passwordSalt";
            Email email = new Email(1, "address@email.com");
            List<Address> addresses = new List<Address>();
            List<Phone> phoneNumbers = new List<Phone>();

            // Act and Assert.
            Assert.Throws<ArgumentException>("login", () => new Administrator(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Set_Prefix_Works tests.
        /// </summary>
        [Fact]
        public void Set_Prefix_Works()
        {
            // Arrange.
            string prefix = "Mr.";

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Prefix == null);

            ((IAdministrator)admin).Prefix = prefix;

            Assert.True(admin.Modified == true);
            Assert.True(((IAdministrator)admin).Prefix == prefix);
        }

        /// <summary>
        /// Set_Prefix_Fails_PrefixLong tests.
        /// </summary>
        [Fact]
        public void Set_Prefix_Fails_PrefixLong()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Prefix == null);

            Assert.Throws<ArgumentException>("prefix", () => (((IAdministrator)admin).Prefix = c_veryLongPrefix));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Prefix == null);
        }

        /// <summary>
        /// Set_FirstName_Works tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Works()
        {
            // Arrange.
            string firstName = "John";

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).FirstName == null);

            ((IAdministrator)admin).FirstName = firstName;

            Assert.True(admin.Modified == true);
            Assert.True(((IAdministrator)admin).FirstName == firstName);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameNull tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameNull()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).FirstName == null);

            Assert.Throws<ArgumentException>("firstName", () => (((IAdministrator)admin).FirstName = null));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameEmpty tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameEmpty()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).FirstName == null);

            Assert.Throws<ArgumentException>("firstName", () => (((IAdministrator)admin).FirstName = string.Empty));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameWhitespace()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).FirstName == null);

            Assert.Throws<ArgumentException>("firstName", () => (((IAdministrator)admin).FirstName = "      "));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameLong()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).FirstName == null);

            Assert.Throws<ArgumentException>("firstName", () => (((IAdministrator)admin).FirstName = c_veryLongName));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).FirstName == null);
        }

        /// <summary>
        /// Set_MiddleName_Works tests.
        /// </summary>
        [Fact]
        public void Set_MiddleName_Works()
        {
            // Arrange.
            string middleName = "Joseph";

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).MiddleName == null);

            ((IAdministrator)admin).MiddleName = middleName;

            Assert.True(admin.Modified == true);
            Assert.True(((IAdministrator)admin).MiddleName == middleName);
        }

        /// <summary>
        /// Set_MiddleName_Fails_MiddleNameLong tests.
        /// </summary>
        [Fact]
        public void Set_MiddleName_Fails_MiddleNameLong()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).MiddleName == null);

            Assert.Throws<ArgumentException>("middleName", () => (((IAdministrator)admin).MiddleName = c_veryLongName));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).MiddleName == null);
        }

        /// <summary>
        /// Set_LastName_Works tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Works()
        {
            // Arrange.
            string lastName = "Doe";

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).LastName == null);

            ((IAdministrator)admin).LastName = lastName;

            Assert.True(admin.Modified == true);
            Assert.True(((IAdministrator)admin).LastName == lastName);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameNull tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameNull()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).LastName == null);

            Assert.Throws<ArgumentException>("lastName", () => (((IAdministrator)admin).LastName = null));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameEmpty tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameEmpty()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).LastName == null);

            Assert.Throws<ArgumentException>("lastName", () => (((IAdministrator)admin).LastName = string.Empty));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameWhitespace()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).LastName == null);

            Assert.Throws<ArgumentException>("lastName", () => (((IAdministrator)admin).LastName = "      "));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameLong tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameLong()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).LastName == null);

            Assert.Throws<ArgumentException>("lastName", () => (((IAdministrator)admin).LastName = c_veryLongName));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).LastName == null);
        }

        /// <summary>
        /// Set_Suffix_Works tests.
        /// </summary>
        [Fact]
        public void Set_Suffix_Works()
        {
            // Arrange.
            string suffix = "Sr.";

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Suffix == null);

            ((IAdministrator)admin).Suffix = suffix;

            Assert.True(admin.Modified == true);
            Assert.True(((IAdministrator)admin).Suffix == suffix);
        }

        /// <summary>
        /// Set_Suffix_Fails_SuffixLong tests.
        /// </summary>
        [Fact]
        public void Set_Suffix_Fails_SuffixLong()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Suffix == null);

            Assert.Throws<ArgumentException>("suffix", () => (((IAdministrator)admin).Suffix = c_veryLongPrefix));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Suffix == null);
        }

        /// <summary>
        /// Set_Login_Works tests.
        /// </summary>
        [Fact]
        public void Set_Login_Works()
        {
            // Arrange.
            string login = "JDoe";

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Login == null);

            ((IAdministrator)admin).Login = login;

            Assert.True(admin.Modified == true);
            Assert.True(((IAdministrator)admin).Login == login);
        }

        /// <summary>
        /// Set_Login_Fails_LoginNull tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginNull()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Login == null);

            Assert.Throws<ArgumentException>("login", () => (((IAdministrator)admin).Login = null));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Login == null);
        }

        /// <summary>
        /// Set_Login_Fails_LoginEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginEmpty()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Login == null);

            Assert.Throws<ArgumentException>("login", () => (((IAdministrator)admin).Login = string.Empty));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Login == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginWhitespace()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Login == null);

            Assert.Throws<ArgumentException>("login", () => (((IAdministrator)admin).Login = "      "));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Login == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginLong()
        {
            // Arrange.

            // Act and assert.
            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Login == null);

            Assert.Throws<ArgumentException>("login", () => (((IAdministrator)admin).Login = c_veryLongLogin));

            Assert.True(admin.Modified == false);
            Assert.True(((IAdministrator)admin).Login == null);
        }
        #endregion Base Class Tests
    }
}
