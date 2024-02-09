using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementModel
{
    public class ResponseDTO
    {
        public string StatusCode {  get; set; }
        public string ErrorMessage {  get; set; }
        public Object Data {  get; set; }
        public bool isSuccess { get; set; }
    }
}
