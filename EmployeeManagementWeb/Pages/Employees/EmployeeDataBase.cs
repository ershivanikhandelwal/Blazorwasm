using EmployeeManagementModel;
using EmployeeManagementWeb.Common;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagementWeb.Pages.Employees
{
    public class EmployeeDataBase : ComponentBase
    {
        [Inject]
        public IEmployeeService _employeeService { get; set; }
        public IEnumerable<Employee> Employees;
        public bool ShowFooter { get; set; } = true;
        public int selectedEmployeeCount = 0;
        [Inject]
        public ILocalStorage LocalStorage { get; set; }
        public string token = string.Empty;
        protected async override Task OnInitializedAsync()
        {
			string userInfo = await LocalStorage.GetKeyFromLocalStorage("jwtToken");
			token = userInfo.Split(";")[0]; 
            Employees = (await _employeeService.GetEmployees(token)).ToList();
        }
    }
}
