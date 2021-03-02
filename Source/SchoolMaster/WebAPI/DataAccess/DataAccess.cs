namespace SchoolMaster.WebAPI.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// IDataAccess implementation for interacting with a Microsoft SQL Server database.
    /// </summary>
    public sealed class DataAccess : IDataAccess
    {
        private readonly ILogger<DataAccess> m_logger;
        private readonly string m_sqlConnectionString;
        private readonly IDataAccess m_thisAsIDataAccess;

        private SqlConnection m_sqlConnection;
        private SqlCommand m_sqlCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccess"/> class.
        /// </summary>
        /// <param name="logger"> The logger. </param>
        /// <param name="sqlConnectionString"> The SQL connection string. </param>
        public DataAccess(ILogger<DataAccess> logger,
                          string sqlConnectionString)
        {
            m_logger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                throw new ArgumentException("Argument cannot be null, whitespace, or the empty string.", nameof(sqlConnectionString));
            }

            m_sqlConnectionString = sqlConnectionString;

            m_thisAsIDataAccess = this;
        }

        /// <inheritdoc/>
        IDataReader IDataAccess.ExecuteQuery(string procedure,
                                             IEnumerable<IDataParameter> parameters)
        {
            return AsyncHelper.RunSync(() => m_thisAsIDataAccess.ExecuteQueryAsync(procedure, parameters));
        }

        /// <inheritdoc/>
        async Task<IDataReader> IDataAccess.ExecuteQueryAsync(string procedure,
                                                              IEnumerable<IDataParameter> parameters)
        {
            if (procedure == null)
            {
                throw new ArgumentNullException(nameof(procedure));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            SqlDataReader reader;
            List<IDataParameter> sqlParameters = parameters.ToList();

            try
            {
                await InitializeCommandAsync(procedure, sqlParameters).ConfigureAwait(false);

                m_logger.LogDebug($"DataAccess - IDataAccess.ExecuteQueryAsync executed stored procedure '{procedure}' with {sqlParameters.Count} parameters. Command text '{m_sqlCommand.CommandText}'.");

                reader = await m_sqlCommand.ExecuteReaderAsync(CommandBehavior.Default).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                m_logger.LogError(exception, "DataAccess - IDataAccess.ExecuteQueryAsync");
                throw;
            }

            return reader;
        }

        /// <inheritdoc/>
        object IDataAccess.ExecuteCommand(string procedure,
                                          IEnumerable<IDataParameter> parameters)
        {
            return AsyncHelper.RunSync(() => m_thisAsIDataAccess.ExecuteCommandAsync(procedure, parameters));
        }

        /// <inheritdoc/>
        async Task<object> IDataAccess.ExecuteCommandAsync(string procedure,
                                                           IEnumerable<IDataParameter> parameters)
        {
            if (procedure == null)
            {
                throw new ArgumentNullException(nameof(procedure));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            List<IDataParameter> sqlParameters = parameters.ToList();
            int numberOfRowsAffected;

            try
            {
                await InitializeCommandAsync(procedure, sqlParameters).ConfigureAwait(false);

                m_logger.LogDebug($"DataAccess - IDataAccess.ExecuteCommandAsync executed stored procedure '{procedure}' with {sqlParameters.Count} parameters. Command text '{m_sqlCommand.CommandText}'.");

                numberOfRowsAffected = await m_sqlCommand.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                m_logger.LogError(exception, "DataAccess - IDataAccess.ExecuteCommandAsync");
                throw;
            }

            return numberOfRowsAffected;
        }

        private async Task InitializeCommandAsync(string procedure,
                                                  IEnumerable<IDataParameter> parameters)
        {
            ClearSqlCommandAndConnection();

            m_sqlConnection = new SqlConnection
            {
                ConnectionString = m_sqlConnectionString,
            };

            await m_sqlConnection.OpenAsync().ConfigureAwait(false);

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            m_sqlCommand = new SqlCommand(procedure, m_sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities

            foreach (var parameter in parameters)
            {
                m_sqlCommand.Parameters.Add(parameter);
            }
        }

        private void ClearSqlCommandAndConnection()
        {
            if (m_sqlCommand != null)
            {
                // Be sure the command is not running.
                m_sqlCommand.Cancel();

                // Since we need to add the parameters to the command, and if they were already added
                // to the command previously, we have to remove them in order to be able to recreate the
                // command a subsequent time...
                int parameterCount = m_sqlCommand.Parameters.Count;

                for (int i = parameterCount - 1; i >= 0; i--)
                {
                    m_sqlCommand.Parameters.RemoveAt(i);
                }

                m_sqlCommand.Dispose();
                m_sqlCommand = null;
            }

            if (m_sqlConnection != null)
            {
                // Be sure that the connection is closed.
                if (m_sqlConnection.State != ConnectionState.Closed)
                {
                    m_sqlConnection.Close();
                }

                m_sqlConnection.Dispose();
                m_sqlConnection = null;
            }
        }

        #region IDisposable Support

        /// <summary>
        /// Detects redundant calls.
        /// </summary>
        private bool m_disposed;

        /// <summary>
        /// Dispose method implementation.
        /// </summary>
        /// <param name="disposing">Indicates where we are being called from.</param>
        private void Dispose(bool disposing)
        {
            if (m_disposed == false)
            {
                if (disposing)
                {
                    DisposeSqlObjects();
                }

                m_disposed = true;
            }
        }

        private void DisposeSqlObjects()
        {
            m_sqlCommand?.Dispose();
            m_sqlConnection?.Dispose();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support

    }
}