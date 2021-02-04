namespace SchoolMaster.WebAPI.Tests.DataModelTests
{
    using System;
    using SchoolMaster.WebAPI.DataModel;

    /// <summary>
    /// Class for testing Person.
    /// </summary>
    public class TestPerson : Person, IPerson
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestPerson"/> class.
        /// </summary>
        public TestPerson()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestPerson"/> class.
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
        public TestPerson(int id,
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
            : base(id, role, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, passwordHash, passwordSalt)
        {
        }
    }
}
