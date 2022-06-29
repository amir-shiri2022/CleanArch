using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Domain.ValueObjects;
using CleanArch.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly WriteDbContext _writeDbContext;
        public UserRepository(WriteDbContext writeDbContext)
        {
            _users = writeDbContext.Users;
            _writeDbContext = writeDbContext;
        }
        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _writeDbContext.SaveChangesAsync();  
        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<User> GetAsync(UserId id)
        => _users.Include("_addresses").SingleOrDefaultAsync(a => a.Id == id);

        public async Task UpdateAsync(User user)
        {
            _users.Update(user);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
