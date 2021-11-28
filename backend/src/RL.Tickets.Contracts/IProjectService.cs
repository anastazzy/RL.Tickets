using System.Threading.Tasks;

namespace RL.Tickets.Contracts
{
    public interface IProjectService
    {
        public Task<ProjectDto[]> GetListOfProjectAsync();

    }
}
