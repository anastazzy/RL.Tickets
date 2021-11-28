using System;
using Microsoft.EntityFrameworkCore;
using RL.Tickets.DataAccess;

namespace LR.Tickets.UnitTests
{
    public class WithDataBaseTest
    {
        protected TicketsDbContext DbContext { get; }
        protected WithDataBaseTest()
        {
           var options = new DbContextOptionsBuilder<TicketsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
           DbContext = new TicketsDbContext(options);
           DbContext.Database.EnsureCreated();
        }
    }
}
