using System;
using LollBlog.Shared;
using System.ComponentModel.DataAnnotations;

namespace LollBlog.Client.Models
{
    public class EditEmployeeModel: Employee
    {
        [Compare("Email",ErrorMessage ="Email and Confirm Email much match")]
        public string ConfirmEmail { get; set; }
        public new Department Department { get; set; } = new Department();
    }
}
