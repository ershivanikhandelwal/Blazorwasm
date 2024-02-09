using EmployeeManagementModel;
using EmployeeManagementWeb.Common;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagementWeb.Pages.Employees
{
    public class EmployeeDetailBase : ComponentBase
    {
        [Inject]
        public IEmployeeService _employeeService { get; set; }
        [Parameter]
        public string Id { get; set; }
        public string Coordinates { get; set; }
        public Employee Employee = null;
        public string Buton_Text = "Hide Footer";
        public string Button_Class = null;
        public string token; 
        [Inject]
        public ILocalStorage LocalStorage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
			string userInfo = await LocalStorage.GetKeyFromLocalStorage("jwtToken");
            token = userInfo.Split(";")[0]; 
            Employee = await _employeeService.GetEmployeeById(token,Convert.ToInt32(Id));
        }

        protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = $"X={e.ClientX}, Y={e.ClientY}";
        }

        protected void Button_Click()
        {
            if (Buton_Text == "Hide Footer")
            {
                Buton_Text = "Show Footer";
                Button_Class = "HideFooter";
            }
            else
            {
                Buton_Text = "Hide Footer";
                Button_Class = null;
            }
        }
    }
}
