namespace SchoolMaster.WebAPI.Tests.DataModelTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SchoolMaster.WebAPI.DataModel;
    using Xunit;

    /// <summary>
    /// InstructorTests unit tests.
    /// </summary>
    public class InstructorTests
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
            Instructor instructor = new Instructor();

            // Assert.

            Assert.NotNull(instructor);

            Assert.True(instructor.InstructorId == -1);
            Assert.True(instructor.Modified == false);

            Assert.True(((IInstructor)instructor).Department == null);
            Assert.True(((IInstructor)instructor).Position == null);

            Assert.True(instructor.Modified == false);

            Assert.True(instructor.PersonId == -1);
            Assert.True(instructor.Role == Role.Instructor);
            Assert.True(instructor.LastLoginDate == DateTime.MinValue);
            Assert.True(instructor.LastPasswordChangedDate == DateTime.MinValue);
            Assert.True(instructor.CreatedDate == DateTime.MinValue);

            Assert.True(instructor.Prefix == null);
            Assert.True(instructor.FirstName == null);
            Assert.True(instructor.MiddleName == null);
            Assert.True(instructor.LastName == null);
            Assert.True(instructor.Suffix == null);
            Assert.True(instructor.Login == null);
            Assert.NotNull(((IInstructor)instructor).Email);

            Assert.NotNull(((IInstructor)instructor).Addresses);
            Assert.True(((IInstructor)instructor).Addresses.Count() == 0);
            Assert.NotNull(((IInstructor)instructor).PhoneNumbers);
            Assert.True(((IInstructor)instructor).PhoneNumbers.Count() == 0);
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
            Instructor instructor = new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers);

            List<Address> addressList = ((IInstructor)instructor).Addresses.ToList();
            List<Phone> phoneList = ((IInstructor)instructor).PhoneNumbers.ToList();

            // Assert.

            Assert.NotNull(instructor);

            Assert.True(instructor.InstructorId == id);
            Assert.True(instructor.Modified == false);

            Assert.True(((IInstructor)instructor).Department == department);
            Assert.True(((IInstructor)instructor).Position == position);

            Assert.True(id == instructor.PersonId);
            Assert.True(instructor.Role == Role.Instructor);
            Assert.True(lastLoginDate == ((IInstructor)instructor).LastLoginDate);
            Assert.True(lastPasswordChangedDate == ((IInstructor)instructor).LastPasswordChangedDate);
            Assert.True(createdDate == ((IInstructor)instructor).CreatedDate);
            Assert.True(prefix == ((IInstructor)instructor).Prefix);
            Assert.True(firstName == ((IInstructor)instructor).FirstName);
            Assert.True(middleName == ((IInstructor)instructor).MiddleName);
            Assert.True(lastName == ((IInstructor)instructor).LastName);
            Assert.True(suffix == ((IInstructor)instructor).Suffix);
            Assert.True(login == ((IInstructor)instructor).Login);
            Assert.True(email == ((IInstructor)instructor).Email);

            Assert.True(addresses == ((IInstructor)instructor).Addresses);
            Assert.True(((IInstructor)instructor).Addresses.Count() == 2);

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

            Assert.True(phoneNumbers == ((IInstructor)instructor).PhoneNumbers);
            Assert.True(((IInstructor)instructor).PhoneNumbers.Count() == 2);

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
            Instructor instructor = new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers);

            // Assert.

            Assert.NotNull(instructor);

            Assert.True(instructor.InstructorId == id);
            Assert.True(instructor.Modified == false);

            Assert.True(((IInstructor)instructor).Department == department);
            Assert.True(((IInstructor)instructor).Position == position);

            Assert.True(id == instructor.PersonId);
            Assert.True(instructor.Role == Role.Instructor);
            Assert.True(lastLoginDate == ((IInstructor)instructor).LastLoginDate);
            Assert.True(lastPasswordChangedDate == ((IInstructor)instructor).LastPasswordChangedDate);
            Assert.True(createdDate == ((IInstructor)instructor).CreatedDate);
            Assert.True(prefix == ((IInstructor)instructor).Prefix);
            Assert.True(firstName == ((IInstructor)instructor).FirstName);
            Assert.True(middleName == ((IInstructor)instructor).MiddleName);
            Assert.True(lastName == ((IInstructor)instructor).LastName);
            Assert.True(suffix == ((IInstructor)instructor).Suffix);
            Assert.True(login == ((IInstructor)instructor).Login);
            Assert.True(email == ((IInstructor)instructor).Email);
            Assert.True(addresses == ((IInstructor)instructor).Addresses);
            Assert.True(phoneNumbers == ((IInstructor)instructor).PhoneNumbers);
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
            Assert.Throws<ArgumentNullException>("email", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentNullException>("addresses", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentNullException>("phoneNumbers", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("id", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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

            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Department == null);

            ((IInstructor)instructor).Department = department;

            Assert.True(instructor.Modified == true);
            Assert.True(((IInstructor)instructor).Department == department);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentNull tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentNull()
        {
            // Arrange.

            // Act and assert.

            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Department == null);

            Assert.Throws<ArgumentException>("Department", () => (((IInstructor)instructor).Department = null));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Department == null);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentEmpty()
        {
            // Arrange.

            // Act and assert.

            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Department == null);

            Assert.Throws<ArgumentException>("Department", () => (((IInstructor)instructor).Department = string.Empty));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Department == null);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentWhitespace()
        {
            // Arrange.

            // Act and assert.

            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Department == null);

            Assert.Throws<ArgumentException>("Department", () => (((IInstructor)instructor).Department = "       "));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Department == null);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentLong tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentLong()
        {
            // Arrange.

            // Act and assert.

            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Department == null);

            Assert.Throws<ArgumentException>("Department", () => (((IInstructor)instructor).Department = c_veryLongString));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Department == null);
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

            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Position == null);

            ((IInstructor)instructor).Position = position;

            Assert.True(instructor.Modified == true);
            Assert.True(((IInstructor)instructor).Position == position);
        }

        /// <summary>
        /// Set_Position_Fails_PositionNull tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionNull()
        {
            // Arrange.

            // Act and assert.

            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Position == null);

            Assert.Throws<ArgumentException>("Position", () => (((IInstructor)instructor).Position = null));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Position == null);
        }

        /// <summary>
        /// Set_Position_Fails_PositionEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionEmpty()
        {
            // Arrange.

            // Act and assert.

            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Position == null);

            Assert.Throws<ArgumentException>("Position", () => (((IInstructor)instructor).Position = string.Empty));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Position == null);
        }

        /// <summary>
        /// Set_Department_Fails_PositionWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionWhitespace()
        {
            // Arrange.

            // Act and assert.

            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Position == null);

            Assert.Throws<ArgumentException>("Position", () => (((IInstructor)instructor).Position = "       "));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Position == null);
        }

        /// <summary>
        /// Set_Position_Fails_PositionLong tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionLong()
        {
            // Arrange.

            // Act and assert.

            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Position == null);

            Assert.Throws<ArgumentException>("Position", () => (((IInstructor)instructor).Position = c_veryLongString));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Position == null);
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
            Assert.Throws<ArgumentException>("personId", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("Prefix", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("FirstName", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("FirstName", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("FirstName", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("FirstName", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("MiddleName", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("LastName", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("LastName", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("LastName", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("LastName", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("Suffix", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("Login", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("Login", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("Login", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Assert.Throws<ArgumentException>("Login", () => new Instructor(id, department, position, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Prefix == null);

            ((IInstructor)instructor).Prefix = prefix;

            Assert.True(instructor.Modified == true);
            Assert.True(((IInstructor)instructor).Prefix == prefix);
        }

        /// <summary>
        /// Set_Prefix_Fails_PrefixLong tests.
        /// </summary>
        [Fact]
        public void Set_Prefix_Fails_PrefixLong()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Prefix == null);

            Assert.Throws<ArgumentException>("Prefix", () => (((IInstructor)instructor).Prefix = c_veryLongPrefix));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Prefix == null);
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
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).FirstName == null);

            ((IInstructor)instructor).FirstName = firstName;

            Assert.True(instructor.Modified == true);
            Assert.True(((IInstructor)instructor).FirstName == firstName);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameNull tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameNull()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IInstructor)instructor).FirstName = null));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameEmpty tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameEmpty()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IInstructor)instructor).FirstName = string.Empty));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameWhitespace()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IInstructor)instructor).FirstName = "      "));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameLong()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IInstructor)instructor).FirstName = c_veryLongName));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).FirstName == null);
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
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).MiddleName == null);

            ((IInstructor)instructor).MiddleName = middleName;

            Assert.True(instructor.Modified == true);
            Assert.True(((IInstructor)instructor).MiddleName == middleName);
        }

        /// <summary>
        /// Set_MiddleName_Fails_MiddleNameLong tests.
        /// </summary>
        [Fact]
        public void Set_MiddleName_Fails_MiddleNameLong()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).MiddleName == null);

            Assert.Throws<ArgumentException>("MiddleName", () => (((IInstructor)instructor).MiddleName = c_veryLongName));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).MiddleName == null);
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
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).LastName == null);

            ((IInstructor)instructor).LastName = lastName;

            Assert.True(instructor.Modified == true);
            Assert.True(((IInstructor)instructor).LastName == lastName);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameNull tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameNull()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IInstructor)instructor).LastName = null));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameEmpty tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameEmpty()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IInstructor)instructor).LastName = string.Empty));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameWhitespace()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IInstructor)instructor).LastName = "      "));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameLong tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameLong()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IInstructor)instructor).LastName = c_veryLongName));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).LastName == null);
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
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Suffix == null);

            ((IInstructor)instructor).Suffix = suffix;

            Assert.True(instructor.Modified == true);
            Assert.True(((IInstructor)instructor).Suffix == suffix);
        }

        /// <summary>
        /// Set_Suffix_Fails_SuffixLong tests.
        /// </summary>
        [Fact]
        public void Set_Suffix_Fails_SuffixLong()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Suffix == null);

            Assert.Throws<ArgumentException>("Suffix", () => (((IInstructor)instructor).Suffix = c_veryLongPrefix));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Suffix == null);
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
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Login == null);

            ((IInstructor)instructor).Login = login;

            Assert.True(instructor.Modified == true);
            Assert.True(((IInstructor)instructor).Login == login);
        }

        /// <summary>
        /// Set_Login_Fails_LoginNull tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginNull()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IInstructor)instructor).Login = null));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Login == null);
        }

        /// <summary>
        /// Set_Login_Fails_LoginEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginEmpty()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IInstructor)instructor).Login = string.Empty));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Login == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginWhitespace()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IInstructor)instructor).Login = "      "));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Login == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginLong()
        {
            // Arrange.

            // Act and assert.
            Instructor instructor = new Instructor();
            Assert.NotNull(instructor);

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IInstructor)instructor).Login = c_veryLongLogin));

            Assert.True(instructor.Modified == false);
            Assert.True(((IInstructor)instructor).Login == null);
        }
        #endregion Base Class Tests
    }
}
