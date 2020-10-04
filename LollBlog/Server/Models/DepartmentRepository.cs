using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LollBlog.Shared;
using Microsoft.EntityFrameworkCore;

namespace LollBlog.Server.Models
{
    public class DepartmentRepository : IDepartmentRepositoty
    {
        private readonly AppDbContext appDbContext;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            return await appDbContext.Departments
                .FirstOrDefaultAsync(e => e.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }
    }
}
