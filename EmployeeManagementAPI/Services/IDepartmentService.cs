using EmployeeManagementModel;

namespace EmployeeManagementAPI.Services
{
    public interface IDepartmentService
    {        
        public Task<IEnumerable<Department>> GetAllDepartments();
        public Task<Department> GetDepartmentById(int id);
        public Task<Department> GetDepartmentByName(string name);
        public Task<Department> AddDepartment(Department department);
        public Task<Department> UpdateDepartment(Department department);
        public Task DeleteDepartment(int id);
    }
}
