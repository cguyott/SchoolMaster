namespace SchoolMaster.WebAPI.DataModel
{
    using System;

    /// <summary>
    /// Email class implementation.
    /// </summary>
    public class Email : IEmail
    {
        private readonly int m_id;

        private bool m_modified;
        private string m_email;

        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        public Email()
        {
            m_id = -1;
            m_modified = false;
            m_email = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="id">Unique id for this email in the database.</param>
        /// /// <param name="email">Email.</param>
        public Email(int id, string email)
        {
            if (id < 1)
            {
                throw new ArgumentException("The id must be greater than zero.", nameof(id));
            }

            ValidateEmail(email);

            m_id = id;
            m_modified = false;
            m_email = email;
        }

        /// <summary>
        /// Validate an email address.
        /// </summary>
        /// <param name="email">Email address to validate.</param>
        public static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("An email must be specified.", "Email");
            }

            if (email.Length > 256)
            {
                throw new ArgumentException("The email cannot be greater than 256 characters", "Email");
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
        string IEmail.Email
        {
            get
            {
                return m_email;
            }

            set
            {
                ValidateEmail(value);

                m_modified = true;
                m_email = value;
            }
        }
    }
}
