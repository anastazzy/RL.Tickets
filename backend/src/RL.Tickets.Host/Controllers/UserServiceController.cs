using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RL.Tickets.Contracts;

namespace RL.Tickets.Host.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserServiceController
    {
        private readonly IUserService _service;

        public UserServiceController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<UserDto[]> GetListOdUsersAsync()
        {
            return _service.GetListOfUsersAsync();
        }
    }
}
