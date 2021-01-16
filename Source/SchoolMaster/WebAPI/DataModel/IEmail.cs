namespace SchoolMaster.WebAPI.DataModel
{
    /// <summary>
    /// Phone class interface definition.
    /// </summary>
    public interface IEmail
    {
        /// <summary>
        /// Gets or sets email.
        /// </summary>
        /// <remarks>Cannot exceed 256 characters in length.</remarks>
        string Email { get; set; }
    }
}