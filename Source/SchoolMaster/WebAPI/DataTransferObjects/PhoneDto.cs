namespace SchoolMaster.WebAPI.DataTransferObjects
{
    /// <summary>
    /// Phone data transfer object.
    /// </summary>
    public class PhoneDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneDto"/> class.
        /// </summary>
        public PhoneDto()
        {
            AreaCode = null;
            ExchangeCode = null;
            SubscriberNumber = null;
            ContactOrder = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneDto"/> class.
        /// </summary>
        /// <param name="areaCode">Three digit area code.</param>
        /// <param name="exchangeCode">Three digit exchange code.</param>
        /// <param name="subscriberNumber">Four digit subscriber number.</param>
        /// <param name="contactOrder">Contact order.</param>
        /// <remarks>A phone number is defined as "aaa-eee-ssss", where "aaa" is the area code, "eee" is the exchange code, and "ssss" is the subscriber number.</remarks>
        public PhoneDto(string areaCode,
                        string exchangeCode,
                        string subscriberNumber,
                        int contactOrder)
        {
            AreaCode = areaCode;
            ExchangeCode = exchangeCode;
            SubscriberNumber = subscriberNumber;
            ContactOrder = contactOrder;
        }

        /// <summary>
        /// Gets AreaCode.
        /// </summary>
        /// <remarks>Must be exactly 3 digits.</remarks>
        public string AreaCode { get; init; }

        /// <summary>
        /// Gets ExchangeCode.
        /// </summary>
        /// <remarks>Must be exactly 3 digits.</remarks>
        public string ExchangeCode { get; init; }

        /// <summary>
        /// Gets SubscriberNumber.
        /// </summary>
        /// <remarks>Must be exactly 4 digits.</remarks>
        public string SubscriberNumber { get; init; }

        /// <summary>
        /// Gets ContactOrder.
        /// </summary>
        public int ContactOrder { get; init; }
    }
}
