using CleanArch.Domain.Entities;
using CleanArch.Domain.ValueObjects;
using CleanArch.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.EF.Config
{
    public class ReadConfiguration : IEntityTypeConfiguration<UserReadModel>, IEntityTypeConfiguration<UserAddressReadModel>
    {
        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.HasMany(u => u.UserAddresses)
                .WithOne(ua => ua.UserReadModel);     
        }

        public void Configure(EntityTypeBuilder<UserAddressReadModel> builder)
        {
            builder.ToTable("UserAddresses");
        }
    }
}
