namespace SchoolMaster.WebAPI.Middleware
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Error handing middleware.
    /// </summary>
    [CLSCompliant(false)]
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate m_next;
        private readonly ILogger m_logger;

        /// <summary>Initializes a new instance of the <see cref="ErrorHandlingMiddleware"/> class.</summary>
        /// <param name="next">Next.</param>
        /// <param name="logger">Logger.</param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger logger)
        {
            m_next = next;
            m_logger = logger;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <returns>Task.</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await m_next(context).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Handle an unexpected application exception.
        /// </summary>
        /// <param name="context">Http context for the call.</param>
        /// <param name="exception">The unexpected exception.</param>
        /// <returns>Task.</returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            m_logger.LogError(exception, "Error handled by middleware.");

            string result = System.Text.Json.JsonSerializer.Serialize<string>(exception.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(result);
        }
    }
}