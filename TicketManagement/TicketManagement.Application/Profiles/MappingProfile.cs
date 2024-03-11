using AutoMapper;
using TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManagement.Application.Features.Categories.Queries.GetCategoriesWithEvents;
using TicketManagement.Application.Features.Events.Commands.CreateEvent;
using TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using TicketManagement.Application.Features.Events.Queries.GetEventsList;
using TicketManagement.Application.Features.Orders.GetordersForMonth;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Event, EventListViewModel>().ReverseMap();
            CreateMap<Event, EventDetailViewModel>();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, CategoryEventListViewModel>();
            CreateMap<Category, CategoryListViewModel>();
            CreateMap<Category, CreateCategoryCommand>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
