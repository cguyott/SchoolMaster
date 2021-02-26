namespace SchoolMaster.WebAPI.DataAccess
{
    using System;
    using System.Data;

    /// <summary>
    /// Generic methods for accessing SQL data.
    /// </summary>
    public static class DataAccessHelper
    {
        /// <summary>
        /// Gets a string from the specified database row.
        /// </summary>
        /// <param name="dataRecord">Database row to access.</param>
        /// <param name="index">Column index to access.</param>
        /// <param name="defaultValue">The value to use is the database value is null.</param>
        /// <returns>A string.</returns>
        public static string GetStringFromCurrentRow(IDataRecord dataRecord,
                                                     int index,
                                                     string defaultValue = null)
        {
            if (dataRecord.IsDBNull(index))
            {
                return defaultValue;
            }

            return dataRecord.GetString(index);
        }

        /// <summary>
        /// Gets an integer from the specified database row.
        /// </summary>
        /// <param name="dataRecord">Database row to access.</param>
        /// <param name="index">Column index to access.</param>
        /// <param name="defaultValue">The value to use is the database value is null.</param>
        /// <returns>An integer.</returns>
        public static int GetInt32FromCurrentRow(IDataRecord dataRecord,
                                                 int index,
                                                 int defaultValue)
        {
            if (dataRecord.IsDBNull(index))
            {
                return defaultValue;
            }

            return dataRecord.GetInt32(index);
        }

        /// <summary>
        /// Gets a DateTime from the specified database row.
        /// </summary>
        /// <param name="dataRecord">Database row to access.</param>
        /// <param name="index">Column index to access.</param>
        /// <param name="defaultValue">The value to use is the database value is null.</param>
        /// <returns>A DateTime.</returns>
        public static DateTime GetDateTimeFromCurrentRow(IDataRecord dataRecord,
                                                         int index,
                                                         DateTime defaultValue)
        {
            if (dataRecord.IsDBNull(index))
            {
                return defaultValue;
            }

            return dataRecord.GetDateTime(index);
        }
    }
}
