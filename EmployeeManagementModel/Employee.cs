using EmployeeManagementModel.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace EmployeeManagementModel
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="First name must be required.")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [CustomEmailValidator(AllowedDomain = "pragimtech.com", ErrorMessage = "Domain name must be pragimtech.com")]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
