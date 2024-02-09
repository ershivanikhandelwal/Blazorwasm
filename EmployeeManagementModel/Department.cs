using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementModel
{
    public class Department
    {
        public int DepartmentId {  get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
