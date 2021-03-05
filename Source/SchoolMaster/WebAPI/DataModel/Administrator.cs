namespace SchoolMaster.WebAPI.DataModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Administrator class implementation.
    /// </summary>
    public sealed class Administrator : Person, IAdministrator
    {
        private readonly int m_id;

        private string m_department;
        private string m_position;

        /// <summary>
        /// Initializes a new instance of the <see cref="Administrator"/> class.
        /// </summary>
        public Administrator()
            : base(Role.Administrator)
        {
            m_id = -1;
            m_department = null;
            m_position = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Administrator"/> class.
        /// </summary>
        /// <param name="id">Unique id for this administrator in the database.</param>
        /// <param name="department">Department.</param>
        /// <param name="position">Position.</param>
        /// <param name="personId">Unique id for this address in the database.</param>
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
        public Administrator(int id,
                             string department,
                             string position,
                             int personId,
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
            : base(personId, Role.Administrator, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers)
        {
            if (id < 1)
            {
                throw new ArgumentException("The id must be greater than zero.", nameof(id));
            }

            ValidateDepartment(department);
            ValidatePosition(position);

            m_id = id;
            m_department = department;
            m_position = position;
        }

        /// <summary>
        /// Validate department.
        /// </summary>
        /// <param name="department">Department to be validated.</param>
        public static void ValidateDepartment(string department)
        {
            if (string.IsNullOrWhiteSpace(department))
            {
                throw new ArgumentException("Department must be specified.", nameof(department));
            }

            if (department.Length > 128)
            {
                throw new ArgumentException("Department cannot be greater than 128 characters.", nameof(department));
            }
        }

        /// <summary>
        /// Validate position.
        /// </summary>
        /// <param name="position">Position to be validated.</param>
        public static void ValidatePosition(string position)
        {
            if (string.IsNullOrWhiteSpace(position))
            {
                throw new ArgumentException("Position must be specified.", nameof(position));
            }

            if (position.Length > 128)
            {
                throw new ArgumentException("Position cannot be greater than 128 characters.", nameof(position));
            }
        }

        /// <summary>
        /// Gets the database unique identifier for this administrator.
        /// </summary>
        /// <remarks>This should be "internal", but that prevents the unit tests from working.</remarks>
        public int AdminId
        {
            get
            {
                return m_id;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.Department
        {
            get
            {
                return m_department;
            }

            set
            {
                ValidateDepartment(value);

                Modified = true;
                m_department = value;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.Position
        {
            get
            {
                return m_position;
            }

            set
            {
                ValidatePosition(value);

                Modified = true;
                m_position = value;
            }
        }

        #region Implementation for Person Wrappers

        /// <inheritdoc/>
        string IAdministrator.Prefix
        {
            get
            {
                return Prefix;
            }

            set
            {
                Prefix = value;
                Modified = true;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.FirstName
        {
            get
            {
                return FirstName;
            }

            set
            {
                FirstName = value;
                Modified = true;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.MiddleName
        {
            get
            {
                return MiddleName;
            }

            set
            {
                MiddleName = value;
                Modified = true;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.LastName
        {
            get
            {
                return LastName;
            }

            set
            {
                LastName = value;
                Modified = true;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.Suffix
        {
            get
            {
                return Suffix;
            }

            set
            {
                Suffix = value;
                Modified = true;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.Login
        {
            get
            {
                return Login;
            }

            set
            {
                Login = value;
                Modified = true;
            }
        }

        /// <inheritdoc/>
        DateTime IAdministrator.LastLoginDate
        {
            get
            {
                return LastLoginDate;
            }
        }

        /// <inheritdoc/>
        DateTime IAdministrator.LastPasswordChangedDate
        {
            get
            {
                return LastPasswordChangedDate;
            }
        }

        /// <inheritdoc/>
        DateTime IAdministrator.CreatedDate
        {
            get
            {
                return CreatedDate;
            }
        }

        /// <inheritdoc/>
        Email IAdministrator.Email
        {
            get
            {
                return Email;
            }
        }

        /// <inheritdoc/>
        IEnumerable<Address> IAdministrator.Addresses
        {
            get
            {
                return Addresses;
            }
        }

        /// <inheritdoc/>
        IEnumerable<Phone> IAdministrator.PhoneNumbers
        {
            get
            {
                return PhoneNumbers;
            }
        }

        /// <inheritdoc/>
        bool IAdministrator.SetPassword(string password)
        {
            return SetPassword(password);
        }

        #endregion Implementation for Person Wrappers
    }
}
