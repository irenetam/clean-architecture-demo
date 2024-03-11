using Microsoft.AspNetCore.Components;
using TicketManagement.App.Contracts;
using TicketManagement.App.ViewModels;

namespace TicketManagement.App.Pages
{
    public partial class Login
    {
        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected LoginViewModel LoginViewModel { get; set; }
        protected string Message { get; set; }

        protected override void OnInitialized()
        {
            LoginViewModel = new LoginViewModel();
        }
        protected async void HandleValidSubmit()
        {
            if (await AuthenticationService.Authenticate(LoginViewModel.Email, LoginViewModel.Password))
            {
                NavigationManager.NavigateTo("/");
            }
            Message = "Username/password combination unknown";
        }
    }
}
