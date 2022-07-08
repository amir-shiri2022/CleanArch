using CleanArch.Infrastructure.EF.Config;
using CleanArch.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.EF.Context
{
    public class ReadDbContext : DbContext
    {
        public DbSet<UserReadModel> Users { get; set; }
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base( options )
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("cleanArch");
            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<UserReadModel>(configuration);
            modelBuilder.ApplyConfiguration<UserAddressReadModel>(configuration);

            base.OnModelCreating(modelBuilder);
        }
    }
}
