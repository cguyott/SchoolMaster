namespace SchoolMaster.WebAPI
{
    using System;

    /// <summary>
    /// Data definition for WeatherForecast.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets temperature celsius.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Gets temperature fahrenheit.
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets summary.
        /// </summary>
        public string Summary { get; set; }
    }
}
