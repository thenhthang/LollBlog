using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LollBlog.Shared;
namespace LollBlog.Server.Models
{
    public interface IDepartmentRepositoty
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
    }
}
