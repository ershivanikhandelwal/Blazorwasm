using Blazored.LocalStorage;
using EmployeeManagementModel;
using EmployeeManagementWeb.Common;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagementWeb.Pages.Employees
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService _employeeService { get; set; }
        public IEnumerable<Employee> Employees;
        public bool ShowFooter { get; set; } = true;
        public int selectedEmployeeCount = 0;
        [Inject]
        public ILocalStorage LocalStorage { get; set; }
        public string token=string.Empty;
        protected override async Task OnInitializedAsync()
        {
			string userInfo = await LocalStorage.GetKeyFromLocalStorage("jwtToken");
			token = userInfo.Split(";")[0]; 
            Employees = (await _employeeService.GetEmployees(token)).ToList();
        }

        public void EmployeeSelectionChange(bool value)
        {
            if (value)
                selectedEmployeeCount++;
            else
                selectedEmployeeCount--;
        }

        public async Task EmployeeDelete()
        {
            Employees = await _employeeService.GetEmployees(token);
        }
    }
}
