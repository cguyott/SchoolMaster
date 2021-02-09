namespace SchoolMaster.WebAPI.DataModel
{
    using System;

    /// <summary>
    /// Administrator class implementation.
    /// </summary>
    public class Administrator : Person, IPerson, IAdministrator
    {
        private readonly int m_id;

        private bool m_modified;
        private string m_department;
        private string m_position;

        /// <summary>
        /// Initializes a new instance of the <see cref="Administrator"/> class.
        /// </summary>
        public Administrator()
        {
            m_id = -1;
            m_modified = false;
            m_department = null;
            m_position = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Administrator"/> class.
        /// </summary>
        /// <param name="id">Unique id for this administrator in the database.</param>
        /// <param name="department">Department.</param>
        /// <param name="position">Position.</param>
        public Administrator(int id, string department, string position)
        {
            if (id < 1)
            {
                throw new ArgumentException("The id must be greater than zero.", nameof(id));
            }

            ValidateDepartment(department);
            ValidatePosition(position);

            m_id = id;
            m_modified = false;
            m_department = department;
            m_position = position;
        }

        private void ValidateDepartment(string department)
        {
            if (string.IsNullOrWhiteSpace(department))
            {
                throw new ArgumentException("Department must be specified.", "Department");
            }

            if (department.Length > 128)
            {
                throw new ArgumentException("Address1 cannot be greater than 128 characters.", "Department");
            }
        }

        private void ValidatePosition(string position)
        {
            if (string.IsNullOrWhiteSpace(position))
            {
                throw new ArgumentException("Department must be specified.", "Position");
            }

            if (position.Length > 128)
            {
                throw new ArgumentException("Address1 cannot be greater than 128 characters.", "Position");
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

        /// <summary>
        /// Gets a value indicating whether or not this address has been modified.
        /// </summary>
        /// <remarks>This should be "internal", but that prevents the unit tests from working.</remarks>
        public bool AdminModified
        {
            get
            {
                return m_modified;
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

                m_modified = true;
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

                m_modified = true;
                m_position = value;
            }
        }

        #region Implementation for IPerson Wrappers

        /// <inheritdoc/>
        string IAdministrator.Prefix
        {
            get
            {
                return ((IPerson)this).Prefix;
            }

            set
            {
                m_modified = true;
                ((IPerson)this).Prefix = value;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.FirstName
        {
            get
            {
                return ((IPerson)this).FirstName;
            }

            set
            {
                m_modified = true;
                ((IPerson)this).Prefix = value;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.MiddleName
        {
            get
            {
                return ((IPerson)this).MiddleName;
            }

            set
            {
                m_modified = true;
                ((IPerson)this).MiddleName = value;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.LastName
        {
            get
            {
                return ((IPerson)this).LastName;
            }

            set
            {
                m_modified = true;
                ((IPerson)this).LastName = value;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.Suffix
        {
            get
            {
                return ((IPerson)this).Suffix;
            }

            set
            {
                m_modified = true;
                ((IPerson)this).Suffix = value;
            }
        }

        /// <inheritdoc/>
        string IAdministrator.Login
        {
            get
            {
                return ((IPerson)this).Login;
            }

            set
            {
                m_modified = true;
                ((IPerson)this).Login = value;
            }
        }

        /// <inheritdoc/>
        DateTime IAdministrator.LastLoginDate
        {
            get
            {
                return ((IPerson)this).LastLoginDate;
            }
        }

        /// <inheritdoc/>
        DateTime IAdministrator.LastPasswordChangedDate
        {
            get
            {
                return ((IPerson)this).LastPasswordChangedDate;
            }
        }

        /// <inheritdoc/>
        DateTime IAdministrator.CreatedDate
        {
            get
            {
                return ((IPerson)this).CreatedDate;
            }
        }

        /// <inheritdoc/>
        bool IAdministrator.SetPassword(string password)
        {
            return ((IPerson)this).SetPassword(password);
        }
        #endregion Implementation for IPerson Wrappers
    }
}
