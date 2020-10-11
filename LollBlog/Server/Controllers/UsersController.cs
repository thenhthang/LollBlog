using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LollBlog.Server.Models;
using LollBlog.Shared;
using Microsoft.AspNetCore.Authentication;
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
        [HttpGet]
        [Route("signout")]
        public async Task<ActionResult<User>> Signout()
        {
            User user = new User();
            await HttpContext.SignOutAsync();
            return Ok(user);
        }
        [HttpGet]
        [Route("getcurrentuser")]
        public  ActionResult<User> GetCurrentUser()
        {
            User currentUser = new User();
            if (User.Identity.IsAuthenticated)
            {
                currentUser.Email =  User.FindFirstValue(ClaimTypes.Name);
                return Ok(currentUser);
            }
            else
            {
                return Ok(currentUser);
            }
            
        }

        [HttpPost]
        [Route("signin")]
        public ActionResult<User> SignIn(User user)
        {
            try
            {
                var loggedInUser = userRepository.SignIn(user.Email, user.Password);
                if (loggedInUser != null)
                {
                    var claim = new Claim(ClaimTypes.Name, loggedInUser.Email);
                    var claimsIdentity = new ClaimsIdentity(new[] { claim }, "serverAuth");
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    HttpContext.SignInAsync(claimsPrincipal);

                    return Ok(loggedInUser);
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
