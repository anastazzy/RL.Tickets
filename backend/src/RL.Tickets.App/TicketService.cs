using RL.Tickets.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RL.Tickets.DataAccess;
using RL.Tickets.Domain;

namespace RL.Tickets.App
{
    public class TicketService : ITicketService
    {
        private readonly TicketsDbContext _dbContext;

        public TicketService(TicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> CreateTicketAsync(TicketInputDto ticketDto)
        {
            var ticket = new Ticket()
            {
                Description = ticketDto.Description,
                InitiatorId = ticketDto.InitiatorId,
                Status = ticketDto.Status,
                DateOfClosing = ticketDto.DateOfClosing,
                ExecutorId = ticketDto.ExecutorId,
                ProjectId = ticketDto.ProjectId
            };
            _dbContext.Tickets.Add(ticket);
            await _dbContext.SaveChangesAsync();
            return ticket.Id;
        }
        

        public async Task<bool> EditTicketAsync(long id, TicketInputDto ticketDto)
        {
           var result = await _dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
           result.DateOfClosing = ticketDto.DateOfClosing;
           result.Description = ticketDto.Description;
           result.ExecutorId = ticketDto.ExecutorId;
           result.InitiatorId = ticketDto.InitiatorId;
           result.ProjectId = ticketDto.ProjectId;
           result.Status = ticketDto.Status;
           await _dbContext.SaveChangesAsync();
           return true;
        }

        public async Task<bool> DeleteTicketAsync(long id)
        {
            var result = await _dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _dbContext.Tickets.Remove(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<TicketOutputDto[]> GetListOfTicketsAsync(GetTicketsRequest request)
        {
            var query = _dbContext.Tickets.AsQueryable();
            if (request.Date is not null)
            {
                query = query.Where(x => x.DateOfCreation.Date == request.Date.Value.Date);
            }
            if (request.Status is not null )
            {
                query = query.Where(x => x.Status == request.Status.Value);
            }

            if (request.Initiator is not null)
            {
                query = query.Where(x => x.Initiator.Id == request.Initiator.Value);
            }
            return await query.Select(x => new TicketOutputDto()
            {
                Id = x.Id,
                DateOfCreation = x.DateOfCreation,
                Description = x.Description,
                DateOfClosing = x.DateOfClosing,
                ExecutorId = x.ExecutorId,
                InitiatorId = x.InitiatorId,
                ProjectId = x.ProjectId, 
                Status = x.Status
            }).ToArrayAsync();
        }
    }
}
