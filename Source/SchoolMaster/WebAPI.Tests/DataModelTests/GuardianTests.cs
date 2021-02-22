namespace SchoolMaster.WebAPI.Tests.DataModelTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SchoolMaster.WebAPI.DataModel;
    using Xunit;

    /// <summary>
    /// Guardian unit tests.
    /// </summary>
    public class GuardianTests
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
            Guardian guardian = new Guardian();

            // Assert.

            Assert.NotNull(guardian);

            Assert.True(guardian.GuardianId == -1);
            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).ContactOrder == -1);

            Assert.True(guardian.Modified == false);

            Assert.True(guardian.PersonId == -1);
            Assert.True(guardian.Role == Role.Guardian);
            Assert.True(guardian.LastLoginDate == DateTime.MinValue);
            Assert.True(guardian.LastPasswordChangedDate == DateTime.MinValue);
            Assert.True(guardian.CreatedDate == DateTime.MinValue);

            Assert.True(guardian.Prefix == null);
            Assert.True(guardian.FirstName == null);
            Assert.True(guardian.MiddleName == null);
            Assert.True(guardian.LastName == null);
            Assert.True(guardian.Suffix == null);
            Assert.True(guardian.Login == null);
            Assert.NotNull(((IGuardian)guardian).Email);

            Assert.NotNull(((IGuardian)guardian).Addresses);
            Assert.True(((IGuardian)guardian).Addresses.Count() == 0);
            Assert.NotNull(((IGuardian)guardian).PhoneNumbers);
            Assert.True(((IGuardian)guardian).PhoneNumbers.Count() == 0);
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
            int contactOrder = 1;
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
            Guardian guardian = new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers);

            List<Address> addressList = ((IGuardian)guardian).Addresses.ToList();
            List<Phone> phoneList = ((IGuardian)guardian).PhoneNumbers.ToList();

            // Assert.

            Assert.NotNull(guardian);

            Assert.True(guardian.GuardianId == id);
            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).ContactOrder == contactOrder);

            Assert.True(id == guardian.PersonId);
            Assert.True(guardian.Role == Role.Guardian);
            Assert.True(lastLoginDate == ((IGuardian)guardian).LastLoginDate);
            Assert.True(lastPasswordChangedDate == ((IGuardian)guardian).LastPasswordChangedDate);
            Assert.True(createdDate == ((IGuardian)guardian).CreatedDate);
            Assert.True(prefix == ((IGuardian)guardian).Prefix);
            Assert.True(firstName == ((IGuardian)guardian).FirstName);
            Assert.True(middleName == ((IGuardian)guardian).MiddleName);
            Assert.True(lastName == ((IGuardian)guardian).LastName);
            Assert.True(suffix == ((IGuardian)guardian).Suffix);
            Assert.True(login == ((IGuardian)guardian).Login);
            Assert.True(email == ((IGuardian)guardian).Email);

            Assert.True(addresses == ((IGuardian)guardian).Addresses);
            Assert.True(((IGuardian)guardian).Addresses.Count() == 2);

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

            Assert.True(phoneNumbers == ((IGuardian)guardian).PhoneNumbers);
            Assert.True(((IGuardian)guardian).PhoneNumbers.Count() == 2);

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
            int contactOrder = 1;
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
            Guardian guardian = new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers);

            // Assert.

            Assert.NotNull(guardian);

            Assert.True(guardian.GuardianId == id);
            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).ContactOrder == contactOrder);

            Assert.True(id == guardian.PersonId);
            Assert.True(guardian.Role == Role.Guardian);
            Assert.True(lastLoginDate == ((IGuardian)guardian).LastLoginDate);
            Assert.True(lastPasswordChangedDate == ((IGuardian)guardian).LastPasswordChangedDate);
            Assert.True(createdDate == ((IGuardian)guardian).CreatedDate);
            Assert.True(prefix == ((IGuardian)guardian).Prefix);
            Assert.True(firstName == ((IGuardian)guardian).FirstName);
            Assert.True(middleName == ((IGuardian)guardian).MiddleName);
            Assert.True(lastName == ((IGuardian)guardian).LastName);
            Assert.True(suffix == ((IGuardian)guardian).Suffix);
            Assert.True(login == ((IGuardian)guardian).Login);
            Assert.True(email == ((IGuardian)guardian).Email);
            Assert.True(addresses == ((IGuardian)guardian).Addresses);
            Assert.True(phoneNumbers == ((IGuardian)guardian).PhoneNumbers);
        }

        /// <summary>
        /// Constructor_Fails_NullEmail tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullEmail()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentNullException>("email", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_NullAddresses tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullAddresses()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentNullException>("addresses", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_NullPhoneNumbers tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_NullPhoneNumbers()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentNullException>("phoneNumbers", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_IdLessThanOne tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_IdLessThanOne()
        {
            // Arrange.
            int id = 0;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("id", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Set_ContactOrder_Works tests.
        /// </summary>
        [Fact]
        public void Set_ContactOrder_Works()
        {
            // Arrange.
            int contactOrder = 1;

            // Act and assert.

            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).ContactOrder == -1);

            ((IGuardian)guardian).ContactOrder = contactOrder;

            Assert.True(guardian.Modified == true);
            Assert.True(((IGuardian)guardian).ContactOrder == contactOrder);
        }

        /// <summary>
        /// Set_ContactOrder_Fails_LessThanOne tests.
        /// </summary>
        [Fact]
        public void Set_ContactOrder_Fails_LessThanOne()
        {
            // Arrange.

            // Act and assert.

            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).ContactOrder == -1);

            Assert.Throws<ArgumentException>("ContactOrder", () => (((IGuardian)guardian).ContactOrder = 0));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).ContactOrder == -1);
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
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("personId", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_PrefixLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_PrefixLong()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("Prefix", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameNull()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("FirstName", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameEmpty()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("FirstName", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameWhitespace()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("FirstName", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameLong()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("FirstName", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_MiddleNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_MiddleNameLong()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("MiddleName", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameNull()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("LastName", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameEmpty()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("LastName", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameWhitespace()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("LastName", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LastNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameLong()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("LastName", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_SuffixLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_SuffixLong()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("Suffix", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginNull()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("Login", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginEmpty()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("Login", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginWhitespace()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("Login", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
        }

        /// <summary>
        /// Constructor_Fails_LoginLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginLong()
        {
            // Arrange.
            int id = 1;
            int contactOrder = 1;
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
            Assert.Throws<ArgumentException>("Login", () => new Guardian(id, contactOrder, personId, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers));
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
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Prefix == null);

            ((IGuardian)guardian).Prefix = prefix;

            Assert.True(guardian.Modified == true);
            Assert.True(((IGuardian)guardian).Prefix == prefix);
        }

        /// <summary>
        /// Set_Prefix_Fails_PrefixLong tests.
        /// </summary>
        [Fact]
        public void Set_Prefix_Fails_PrefixLong()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Prefix == null);

            Assert.Throws<ArgumentException>("Prefix", () => (((IGuardian)guardian).Prefix = c_veryLongPrefix));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Prefix == null);
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
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).FirstName == null);

            ((IGuardian)guardian).FirstName = firstName;

            Assert.True(guardian.Modified == true);
            Assert.True(((IGuardian)guardian).FirstName == firstName);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameNull tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameNull()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IGuardian)guardian).FirstName = null));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameEmpty tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameEmpty()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IGuardian)guardian).FirstName = string.Empty));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameWhitespace()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IGuardian)guardian).FirstName = "      "));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameLong()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IGuardian)guardian).FirstName = c_veryLongName));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).FirstName == null);
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
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).MiddleName == null);

            ((IGuardian)guardian).MiddleName = middleName;

            Assert.True(guardian.Modified == true);
            Assert.True(((IGuardian)guardian).MiddleName == middleName);
        }

        /// <summary>
        /// Set_MiddleName_Fails_MiddleNameLong tests.
        /// </summary>
        [Fact]
        public void Set_MiddleName_Fails_MiddleNameLong()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).MiddleName == null);

            Assert.Throws<ArgumentException>("MiddleName", () => (((IGuardian)guardian).MiddleName = c_veryLongName));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).MiddleName == null);
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
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).LastName == null);

            ((IGuardian)guardian).LastName = lastName;

            Assert.True(guardian.Modified == true);
            Assert.True(((IGuardian)guardian).LastName == lastName);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameNull tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameNull()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IGuardian)guardian).LastName = null));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameEmpty tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameEmpty()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IGuardian)guardian).LastName = string.Empty));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameWhitespace()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IGuardian)guardian).LastName = "      "));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameLong tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameLong()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IGuardian)guardian).LastName = c_veryLongName));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).LastName == null);
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
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Suffix == null);

            ((IGuardian)guardian).Suffix = suffix;

            Assert.True(guardian.Modified == true);
            Assert.True(((IGuardian)guardian).Suffix == suffix);
        }

        /// <summary>
        /// Set_Suffix_Fails_SuffixLong tests.
        /// </summary>
        [Fact]
        public void Set_Suffix_Fails_SuffixLong()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Suffix == null);

            Assert.Throws<ArgumentException>("Suffix", () => (((IGuardian)guardian).Suffix = c_veryLongPrefix));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Suffix == null);
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
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Login == null);

            ((IGuardian)guardian).Login = login;

            Assert.True(guardian.Modified == true);
            Assert.True(((IGuardian)guardian).Login == login);
        }

        /// <summary>
        /// Set_Login_Fails_LoginNull tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginNull()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IGuardian)guardian).Login = null));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Login == null);
        }

        /// <summary>
        /// Set_Login_Fails_LoginEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginEmpty()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IGuardian)guardian).Login = string.Empty));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Login == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginWhitespace()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IGuardian)guardian).Login = "      "));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Login == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginLong()
        {
            // Arrange.

            // Act and assert.
            Guardian guardian = new Guardian();
            Assert.NotNull(guardian);

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IGuardian)guardian).Login = c_veryLongLogin));

            Assert.True(guardian.Modified == false);
            Assert.True(((IGuardian)guardian).Login == null);
        }
        #endregion Base Class Tests
    }
}
