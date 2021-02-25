namespace SchoolMaster.WebAPI.DataTransferObjects
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Administrator data transfer object.
    /// </summary>
    public class AdministratorDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdministratorDto"/> class.
        /// </summary>
        public AdministratorDto()
        {
            Id = -1;
            Department = null;
            Position = null;
            LastLoginDate = DateTime.MinValue;
            LastPasswordChangedDate = DateTime.MinValue;
            CreatedDate = DateTime.MinValue;
            Prefix = null;
            FirstName = null;
            MiddleName = null;
            LastName = null;
            Suffix = null;
            Login = null;
            Email = null;
            Addresses = new List<AddressDto>();
            PhoneNumbers = new List<PhoneDto>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministratorDto"/> class.
        /// </summary>
        /// <param name="id">Unique id for this administrator in the database.</param>
        /// <param name="department">Department.</param>
        /// <param name="position">Position.</param>
        /// <param name="lastLoginDate">Last login date.</param>
        /// <param name="lastPasswordChangedDate">Last password changed date.</param>
        /// <param name="createdDate">Created date.</param>
        /// <param name="prefix">Prefix.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="middleName">Middle name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="suffix">Suffix.</param>
        /// <param name="login">Login.</param>
        /// <param name="email">Email.</param>
        /// <param name="addresses">Collection of addresses.</param>
        /// <param name="phoneNumbers">Collection of phone numbers.</param>
        public AdministratorDto(int id,
                                string department,
                                string position,
                                DateTime lastLoginDate,
                                DateTime lastPasswordChangedDate,
                                DateTime createdDate,
                                string prefix,
                                string firstName,
                                string middleName,
                                string lastName,
                                string suffix,
                                string login,
                                string email,
                                List<AddressDto> addresses,
                                List<PhoneDto> phoneNumbers)
        {
            Id = id;
            Department = department;
            Position = position;
            LastLoginDate = lastLoginDate;
            LastPasswordChangedDate = lastPasswordChangedDate;
            CreatedDate = createdDate;
            Prefix = prefix;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Suffix = suffix;
            Login = login;
            Email = email;
            Addresses = addresses;
            PhoneNumbers = phoneNumbers;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Department.
        /// </summary>
        /// <remarks>Cannot exceed 128 characters in length. Cannot be null, empty string, or whitespace.</remarks>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets Position.
        /// </summary>
        /// <remarks>Cannot exceed 128 characters in length. Cannot be null, empty string, or whitespace.</remarks>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets Prefix.
        /// </summary>
        /// <remarks>Cannot exceed 6 characters in length.</remarks>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets FirstName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets MiddleName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Suffix.
        /// </summary>
        /// <remarks>Cannot exceed 6 characters in length.</remarks>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets or sets Login.
        /// </summary>
        /// <remarks>Cannot exceed 64 characters in length.</remarks>
        public string Login { get; set; }

        /// <summary>
        /// Gets LastLoginDate.
        /// </summary>
        public DateTime LastLoginDate { get; }

        /// <summary>
        /// Gets LastPasswordChangedDate.
        /// </summary>
        public DateTime LastPasswordChangedDate { get; }

        /// <summary>
        /// Gets CreatedDate.
        /// </summary>
        public DateTime CreatedDate { get; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        /// <remarks>Cannot exceed 256 characters in length.</remarks>
        public string Email { get; set; }

        /// <summary>
        /// Gets Addresses.
        /// </summary>
        public IEnumerable<AddressDto> Addresses { get; }

        /// <summary>
        /// Gets PhoneNumbers.
        /// </summary>
        public IEnumerable<PhoneDto> PhoneNumbers { get; }
    }
}
