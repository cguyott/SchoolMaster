namespace SchoolMaster.WebAPI.Tests.DataModelTests
{
    using System;
    using SchoolMaster.WebAPI.DataModel;
    using Xunit;

    /// <summary>
    /// Person unit tests.
    /// </summary>
    public class PersonTests
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
            TestPerson person = new TestPerson();

            // Assert.

            Assert.NotNull(person);
            Assert.True(person.Modified == false);

            Assert.True(person.Id == -1);
            Assert.True(person.Role == Role.Unknown);
            Assert.True(((IPerson)person).LastLoginDate == DateTime.MinValue);
            Assert.True(((IPerson)person).LastPasswordChangedDate == DateTime.MinValue);
            Assert.True(((IPerson)person).CreatedDate == DateTime.MinValue);

            Assert.True(((IPerson)person).Prefix == null);
            Assert.True(((IPerson)person).FirstName == null);
            Assert.True(((IPerson)person).MiddleName == null);
            Assert.True(((IPerson)person).LastName == null);
            Assert.True(((IPerson)person).Suffix == null);
            Assert.True(((IPerson)person).Login == null);
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
            Role role = Role.Instructor;
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

            // Act.
            TestPerson person = new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt);

            // Assert.

            Assert.NotNull(person);
            Assert.True(person.Modified == false);

            Assert.True(id == person.Id);
            Assert.True(role == person.Role);
            Assert.True(lastLoginDate == ((IPerson)person).LastLoginDate);
            Assert.True(lastPasswordChangedDate == ((IPerson)person).LastPasswordChangedDate);
            Assert.True(createdDate == ((IPerson)person).CreatedDate);
            Assert.True(prefix == ((IPerson)person).Prefix);
            Assert.True(firstName == ((IPerson)person).FirstName);
            Assert.True(middleName == ((IPerson)person).MiddleName);
            Assert.True(lastName == ((IPerson)person).LastName);
            Assert.True(suffix == ((IPerson)person).Suffix);
            Assert.True(login == ((IPerson)person).Login);
        }

        /// <summary>
        /// Constructor_Fails_IdLessThanOne tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_IdLessThanOne()
        {
            // Arrange.
            int id = 0;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("id", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_RoleNotSet tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_RoleNotSet()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Unknown;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("role", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_PrefixLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_PrefixLong()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("Prefix", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameNull()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("FirstName", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameEmpty()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("FirstName", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameWhitespace()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("FirstName", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_FirstNameLong()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("FirstName", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_MiddleNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_MiddleNameLong()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("MiddleName", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_LastNameNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameNull()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("LastName", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_LastNameEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameEmpty()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("LastName", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_LastNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameWhitespace()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("LastName", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_LastNameLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LastNameLong()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("LastName", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_SuffixLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_SuffixLong()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("Suffix", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_LoginNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginNull()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("Login", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_LoginEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginEmpty()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("Login", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_LoginWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginWhitespace()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("Login", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
        }

        /// <summary>
        /// Constructor_Fails_LoginLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_LoginLong()
        {
            // Arrange.
            int id = 1;
            Role role = Role.Instructor;
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

            // Act and Assert.
            Assert.Throws<ArgumentException>("Login", () => new TestPerson(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt));
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
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Prefix == null);

            ((IPerson)person).Prefix = prefix;

            Assert.True(person.Modified == true);
            Assert.True(((IPerson)person).Prefix == prefix);
        }

        /// <summary>
        /// Set_Prefix_Fails_PrefixLong tests.
        /// </summary>
        [Fact]
        public void Set_Prefix_Fails_PrefixLong()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Prefix == null);

            Assert.Throws<ArgumentException>("Prefix", () => (((IPerson)person).Prefix = c_veryLongPrefix));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Prefix == null);
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
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).FirstName == null);

            ((IPerson)person).FirstName = firstName;

            Assert.True(person.Modified == true);
            Assert.True(((IPerson)person).FirstName == firstName);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameNull tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameNull()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IPerson)person).FirstName = null));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameEmpty tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameEmpty()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IPerson)person).FirstName = string.Empty));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameWhitespace()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IPerson)person).FirstName = "      "));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).FirstName == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Set_FirstName_Fails_FirstNameLong()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).FirstName == null);

            Assert.Throws<ArgumentException>("FirstName", () => (((IPerson)person).FirstName = c_veryLongName));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).FirstName == null);
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
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).MiddleName == null);

            ((IPerson)person).MiddleName = middleName;

            Assert.True(person.Modified == true);
            Assert.True(((IPerson)person).MiddleName == middleName);
        }

        /// <summary>
        /// Set_MiddleName_Fails_MiddleNameLong tests.
        /// </summary>
        [Fact]
        public void Set_MiddleName_Fails_MiddleNameLong()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).MiddleName == null);

            Assert.Throws<ArgumentException>("MiddleName", () => (((IPerson)person).MiddleName = c_veryLongName));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).MiddleName == null);
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
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).LastName == null);

            ((IPerson)person).LastName = lastName;

            Assert.True(person.Modified == true);
            Assert.True(((IPerson)person).LastName == lastName);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameNull tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameNull()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IPerson)person).LastName = null));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameEmpty tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameEmpty()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IPerson)person).LastName = string.Empty));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameWhitespace()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IPerson)person).LastName = "      "));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).LastName == null);
        }

        /// <summary>
        /// Set_LastName_Fails_LastNameLong tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Fails_LastNameLong()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).LastName == null);

            Assert.Throws<ArgumentException>("LastName", () => (((IPerson)person).LastName = c_veryLongName));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).LastName == null);
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
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Suffix == null);

            ((IPerson)person).Suffix = suffix;

            Assert.True(person.Modified == true);
            Assert.True(((IPerson)person).Suffix == suffix);
        }

        /// <summary>
        /// Set_Suffix_Fails_SuffixLong tests.
        /// </summary>
        [Fact]
        public void Set_Suffix_Fails_SuffixLong()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Suffix == null);

            Assert.Throws<ArgumentException>("Suffix", () => (((IPerson)person).Suffix = c_veryLongPrefix));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Suffix == null);
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
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Login == null);

            ((IPerson)person).Login = login;

            Assert.True(person.Modified == true);
            Assert.True(((IPerson)person).Login == login);
        }

        /// <summary>
        /// Set_Login_Fails_LoginNull tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginNull()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IPerson)person).Login = null));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Login == null);
        }

        /// <summary>
        /// Set_Login_Fails_LoginEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginEmpty()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IPerson)person).Login = string.Empty));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Login == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginWhitespace()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IPerson)person).Login = "      "));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Login == null);
        }

        /// <summary>
        /// Set_FirstName_Fails_FirstNameLong tests.
        /// </summary>
        [Fact]
        public void Set_Login_Fails_LoginLong()
        {
            // Arrange.

            // Act and assert.
            TestPerson person = new TestPerson();
            Assert.NotNull(person);

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Login == null);

            Assert.Throws<ArgumentException>("Login", () => (((IPerson)person).Login = c_veryLongLogin));

            Assert.True(person.Modified == false);
            Assert.True(((IPerson)person).Login == null);
        }
    }
}
