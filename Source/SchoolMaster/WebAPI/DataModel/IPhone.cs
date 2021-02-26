namespace SchoolMaster.WebAPI.DataModel
{
    /// <summary>
    /// Phone class interface definition.
    /// </summary>
    public interface IPhone
    {
        /// <summary>
        /// Gets or sets AreaCode.
        /// </summary>
        /// <remarks>Must be exactly 3 digits.</remarks>
        string AreaCode { get; set; }

        /// <summary>
        /// Gets or sets ExchangeCode.
        /// </summary>
        /// <remarks>Must be exactly 3 digits.</remarks>
        string ExchangeCode { get; set; }

        /// <summary>
        /// Gets or sets SubscriberNumber.
        /// </summary>
        /// <remarks>Must be exactly 4 digits.</remarks>
        string SubscriberNumber { get; set; }

        /// <summary>
        /// Gets or sets ContactOrder.
        /// </summary>
        int ContactOrder { get; set; }
    }
}
