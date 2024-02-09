using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;
using EmployeeManagementModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagementAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly AppDBContext _appDBContext;
        public DepartmentService(AppDBContext appDBContext) {
            _appDBContext = appDBContext;
            this._departmentRepository = new Repository<Department>(_appDBContext);
        }
        public async Task<Department> AddDepartment(Department department)
        {
            return await _departmentRepository.Add(department);
        }

        public async Task DeleteDepartment(int id)
        {
            await _departmentRepository.Delete(a=>a.DepartmentId==id);
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _departmentRepository.GetAll();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _departmentRepository.GetSingle(a=>a.DepartmentId==id);
        }

        public async Task<Department> GetDepartmentByName(string name)
        {
            return await _departmentRepository.GetSingle(a=>a.DepartmentName==name);
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            var dept=await _departmentRepository.GetSingle(a=>a.DepartmentId==department.DepartmentId);   
            if(dept!=null)
            {
                dept.DepartmentName = department.DepartmentName;
                return await _departmentRepository.UpdateEntity(department);
            }
            return null;
        }
    }
}
