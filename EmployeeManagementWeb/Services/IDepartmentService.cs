using EmployeeManagementModel;
using Refit;

namespace EmployeeManagementWeb.Services
{
    public interface IDepartmentService
    {
        [Get("/Department/getAllDepartment")]
        [Headers("Authorization: Bearer")]
        public Task<IEnumerable<Department>> GetAllDepartment([Header("Authorization")] string authorization);
        [Get("/getDepartmentById/{id}")]
        [Headers("Authorization: Bearer")]
        public Task<IEnumerable<Employee>> GetDepartmentById([Header("Authorization")] string authorization,int id);
    }
}
