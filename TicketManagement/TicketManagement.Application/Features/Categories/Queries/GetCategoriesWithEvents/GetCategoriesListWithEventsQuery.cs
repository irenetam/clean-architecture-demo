using MediatR;

namespace TicketManagement.Application.Features.Categories.Queries.GetCategoriesWithEvents;

public class GetCategoriesListWithEventsQuery: IRequest<List<CategoryEventListViewModel>>
{
    public bool IncludeHistory { get; set; }
}
