namespace SchoolMaster.WebAPI.Tests.DataModelTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SchoolMaster.WebAPI.DataModel;
    using Xunit;

    /// <summary>
    /// studentTests unit tests.
    /// </summary>
    public class StudentTests
    {
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
            Student student = new Student();

            // Assert.

            Assert.NotNull(student);

            Assert.True(student.StudentId == -1);
            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).GradeLevel == -1);

            Assert.True(student.Modified == false);

            Assert.True(student.PersonId == -1);
            Assert.True(student.Role == Role.Student);
            Assert.True(student.LastLoginDate == DateTime.MinValue);
            Assert.True(student.LastPasswordChangedDate == DateTime.MinValue);
            Assert.True(student.CreatedDate == DateTime.MinValue);

            Assert.True(student.Prefix == null);
            Assert.True(student.FirstName == null);
            Assert.True(student.MiddleName == null);
            Assert.True(student.LastName == null);
            Assert.True(student.Suffix == null);
            Assert.True(student.Login == null);
            Assert.NotNull(((IStudent)student).Email);

            Assert.NotNull(((IStudent)student).Addresses);
            Assert.True(((IStudent)student).Addresses.Any() == false);
            Assert.NotNull(((IStudent)student).PhoneNumbers);
            Assert.True(((IStudent)student).PhoneNumbers.Any() == false);
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
            int gradeLevel = 1;
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
            Student student = new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers);

            List<Address> addressList = ((IStudent)student).Addresses.ToList();
            List<Phone> phoneList = ((IStudent)student).PhoneNumbers.ToList();

            // Assert.

            Assert.NotNull(student);

            Assert.True(student.StudentId == id);
            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).GradeLevel == gradeLevel);

            Assert.True(id == student.PersonId);
            Assert.True(student.Role == Role.Student);
            Assert.True(lastLoginDate == ((IStudent)student).LastLoginDate);
            Assert.True(lastPasswordChangedDate == ((IStudent)student).LastPasswordChangedDate);
            Assert.True(createdDate == ((IStudent)student).CreatedDate);
            Assert.True(prefix == ((IStudent)student).Prefix);
            Assert.True(firstName == ((IStudent)student).FirstName);
            Assert.True(middleName == ((IStudent)student).MiddleName);
            Assert.True(lastName == ((IStudent)student).LastName);
            Assert.True(suffix == ((IStudent)student).Suffix);
            Assert.True(login == ((IStudent)student).Login);
            Assert.True(email == ((IStudent)student).Email);

            Assert.True(addresses == ((IStudent)student).Addresses);
            Assert.True(((IStudent)student).Addresses.Count() == 2);

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

            Assert.True(phoneNumbers == ((IStudent)student).PhoneNumbers);
            Assert.True(((IStudent)student).PhoneNumbers.Count() == 2);

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
            int gradeLevel = 1;
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
            Student student = new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers);

            // Assert.

            Assert.NotNull(student);

            Assert.True(student.StudentId == id);
            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).GradeLevel == gradeLevel);

            Assert.True(id == student.PersonId);
            Assert.True(student.Role == Role.Student);
            Assert.True(lastLoginDate == ((IStudent)student).LastLoginDate);
            Assert.True(lastPasswordChangedDate == ((IStudent)student).LastPasswordChangedDate);
            Assert.True(createdDate == ((IStudent)student).CreatedDate);
            Assert.True(prefix == ((IStudent)student).Prefix);
            Assert.True(firstName == ((IStudent)student).FirstName);
            Assert.True(middleName == ((IStudent)student).MiddleName);
            Assert.True(lastName == ((IStudent)student).LastName);
            Assert.True(suffix == ((IStudent)student).Suffix);
            Assert.True(login == ((IStudent)student).Login);
            Assert.True(email == ((IStudent)student).Email);
            Assert.True(addresses == ((IStudent)student).Addresses);
            Assert.True(phoneNumbers == ((IStudent)student).PhoneNumbers);
        }

        /// <summary>
        /// Constructor_Fails_NullEmail tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullEmail()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentNullException>("email", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_NullAddresses tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullAddresses()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentNullException>("addresses", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_NullPhoneNumbers tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullPhoneNumbers()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentNullException>("phoneNumbers", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_IdLessThanOne tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_IdLessThanOne()
        {
            // Arrange.
            int id = 0;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("id", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Set_GradeLevel_Works tests.
        /// </summary>
        [Fact]
        public void Set_GradeLevel_Works()
        {
            // Arrange.
            int gradeLevel = 1;

            // Act and assert.

            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).GradeLevel == -1);

            ((IStudent)student).GradeLevel = gradeLevel;

            Assert.True(student.Modified == true);
            Assert.True(((IStudent)student).GradeLevel == gradeLevel);
        }

        /// <summary>
        /// Set_GradeLevel_Fails_LessThanZero tests.
        /// </summary>
        [Fact]
        public void Set_GradeLevel_Fails_LessThanZero()
        {
            // Arrange.

            // Act and assert.

            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).GradeLevel == -1);

            Assert.Throws<ArgumentException>("gradeLevel", () => (((IStudent)student).GradeLevel = -2));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).GradeLevel == -1);
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
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("personId", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_PrefixLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_PrefixLong()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("prefix", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameNull()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("firstName", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameEmpty()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("firstName", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameWhitespace()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("firstName", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameLong()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("firstName", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_MiddleNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_MiddleNameLong()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("middleName", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameNull()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("lastName", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameEmpty()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("lastName", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameWhitespace()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("lastName", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameLong()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("lastName", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_SuffixLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_SuffixLong()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("suffix", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginNull()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("login", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginEmpty()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("login", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginWhitespace()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("login", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginLong()
        {
            // Arrange.
            int id = 1;
            int gradeLevel = 1;
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
            Assert.Throws<ArgumentException>("login", () => new Student(id, gradeLevel, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Prefix == null);

            ((IStudent)student).Prefix = prefix;

            Assert.True(student.Modified == true);
            Assert.True(((IStudent)student).Prefix == prefix);
        }

        /// <summary>
        /// Set_Prefix_Fails_PrefixLong tests.
        /// </summary>
        [Fact]
        public void Set_Prefix_Fails_PrefixLong()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Prefix == null);

            Assert.Throws<ArgumentException>("prefix", () => (((IStudent)student).Prefix = c_veryLongPrefix));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Prefix == null);
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
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).FirstName == null);

            ((IStudent)student).FirstName = firstName;

            Assert.True(student.Modified == true);
            Assert.True(((IStudent)student).FirstName == firstName);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameNull tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameNull()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).FirstName == null);

            Assert.Throws<ArgumentException>("firstName", () => (((IStudent)student).FirstName = null));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameEmpty tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameEmpty()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).FirstName == null);

            Assert.Throws<ArgumentException>("firstName", () => (((IStudent)student).FirstName = string.Empty));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameWhitespace()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).FirstName == null);

            Assert.Throws<ArgumentException>("firstName", () => (((IStudent)student).FirstName = "      "));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameLong()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).FirstName == null);

            Assert.Throws<ArgumentException>("firstName", () => (((IStudent)student).FirstName = c_veryLongName));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).FirstName == null);
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
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).MiddleName == null);

            ((IStudent)student).MiddleName = middleName;

            Assert.True(student.Modified == true);
            Assert.True(((IStudent)student).MiddleName == middleName);
        }

        /// <summary>
        /// Set_MiddleName_Fails_MiddleNameLong tests.
        /// </summary>
        [Fact]
        public void Set_MiddleName_Fails_MiddleNameLong()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).MiddleName == null);

            Assert.Throws<ArgumentException>("middleName", () => (((IStudent)student).MiddleName = c_veryLongName));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).MiddleName == null);
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
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).LastName == null);

            ((IStudent)student).LastName = lastName;

            Assert.True(student.Modified == true);
            Assert.True(((IStudent)student).LastName == lastName);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameNull tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameNull()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).LastName == null);

            Assert.Throws<ArgumentException>("lastName", () => (((IStudent)student).LastName = null));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameEmpty tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameEmpty()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).LastName == null);

            Assert.Throws<ArgumentException>("lastName", () => (((IStudent)student).LastName = string.Empty));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameWhitespace()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).LastName == null);

            Assert.Throws<ArgumentException>("lastName", () => (((IStudent)student).LastName = "      "));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameLong tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameLong()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).LastName == null);

            Assert.Throws<ArgumentException>("lastName", () => (((IStudent)student).LastName = c_veryLongName));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).LastName == null);
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
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Suffix == null);

            ((IStudent)student).Suffix = suffix;

            Assert.True(student.Modified == true);
            Assert.True(((IStudent)student).Suffix == suffix);
        }

        /// <summary>
        /// Set_Suffix_Fails_SuffixLong tests.
        /// </summary>
        [Fact]
        public void Set_Suffix_Fails_SuffixLong()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Suffix == null);

            Assert.Throws<ArgumentException>("suffix", () => (((IStudent)student).Suffix = c_veryLongPrefix));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Suffix == null);
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
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Login == null);

            ((IStudent)student).Login = login;

            Assert.True(student.Modified == true);
            Assert.True(((IStudent)student).Login == login);
        }

        /// <summary>
        /// Set_Login_Fails_LoginNull tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginNull()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Login == null);

            Assert.Throws<ArgumentException>("login", () => (((IStudent)student).Login = null));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Login == null);
        }

        /// <summary>
        /// Set_Login_Fails_LoginEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginEmpty()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Login == null);

            Assert.Throws<ArgumentException>("login", () => (((IStudent)student).Login = string.Empty));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Login == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginWhitespace()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Login == null);

            Assert.Throws<ArgumentException>("login", () => (((IStudent)student).Login = "      "));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Login == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginLong()
        {
            // Arrange.

            // Act and assert.
            Student student = new Student();
            Assert.NotNull(student);

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Login == null);

            Assert.Throws<ArgumentException>("login", () => (((IStudent)student).Login = c_veryLongLogin));

            Assert.True(student.Modified == false);
            Assert.True(((IStudent)student).Login == null);
        }
        #endregion Base Class Tests
    }
}
