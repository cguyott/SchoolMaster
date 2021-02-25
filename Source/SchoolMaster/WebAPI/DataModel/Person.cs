namespace SchoolMaster.WebAPI.DataModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Person class implementation.
    /// </summary>
    /// <remarks>This should be internal but we need to make it public so our unit tests can access it.</remarks>
    public abstract class Person
    {
        private readonly int m_id;
        private readonly Role m_role;
        private readonly DateTime m_lastLoginDate;
        private readonly DateTime m_lastPasswordChangedDate;
        private readonly DateTime m_createdDate;
        private readonly Email m_email;
        private readonly IEnumerable<Address> m_addresses;
        private readonly IEnumerable<Phone> m_phoneNumbers;

        private bool m_modified;
        private string m_prefix;
        private string m_firstName;
        private string m_middleName;
        private string m_lastName;
        private string m_suffix;
        private string m_login;
        private string m_passwordHash;
        private string m_passwordSalt;

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        private Person()
        {
            m_id = -1;
            m_role = Role.Unknown;
            m_lastLoginDate = DateTime.MinValue;
            m_lastPasswordChangedDate = DateTime.MinValue;
            m_createdDate = DateTime.MinValue;

            m_modified = false;
            m_prefix = null;
            m_firstName = null;
            m_middleName = null;
            m_lastName = null;
            m_suffix = null;
            m_login = null;
            m_passwordHash = null;
            m_passwordSalt = null;

            m_email = new Email();
            m_addresses = new List<Address>();
            m_phoneNumbers = new List<Phone>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="role">Role.</param>
        public Person(Role role)
            : this()
        {
            m_role = role;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        ///
        /// Internal changed to public to allow for unit testing.
        /// </summary>
        /// <param name="personId">Unique id for this address in the database.</param>
        /// <param name="role">Role.</param>
        /// <param name="lastLoginDate">Last login date.</param>
        /// <param name="lastPasswordChangedDate">Last password changed date.</param>
        /// <param name="createdDate">Created date.</param>
        /// <param name="prefix">Prefix.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="middleName">Middle name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="suffix">Suffix.</param>
        /// <param name="login">Login.</param>
        /// <param name="passwordHash">Password hash.</param>
        /// <param name="passwordSalt">Password salt.</param>
        /// <param name="email">Email.</param>
        /// <param name="addresses">Collection of addresses.</param>
        /// <param name="phoneNumbers">Collection of phone numbers.</param>
        public Person(int personId,
                      Role role,
                      DateTime lastLoginDate,
                      DateTime lastPasswordChangedDate,
                      DateTime createdDate,
                      string prefix,
                      string firstName,
                      string middleName,
                      string lastName,
                      string suffix,
                      string login,
                      string passwordHash,
                      string passwordSalt,
                      Email email,
                      List<Address> addresses,
                      List<Phone> phoneNumbers)
        {
            m_email = email ?? throw new ArgumentNullException(nameof(email));
            m_addresses = addresses ?? throw new ArgumentNullException(nameof(addresses));
            m_phoneNumbers = phoneNumbers ?? throw new ArgumentNullException(nameof(phoneNumbers));

            if (personId < 1)
            {
                throw new ArgumentException("The id must be greater than zero.", nameof(personId));
            }

            if ((role == Role.Unknown) || (role == Role.Unused))
            {
                throw new ArgumentException("A valid role must be specified.", nameof(role));
            }

            ValidatePrefix(prefix);
            ValidateFirstName(firstName);
            ValidateMiddleName(middleName);
            ValidateLastName(lastName);
            ValidateSuffix(suffix);
            ValidateLogin(login);
            ValidatePasswordHash(passwordHash);
            ValidatePasswordSalt(passwordSalt);

            m_id = personId;
            m_role = role;
            m_lastLoginDate = lastLoginDate;
            m_lastPasswordChangedDate = lastPasswordChangedDate;
            m_createdDate = createdDate;

            m_modified = false;
            m_prefix = prefix;
            m_firstName = firstName;
            m_middleName = middleName;
            m_lastName = lastName;
            m_suffix = suffix;
            m_login = login;
            m_passwordHash = passwordHash;
            m_passwordSalt = passwordSalt;
        }

        /// <summary>
        /// Validate prefix.
        /// </summary>
        /// <param name="prefix">Prefix to be validated.</param>
        /// <returns>Updated prefix.</returns>
        public static string ValidatePrefix(string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix))
            {
                prefix = null;
            }
            else if (prefix.Length > 6)
            {
                throw new ArgumentException("Prefix cannot be greater than 6 characters.", "Prefix");
            }

            return prefix;
        }

        /// <summary>
        /// Validate first name.
        /// </summary>
        /// <param name="firstName">First name to be validated.</param>
        public static void ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name must be specified.", "FirstName");
            }

            if (firstName.Length > 50)
            {
                throw new ArgumentException("First name cannot be greater than 50 characters.", "FirstName");
            }
        }

        /// <summary>
        /// Validate middle name.
        /// </summary>
        /// <param name="middleName">Middle name to be validated.</param>
        /// <returns>Updated middle name.</returns>
        public static string ValidateMiddleName(string middleName)
        {
            if (string.IsNullOrWhiteSpace(middleName))
            {
                middleName = null;
            }
            else if (middleName.Length > 50)
            {
                throw new ArgumentException("Middle name cannot be greater than 50 characters.", "MiddleName");
            }

            return middleName;
        }

        /// <summary>
        /// Validate last name.
        /// </summary>
        /// <param name="lastName">Last name to be validated.</param>
        public static void ValidateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("First name must be specified.", "LastName");
            }

            if (lastName.Length > 50)
            {
                throw new ArgumentException("Last name cannot be greater than 50 characters.", "LastName");
            }
        }

        /// <summary>
        /// Validate suffix.
        /// </summary>
        /// <param name="suffix">Suffix to be validated.</param>
        /// <returns>Updated suffix.</returns>
        public static string ValidateSuffix(string suffix)
        {
            if (string.IsNullOrWhiteSpace(suffix))
            {
                suffix = null;
            }
            else if (suffix.Length > 6)
            {
                throw new ArgumentException("Suffix cannot be greater than 6 characters.", "Suffix");
            }

            return suffix;
        }

        /// <summary>
        /// Validate login.
        /// </summary>
        /// <param name="login">Login to be validated.</param>
        public static void ValidateLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException("Login must be specified.", "Login");
            }

            if (login.Length > 64)
            {
                throw new ArgumentException("Login cannot be greater than 64 characters.", "Login");
            }
        }

        /// <summary>
        /// Validate password hash.
        /// </summary>
        /// <param name="passwordHash">Password hash to be validated.</param>
        public static void ValidatePasswordHash(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException("Password hash must be specified.", "PasswordHash");
            }

            if (passwordHash.Length > 30)
            {
                throw new ArgumentException("Password hash cannot be greater than 30 characters.", "PasswordHash");
            }
        }

        /// <summary>
        /// Validate password salt.
        /// </summary>
        /// <param name="paswordSalt">Password salt to be validated.</param>
        public static void ValidatePasswordSalt(string paswordSalt)
        {
            if (string.IsNullOrWhiteSpace(paswordSalt))
            {
                throw new ArgumentException("Password salt must be specified.", "PasswordSalt");
            }

            if (paswordSalt.Length > 30)
            {
                throw new ArgumentException("Password salt cannot be greater than 30 characters.", "PasswordSalt");
            }
        }

        /// <summary>
        /// Gets the database unique identifier for this address.
        /// </summary>
        public int PersonId
        {
            get
            {
                return m_id;
            }
        }

        /// <summary>
        /// Gets the underlying role for this person instance.
        /// </summary>
        public Role Role
        {
            get
            {
                return m_role;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not this object has been modified.
        /// </summary>
        public bool Modified
        {
            get
            {
                return m_modified;
            }

            set
            {
                m_modified = value;
            }
        }

        /// <summary>
        /// Gets or sets Prefix.
        /// </summary>
        /// <remarks>Cannot exceed 6 characters in length.</remarks>
        public string Prefix
        {
            get
            {
                return m_prefix;
            }

            set
            {
                ValidatePrefix(value);

                m_modified = true;
                m_prefix = value;
            }
        }

        /// <summary>
        /// Gets or sets FirstName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        public string FirstName
        {
            get
            {
                return m_firstName;
            }

            set
            {
                ValidateFirstName(value);

                m_modified = true;
                m_firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets MiddleName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        public string MiddleName
        {
            get
            {
                return m_middleName;
            }

            set
            {
                ValidateMiddleName(value);

                m_modified = true;
                m_middleName = value;
            }
        }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        public string LastName
        {
            get
            {
                return m_lastName;
            }

            set
            {
                ValidateLastName(value);

                m_modified = true;
                m_lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets Suffix.
        /// </summary>
        /// <remarks>Cannot exceed 6 characters in length.</remarks>
        public string Suffix
        {
            get
            {
                return m_suffix;
            }

            set
            {
                ValidateSuffix(value);

                m_modified = true;
                m_suffix = value;
            }
        }

        /// <summary>
        /// Gets or sets Login.
        /// </summary>
        /// <remarks>Cannot exceed 64 characters in length.</remarks>
        public string Login
        {
            get
            {
                return m_login;
            }

            set
            {
                ValidateLogin(value);

                m_modified = true;
                m_login = value;
            }
        }

        /// <summary>
        /// Gets lastLoginDate.
        /// </summary>
        public DateTime LastLoginDate
        {
            get
            {
                return m_lastLoginDate;
            }
        }

        /// <summary>
        /// Gets lastPasswordChangedDate.
        /// </summary>
        public DateTime LastPasswordChangedDate
        {
            get
            {
                return m_lastPasswordChangedDate;
            }
        }

        /// <summary>
        /// Gets createdDate.
        /// </summary>
        public DateTime CreatedDate
        {
            get
            {
                return m_createdDate;
            }
        }

        /// <summary>
        /// Gets email.
        /// </summary>
        public Email Email
        {
            get
            {
                return m_email;
            }
        }

        /// <summary>
        /// Gets addresses.
        /// </summary>
        public IEnumerable<Address> Addresses
        {
            get
            {
                return m_addresses;
            }
        }

        /// <summary>
        /// Gets phone numbers.
        /// </summary>
        public IEnumerable<Phone> PhoneNumbers
        {
            get
            {
                return m_phoneNumbers;
            }
        }

        /// <summary>
        /// Sets or updates the password.
        /// </summary>
        /// <param name="password">Password.</param>
        /// <returns>"true" if successfully set; "false" otherwise.</returns>
        public bool SetPassword(string password)
        {
            // to do

            if (string.IsNullOrWhiteSpace(password) == false)
            {
                if (m_passwordHash == null)
                {
                    m_passwordHash = "string1";
                }

                if (m_passwordSalt == null)
                {
                    m_passwordSalt = "string2";
                }
            }

            return true;
        }
    }
}
