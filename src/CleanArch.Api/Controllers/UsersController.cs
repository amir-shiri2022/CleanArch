using CleanArch.Application.Commands;
using CleanArch.Application.Dto;
using CleanArch.Application.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Factories;
using CleanArch.Domain.Repositories;
using CleanArch.Infrastructure.EF.Context;
using CleanArch.Infrastructure.EF.Models;
using CleanArch.Shared.Abstractions.Commands;
using CleanArch.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public UsersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserWithAddress command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SearchUsersResultDto>>> Get([FromQuery] SearchUsers query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }
    }
}
