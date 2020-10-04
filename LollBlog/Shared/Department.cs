using System;
using System.ComponentModel.DataAnnotations;

namespace LollBlog.Shared
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
