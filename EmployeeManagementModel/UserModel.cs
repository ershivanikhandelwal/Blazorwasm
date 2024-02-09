using EmployeeManagementModel.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementModel
{
    public class UsersModel
    {
        public int Id { get; set; }

        [Required]
        public string Username {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
