using MediatR;

namespace TicketManagement.Application.Features.Orders.GetordersForMonth
{
    public class GetOrdersForMonthQuery: IRequest<PagedOrdersForMonthViewModel>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
