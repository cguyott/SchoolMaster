namespace SchoolMaster.WebAPI.DataModel
{
    using System;

    /// <summary>
    /// Person class interface definition.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Gets or sets Prefix.
        /// </summary>
        /// <remarks>Cannot exceed 6 characters in length.</remarks>
        string Prefix { get; set; }

        /// <summary>
        /// Gets or sets FirstName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets MiddleName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets Suffix.
        /// </summary>
        /// <remarks>Cannot exceed 6 characters in length.</remarks>
        string Suffix { get; set; }

        /// <summary>
        /// Gets or sets Login.
        /// </summary>
        /// <remarks>Cannot exceed 64 characters in length.</remarks>
        string Login { get; set; }

        /// <summary>
        /// Gets lastLoginDate.
        /// </summary>
        DateTime LastLoginDate { get; }

        /// <summary>
        /// Gets lastPasswordChangedDate.
        /// </summary>
        DateTime LastPasswordChangedDate { get; }

        /// <summary>
        /// Gets createdDate.
        /// </summary>
        DateTime CreatedDate { get; }

        /// <summary>
        /// Sets or updates the password.
        /// </summary>
        /// <param name="password">Password.</param>
        /// <returns>"true" if successfully set; "false" otherwise.</returns>
        bool SetPassword(string password);
    }
}
