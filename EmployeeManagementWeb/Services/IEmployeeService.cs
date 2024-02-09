using EmployeeManagementModel;
using Refit;

namespace EmployeeManagementWeb.Services
{
    public interface IEmployeeService
    {
        [Get("/Employee/getEmployees")]
        public Task<IEnumerable<Employee>> GetEmployees([Header("Authorization")] string authorization);
        [Get("/Employee/search")]
        public Task<IEnumerable<Employee>> Search([Header("Authorization")] string authorization,string? name, Gender? gender);
        [Get("/Employee/getEmployeeById/{id}")]
        public Task<Employee> GetEmployeeById([Header("Authorization")] string authorization,int id);
        [Post("/Employee/addEmployee")]
        public Task<Employee> AddNewEmployee([Header("Authorization")] string authorization, Employee emp);
        [Put("/Employee/updateEmployee")]
        public Task<Employee> UpdateEmployee([Header("Authorization")] string authorization,Employee emp);
        [Delete("/Employee/deleteEmployee/{id}")]
        public Task DeleteEmployee([Header("Authorization")] string authorization, int id);
    }
}
