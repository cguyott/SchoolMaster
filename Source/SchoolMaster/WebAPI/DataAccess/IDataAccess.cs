namespace SchoolMaster.WebAPI.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    /// <summary>
    /// Data Access Interface.
    /// </summary>
    public interface IDataAccess : IDisposable
    {
        /// <summary>
        ///   Synchronously executes a stored procedure.
        /// </summary>
        /// <param name="procedure">
        ///   The stored procedure.
        /// </param>
        /// <param name="parameters">
        ///   The stored procedure parameters.
        /// </param>
        /// <returns>An IDataReader for accessing the returned data.</returns>
        IDataReader ExecuteQuery(string procedure, IEnumerable<IDataParameter> parameters);

        /// <summary>
        ///   Asynchronously executes a stored procedure.
        /// </summary>
        /// <param name="procedure">
        ///   The stored procedure.
        /// </param>
        /// <param name="parameters">
        ///   The stored procedure parameters.
        /// </param>
        /// <returns>A Task containing an IDataReader for accessing the returned data.</returns>
        Task<IDataReader> ExecuteQueryAsync(string procedure, IEnumerable<IDataParameter> parameters);

        /// <summary>
        /// Synchronously executes a stored procedure and returns a value if appropriate.
        /// </summary>
        /// <param name="procedure">
        /// The name of the stored procedure to execute.
        /// </param>
        /// <param name="parameters">
        /// A collection instance that supports ICollection and contains IDataParameter objects.
        /// </param>
        /// <returns>An object.</returns>
        int ExecuteCommand(string procedure, IEnumerable<IDataParameter> parameters);

        /// <summary>
        /// Asynchronously executes a stored procedure and returns a value if appropriate.
        /// </summary>
        /// <param name="procedure">
        /// The name of the stored procedure to execute.
        /// </param>
        /// <param name="parameters">
        /// A collection instance that supports ICollection and contains IDataParameter objects.
        /// </param>
        /// <returns>An object.</returns>
        Task<int> ExecuteCommandAsync(string procedure, IEnumerable<IDataParameter> parameters);
    }
}
