using CleanArch.Application.Dto;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Factories;
using CleanArch.Domain.Repositories;
using CleanArch.Infrastructure.EF.Context;
using CleanArch.Infrastructure.EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _factory;
        private readonly ReadDbContext _readDbContext;
        public UsersController(
             IUserRepository userRepository
            , IUserFactory factory
            , ReadDbContext readDbContext)
        {
            _userRepository = userRepository;
            _factory = factory;
            _readDbContext = readDbContext;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto command)
        {
            var user = _factory.Create(command.Id, command.Name);
            await _userRepository.AddAsync(user);
            return Ok(user);
        }
        [HttpGet]
        public async Task<ActionResult<List<UserReadModel>>> Get([FromQuery] string SearchPhrase,CancellationToken cancellationToken)
        {
            var result = await _readDbContext.Users
                .Where(p => EF.Functions.ILike(p.Name, $"%{SearchPhrase}%"))
                .ToListAsync(cancellationToken);

            return OkOrNotFound(result);
        }
    }
}
