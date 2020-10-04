using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LollBlog.Server.Models;
using LollBlog.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LollBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepositoty departmentRepositoty;
        public DepartmentsController(IDepartmentRepositoty departmentRepositoty)
        {
            this.departmentRepositoty = departmentRepositoty;
        }
        [HttpGet]
        public async Task<ActionResult<Department[]>> GetDepartments()
        {
            try
            {
                return Ok(await departmentRepositoty.GetDepartments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            try
            {
                return Ok(await departmentRepositoty.GetDepartment(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
