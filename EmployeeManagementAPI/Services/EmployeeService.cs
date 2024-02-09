using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;
using EmployeeManagementModel;
using System.Linq.Expressions;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly AppDBContext _appDBContext;
        public EmployeeService(AppDBContext appDBContext) { 
            _appDBContext = appDBContext;
            this._employeeRepository = new Repository<Employee>(_appDBContext);
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            return await _employeeRepository.Add(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await (_employeeRepository.Delete(a=>a.EmployeeId==id));    
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAll(s=>s.Department);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetSingle(a=>a.EmployeeId==id,s=>s.Department);
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            Expression<Func<Employee, bool>> filter= null;
            if (!string.IsNullOrEmpty(name) && gender != null)
                filter = a => (a.FirstName + " " + a.LastName).Equals(name) && a.Gender == gender;
            else if (!string.IsNullOrEmpty(name))
                filter = a => (a.FirstName + " " + a.LastName).Equals(name);
            else if (gender != null)
                filter = a => a.Gender == gender;
            if(filter!=null)
                return await _employeeRepository.Search(filter);
            return await _employeeRepository.GetAll();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result=await _employeeRepository.GetSingle(a=>a.EmployeeId== employee.EmployeeId, s => s.Department);
            if (result != null)
            {
                result.PhotoPath = employee.PhotoPath;
                result.DateOfBirth = employee.DateOfBirth;
                result.Email = employee.Email;
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.DepartmentId = employee.DepartmentId;
                result.Gender=employee.Gender;
                return await _employeeRepository.UpdateEntity(result);
            }
            return null;
        }
    }
}
