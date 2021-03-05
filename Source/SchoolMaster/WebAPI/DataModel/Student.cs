namespace SchoolMaster.WebAPI.DataModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Student class implementation.
    /// </summary>
    public sealed class Student : Person, IStudent
    {
        private readonly int m_id;

        private int m_gradeLevel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        public Student()
            : base(Role.Student)
        {
            m_id = -1;
            m_gradeLevel = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="id">Unique id for this administrator in the database.</param>
        /// <param name="gradeLevel">Grade level.</param>
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
        public Student(int id,
                       int gradeLevel,
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
            : base(personId, Role.Student, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers)
        {
            if (id < 1)
            {
                throw new ArgumentException("The id must be greater than zero.", nameof(id));
            }

            ValidateGradeLevel(gradeLevel);

            m_id = id;
            m_gradeLevel = gradeLevel;
        }

        /// <summary>
        /// Validate grade level.
        /// </summary>
        /// <param name="gradeLevel">Grade level to be validated.</param>
        public static void ValidateGradeLevel(int gradeLevel)
        {
            if (gradeLevel < 0)
            {
                throw new ArgumentException("GradeLevel must be zero or greater.", nameof(gradeLevel));
            }
        }

        /// <summary>
        /// Gets the database unique identifier for this administrator.
        /// </summary>
        /// <remarks>This should be "internal", but that prevents the unit tests from working.</remarks>
        public int StudentId
        {
            get
            {
                return m_id;
            }
        }

        /// <inheritdoc/>
        int IStudent.GradeLevel
        {
            get
            {
                return m_gradeLevel;
            }

            set
            {
                ValidateGradeLevel(value);

                Modified = true;
                m_gradeLevel = value;
            }
        }

        #region Implementation for Person Wrappers

        /// <inheritdoc/>
        string IStudent.Prefix
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
        string IStudent.FirstName
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
        string IStudent.MiddleName
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
        string IStudent.LastName
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
        string IStudent.Suffix
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
        string IStudent.Login
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
        DateTime IStudent.LastLoginDate
        {
            get
            {
                return LastLoginDate;
            }
        }

        /// <inheritdoc/>
        DateTime IStudent.LastPasswordChangedDate
        {
            get
            {
                return LastPasswordChangedDate;
            }
        }

        /// <inheritdoc/>
        DateTime IStudent.CreatedDate
        {
            get
            {
                return CreatedDate;
            }
        }

        /// <inheritdoc/>
        Email IStudent.Email
        {
            get
            {
                return Email;
            }
        }

        /// <inheritdoc/>
        IEnumerable<Address> IStudent.Addresses
        {
            get
            {
                return Addresses;
            }
        }

        /// <inheritdoc/>
        IEnumerable<Phone> IStudent.PhoneNumbers
        {
            get
            {
                return PhoneNumbers;
            }
        }

        /// <inheritdoc/>
        bool IStudent.SetPassword(string password)
        {
            return SetPassword(password);
        }

        #endregion Implementation for Person Wrappers
    }
}
