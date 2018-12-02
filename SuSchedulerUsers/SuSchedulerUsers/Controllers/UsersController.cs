using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuSchedulerUsers.Dtos;
using SuSchedulerUsers.Services;

namespace SuSchedulerUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _usersService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}