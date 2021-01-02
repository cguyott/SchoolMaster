namespace SchoolMaster.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Controller for the WeatherForecast Web API.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [CLSCompliant(false)]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        private readonly ILogger<WeatherForecastController> m_logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            m_logger = logger;
        }

        /// <summary>
        /// HTTP Get.
        /// </summary>
        /// <returns>A collection of WeatherForecast items.</returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            if (m_logger != null)
            {
                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)],
                })
                .ToArray();
            }
            else
            {
                throw new MissingMemberException();
            }
        }
    }
}
