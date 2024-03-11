using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;
using System.Linq;

namespace TicketManagement.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<List<EventListViewModel>>
    {
    }
    public class GetEventsListqueryHandler : IRequestHandler<GetEventsListQuery, List<EventListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Event> _eventRepository;
        public GetEventsListqueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<List<EventListViewModel>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var events = (await _eventRepository.GetAllAsync()).OrderBy(x => x.Date);
            return _mapper.Map<List<EventListViewModel>>(events);
        }
    }
}
