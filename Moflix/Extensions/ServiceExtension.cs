using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Moflix.WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services) 
        {
            services.AddSwaggerGen(Option =>
            {
                List<string> xmlFiles =Directory.GetFiles(AppContext.BaseDirectory, "*.xml", searchOption:SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => Option.IncludeXmlComments(xmlFile));

                Option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "StockApp API",
                    Description = "This Api will be responsible for overall data distribution",
                    Contact = new OpenApiContact
                    {
                        Name = "Brian Peña 2021-0948\r\nEmmanuel Popa 2021-0523\r\nMoisés Méndez 2020-9360\r\nJeremy Reinoso 2021-0751\r\nMisael Urbáez 2019-8934\r\nEimy Figueroa 2020-9190\r\nRene Ortega 2021-1563\r\nSaul Duran 2020-9489",
                        Email = "itla.edu.do",
                        Url = new Uri("https://www.itla.edu.do")
                    }
                });

                Option.DescribeAllParametersInCamelCase();
                Option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token in this format - Bearer {your token here}"
                });
                Option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });

            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}