﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace EmployeeManagementWeb.ExceptionHandling
{
    public class CustomErrorBoundry : ErrorBoundary
    {
        [Inject]
        private IWebAssemblyHostEnvironment env { get; set; }
        protected override Task OnErrorAsync(Exception exception)
        {
            if (env.IsDevelopment())
            {
                return base.OnErrorAsync(exception);
            }
            return Task.CompletedTask;
        }
    }
}
