using CleanArch.Domain.Entities;
using CleanArch.Domain.ValueObjects;
using CleanArch.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Events
{
    public record UserAddressAdded(User User, UserAddress UserAddress) : IDomainEvent;

}
