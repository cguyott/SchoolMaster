namespace SchoolMaster.WebAPI.DataModel
{
    using System;

    /// <summary>
    /// Address class implementation.
    /// </summary>
    public class Address : IAddress
    {
        private readonly int m_id;

        private bool m_modified;
        private string m_address1;
        private string m_address2;
        private string m_city;
        private string m_state;
        private string m_zip;

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        {
            m_id = -1;
            m_modified = false;
            m_address1 = null;
            m_address2 = null;
            m_city = null;
            m_state = null;
            m_zip = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="id">Unique id for this address in the database.</param>
        /// <param name="address1">Address 1.</param>
        /// <param name="address2">Address 2.</param>
        /// <param name="city">City.</param>
        /// <param name="state">State.</param>
        /// <param name="zip">Zip.</param>
        public Address(int id,
                       string address1,
                       string address2,
                       string city,
                       string state,
                       string zip)
        {
            if (id < 1)
            {
                throw new ArgumentException("The id must be greater than zero.", nameof(id));
            }

            ValidateAddress1(address1);
            address2 = ValidateAddress2(address2);
            ValidateCity(city);
            ValidateState(state);
            ValidateZip(zip);

            m_id = id;
            m_modified = false;
            m_address1 = address1;
            m_address2 = address2;
            m_city = city;
            m_state = state;
            m_zip = zip;
        }

        private void ValidateAddress1(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address1 must be specified.", "Address1");
            }

            if (address.Length > 95)
            {
                throw new ArgumentException("Address1 cannot be greater than 95 characters.", "Address1");
            }
        }

        private string ValidateAddress2(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                address = null;
            }
            else if (address.Length > 95)
            {
                throw new ArgumentException("Address2 cannot be greater than 95 characters.", "Address2");
            }

            return address;
        }

        private void ValidateCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City must be specified.", "City");
            }

            if (city.Length > 50)
            {
                throw new ArgumentException("City cannot be greater than 50 characters.", "City");
            }
        }

        private void ValidateState(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                throw new ArgumentException("State must be specified.", "State");
            }

            if (state.Length != 2)
            {
                throw new ArgumentException("State must be 2 characters.", "State");
            }
        }

        private void ValidateZip(string zip)
        {
            if (string.IsNullOrWhiteSpace(zip))
            {
                throw new ArgumentException("A zip code must be specified.", "Zip");
            }

            if (zip.Length != 5 && zip.Length != 10)
            {
                throw new ArgumentException("The zip code must be five or ten characters.", "Zip");
            }

            if ((zip.Length == 5) && (int.TryParse(zip, out int _) == false))
            {
                throw new ArgumentException("The 5 character zip code must be numeric.", "Zip");
            }
            else if (zip[5] != '-')
            {
                throw new ArgumentException("The sixth character in the zip code must be a hyphen.", "Zip");
            }
            else
            {
                string tmp = zip.Replace('-', '0');

                if (int.TryParse(tmp, out int _) == false)
                {
                    throw new ArgumentException("The 10 character zip code must be numeric except for the hyphen.", "Zip");
                }
            }
        }

        /// <summary>
        /// Gets the database unique identifier for this address.
        /// </summary>
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
        public bool Modified
        {
            get
            {
                return m_modified;
            }
        }

        /// <inheritdoc/>
        string IAddress.Address1
        {
            get
            {
                return m_address1;
            }

            set
            {
                ValidateAddress1(value);

                m_modified = true;
                m_address1 = value;
            }
        }

        /// <inheritdoc/>
        string IAddress.Address2
        {
            get
            {
                return m_address2;
            }

            set
            {
                value = ValidateAddress2(value);

                m_modified = true;
                m_address2 = value;
            }
        }

        /// <inheritdoc/>
        string IAddress.City
        {
            get
            {
                return m_city;
            }

            set
            {
                ValidateCity(value);

                m_modified = true;
                m_city = value;
            }
        }

        /// <inheritdoc/>
        string IAddress.State
        {
            get
            {
                return m_state;
            }

            set
            {
                ValidateState(value);

                m_modified = true;
                m_state = value;
            }
        }

        /// <inheritdoc/>
        string IAddress.Zip
        {
            get
            {
                return m_zip;
            }

            set
            {
                ValidateZip(value);

                m_modified = true;
                m_zip = value;
            }
        }
    }
}
