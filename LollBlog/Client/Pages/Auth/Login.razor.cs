using System;
using Microsoft.AspNetCore.Components;
using LollBlog.Shared;
using LollBlog.Client.Services;


namespace LollBlog.Client.Pages
{
    public  class LoginBase : ComponentBase
    {
        [Inject]
        public IUserService userService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public User UserModel = new User();
        public async void HanleLoginSubmit()
        {
            var user = await userService.SignIn(UserModel);
            if(user != null)
            {
                NavigationManager.NavigateTo("/profile", true);
            }
        }
    }
}
