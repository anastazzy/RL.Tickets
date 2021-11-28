using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RL.Tickets.App;
using RL.Tickets.Contracts;
using RL.Tickets.Domain;
using Xunit;

namespace LR.Tickets.UnitTests
{
    public class TicketServiceTest : WithDataBaseTest
    {
        private readonly TicketService _service;

        public TicketServiceTest()
        {
            _service = new TicketService(DbContext);
        }
        [Fact]
        public async Task CreateTickets_ShouldCreateTickets()
        {
            var ticket = new TicketInputDto()
            {
                DateOfClosing = new DateTime(2022, 02, 15),
                Description = "dwhue",
                ExecutorId = 1,
                ProjectId = 3,
                InitiatorId = 4,
                Status = Status.InProcess
            };

            var result = await _service.CreateTicketAsync(ticket);
            var insertedTicket = await DbContext.Tickets
                .Include(x => x.Initiator)
                .Include(x => x.Executor)
                .Include(x => x.Project)
                .FirstAsync(x => x.Id == result);

            Assert.Equal("K-02", insertedTicket.Project.Name);
            Assert.Equal("Алексей", insertedTicket.Initiator.FirstName);
        }
    }
}
