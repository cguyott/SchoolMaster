namespace SchoolMaster.WebAPI.Swagger
{
    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Extension methods to add swagger details to an instance of a <see cref="IServiceCollection"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Add support for online documentation.
        /// </summary>
        /// <param name="services">The instance of the <see cref="IServiceCollection"/>  to which the swagger service will be added.</param>
        /// <remarks>
        /// The documentation will be hosted at https://server:port/swagger/index.html.  When running the host
        /// as a console app in the development environment the URL is http://localhost:5000/swagger/index.html.
        /// </remarks>
        /// <returns><paramref name="services"/>, with the added online documentation.</returns>
        public static IServiceCollection AddSwaggerDocument(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "School Master API",
                    Description = "School Master API",
                    TermsOfService = null,
                    Contact = new OpenApiContact
                    {
                        Name = "Briarwood Consulting",
                        Email = string.Empty,
                        Url = null,
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Copyright © 2021 Briarwood Consulting",
                        Url = null,
                    },
                });

                // Set the comments path for the Swagger JSON and UI.
                string xmlBaseFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlBaseFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Description = "JWT Authorization Header \"Authorization: Bearer {token}\"",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        },
                        Array.Empty<string>()
                    },
                });
            });

            return services;
        }
    }
}
