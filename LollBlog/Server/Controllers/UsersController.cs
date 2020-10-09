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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await userRepository.GetUser(id);
            return Ok(user);
        }
        [HttpPost("{signin}")]
        public ActionResult<User> SignIn(User user)
        {
            try
            {
                var u = userRepository.SignIn(user.Email, user.Password);
                if (u != null)
                {
                    return Ok(u);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "" +
                    "Error retrieving data from the database");
            }

        }
    }

}
