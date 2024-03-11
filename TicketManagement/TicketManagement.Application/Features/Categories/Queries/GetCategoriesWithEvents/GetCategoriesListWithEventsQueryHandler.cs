using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.Categories.Queries.GetCategoriesWithEvents
{
    public class GetCategoriesListWithEventsQueryHandler :
        IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListViewModel>>
    {
        private readonly IMapper _mapper;
        private ICategoryRepository _categoryRepository;
        public GetCategoriesListWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository) 
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        async Task<List<CategoryEventListViewModel>> IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListViewModel>>.Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
            return _mapper.Map<List<CategoryEventListViewModel>>(list);
        }
    }
}
