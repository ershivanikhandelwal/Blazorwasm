using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagementModel.Validators
{
    public class CustomEmailValidator : ValidationAttribute
    {
        public string AllowedDomain {  get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                string[] domain = value.ToString().Split("@");
                if (domain.Length > 1 && domain[1] == AllowedDomain)
                {
                    return null;
                }
                else
                {
                    return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                }
            }
            else
            {
                return null;
            }            
        }
    }
}
