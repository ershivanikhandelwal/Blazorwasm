using Microsoft.AspNetCore.Components;
using EmployeeManagementModel;
using EmployeeManagementWeb.Services;
using AutoMapper;
using EmployeeManagment.Common.Component;

namespace EmployeeManagementWeb.Pages.User.Registration
{
    public class UserRegistrationBase : ComponentBase
    {
        public UsersModel user { get; set; }
        [Inject]
        public IUserService userService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        private IMapper mapper { get; set; }
        public bool isRequestProcessed = false;
        public string message { get; set; }
        public AlertDialogBase alertDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            user = new UsersModel();
        }

        public async Task SaveChanges()
        {
            isRequestProcessed = true;
            Users usr=mapper.Map<UsersModel, Users>(user);
            ResponseDTO response=await userService.RegisterUser(usr);
            if(response.isSuccess)
            {
                navigationManager.NavigateTo("/Login");
            }
            else
            {
                alertDialog.show();
                message = response.ErrorMessage;
            }
            isRequestProcessed = false;
        }
    }
}
