using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace LollBlog.Client.Pages
{
    public class indexBase :ComponentBase
    {
        [Inject]
        NavigationManager navigationManager { get; set; }
        [Inject]
        AuthenticationStateProvider authenticationStateProvider { get; set; }
        protected async override Task OnInitializedAsync()
        {
            var auth = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (auth.User.Identity.IsAuthenticated)
            {
                navigationManager.NavigateTo("/");
            }
            else
            {
                navigationManager.NavigateTo("/login");
            }
        }
    }
}
