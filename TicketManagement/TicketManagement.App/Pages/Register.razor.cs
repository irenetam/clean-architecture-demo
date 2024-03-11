using Microsoft.AspNetCore.Components;
using TicketManagement.App.Contracts;
using TicketManagement.App.ViewModels;

namespace TicketManagement.App.Pages
{
    public partial class Register
    {
        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }
        protected RegisterViewModel RegisterViewModel { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected string Message { get; set; }

        protected override void OnInitialized()
        {
            RegisterViewModel = new RegisterViewModel();
        }
        protected async void HandleValidSubmit()
        {
            var result = await AuthenticationService.Register(RegisterViewModel.FirstName, RegisterViewModel.LastName, RegisterViewModel.UserName, RegisterViewModel.Email, RegisterViewModel.Password);

            if (result)
            {
                NavigationManager.NavigateTo("home");
            }
            Message = "Something went wrong, please try again.";
        }
    }
}
