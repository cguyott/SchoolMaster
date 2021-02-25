namespace SchoolMaster.WebAPI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SchoolMaster.WebAPI.DataTransferObjects;

    /// <summary>
    /// Handles HTTP requests to support CRUD operations on the Administrator class.
    /// </summary>
    [CLSCompliant(false)]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
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
        public ActionResult<AdministratorDto> GetAdministrator([FromRoute] int adminId)
        {
            if (adminId < 0)
            {
                return Forbid();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
