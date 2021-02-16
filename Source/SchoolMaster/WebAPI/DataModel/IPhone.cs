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
        /// <remarks>Must be exactly 3 digits.</remarks>
        string AreaCode { get; set; }

        /// <summary>
        /// Gets or sets exchange code.
        /// </summary>
        /// <remarks>Must be exactly 3 digits.</remarks>
        string ExchangeCode { get; set; }

        /// <summary>
        /// Gets or sets subscriber number.
        /// </summary>
        /// <remarks>Must be exactly 4 digits.</remarks>
        string SubscriberNumber { get; set; }

        /// <summary>
        /// Gets or sets contact order.
        /// </summary>
        int ContactOrder { get; set; }
    }
}
