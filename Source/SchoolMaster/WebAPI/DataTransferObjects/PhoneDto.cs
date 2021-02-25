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
        /// Gets or sets AreaCode.
        /// </summary>
        /// <remarks>Must be exactly 3 digits.</remarks>
        public string AreaCode { get; set; }

        /// <summary>
        /// Gets or sets ExchangeCode.
        /// </summary>
        /// <remarks>Must be exactly 3 digits.</remarks>
        public string ExchangeCode { get; set; }

        /// <summary>
        /// Gets or sets SubscriberNumber.
        /// </summary>
        /// <remarks>Must be exactly 4 digits.</remarks>
        public string SubscriberNumber { get; set; }

        /// <summary>
        /// Gets or sets ContactOrder.
        /// </summary>
        public int ContactOrder { get; set; }
    }
}
