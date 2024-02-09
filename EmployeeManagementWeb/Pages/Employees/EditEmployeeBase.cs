using AutoMapper;
using EmployeeManagementModel;
using EmployeeManagementWeb.Common;
using EmployeeManagementWeb.Models;
using EmployeeManagementWeb.Services;
using EmployeeManagment.Common.Component;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagementWeb.Pages.Employees
{
    public class EditEmployeeBase : ComponentBase
    {
        public string PageTitle = "Edit Employee";
        [Inject]
        public IEmployeeService _employeeService { get; set; }
        [Inject]
        public IDepartmentService _departmentService { get; set; }
        [Inject]
        public IMapper mapper { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Parameter]
        public string Id { get; set; }
        private Employee Employee { get; set; }
        public EditEmployeeModel employeeModel { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public ConfirmDialogBase DeleteConfirmationDialog { get; set; }
        public string token;
        [Inject]
        public ILocalStorage LocalStorage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            string userInfo = await LocalStorage.GetKeyFromLocalStorage("jwtToken");
            token = userInfo.Split(";")[0];
			Departments = await _departmentService.GetAllDepartment(token);
            if (string.IsNullOrEmpty(Id) || Id == "0")
            {
                PageTitle = "Add Employee";
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/mary.png",
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    Email = string.Empty,
                    Department = Departments.FirstOrDefault(),
                };
            }
            else
            {
                Employee = await _employeeService.GetEmployeeById(token, Convert.ToInt32(Id));
            }
            employeeModel = mapper.Map<Employee, EditEmployeeModel>(Employee);
        }

        protected async Task SaveChanges()
        {
            Employee emp = mapper.Map<EditEmployeeModel, Employee>(employeeModel);
            Employee result = null;
            if (emp.EmployeeId == 0)
            {
                emp.Department = null;
                result = await _employeeService.AddNewEmployee(token,emp);
            }
            else
            {
                result = await _employeeService.UpdateEmployee(token, emp);
            }
            if (result != null)
            {
                navigationManager.NavigateTo("/employeeList");
            }
        }

        public async Task Delete_Click()
        {
            DeleteConfirmationDialog.show();
        }

        public async void Confirm_Click(bool delete_click)
        {
            if (delete_click)
            {
                if (Employee.EmployeeId > 0)
                {
                    await _employeeService.DeleteEmployee(token, Employee.EmployeeId);
                    navigationManager.NavigateTo("/employeeList");
                }
            }
        }
    }
}
