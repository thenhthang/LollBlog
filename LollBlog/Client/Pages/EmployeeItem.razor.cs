using System;
using System.Threading.Tasks;
using LollBlog.Shared;
using Microsoft.AspNetCore.Components;
using LollBlog.Client;
using LollBlog.Client.Services;

namespace LollBlog.Client.Pages
{
    public class EmployeeItemBase: ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }
        [Parameter]
        public EventCallback<int> OnDeleteEmployee { get; set; }
        public async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }
        public void Delete_Click()
        {
            DeleteMessageBox.Show();
        }
        public async Task MessageDialogResult(int value)
        {
            if(value == 1)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnDeleteEmployee.InvokeAsync(Employee.EmployeeId);
            }
        }
        //public async Task Delete_Click()
        //{
        //    await EmployeeService.DeleteEmployee(Employee.EmployeeId);
        //    await OnDeleteEmployee.InvokeAsync(Employee.EmployeeId);
        //}
        protected Pam.Components.MessageBoxBase DeleteMessageBox { get; set; }
    }
}
