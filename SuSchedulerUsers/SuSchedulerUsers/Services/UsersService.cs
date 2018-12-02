using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using SuSchedulerUsers.Dtos;
using SuSchedulerUsers.Settings;
using SuSchedulerUsers.Sql;

namespace SuSchedulerUsers.Services
{
    public class UsersService : IUsersService
    {
        private readonly ConnectionStrings _connectionStrings;

        public UsersService(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public async Task<User> GetUserAsync(int id)
        {
            IEnumerable<User> result;
            using (var conn = new SqlConnection(_connectionStrings.UsersDb))
            {
                var param = new DynamicParameters();
                param.Add("@UserId", id, DbType.Int32, ParameterDirection.Input);

                result = await conn.QueryAsync<User, Company, Position, User>(GetRequests.GetUser,
                    (user, company, position) =>
                    {
                        user.Company = company;
                        user.Position = position;

                        return user;
                    }, param);
            }

            return result.SingleOrDefault();
        }

        public async Task<IEnumerable<User>> GetCompanyUsersAsync(int companyId)
        {
            IEnumerable<User> result;
            using (var conn = new SqlConnection(_connectionStrings.UsersDb))
            {
                var param = new DynamicParameters();
                param.Add("@CompanyId", companyId, DbType.Int32, ParameterDirection.Input);

                result = await conn.QueryAsync<User, Company, Position, User>(GetRequests.GetCompanyUsers,
                    (user, company, position) =>
                    {
                        user.Company = company;
                        user.Position = position;

                        return user;
                    }, param);
            }

            return result;
        }

        public async Task<Company> GetCompanyAsync(int companyId)
        {
            Company result;
            using (var conn = new SqlConnection(_connectionStrings.UsersDb))
            {
                var param = new DynamicParameters();
                param.Add("@Id", companyId, DbType.Int32, ParameterDirection.Input);

                result = await conn.QuerySingleAsync<Company>(GetRequests.GetCompany, param);
            }

            return result;
        }
    }
}
