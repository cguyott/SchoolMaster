namespace SchoolMaster.WebAPI.DataModel
{
    /// <summary>
    /// Return codes used by internal methods within SchoolMaster.
    /// </summary>
    public enum ErrorStatus
    {
        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined = -1,

        /// <summary>
        /// Succeeded.
        /// </summary>
        Succeeded,

        /// <summary>
        /// Failed.
        /// </summary>
        Failed,
    }
}
