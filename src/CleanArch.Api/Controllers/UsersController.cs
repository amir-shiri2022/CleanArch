using CleanArch.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    public class UsersController : BaseController
    {
        public async Task<ActionResult> Post([FromBody] UserDto command)
        {
            return Ok(command);
        }
    }
}
