using System.Collections.Generic;
using SuSchedulerUsers.Dtos;
using System.Threading.Tasks;

namespace SuSchedulerUsers.Services
{
    public interface IUsersService
    {
        Task<User> GetUserAsync(int id);

        Task<IEnumerable<User>> GetCompanyUsersAsync(int companyId);

        Task<Company> GetCompanyAsync(int companyId);
    }
}
