using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LollBlog.Shared;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LollBlog.Client.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<User> GetCurrentUser()
        {
            var result = await httpClient.GetFromJsonAsync<User>("api/users/getcurrentuser");
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<User>($"api/users/{id}");
        }

        public async Task<User> SignIn(User user)
        {
            user.Password = Util.EnCrypt(user.Password);
            var result = await httpClient.PostAsJsonAsync<User>("api/users/signin", user);
            return await result.Content.ReadFromJsonAsync<User>();

        }

        public async Task<User> SignOut()
        {
            var result = await httpClient.GetFromJsonAsync<User>("api/users/signout");
            return result;
        }
    }
}
