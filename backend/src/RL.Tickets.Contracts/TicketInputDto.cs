using RL.Tickets.Domain;
using System;

namespace RL.Tickets.Contracts
{
    public class TicketInputDto
    {
        public string Description { get; set; }
        public int InitiatorId { get; set; }
        public int ProjectId { get; set; }
        public Status Status { get; set; }
        public DateTimeOffset? DateOfClosing { get; set; }
        public int? ExecutorId { get; set; }
    }
}
