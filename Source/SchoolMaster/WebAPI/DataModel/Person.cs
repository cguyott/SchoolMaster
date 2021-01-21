namespace SchoolMaster.WebAPI.DataModel
{
    using System;

    /// <summary>
    /// Person class implementation.
    /// </summary>
    public abstract class Person : IPerson
    {
        private readonly int m_id;
        private readonly Role m_role;
        private readonly DateTime m_lastLoginDate;
        private readonly DateTime m_lastPasswordChangedDate;
        private readonly DateTime m_createdDate;

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
        public Person()
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
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="id">Unique id for this address in the database.</param>
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
        internal Person(int id,
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
                        string passwordSalt)
        {
            if (id < 1)
            {
                throw new ArgumentException("The id must be greater than zero.", nameof(id));
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

            m_id = id;
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

        private string ValidatePrefix(string prefix)
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

        private void ValidateFirstName(string firstName)
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

        private string ValidateMiddleName(string middleName)
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

        private void ValidateLastName(string lastName)
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

        private string ValidateSuffix(string suffix)
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

        private void ValidateLogin(string login)
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

        private void ValidatePasswordHash(string passwordHash)
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

        private void ValidatePasswordSalt(string paswordSalt)
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
        /// <remarks>This should be "internal", but that prevents the unit tests from working.</remarks>
        public int Id
        {
            get
            {
                return m_id;
            }
        }

        /// <summary>
        /// Gets the underlying role for this person instance.
        /// </summary>
        /// <remarks>This should be "internal", but that prevents the unit tests from working.</remarks>
        public Role Role
        {
            get
            {
                return m_role;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not this address has been modified.
        /// </summary>
        /// <remarks>This should be "internal", but that prevents the unit tests from working.</remarks>
        public bool Modified
        {
            get
            {
                return m_modified;
            }
        }

        /// <inheritdoc/>
        string IPerson.Prefix
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

        /// <inheritdoc/>
        string IPerson.FirstName
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

        /// <inheritdoc/>
        string IPerson.MiddleName
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

        /// <inheritdoc/>
        string IPerson.LastName
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

        /// <inheritdoc/>
        string IPerson.Suffix
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

        /// <inheritdoc/>
        string IPerson.Login
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

        /// <inheritdoc/>
        DateTime IPerson.LastLoginDate
        {
            get
            {
                return m_lastLoginDate;
            }
        }

        /// <inheritdoc/>
        DateTime IPerson.LastPasswordChangedDate
        {
            get
            {
                return m_lastPasswordChangedDate;
            }
        }

        /// <inheritdoc/>
        DateTime IPerson.CreatedDate
        {
            get
            {
                return m_createdDate;
            }
        }

        /// <inheritdoc/>
        bool IPerson.SetPassword(string password)
        {
            // to do

            if (m_passwordHash == null)
            {
                m_passwordHash = "string1";
            }

            if (m_passwordSalt == null)
            {
                m_passwordSalt = "string2";
            }

            return true;
        }
    }
}
