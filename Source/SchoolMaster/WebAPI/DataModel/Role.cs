namespace SchoolMaster.WebAPI.DataModel
{
    /// <summary>
    /// Role enumeration.
    /// </summary>
    /// <remarks>The values assigned to each member are specified in the SchoolMaster database. Do not change these values.</remarks>
    public enum Role
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Unused.
        /// </summary>
        Unused = 0,

        /// <summary>
        /// Administrator.
        /// </summary>
        Administrator = 1,

        /// <summary>
        /// Instructor.
        /// </summary>
        Instructor = 2,

        /// <summary>
        /// Student.
        /// </summary>
        Student = 3,

        /// <summary>
        /// Guardian.
        /// </summary>
        Guardian = 4,
    }
}
