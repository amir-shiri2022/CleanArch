using CleanArch.Application.Dto;
using CleanArch.Domain.Factories;
using CleanArch.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _factory;

        public UsersController(
            IUserRepository userRepository,
            IUserFactory factory
            )
        {
            _userRepository = userRepository;
            _factory = factory;
        }
        [HttpPost("Post")]
        public async Task<ActionResult> Post([FromBody] UserDto command)
        {
            var user = _factory.Create(command.Id, command.Name);
            await _userRepository.AddAsync(user);
            return Ok(user);
        }
    }
}
