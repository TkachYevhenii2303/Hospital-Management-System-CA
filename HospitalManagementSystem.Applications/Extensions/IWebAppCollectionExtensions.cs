using Hospital_Management_System_Applications.Exceptions.Handling;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Extensions
{
    public static class IWebAppCollectionExtensions
    {
        public static void AddWebApplicationLayer(this IApplicationBuilder app)
        {
            app.AddExceptionHandling();
        }

        private static void AddExceptionHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
