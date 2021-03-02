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
        [Route("api/v1/Administrator/{adminId}")]
        [ProducesResponseType(typeof(AdministratorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AdministratorDto>> GetAdministrator([FromRoute] int adminId)
        {
            if (adminId < 1)
            {
                string errorMessage = "adminId cannot be less than 1.";
                m_logger.LogError("AdministratorController.GetAdministrator: " + errorMessage);
                return StatusCode(StatusCodes.Status400BadRequest, errorMessage);
            }

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter parameter = new SqlParameter("AdminId", System.Data.SqlDbType.Int)
                {
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

                AdministratorDto administratorDto = AdministratorDtoHelper.GetAdministratorDto(results, phoneDtos, addressDtos);
                results.Close();

                return new JsonResult(administratorDto);
            }
            catch (SqlException sqlException)
            {
                m_logger.LogError("AdministratorController.GetAdministrator: " + sqlException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, sqlException.Message);
            }
        }
    }
}
