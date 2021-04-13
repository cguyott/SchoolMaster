namespace SchoolMaster.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using SchoolMaster.WebAPI.DataAccess;
    using SchoolMaster.WebAPI.DataTransferObjects;

    /// <summary>
    /// Handles HTTP requests to support CRUD operations on the Administrator class.
    /// </summary>
    [CLSCompliant(false)]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly ILogger<AdministratorController> m_logger;
        private readonly ILogger<DataAccess> m_dataAccessLogger;
        private readonly IConfiguration m_configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministratorController"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="dataAccessLogger">Data Access Logger.</param>
        /// <param name="configuration">Configuration.</param>
        public AdministratorController(ILogger<AdministratorController> logger,
                                       ILogger<DataAccess> dataAccessLogger,
                                       IConfiguration configuration)
        {
            m_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            m_dataAccessLogger = dataAccessLogger ?? throw new ArgumentNullException(nameof(dataAccessLogger));
            m_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Retrieves the detailed information for the specified administrator.
        /// </summary>
        /// <param name="adminId">The id of the administrator who's detailed information has been requested.</param>
        /// <returns>An instance of the AdministratorDto class.</returns>
        [HttpGet]
        [Route("api/v1/Administrator/ById")]
        [ProducesResponseType(typeof(AdministratorResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AdministratorResponseDto>> GetAdministrator([FromQuery] int adminId)
        {
            if (adminId < 1)
            {
                string errorMessage = "AdminId cannot be less than 1.";
                m_logger.LogError("AdministratorController.GetAdministrator: " + errorMessage);
                return StatusCode(StatusCodes.Status400BadRequest, errorMessage);
            }

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter parameter = new SqlParameter("AdminId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = adminId,
                };
                parameters.Add(parameter);

                string sqlConnection = m_configuration.GetValue<string>("SQL:connectString");
                using IDataAccess dataAccess = new DataAccess(m_dataAccessLogger, sqlConnection);
                using IDataReader results = await dataAccess.ExecuteQueryAsync("GetAdministrator", parameters).ConfigureAwait(false);

                IEnumerable<PhoneDto> phoneDtos = PhoneDtoHelper.GetPhoneDtos(results);
                results.NextResult();

                IEnumerable<AddressDto> addressDtos = AddressDtoHelper.GetAddressDtos(results);
                results.NextResult();

                AdministratorResponseDto administratorDto = AdministratorDtoHelper.GetAdministratorDto(results, phoneDtos, addressDtos);
                results.Close();

                // This is a stupid hack because IDataReader does not have an implementation of "HasRows".
                if (administratorDto == null)
                {
                    string errorMessage = "Specified AdminId not found.";
                    m_logger.LogError("AdministratorController.GetAdministrator: " + errorMessage);
                    return StatusCode(StatusCodes.Status404NotFound, errorMessage);
                }

                return new JsonResult(administratorDto);
            }
            catch (SqlException sqlException)
            {
                m_logger.LogError("AdministratorController.GetAdministrator: " + sqlException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, sqlException.Message);
            }
        }

        /// <summary>
        /// Retrieves the detailed information for the specified administrator.
        /// </summary>
        /// <param name="adminLogin">The login of the administrator who's detailed information has been requested.</param>
        /// <returns>An instance of the AdministratorDto class.</returns>
        [HttpGet]
        [Route("api/v1/Administrator/ByLogin")]
        [ProducesResponseType(typeof(AdministratorResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AdministratorResponseDto>> GetAdministratorByLogin([FromQuery] string adminLogin)
        {
            if (string.IsNullOrWhiteSpace(adminLogin))
            {
                string errorMessage = "A valid AdminLogin must be specified.";
                m_logger.LogError("AdministratorController.GetAdministratorByLogin: " + errorMessage);
                return StatusCode(StatusCodes.Status400BadRequest, errorMessage);
            }

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter parameter = new SqlParameter("AdminLogin", SqlDbType.NVarChar, 64)
                {
                    Direction = ParameterDirection.Input,
                    Value = adminLogin,
                };
                parameters.Add(parameter);

                string sqlConnection = m_configuration.GetValue<string>("SQL:connectString");
                using IDataAccess dataAccess = new DataAccess(m_dataAccessLogger, sqlConnection);
                using IDataReader results = await dataAccess.ExecuteQueryAsync("GetAdministratorByLogin", parameters).ConfigureAwait(false);

                IEnumerable<PhoneDto> phoneDtos = PhoneDtoHelper.GetPhoneDtos(results);
                results.NextResult();

                IEnumerable<AddressDto> addressDtos = AddressDtoHelper.GetAddressDtos(results);
                results.NextResult();

                AdministratorResponseDto administratorDto = AdministratorDtoHelper.GetAdministratorDto(results, phoneDtos, addressDtos);
                results.Close();

                // This is a stupid hack because IDataReader does not have an implementation of "HasRows".
                if (administratorDto == null)
                {
                    string errorMessage = "Specified AdminLogin not found.";
                    m_logger.LogError("AdministratorController.GetAdministratorByLogin: " + errorMessage);
                    return StatusCode(StatusCodes.Status404NotFound, errorMessage);
                }

                return new JsonResult(administratorDto);
            }
            catch (SqlException sqlException)
            {
                m_logger.LogError("AdministratorController.GetAdministratorByLogin: " + sqlException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, sqlException.Message);
            }
        }

        /// <summary>
        /// Deletes the specified administrator and all related data.
        /// </summary>
        /// <param name="adminId">The id of the administrator who will be deleted.</param>
        /// <returns>An HTTP 200 success status code.</returns>
        /// <remarks>This operation cannot be undone.</remarks>
        [HttpDelete]
        [Route("api/v1/Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAdministrator([FromQuery] int adminId)
        {
            if (adminId < 1)
            {
                string errorMessage = "AdminId cannot be less than 1.";
                m_logger.LogError("AdministratorController.DeleteAdministrator: " + errorMessage);
                return StatusCode(StatusCodes.Status400BadRequest, errorMessage);
            }

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter parameter = new SqlParameter("AdminId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = adminId,
                };
                parameters.Add(parameter);

                parameter = new SqlParameter("Results", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output,
                };
                parameters.Add(parameter);

                int resultsIndex = parameters.Count - 1;

                string sqlConnection = m_configuration.GetValue<string>("SQL:connectString");
                using IDataAccess dataAccess = new DataAccess(m_dataAccessLogger, sqlConnection);
                _ = await dataAccess.ExecuteCommandAsync("DeleteAdministrator", parameters).ConfigureAwait(false);

                int results = (int)(parameters[resultsIndex].Value);

                switch (results)
                {
                    case 0:
                        m_logger.LogError("AdministratorController.DeleteAdministrator: Requested administrator successfully deleted.");
                        return StatusCode(StatusCodes.Status200OK);
                    case 1:
                        m_logger.LogError("AdministratorController.DeleteAdministrator: Requested administrator not found.");
                        return StatusCode(StatusCodes.Status404NotFound);
                    default:
                        m_logger.LogError("AdministratorController.DeleteAdministrator: Unexpected status was returned from the database.");
                        return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected status returned from the database.");
                }
            }
            catch (SqlException sqlException)
            {
                m_logger.LogError("AdministratorController.DeleteAdministrator: " + sqlException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, sqlException.Message);
            }
        }

        /// <summary>
        /// Creates the specified administrator and all related data.
        /// </summary>
        /// <param name="newAdmin">The data related to the administrator to be created.</param>
        /// <returns>An HTTP 200 success status code.</returns>
        /// <remarks>This operation cannot be undone.</remarks>
        [HttpPost]
        [Route("api/v1/Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<int>> CreateAdministrator([FromBody] AdministratorRequestDto newAdmin)
        {
            if (newAdmin == null)
            {
                string errorMessage = "Administrator data is not valid.";
                m_logger.LogError("AdministratorController.CreateAdministrator: " + errorMessage);
                return StatusCode(StatusCodes.Status400BadRequest, errorMessage);
            }

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                ControllerHelpers.SetPersonSqlParameters(parameters,
                                                         newAdmin.Prefix,
                                                         newAdmin.FirstName,
                                                         newAdmin.MiddleName,
                                                         newAdmin.LastName,
                                                         newAdmin.Suffix,
                                                         newAdmin.Login,
                                                         newAdmin.Email,
                                                         newAdmin.Addresses,
                                                         newAdmin.PhoneNumbers);

                if (string.IsNullOrWhiteSpace(newAdmin.Department))
                {
                    throw new ArgumentException("Department cannot be null, empty, or whitespace.");
                }

                SqlParameter parameter = new SqlParameter("Department", SqlDbType.NVarChar, 128)
                {
                    Direction = ParameterDirection.Input,
                    Value = newAdmin.Department,
                };
                parameters.Add(parameter);

                if (string.IsNullOrWhiteSpace(newAdmin.Position))
                {
                    throw new ArgumentException("Position cannot be null, empty, or whitespace.");
                }

                parameter = new SqlParameter("Position", SqlDbType.NVarChar, 128)
                {
                    Direction = ParameterDirection.Input,
                    Value = newAdmin.Position,
                };
                parameters.Add(parameter);

                parameter = new SqlParameter("AdministratorId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output,
                };
                parameters.Add(parameter);

                int administratorIdIndex = parameters.Count - 1;

                parameter = new SqlParameter("Results", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output,
                };
                parameters.Add(parameter);

                int resultsIndex = parameters.Count - 1;

                string sqlConnection = m_configuration.GetValue<string>("SQL:connectString");
                using IDataAccess dataAccess = new DataAccess(m_dataAccessLogger, sqlConnection);
                _ = await dataAccess.ExecuteQueryAsync("CreateAdministrator", parameters).ConfigureAwait(false);

                int administratorId = (int)(parameters[administratorIdIndex].Value);
                int results = (int)(parameters[resultsIndex].Value);

                switch (results)
                {
                    case 0:
                        m_logger.LogError("AdministratorController.CreateAdministrator: Requested administrator successfully created.");
                        return new JsonResult(administratorId); // Returns a StatusCodes.Status200OK.
                    case 1:
                        m_logger.LogError("AdministratorController.CreateAdministrator: Requested administrator already exists.");
                        return StatusCode(StatusCodes.Status409Conflict);
                    default:
                        m_logger.LogError("AdministratorController.CreateAdministrator: Unexpected status was returned from the database.");
                        return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected status returned from the database.");
                }
            }
            catch (ArgumentException argExeption)
            {
                m_logger.LogError("AdministratorController.CreateAdministrator: " + argExeption.Message);
                return StatusCode(StatusCodes.Status400BadRequest, argExeption.Message);
            }
            catch (SqlException sqlException)
            {
                m_logger.LogError("AdministratorController.CreateAdministrator: " + sqlException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, sqlException.Message);
            }
        }

        /// <summary>
        /// Updates the specified administrator and all related data.
        /// </summary>
        /// <param name="adminId">adminId.</param>
        /// <param name="updatedAdmin">The data related to the administrator to be updated.</param>
        /// <returns>An HTTP 200 success status code.</returns>
        /// <remarks>This operation cannot be undone.</remarks>
        [HttpPut]
        [Route("api/v1/Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAdministrator([FromQuery] int adminId, [FromBody] AdministratorRequestDto updatedAdmin)
        {
            if (adminId < 1)
            {
                string errorMessage = "AdminId must be greater than zero.";
                m_logger.LogError("AdministratorController.UpdateAdministrator: " + errorMessage);
                return StatusCode(StatusCodes.Status400BadRequest, errorMessage);
            }

            if (updatedAdmin == null)
            {
                string errorMessage = "Administrator data is not specified.";
                m_logger.LogError("AdministratorController.UpdateAdministrator: " + errorMessage);
                return StatusCode(StatusCodes.Status400BadRequest, errorMessage);
            }

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                SqlParameter parameter = new SqlParameter("AdministratorId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = adminId,
                };
                parameters.Add(parameter);

                ControllerHelpers.SetPersonSqlParameters(parameters,
                                                         updatedAdmin.Prefix,
                                                         updatedAdmin.FirstName,
                                                         updatedAdmin.MiddleName,
                                                         updatedAdmin.LastName,
                                                         updatedAdmin.Suffix,
                                                         updatedAdmin.Login,
                                                         updatedAdmin.Email,
                                                         updatedAdmin.Addresses,
                                                         updatedAdmin.PhoneNumbers);

                if (string.IsNullOrWhiteSpace(updatedAdmin.Department))
                {
                    throw new ArgumentException("Department cannot be null, empty, or whitespace.");
                }

                parameter = new SqlParameter("Department", SqlDbType.NVarChar, 128)
                {
                    Direction = ParameterDirection.Input,
                    Value = updatedAdmin.Department,
                };
                parameters.Add(parameter);

                if (string.IsNullOrWhiteSpace(updatedAdmin.Position))
                {
                    throw new ArgumentException("Position cannot be null, empty, or whitespace.");
                }

                parameter = new SqlParameter("Position", SqlDbType.NVarChar, 128)
                {
                    Direction = ParameterDirection.Input,
                    Value = updatedAdmin.Position,
                };
                parameters.Add(parameter);

                parameter = new SqlParameter("Results", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output,
                };
                parameters.Add(parameter);

                int resultsIndex = parameters.Count - 1;

                string sqlConnection = m_configuration.GetValue<string>("SQL:connectString");
                using IDataAccess dataAccess = new DataAccess(m_dataAccessLogger, sqlConnection);
                _ = await dataAccess.ExecuteQueryAsync("UpdateAdministrator", parameters).ConfigureAwait(false);

                int results = (int)(parameters[resultsIndex].Value);

                switch (results)
                {
                    case 0:
                        m_logger.LogError("AdministratorController.UpdateAdministrator: Requested administrator successfully updated.");
                        return StatusCode(StatusCodes.Status200OK);
                    case 1:
                        m_logger.LogError("AdministratorController.UpdateAdministrator: Requested administrator does not exist.");
                        return StatusCode(StatusCodes.Status404NotFound);
                    default:
                        m_logger.LogError("AdministratorController.UpdateAdministrator: Unexpected status was returned from the database.");
                        return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected status returned from the database.");
                }
            }
            catch (ArgumentException argExeption)
            {
                m_logger.LogError("AdministratorController.UpdateAdministrator: " + argExeption.Message);
                return StatusCode(StatusCodes.Status400BadRequest, argExeption.Message);
            }
            catch (SqlException sqlException)
            {
                m_logger.LogError("AdministratorController.UpdateAdministrator: " + sqlException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, sqlException.Message);
            }
        }
    }
}
