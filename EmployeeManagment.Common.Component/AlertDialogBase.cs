using Microsoft.AspNetCore.Components;

namespace EmployeeManagment.Common.Component
{
    public class AlertDialogBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }
        [Parameter]
        public string AlertTitle { get; set; }
        [Parameter]
        public string AlertMessage { get; set; }

        public void show()
        {
            this.ShowConfirmation = true;
            StateHasChanged();
        }

        public async Task OnConfirmationChange(bool confirmation)
        {
            this.ShowConfirmation = false;
        }
    }
}
