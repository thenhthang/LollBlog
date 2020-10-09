using System;
using System.Threading.Tasks;
using LollBlog.Shared;

namespace LollBlog.Server.Models
{
    public interface IUserRepository
    {
        User SignIn(string email,string password);
        Task<User> ChangePassWord(string email,string password,string newPassword);
        Task<User> SignOut();
        Task<User> SignUp(User user);
        Task<User> ChangeProfile(User userProfile);
        Task<User> GetUser(int id);
    }
}
