using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Hospital_Management_System_WEB_API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPresentationLayer(this IServiceCollection services)
        {
            services.AddSwaggerConfiguration();
        }
        private static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hospital Management System API",
                    Description = "The Hospital Management System API is a powerful and flexible application programming interface (API) built on the .NET framework. It provides a set of web services that allow seamless integration and interaction with the hospital management system, enabling developers to build robust healthcare applications and enhance the functionalities of existing systems. This document serves as a guide for developers, providing an overview of the API and instructions for its usage.",
                    Version = "v1"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }
    }
}
