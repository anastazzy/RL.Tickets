using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RL.Tickets.Contracts;
using RL.Tickets.DataAccess;
using RL.Tickets.Domain;

namespace RL.Tickets.App
{
    public class UserService : IUserService
    {
        private readonly TicketsDbContext _dbContext;

        public UserService(TicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private Task<UserDto[]> GetUsersAsync(IQueryable<User> query)
        {
            return query.Select(x => new UserDto()
            {
                Id = x.Id,
                Name = x.SecondName + " " + x.FirstName + " " + x.Patronymic
            }).ToArrayAsync();

        }
        public async Task<UserDto[]> GetListOfUsersAsync()
        {
            return await GetUsersAsync(_dbContext.Users);
        }

        public async Task<UserDto[]> GetListOfInitiatorsAsync()
        {
            return await GetUsersAsync(_dbContext.Users.Where(x => x.TicketsAsInitiator.Any()));
        }
    }
}
