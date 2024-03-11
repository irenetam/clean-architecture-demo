using AutoMapper;
using TicketManagement.App.Services;
using TicketManagement.App.ViewModels;

namespace TicketManagement.App.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<CategoryEventDto, EventNestedViewModel>();
            CreateMap<CategoryEventDto, CategoryViewModel>();
            CreateMap<CategoryEventListViewModel, CategoryEventsViewModel>();
            CreateMap<CategoryListViewModel, CategoryViewModel>();
            CreateMap<CategoryViewModel, CreateCategoryCommand>();
            CreateMap<Services.EventListViewModel, ViewModels.EventListViewModel>();
            CreateMap<Services.EventDetailViewModel, ViewModels.EventDetailViewModel>();
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<ViewModels.EventDetailViewModel, UpdateEventCommand>();
            CreateMap<ViewModels.EventDetailViewModel, CreateEventCommand>();
            CreateMap<Services.PagedOrdersForMonthViewModel, ViewModels.PagedOrderForMonthViewModel>();
            CreateMap<OrdersForMonthDto, OrdersForMonthListViewModel>();
        }
    }
}
