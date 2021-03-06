﻿namespace SchoolMaster.WebAPI.DataModel
{
    /// <summary>
    /// Address class interface definition.
    /// </summary>
    public interface IAddress
    {
        /// <summary>
        /// Gets or sets Address1.
        /// </summary>
        /// <remarks>Cannot exceed 95 characters in length. Cannot be null, empty string, or whitespace.</remarks>
        string Address1 { get; set; }

        /// <summary>
        /// Gets or sets Address2.
        /// </summary>
        /// <remarks>Cannot exceed 95 characters in length. Can be null. Cannot be empty string or whitespace. Attempting to set this property to whitespace or an empty string will set it to null.</remarks>
        string Address2 { get; set; }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        /// <remarks>Cannot exceed 50 characters in length.</remarks>
        string City { get; set; }

        /// <summary>
        /// Gets or sets State.
        /// </summary>
        /// <remarks>Must be exactly 2 characters.</remarks>
        string State { get; set; }

        /// <summary>
        /// Gets or sets Zip.
        /// </summary>
        /// <remarks>Must be either 5 characters (#####) or 10 characters (#####-####).</remarks>
        string Zip { get; set; }
    }
}
