using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TicketManagement.App.Auth;
using TicketManagement.App.Contracts;

namespace TicketManagement.App.Pages
{
    public partial class Index
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        protected IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        }
        protected void NavigateToLogin()
        {
            NavigationManager.NavigateTo("login");
        }

        protected async void Logout()
        {
            await AuthenticationService.Logout();
        }
        protected void NavigateToRegister()
        {
            NavigationManager.NavigateTo("register");
        }
    }
}
