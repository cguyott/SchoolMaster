namespace SchoolMaster.WebAPI.DataTransferObjects
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Administrator data transfer object.
    /// </summary>
    public class InstructorRequestDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstructorRequestDto"/> class.
        /// </summary>
        public InstructorRequestDto()
        {
            Department = null;
            Position = null;
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
        /// Initializes a new instance of the <see cref="InstructorRequestDto"/> class.
        /// </summary>
        /// <param name="department">Department.</param>
        /// <param name="position">Position.</param>
        /// <param name="prefix">Prefix.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="middleName">Middle name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="suffix">Suffix.</param>
        /// <param name="login">Login.</param>
        /// <param name="email">Email.</param>
        /// <param name="addresses">Collection of addresses.</param>
        /// <param name="phoneNumbers">Collection of phone numbers.</param>
        public InstructorRequestDto(string department,
                                       string position,
                                       string prefix,
                                       string firstName,
                                       string middleName,
                                       string lastName,
                                       string suffix,
                                       string login,
                                       string email,
                                       IEnumerable<AddressDto> addresses,
                                       IEnumerable<PhoneDto> phoneNumbers)
        {
            Department = department;
            Position = position;
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
        /// Gets Department.
        /// </summary>
        /// <remarks>Cannot exceed 128 characters in length. Cannot be null, empty string, or whitespace.</remarks>
        public string Department { get; init; }

        /// <summary>
        /// Gets Position.
        /// </summary>
        /// <remarks>Cannot exceed 128 characters in length. Cannot be null, empty string, or whitespace.</remarks>
        public string Position { get; init; }

        /// <summary>
        /// Gets Prefix.
        /// </summary>
        /// <remarks>Cannot exceed 6 characters in length.</remarks>
        public string Prefix { get; init; }

        /// <summary>
        /// Gets FirstName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        public string FirstName { get; init; }

        /// <summary>
        /// Gets MiddleName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        public string MiddleName { get; init; }

        /// <summary>
        /// Gets LastName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        public string LastName { get; init; }

        /// <summary>
        /// Gets Suffix.
        /// </summary>
        /// <remarks>Cannot exceed 6 characters in length.</remarks>
        public string Suffix { get; init; }

        /// <summary>
        /// Gets Login.
        /// </summary>
        /// <remarks>Cannot exceed 64 characters in length.</remarks>
        public string Login { get; init; }

        /// <summary>
        /// Gets Email.
        /// </summary>
        /// <remarks>Cannot exceed 256 characters in length.</remarks>
        public string Email { get; init; }

        /// <summary>
        /// Gets Addresses.
        /// </summary>
        public IEnumerable<AddressDto> Addresses { get; init; }

        /// <summary>
        /// Gets PhoneNumbers.
        /// </summary>
        public IEnumerable<PhoneDto> PhoneNumbers { get; init; }
    }
}
