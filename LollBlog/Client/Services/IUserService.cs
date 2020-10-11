using System;
using System.Threading.Tasks;
using LollBlog.Shared;
namespace LollBlog.Client.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);
        Task<User> SignIn(User user);
        Task<User> GetCurrentUser();
        Task<User> SignOut();
    }
}
