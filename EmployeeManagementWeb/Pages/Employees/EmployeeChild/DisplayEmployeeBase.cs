using EmployeeManagementModel;
using EmployeeManagementWeb.Common;
using EmployeeManagementWeb.Services;
using EmployeeManagment.Common.Component;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagementWeb.Pages.Employees.EmployeeChild
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Inject]
        public IEmployeeService employeeService { get; set; }

        public ConfirmDialogBase DeleteConfirmationDialog { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }
        [Parameter]
        public EventCallback<int> OnEmployeeDelete { get; set; }
        public string token;
        [Inject]
        public ILocalStorage LocalStorage { get; set; }

        public async Task checkBoxSelection(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }

        public void Delete_click()
        {
            DeleteConfirmationDialog.show();
        }

        public async void Confirm_Click(bool delete_click)
        {
            if (delete_click)
            {
                if (Employee.EmployeeId > 0)
                {
					string userInfo = await LocalStorage.GetKeyFromLocalStorage("jwtToken");
					token = userInfo.Split(";")[0]; 
                    await employeeService.DeleteEmployee(token, Employee.EmployeeId);
                    await OnEmployeeDelete.InvokeAsync(Employee.EmployeeId);
                }
            }
        }
    }
}
