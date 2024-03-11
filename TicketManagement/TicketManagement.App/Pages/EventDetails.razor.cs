using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using TicketManagement.App.Contracts;
using TicketManagement.App.Services.Base;
using TicketManagement.App.ViewModels;

namespace TicketManagement.App.Pages
{
    public partial class EventDetails
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string EventId { get; set; }
        private Guid SelectedEventId = Guid.Empty;
        public string SelectedCategoryId { get; set; }
        public string Message { get; set; }

        public EventDetailViewModel EventDetailViewModel { get; set; } = new EventDetailViewModel() { Date = DateTime.Now.AddDays(1)};
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
            = new ObservableCollection<CategoryViewModel>();

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(EventId, out SelectedEventId))
            {
                EventDetailViewModel = await EventDataService.GetEventById(SelectedEventId);
                SelectedCategoryId = EventDetailViewModel.CategoryId.ToString();
            }
            
            var list = await CategoryDataService.GetAllCategories();
            Categories = new ObservableCollection<CategoryViewModel>(list);
            SelectedCategoryId = Categories.FirstOrDefault().Id.ToString();
        }

        protected async Task DeleteEvent()
        {
            var response = await EventDataService.DeleteEvent(SelectedEventId);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/eventoverview");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
        protected async Task HandleValidSubmit()
        {
            EventDetailViewModel.CategoryId = Guid.Parse(SelectedCategoryId);
            ApiResponse<Guid> response;

            if (SelectedEventId == Guid.Empty)
            {
                response = await EventDataService.CreateEvent(EventDetailViewModel);
            }
            else
            {
                response = await EventDataService.UpdateEvent(EventDetailViewModel);
            }

            HandleResponse(response);
        }
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/eventoverview");
        }
    }
}
