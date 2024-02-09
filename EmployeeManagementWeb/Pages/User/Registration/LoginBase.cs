using Blazored.LocalStorage;
using EmployeeManagementModel;
using EmployeeManagementWeb.Common;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace EmployeeManagementWeb.Pages.User.Registration
{
    public class LoginBase : ComponentBase
    {
        public LoginModel user { get; set; }
        [Inject]
        public IUserService userService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject] 
        public ILocalStorage LocalStorage {  get; set; }
        public bool isRequestProcessed = false;
        protected override async Task OnInitializedAsync()
        {
            user = new LoginModel();
        }
        public string errorMessage = string.Empty;

        public async Task LoginUser()
        {
            isRequestProcessed = true;
            ResponseDTO response=await userService.LoginUser(user);
            if(response.isSuccess)
            {
                await LocalStorage.SetLocalStorage("jwtToken", "Bearer " + response.Data.ToString());
                navigationManager.NavigateTo("/employeeList");
                errorMessage = response.ErrorMessage;
            }
            else
            {
                errorMessage = response.ErrorMessage;
            }
            isRequestProcessed = false;
        }
    }
}
