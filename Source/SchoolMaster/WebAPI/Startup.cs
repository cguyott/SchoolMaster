namespace SchoolMaster.WebAPI
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using SchoolMaster.WebAPI.Middleware;
    using SchoolMaster.WebAPI.Swagger;

    /// <summary>
    /// Startup class for initializing our Web API environment.
    /// </summary>
    [CLSCompliant(false)]
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Configuration data for our Web API.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Gets configuration data for our Web API.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Services collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            string sqlConnection = Configuration.GetValue<string>("SQL:connectString");

            services.AddControllers();
            services.AddHealthChecks()
                .AddSqlServer(sqlConnection);

            services.AddSwaggerDocument();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application builder.</param>
        /// <param name="env">Web host environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _ = app ?? throw new ArgumentNullException(nameof(app));
            _ = env ?? throw new ArgumentNullException(nameof(env));

            // Inject middleware to handle all exceptions.
            ILogger errorHandlingLogger = app.ApplicationServices.GetService<ILogger<ErrorHandlingMiddleware>>();
            app.UseMiddleware<ErrorHandlingMiddleware>(errorHandlingLogger);

            // Inject middlware to log every API call.
            errorHandlingLogger = app.ApplicationServices.GetService<ILogger<RequestLoggingMiddleware>>();
            app.UseMiddleware<RequestLoggingMiddleware>(errorHandlingLogger);

            // This is critical!  If you don't add authentication the token will validate
            // but the request will return 401 (unauthorized);
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change
                // this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "School Master API v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks(
                    "/health",
                    new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
                    {
                        ResponseWriter = SchoolMaster.WebAPI.HealthCheck.ResponseWriters.WriteResponse,
                    });
            });
        }
    }
}
