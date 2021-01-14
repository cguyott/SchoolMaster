namespace SchoolMaster.WebAPI.DataModel
{
    /// <summary>
    /// Phone class interface definition.
    /// </summary>
    public interface IPhone
    {
        /// <summary>
        /// Gets or sets area code.
        /// </summary>
        string AreaCode { get; set; }

        /// <summary>
        /// Gets or sets exchange code.
        /// </summary>
        string ExchangeCode { get; set; }

        /// <summary>
        /// Gets or sets subscriber number.
        /// </summary>
        string SubscriberNumber { get; set; }

        /// <summary>
        /// Gets or sets contact order.
        /// </summary>
        int ContactOrder { get; set; }
    }
}
