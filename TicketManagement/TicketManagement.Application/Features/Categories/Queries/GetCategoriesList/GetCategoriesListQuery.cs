using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery: IRequest<List<CategoryListViewModel>>
    {
    }

    public class GetCategoriesListQueryHandler: IRequestHandler<GetCategoriesListQuery, List<CategoryListViewModel>>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoriesListQueryHandler(IAsyncRepository<Category> categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListViewModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = (await _categoryRepository.GetAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<List<CategoryListViewModel>>(categories);
        }
    }
}
