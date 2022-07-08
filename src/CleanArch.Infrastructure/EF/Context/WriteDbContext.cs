using CleanArch.Domain.Entities;
using CleanArch.Domain.ValueObjects;
using CleanArch.Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.EF.Context
{
    public class WriteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public WriteDbContext(DbContextOptions<WriteDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("cleanArch");
            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<User>(configuration);
            modelBuilder.ApplyConfiguration<UserAddress>(configuration);
            base.OnModelCreating(modelBuilder);
        }
    }
}
