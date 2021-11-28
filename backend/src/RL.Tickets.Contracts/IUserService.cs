using System.Threading.Tasks;

namespace RL.Tickets.Contracts
{
    public interface IUserService
    {
        public Task<UserDto[]> GetListOfUsersAsync();
        public Task<UserDto[]> GetListOfInitiatorsAsync();
    }
}
