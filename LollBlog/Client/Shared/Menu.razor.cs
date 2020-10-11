using System;
using System.Threading.Tasks;
using LollBlog.Client.Services;
using Microsoft.AspNetCore.Components;

namespace LollBlog.Client.Shared
{
    public class MenuBase : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

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
