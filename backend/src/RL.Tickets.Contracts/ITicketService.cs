using System.Threading.Tasks;

namespace RL.Tickets.Contracts
{
    public interface ITicketService
    {
        public Task<long> CreateTicketAsync(TicketInputDto ticketDto);
        public Task<bool> EditTicketAsync(long id, TicketInputDto ticketDto);
        public Task<bool> DeleteTicketAsync(long id);
        public Task<TicketOutputDto[]> GetListOfTicketsAsync(GetTicketsRequest request);

    }
}
