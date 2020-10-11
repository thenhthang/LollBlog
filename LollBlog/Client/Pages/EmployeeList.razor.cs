using System;
using Microsoft.AspNetCore.Components;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using LollBlog.Shared;
using System.Threading.Tasks;
using LollBlog.Client.Services;
using System.Linq;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
namespace LollBlog.Client.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public bool ShowFooter { get; set; } = true;

        public IEnumerable<Employee> Employees { get; set; }
        
        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        public AuthenticationStateProvider authenticationStateProvider { get; set; }

        protected bool IsAuthenticated { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            var auth = await authenticationStateProvider.GetAuthenticationStateAsync();
            var authUser = auth.User;
            if (authUser.Identity.IsAuthenticated)
            {
                IsAuthenticated = true;
                var claim = authUser.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
                var userId = Convert.ToInt64(claim?.Value);
                Employees = (await EmployeeService.GetEmployees()).ToList();
            }
            else
            {
                IsAuthenticated = false;
            }
            
            //await Task.Run(LoadEmployees);
        }

        protected int SelectedEmployeeCount { get; set; } = 0;
         
        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeeCount++;
            }
            else
            {
                SelectedEmployeeCount--;
            }
        }
        protected Task CreateNewEmployee()
        {
            NavigationManager.NavigateTo("/editemployee");
            return Task.CompletedTask;
        }
        protected void DeleteEmployee(int employeeId)
        {
             Employees = Employees.Where(e => e.EmployeeId != employeeId);
        }
        private void LoadEmployees()
        {
            System.Threading.Thread.Sleep(3000);
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "David@pragimtech.com",
                DateOfBrith = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john.png"
            };

            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@pragimtech.com",
                DateOfBrith = new DateTime(1981, 12, 22),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/sam.jpg"
            };

            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@pragimtech.com",
                DateOfBrith = new DateTime(1979, 11, 11),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "images/mary.png"
            };

            Employee e4 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@pragimtech.com",
                DateOfBrith = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                DepartmentId = 4,
                PhotoPath = "images/sara.png"
            };

            Employees = new List<Employee> { e1, e2, e3, e4 };
        }
    }
}
