using System;

namespace RL.Tickets.Domain
{
    public class Ticket
    {
        public long Id { get; set; }
        public DateTimeOffset DateOfCreation { get; set; } = DateTimeOffset.UtcNow;
        public string Description { get; set; }
        public int InitiatorId { get; set; }
        public int ProjectId { get; set; }
        public Status Status { get; set; }
        public DateTimeOffset? DateOfClosing { get; set; }
        public int? ExecutorId { get; set; }
        
        public Project Project { get; set; }
        public User Executor { get; set; }
        public User Initiator { get; set; }
    }
}
