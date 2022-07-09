using CleanArch.Application.Dto;
using CleanArch.Application.Queries;
using CleanArch.Infrastructure.EF.Context;
using CleanArch.Infrastructure.EF.Models;
using CleanArch.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.EF.Queries.Handlers
{
    public class SearchUsersHandler : IQueryHandler<SearchUsers, IEnumerable<SearchUsersResultDto>>
    {
        private readonly DbSet<UserReadModel> _users;
        public SearchUsersHandler(ReadDbContext context)
        {
            _users = context.Users;
        }
        public async Task<IEnumerable<SearchUsersResultDto>> HandleAsync(SearchUsers query)
        {
            var result = await _users
                .Where(p => Microsoft.EntityFrameworkCore.EF.Functions.ILike(p.Name, $"%{query.SearchPhrase}%"))
                .Select(u=>u.AsDto())
                .ToListAsync();

            return result;
        }
    }
}
