using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RL.Tickets.Contracts;

namespace RL.Tickets.Host.Controllers
{
    [Route("api/initiators")]
    [ApiController]
    public class InitiatorServiceController
    {
        private readonly IUserService _service;

        public InitiatorServiceController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<UserDto[]> GetListInitiatorAsync()
        {
            return _service.GetListOfInitiatorsAsync();
        }
    }
}
