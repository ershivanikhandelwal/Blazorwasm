using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagment.Common.Component
{
    public class ConfirmDialogBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }
        [Parameter]
        public string ConfirmationTitle { get; set; }
        [Parameter]
        public string ConfirmationMessage { get; set; }
        [Parameter]
        public EventCallback<bool> DeleteConfirmation { get; set; }

        public void show()
        {
            this.ShowConfirmation = true;
            StateHasChanged();
        }

        public async Task OnConfirmationChange(bool confirmation)
        {
            this.ShowConfirmation = false;
            await DeleteConfirmation.InvokeAsync(confirmation);
        }
    }
}
