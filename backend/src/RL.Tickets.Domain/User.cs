using System.Collections.Generic;

namespace RL.Tickets.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }

        public IEnumerable<Ticket> TicketsAsExecutor { get; set; }
        public IEnumerable<Ticket> TicketsAsInitiator { get; set; }
    }
}
