using CleanArch.Domain.Entities;
using CleanArch.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArch.Infrastructure.EF.Config
{
    public class WriteConfiguration : IEntityTypeConfiguration<User> , IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            var userNameConvertor = new ValueConverter<UserName, string>(n => n.Value,
                n => new UserName(n));

            builder
                .Property(u => u.Id)
                .HasConversion(id => id.Value, id => new UserId(id));

            builder
               .Property(typeof(UserName), "_name")
               .HasConversion(userNameConvertor)
               .HasColumnName("Name");

            builder
                .HasMany(typeof(UserAddress), "_addresses");

            builder.ToTable("users");

        }

        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddresses");
            builder.Property<Guid>("Id");
            builder.Property(ua => ua.Address);
            builder.Property(ua => ua.PostalCode);
            builder.Property(ua => ua.City);
        }
    }
}
