using System;
using System.Threading.Tasks;
using LollBlog.Shared;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace LollBlog.Server.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Task<User> ChangePassWord(string email, string password, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<User> ChangeProfile(User userProfile)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int id)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync<User>(
                e => e.UserId == id);
            return user;

        }

        public User SignIn(string email, string password)
        {
            var user = appDbContext.Users.FirstOrDefault(
                e => e.Email == email &&
                e.Password == password);
            return user;
        }

        public Task<User> SignOut()
        {
            throw new NotImplementedException();
        }

        public Task<User> SignUp(User user)
        {
            throw new NotImplementedException();
        }
    }
}
