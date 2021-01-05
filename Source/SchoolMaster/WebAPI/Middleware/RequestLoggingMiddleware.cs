namespace SchoolMaster.WebAPI.Middleware
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Logs all HTTP requests to the application.
    /// </summary>
    [CLSCompliant(false)]
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate m_next;
        private readonly ILogger m_logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestLoggingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware to invoke.</param>
        /// <param name="logger">The logger for this instance.</param>
        public RequestLoggingMiddleware(RequestDelegate next, ILogger logger)
        {
            m_next = next;
            m_logger = logger;
        }

        /// <summary>
        /// Invoke this middleware.
        /// </summary>
        /// <param name="context">HttpContext for the call.</param>
        /// <returns>Task.</returns>
        public async Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            DateTime start = DateTime.Now;

            // Process context.Request.
            string method = context.Request.Method;
            string path = context.Request.Path.Value;

            await m_next(context).ConfigureAwait(true);

            // Process context.Response.
            double responseTime = (DateTime.Now - start).TotalMilliseconds;
            string status = context.Response.StatusCode.ToString(System.Globalization.CultureInfo.InvariantCulture);
            long length = context.Response.ContentLength != null ? (long)context.Response.ContentLength : 0;

            string msg = $"{method} {path} {status} {length} {responseTime}";
            LogInfo(msg);
        }

        /// <summary>
        /// Write an information statement to the log.
        /// </summary>
        /// <param name="toLog">Message to write.</param>
        protected void LogInfo(string toLog)
        {
            m_logger.LogInformation(toLog);
        }
    }
}