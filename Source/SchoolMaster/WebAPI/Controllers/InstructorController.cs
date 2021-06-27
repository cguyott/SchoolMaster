namespace SchoolMaster.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using SchoolMaster.WebAPI.DataAccess;
    using SchoolMaster.WebAPI.DataTransferObjects;

    /// <summary>
    /// Handles HTTP requests to support CRUD operations on the Instructor class.
    /// </summary>
    [CLSCompliant(false)]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly ILogger<InstructorController> m_logger;
        private readonly ILogger<DataAccess> m_dataAccessLogger;
        private readonly IConfiguration m_configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="InstructorController"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="dataAccessLogger">Data Access Logger.</param>
        /// <param name="configuration">Configuration.</param>
        public InstructorController(ILogger<InstructorController> logger,
                                       ILogger<DataAccess> dataAccessLogger,
                                       IConfiguration configuration)
        {
            m_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            m_dataAccessLogger = dataAccessLogger ?? throw new ArgumentNullException(nameof(dataAccessLogger));
            m_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Deletes the specified instructor and all related data.
        /// </summary>
        /// <param name="instructorId">The id of the instructor who will be deleted.</param>
        /// <returns>An HTTP 200 success status code.</returns>
        /// <remarks>This operation cannot be undone.</remarks>
        [HttpDelete]
        [Route("api/v1/Instructor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteInstructor([FromQuery] int instructorId)
        {
            if (instructorId < 1)
            {
                string errorMessage = "InstructorId cannot be less than 1.";
                m_logger.LogError("InstructorController.DeleteInstructor: " + errorMessage);
                return StatusCode(StatusCodes.Status400BadRequest, errorMessage);
            }

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter parameter = new SqlParameter("InstructorId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = instructorId,
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
                _ = await dataAccess.ExecuteCommandAsync("DeleteInstructor", parameters).ConfigureAwait(false);

                int results = (int)(parameters[resultsIndex].Value);

                switch (results)
                {
                    case 0:
                        m_logger.LogError("InstructorController.DeleteInstructor: Requested administrator successfully deleted.");
                        return StatusCode(StatusCodes.Status200OK);
                    case 1:
                        m_logger.LogError("InstructorController.DeleteInstructor: Requested administrator not found.");
                        return StatusCode(StatusCodes.Status404NotFound);
                    default:
                        m_logger.LogError("InstructorController.DeleteInstructor: Unexpected status was returned from the database.");
                        return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected status returned from the database.");
                }
            }
            catch (SqlException sqlException)
            {
                m_logger.LogError("InstructorController.DeleteInstructor: " + sqlException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, sqlException.Message);
            }
        }

        /// <summary>
        /// Creates the specified instructor and all related data.
        /// </summary>
        /// <param name="newInstructor">The data related to the administrator to be created.</param>
        /// <returns>An HTTP 200 success status code.</returns>
        /// <remarks>This operation cannot be undone.</remarks>
        [HttpPost]
        [Route("api/v1/Instructor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<int>> CreateInstructor([FromBody] InstructorRequestDto newInstructor)
        {
            if (newInstructor == null)
            {
                string errorMessage = "Instructor data is not valid.";
                m_logger.LogError("InstructorController.CreateInstructor: " + errorMessage);
                return StatusCode(StatusCodes.Status400BadRequest, errorMessage);
            }

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                ControllerHelpers.SetPersonSqlParameters(parameters,
                                                         newInstructor.Prefix,
                                                         newInstructor.FirstName,
                                                         newInstructor.MiddleName,
                                                         newInstructor.LastName,
                                                         newInstructor.Suffix,
                                                         newInstructor.Login,
                                                         newInstructor.Email,
                                                         newInstructor.Addresses,
                                                         newInstructor.PhoneNumbers);

                if (string.IsNullOrWhiteSpace(newInstructor.Department))
                {
                    throw new ArgumentException("Department cannot be null, empty, or whitespace.");
                }

                SqlParameter parameter = new SqlParameter("Department", SqlDbType.NVarChar, 128)
                {
                    Direction = ParameterDirection.Input,
                    Value = newInstructor.Department,
                };
                parameters.Add(parameter);

                if (string.IsNullOrWhiteSpace(newInstructor.Position))
                {
                    throw new ArgumentException("Position cannot be null, empty, or whitespace.");
                }

                parameter = new SqlParameter("Position", SqlDbType.NVarChar, 128)
                {
                    Direction = ParameterDirection.Input,
                    Value = newInstructor.Position,
                };
                parameters.Add(parameter);

                parameter = new SqlParameter("InstructorId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output,
                };
                parameters.Add(parameter);

                int instructorIdIndex = parameters.Count - 1;

                parameter = new SqlParameter("Results", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output,
                };
                parameters.Add(parameter);

                int resultsIndex = parameters.Count - 1;

                string sqlConnection = m_configuration.GetValue<string>("SQL:connectString");
                using IDataAccess dataAccess = new DataAccess(m_dataAccessLogger, sqlConnection);
                _ = await dataAccess.ExecuteQueryAsync("CreateInstructor", parameters).ConfigureAwait(false);

                int administratorId = (int)(parameters[instructorIdIndex].Value);
                int results = (int)(parameters[resultsIndex].Value);

                switch (results)
                {
                    case 0:
                        m_logger.LogError("InstructorController.CreateInstructor: Requested administrator successfully created.");
                        return new JsonResult(administratorId); // Returns a StatusCodes.Status200OK.
                    case 1:
                        m_logger.LogError("InstructorController.CreateInstructor: Requested administrator already exists.");
                        return StatusCode(StatusCodes.Status409Conflict);
                    default:
                        m_logger.LogError("InstructorController.CreateInstructor: Unexpected status was returned from the database.");
                        return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected status returned from the database.");
                }
            }
            catch (ArgumentException argExeption)
            {
                m_logger.LogError("InstructorController.CreateInstructor: " + argExeption.Message);
                return StatusCode(StatusCodes.Status400BadRequest, argExeption.Message);
            }
            catch (SqlException sqlException)
            {
                m_logger.LogError("InstructorController.CreateInstructor: " + sqlException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, sqlException.Message);
            }
        }

        /// <summary>
        /// Updates the specified instructor and all related data.
        /// </summary>
        /// <param name="instructorId">instructorId.</param>
        /// <param name="updatedInstructor">The data related to the instructor to be updated.</param>
        /// <returns>An HTTP 200 success status code.</returns>
        /// <remarks>This operation cannot be undone.</remarks>
        [HttpPut]
        [Route("api/v1/Instructor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateInstructor([FromQuery] int instructorId, [FromBody] InstructorRequestDto updatedInstructor)
        {
            if (instructorId < 1)
            {
                string errorMessage = "InstructorId must be greater than zero.";
                m_logger.LogError("InstructorController.UpdateInstructor: " + errorMessage);
                return StatusCode(StatusCodes.Status400BadRequest, errorMessage);
            }

            if (updatedInstructor == null)
            {
                string errorMessage = "Instructor data is not specified.";
                m_logger.LogError("InstructorController.UpdateInstructor: " + errorMessage);
                return StatusCode(StatusCodes.Status400BadRequest, errorMessage);
            }

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                SqlParameter parameter = new SqlParameter("InstructorId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = instructorId,
                };
                parameters.Add(parameter);

                ControllerHelpers.SetPersonSqlParameters(parameters,
                                                         updatedInstructor.Prefix,
                                                         updatedInstructor.FirstName,
                                                         updatedInstructor.MiddleName,
                                                         updatedInstructor.LastName,
                                                         updatedInstructor.Suffix,
                                                         updatedInstructor.Login,
                                                         updatedInstructor.Email,
                                                         updatedInstructor.Addresses,
                                                         updatedInstructor.PhoneNumbers);

                if (string.IsNullOrWhiteSpace(updatedInstructor.Department))
                {
                    throw new ArgumentException("Department cannot be null, empty, or whitespace.");
                }

                parameter = new SqlParameter("Department", SqlDbType.NVarChar, 128)
                {
                    Direction = ParameterDirection.Input,
                    Value = updatedInstructor.Department,
                };
                parameters.Add(parameter);

                if (string.IsNullOrWhiteSpace(updatedInstructor.Position))
                {
                    throw new ArgumentException("Position cannot be null, empty, or whitespace.");
                }

                parameter = new SqlParameter("Position", SqlDbType.NVarChar, 128)
                {
                    Direction = ParameterDirection.Input,
                    Value = updatedInstructor.Position,
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
                _ = await dataAccess.ExecuteQueryAsync("UpdateInstructor", parameters).ConfigureAwait(false);

                int results = (int)(parameters[resultsIndex].Value);

                switch (results)
                {
                    case 0:
                        m_logger.LogError("InstructorController.UpdateInstructor: Requested instructor successfully updated.");
                        return StatusCode(StatusCodes.Status200OK);
                    case 1:
                        m_logger.LogError("InstructorController.UpdateInstructor: Requested instructor does not exist.");
                        return StatusCode(StatusCodes.Status404NotFound);
                    default:
                        m_logger.LogError("InstructorController.UpdateInstructor: Unexpected status was returned from the database.");
                        return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected status returned from the database.");
                }
            }
            catch (ArgumentException argExeption)
            {
                m_logger.LogError("InstructorController.UpdateInstructor: " + argExeption.Message);
                return StatusCode(StatusCodes.Status400BadRequest, argExeption.Message);
            }
            catch (SqlException sqlException)
            {
                m_logger.LogError("InstructorController.UpdateInstructor: " + sqlException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, sqlException.Message);
            }
        }
    }
}
