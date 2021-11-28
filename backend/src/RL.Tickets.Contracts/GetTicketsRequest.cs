using System;
using RL.Tickets.Domain;

namespace RL.Tickets.Contracts
{
    public class GetTicketsRequest
    {
        public DateTimeOffset? Date { get; set; }
        public Status? Status { get; set; }
        public int? Initiator { get; set; }
    }
}
