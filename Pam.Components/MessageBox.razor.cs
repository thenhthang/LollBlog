using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
namespace Pam.Components
{
    enum DialogResult
    {
        Yes = 1,
        No = 2,
        Cancel = 3,
        Exit = 4
    }
    public  class MessageBoxBase: ComponentBase 
    {
        public bool ShowConfirmation { get; set; } 
        public void Show()
        {
            this.ShowConfirmation = true;
            this.StateHasChanged();
        }
        [Parameter]
        public EventCallback<int> MessageBoxChanged { get; set; }
        [Parameter]
        public string Title { get; set; } = "MessageBox";
        [Parameter]
        public string Message { get; set; } = "Are you agree?";

        protected async Task OnMessageBoxChanged(int value)
        {
            ShowConfirmation = false;
            await this.MessageBoxChanged.InvokeAsync(value);
        }


    }
}
