using CleanArch.Application.Commands;
using CleanArch.Application.Dto;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Factories;
using CleanArch.Domain.Repositories;
using CleanArch.Infrastructure.EF.Context;
using CleanArch.Infrastructure.EF.Models;
using CleanArch.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ReadDbContext _readDbContext;
        public UsersController(ReadDbContext readDbContext, ICommandDispatcher commandDispatcher)
        {
            _readDbContext = readDbContext;
            _commandDispatcher = commandDispatcher;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserWithAddress command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
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
