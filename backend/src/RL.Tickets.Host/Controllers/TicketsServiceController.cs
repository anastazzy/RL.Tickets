using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RL.Tickets.Contracts;

namespace RL.Tickets.Host.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketsServiceController
    {
        private readonly ITicketService _service;

        public TicketsServiceController(ITicketService service)
        {
            _service = service;
        }


        [HttpPost]
        public Task<long> CreateTicketAsync(TicketInputDto ticket)
        {
            return _service.CreateTicketAsync(ticket);
        }

        [HttpDelete("{id}")]
        public Task<bool> DeleteTicketAsync(int id)
        {
            return _service.DeleteTicketAsync(id);
        }

        [HttpPut("{id}")]
        public Task<bool> EditTicketAsync(int id, TicketInputDto ticket)
        {
            return _service.EditTicketAsync(id, ticket);
        }

        [HttpGet]
        public Task<TicketOutputDto[]> GetAllTicketsAsync([FromQuery]GetTicketsRequest request)
        {
            return _service.GetListOfTicketsAsync(request);
        }

    }
}
