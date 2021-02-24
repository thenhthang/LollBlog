using System;
using System.Security.Claims;
using System.Threading.Tasks;
using LollBlog.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace LollBlog.Client.Shared
{
    public class MenuBase : ComponentBase
    {
        protected string RoleName { get; set; }
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthenticationStateProvider authenticationStateProvider { get; set; }
        protected bool expandSubNav = false;
        protected async override Task OnInitializedAsync()
        {
            var auth = await authenticationStateProvider.GetAuthenticationStateAsync();
            var authUser = auth.User;
            if (authUser.Identity.IsAuthenticated)
            {
                var claim = authUser.FindFirst(c => c.Type == ClaimTypes.Role);
                var roleId = claim?.Value;
                if(roleId == "1")
                {
                    this.RoleName = "CEO";
                }
                else
                {
                    this.RoleName = "Developer";
                }
                Console.WriteLine("ROLE: "+ roleId);
            }
            else
            {
                
            }
        }
        public void LoginUser()
        {
            NavigationManager.NavigateTo("/login");
        }
        public async Task LogoutUser()
        {
            await UserService.SignOut();
            NavigationManager.NavigateTo("/",true);
        }
    }
}
