using EmployeeManagementModel;
using EmployeeManagementModel.Validators;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWeb.Models
{
    public class EditEmployeeModel
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
        [CompareProperty("Email",ErrorMessage ="Email and ConfirmEmail does not match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        [ValidateComplexType]
        public Department Department { get; set; }
    }
}
