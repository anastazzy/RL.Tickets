using System.Collections.Generic;

namespace RL.Tickets.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
