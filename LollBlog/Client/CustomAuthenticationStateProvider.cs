using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using LollBlog.Client.Services;
using LollBlog.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
namespace LollBlog.Client
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;
        //[Inject]
        //public IUserService UserService { get; set; }
        public CustomAuthenticationStateProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async  override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                //var currentUser = await UserService.GetCurrentUser();
                var currentUser = await httpClient.GetFromJsonAsync<User>("api/users/getcurrentuser");


                if (currentUser != null && currentUser.Email != null)
                    {
                        Console.WriteLine("Khac null");
                        var claimEmailAddress = new Claim(ClaimTypes.Name, currentUser.Email);
                        var claimIdentifier = new Claim(ClaimTypes.NameIdentifier, Convert.ToString(currentUser.UserId));
                        var claimsIdentity = new ClaimsIdentity(new[] {claimEmailAddress,claimIdentifier }, "serverAuth");
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        return new AuthenticationState(claimsPrincipal);
                    }
                    else
                    {
                        Console.WriteLine("Bang null");
                        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                    }
                
            }catch(Exception ex)
            {
                Console.WriteLine("Loi: "+ex.ToString());
            }
            return null;
        }
    }
}
