using CleanArch.Domain.Entities;
using CleanArch.Domain.ValueObjects;

namespace CleanArch.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(UserId id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
