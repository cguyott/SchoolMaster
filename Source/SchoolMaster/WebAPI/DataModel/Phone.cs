namespace SchoolMaster.WebAPI.DataModel
{
    using System;

    /// <summary>
    /// Phone class implementation.
    /// </summary>
    public sealed class Phone : IPhone
    {
        private readonly int m_id;

        private bool m_modified;
        private string m_areaCode;
        private string m_exchangeCode;
        private string m_subscriberNumber;
        private int m_contactOrder;

        /// <summary>
        /// Initializes a new instance of the <see cref="Phone"/> class.
        /// </summary>
        public Phone()
        {
            m_id = -1;
            m_modified = false;
            m_areaCode = null;
            m_exchangeCode = null;
            m_subscriberNumber = null;
            m_contactOrder = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Phone"/> class.
        /// </summary>
        /// <param name="id">Unique id for this phone number in the database.</param>
        /// <param name="areaCode">Three digit area code.</param>
        /// <param name="exchangeCode">Three digit exchange code.</param>
        /// <param name="subscriberNumber">Four digit subscriber number.</param>
        /// <param name="contactOrder">Contact order.</param>
        /// <remarks>A phone number is defined as "aaa-eee-ssss", where "aaa" is the area code, "eee" is the exchange code, and "ssss" is the subscriber number.</remarks>
        public Phone(int id,
                     string areaCode,
                     string exchangeCode,
                     string subscriberNumber,
                     int contactOrder)
        {
            if (id < 1)
            {
                throw new ArgumentException("The id must be greater than zero.", nameof(id));
            }

            ValidateAreaCode(areaCode);
            ValidateExchangeCode(exchangeCode);
            ValidateSubscriberNumber(subscriberNumber);

            m_id = id;
            m_modified = false;
            m_areaCode = areaCode;
            m_exchangeCode = exchangeCode;
            m_subscriberNumber = subscriberNumber;
            m_contactOrder = contactOrder;
        }

        /// <summary>
        /// Validate area code.
        /// </summary>
        /// <param name="areaCode">Area code to be validated.</param>
        public static void ValidateAreaCode(string areaCode)
        {
            if (string.IsNullOrWhiteSpace(areaCode))
            {
                throw new ArgumentException("A three digit area code must be specified.", nameof(areaCode));
            }

            if (areaCode.Length != 3)
            {
                throw new ArgumentException("The area code must be three digits.", nameof(areaCode));
            }

            if (int.TryParse(areaCode, out int _) == false)
            {
                throw new ArgumentException("The area code must be numeric.", nameof(areaCode));
            }
        }

        /// <summary>
        /// Validate exchange code.
        /// </summary>
        /// <param name="exchangeCode">Exchange code to be validated.</param>
        public static void ValidateExchangeCode(string exchangeCode)
        {
            if (string.IsNullOrWhiteSpace(exchangeCode))
            {
                throw new ArgumentException("A three digit exchange code must be specified.", nameof(exchangeCode));
            }

            if (exchangeCode.Length != 3)
            {
                throw new ArgumentException("The exchange code must be three digits.", nameof(exchangeCode));
            }

            if (int.TryParse(exchangeCode, out int _) == false)
            {
                throw new ArgumentException("The exchange code must be numeric.", nameof(exchangeCode));
            }
        }

        /// <summary>
        /// Validate subscriber number.
        /// </summary>
        /// <param name="subscriberNumber">Subscriber number to be validated.</param>
        public static void ValidateSubscriberNumber(string subscriberNumber)
        {
            if (string.IsNullOrWhiteSpace(subscriberNumber))
            {
                throw new ArgumentException("A four digit subscriber number must be specified.", nameof(subscriberNumber));
            }

            if (subscriberNumber.Length != 4)
            {
                throw new ArgumentException("The subscriber number must be four digits.", nameof(subscriberNumber));
            }

            if (int.TryParse(subscriberNumber, out int _) == false)
            {
                throw new ArgumentException("The subscriber number must be numeric.", nameof(subscriberNumber));
            }
        }

        /// <summary>
        /// Gets the database unique identifier for this phone.
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
        /// Gets a value indicating whether or not this phone has been modified.
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
        string IPhone.AreaCode
        {
            get
            {
                return m_areaCode;
            }

            set
            {
                ValidateAreaCode(value);

                m_modified = true;
                m_areaCode = value;
            }
        }

        /// <inheritdoc/>
        string IPhone.ExchangeCode
        {
            get
            {
                return m_exchangeCode;
            }

            set
            {
                ValidateExchangeCode(value);

                m_modified = true;
                m_exchangeCode = value;
            }
        }

        /// <inheritdoc/>
        string IPhone.SubscriberNumber
        {
            get
            {
                return m_subscriberNumber;
            }

            set
            {
                ValidateSubscriberNumber(value);

                m_modified = true;
                m_subscriberNumber = value;
            }
        }

        /// <inheritdoc/>
        int IPhone.ContactOrder
        {
            get
            {
                return m_contactOrder;
            }

            set
            {
                m_modified = true;
                m_contactOrder = value;
            }
        }
    }
}
