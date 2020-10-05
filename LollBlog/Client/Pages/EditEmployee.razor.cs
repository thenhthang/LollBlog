using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LollBlog.Client.Services;
using LollBlog.Shared;
using System.Linq;
using Microsoft.AspNetCore.Components;
using LollBlog.Client.Models;

namespace LollBlog.Client.Pages
{
    public class EditEmployeeBase:ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        [Parameter]
        public string Id { get; set; }
        public string PageHeaderText { get; set; }
        private int _EmployeeID { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        protected Pam.Components.MessageBoxBase DeleteMessageBox { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string DepartmentId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int _EmployeeID);
            if (_EmployeeID != 0)
            {
                PageHeaderText = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
                
            }
            else
            {
                PageHeaderText = "Create Employee";
                Employee = new Employee()
                {
                    DepartmentId = 1,
                    DateOfBrith = DateTime.Now.Date,
                    PhotoPath = "images/nophoto.jpg"
                };
                
            }
            MapEmployee(Employee, EditEmployeeModel);
            Departments = (await DepartmentService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartmentId.ToString();
        }
        protected async Task HandleValidSubmit()
        {
            Employee result;
            if (EditEmployeeModel.EmployeeId != 0)
            {
                 result = await EmployeeService.UpdateEmployee(EditEmployeeModel);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(EditEmployeeModel);
            }

            if(result != null)
            {
                NavigationManager.NavigateTo("/employeelist");
            }
        }
        protected void Delete_Click()
        {
            DeleteMessageBox.Show();
        }
        protected async Task MessageDialogResult(int value)
        {
            if(value == 1)
            {
                if (Employee.EmployeeId > 0)
                {
                    await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                    NavigationManager.NavigateTo("/employeelist");
                }
            }
        }

        private void MapEmployee(Employee source,EditEmployeeModel des)
        {
            des.DepartmentId = source.DepartmentId;
            des.DateOfBrith = source.DateOfBrith;
            des.Department = source.Department;
            des.EmployeeId = source.EmployeeId;
            des.Gender = source.Gender;
            des.LastName = source.LastName;
            des.FirstName = source.FirstName;
            des.PhotoPath = source.PhotoPath;
            des.Email = source.Email;
            des.ConfirmEmail = source.Email;
        }
    }
}
