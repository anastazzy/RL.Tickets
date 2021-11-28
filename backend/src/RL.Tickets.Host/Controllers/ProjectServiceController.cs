using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RL.Tickets.Contracts;

namespace RL.Tickets.Host.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectServiceController
    {
        private readonly IProjectService _service;

        public ProjectServiceController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<ProjectDto[]> GetListOfProjectsAsync()
        {
            return _service.GetListOfProjectAsync();
        }
    }
}
