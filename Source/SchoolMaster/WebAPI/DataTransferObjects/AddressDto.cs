namespace SchoolMaster.WebAPI.DataTransferObjects
{
    /// <summary>
    /// Address data transfer object.
    /// </summary>
    public class AddressDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressDto"/> class.
        /// </summary>
        public AddressDto()
        {
            Address1 = null;
            Address2 = null;
            City = null;
            State = null;
            Zip = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressDto"/> class.
        /// </summary>
        /// <param name="address1">Address 1.</param>
        /// <param name="address2">Address 2.</param>
        /// <param name="city">City.</param>
        /// <param name="state">State.</param>
        /// <param name="zip">Zip.</param>
        public AddressDto(string address1,
                          string address2,
                          string city,
                          string state,
                          string zip)
        {
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zip;
        }

        /// <summary>
        /// Gets Address1.
        /// </summary>
        /// <remarks>Cannot exceed 95 characters in length. Cannot be null, empty string, or whitespace.</remarks>
        public string Address1 { get; init; }

        /// <summary>
        /// Gets Address2.
        /// </summary>
        /// <remarks>Cannot exceed 95 characters in length. Can be null. Cannot be empty string or whitespace. Attempting to set this property to whitespace or an empty string will set it to null.</remarks>
        public string Address2 { get; init; }

        /// <summary>
        /// Gets City.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        public string City { get; init; }

        /// <summary>
        /// Gets State.
        /// </summary>
        /// <remarks>Must be exactly 2 characters.</remarks>
        public string State { get; init; }

        /// <summary>
        /// Gets Zip.
        /// </summary>
        /// <remarks>Must be either 5 characters (#####) or 10 characters (#####-####).</remarks>
        public string Zip { get; init; }
    }
}
