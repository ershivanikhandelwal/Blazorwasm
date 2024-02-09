using EmployeeManagementModel;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> Search(string name, Gender? gender);
        public Task<IEnumerable<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(int id);
        public Task<Employee> AddEmployee(Employee employee);
        public Task<Employee> UpdateEmployee(Employee employee);
        public Task DeleteEmployee(int id);
    }
}
