namespace SchoolMaster.WebAPI.HealthCheck
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Diagnostics.HealthChecks;

    /// <summary>
    /// Response writers for returning JSON responses.
    /// </summary>
    public static class ResponseWriters
    {
        /// <summary>
        /// Gets the version of the process executable in the default application domain.
        /// In other application domains, this is the first executable that was executed by
        /// AppDomain.ExecuteAssembly.
        /// </summary>
        internal static string Version { get; } = GetVersion();

        /// <summary>
        /// Custom response writer for HAP Services health checkers.
        /// </summary>
        /// <param name="context">HTTP context.</param>
        /// <param name="report">Health report result.</param>
        /// <returns>A task.</returns>
        [CLSCompliant(false)]
        public static Task WriteResponse(HttpContext context, HealthReport report)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context));
            _ = report ?? throw new ArgumentNullException(nameof(report));

            string status = report.Status.ToString();
            string version = ResponseWriters.Version;
            string dateTime8601 = DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'", CultureInfo.InvariantCulture);

            JsonWriterOptions options = new JsonWriterOptions
            {
                Indented = true,
            };

            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream, options))
            {
                writer.WriteStartObject();
                writer.WriteString("status", status);
                writer.WriteString("version", version);
                writer.WriteString("datetime", dateTime8601);
                writer.WriteEndObject();
            }

            string json = Encoding.UTF8.GetString(stream.ToArray());

            context.Response.ContentType = "application/json; charset=utf-8";
            return context.Response.WriteAsync(json);
        }

        /// <summary>
        /// Custom response writer for HAP Services health checkers that returns the entire contents of HealthReport in JSON.
        ///
        /// This writer is especially helpful for dumping the contents of the HealthReport.  Very useful for trouble shooting.
        /// </summary>
        /// <param name="context">HTTP context.</param>
        /// <param name="report">Health report result.</param>
        /// <returns>A task.</returns>
        [CLSCompliant(false)]
        public static Task WriteResponseFull(HttpContext context, HealthReport report)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context));
            _ = report ?? throw new ArgumentNullException(nameof(report));

            JsonWriterOptions options = new JsonWriterOptions
            {
                Indented = true,
            };

            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream, options))
            {
                writer.WriteStartObject();
                writer.WriteString("status", report.Status.ToString());
                writer.WriteStartObject("results");

                foreach (KeyValuePair<string, HealthReportEntry> entry in report.Entries)
                {
                    writer.WriteStartObject(entry.Key);
                    writer.WriteString("status", entry.Value.Status.ToString());
                    writer.WriteString("description", entry.Value.Description);
                    writer.WriteStartObject("data");

                    foreach (var item in entry.Value.Data)
                    {
                        writer.WritePropertyName(item.Key);
                        JsonSerializer.Serialize(writer, item.Value, item.Value?.GetType() ?? typeof(object));
                    }

                    writer.WriteEndObject();
                    writer.WriteEndObject();
                }

                writer.WriteEndObject();
                writer.WriteEndObject();
            }

            string json = Encoding.UTF8.GetString(stream.ToArray());

            context.Response.ContentType = "application/json; charset=utf-8";
            return context.Response.WriteAsync(json);
        }

#nullable enable

        /// <summary>
        /// This method is used here and in some of the IHealthCheck implementations.
        ///
        /// The null checks in this method are required to prevent compiler and runtime errors.
        /// </summary>
        /// <returns>The version number or "&lt;Unknown&gt;".</returns>
        private static string GetVersion()
        {
            string retValue = "<Unknown>";

            Assembly? entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                Version? entryAssemblyVersion = entryAssembly.GetName().Version;
                if (entryAssemblyVersion != null)
                {
                    retValue = entryAssemblyVersion.ToString();
                }
            }

            return retValue;
        }
    }
}
