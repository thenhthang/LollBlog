using System;
using System.ComponentModel.DataAnnotations;
using LollBlog.Client.CustomValidators;

namespace LollBlog.Shared
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Tên bắt buột nhập")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailValidator(AllowedDomain ="tnquoc.com",ErrorMessage ="Only tnquoc.com is allwed")]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfBrith { get; set; }

        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
