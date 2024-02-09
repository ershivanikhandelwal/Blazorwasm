using EmployeeManagementModel;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EmployeeManagementAPI.Middleware
{
    public class ExceptionMiddlewareExtensions
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _enviroment;
        public ExceptionMiddlewareExtensions(RequestDelegate next, IWebHostEnvironment enviroment)
        {
            _next = next;
            _enviroment = enviroment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                if(context.Response.HasStarted)
                {
                    throw;
                }
                context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                if(_enviroment.IsDevelopment())
                {
                    await context.Response.WriteAsync($"An error occured: {ex.ToString()}");
                }
                else
                {
                    await context.Response.WriteAsync("An unexpected error occured.");
                }
            }
        }
    }
}
