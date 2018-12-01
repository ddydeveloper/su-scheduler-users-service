using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuSchedulerUsers.Dtos;
using SuSchedulerUsers.Services;

namespace SuSchedulerUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public CompaniesController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{id}/users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(int id)
        {
            return Ok(await _usersService.GetCompanyUsersAsync(id));
        }
    }
}