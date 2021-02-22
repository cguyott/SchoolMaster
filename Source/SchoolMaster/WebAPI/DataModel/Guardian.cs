namespace SchoolMaster.WebAPI.DataModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Guardian class implementation.
    /// </summary>
    public class Guardian : Person, IGuardian
    {
        private readonly int m_id;

        private int m_contactOrder;

        /// <summary>
        /// Initializes a new instance of the <see cref="Guardian"/> class.
        /// </summary>
        public Guardian()
            : base(Role.Guardian)
        {
            m_id = -1;
            m_contactOrder = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guardian"/> class.
        /// </summary>
        /// <param name="id">Unique id for this Guardian in the database.</param>
        /// <param name="contactOrder">Contact order.</param>
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
        public Guardian(int id,
                        int contactOrder,
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
            : base(personId, Role.Guardian, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt, email, addresses, phoneNumbers)
        {
            if (id < 1)
            {
                throw new ArgumentException("The id must be greater than zero.", nameof(id));
            }

            ValidateContactOrder(contactOrder);

            m_id = id;
            m_contactOrder = contactOrder;
        }

        private void ValidateContactOrder(int contactOrder)
        {
            if (contactOrder < 1)
            {
                throw new ArgumentException("Contact order must be greater than zero.", "ContactOrder");
            }
        }

        /// <summary>
        /// Gets the database unique identifier for this Guardian.
        /// </summary>
        /// <remarks>This should be "internal", but that prevents the unit tests from working.</remarks>
        public int GuardianId
        {
            get
            {
                return m_id;
            }
        }

        /// <inheritdoc/>
        int IGuardian.ContactOrder
        {
            get
            {
                return m_contactOrder;
            }

            set
            {
                ValidateContactOrder(value);

                Modified = true;
                m_contactOrder = value;
            }
        }

        #region Implementation for IPerson Wrappers

        /// <inheritdoc/>
        string IGuardian.Prefix
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
        string IGuardian.FirstName
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
        string IGuardian.MiddleName
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
        string IGuardian.LastName
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
        string IGuardian.Suffix
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
        string IGuardian.Login
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
        DateTime IGuardian.LastLoginDate
        {
            get
            {
                return LastLoginDate;
            }
        }

        /// <inheritdoc/>
        DateTime IGuardian.LastPasswordChangedDate
        {
            get
            {
                return LastPasswordChangedDate;
            }
        }

        /// <inheritdoc/>
        DateTime IGuardian.CreatedDate
        {
            get
            {
                return CreatedDate;
            }
        }

        /// <inheritdoc/>
        Email IGuardian.Email
        {
            get
            {
                return Email;
            }
        }

        /// <inheritdoc/>
        IEnumerable<Address> IGuardian.Addresses
        {
            get
            {
                return Addresses;
            }
        }

        /// <inheritdoc/>
        IEnumerable<Phone> IGuardian.PhoneNumbers
        {
            get
            {
                return PhoneNumbers;
            }
        }

        /// <inheritdoc/>
        bool IGuardian.SetPassword(string password)
        {
            return SetPassword(password);
        }
        #endregion Implementation for IPerson Wrappers
    }
}
