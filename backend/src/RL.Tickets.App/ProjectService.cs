using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RL.Tickets.Contracts;
using RL.Tickets.DataAccess;

namespace RL.Tickets.App
{
    public class ProjectService : IProjectService
    {
        private readonly TicketsDbContext _dbContext;

        public ProjectService(TicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProjectDto[]> GetListOfProjectAsync()
        {
            return await _dbContext.Projects.Select(x => new ProjectDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToArrayAsync();
        }
    }
}
