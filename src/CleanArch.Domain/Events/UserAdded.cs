using CleanArch.Domain.Entities;
using CleanArch.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Events
{
    public record UserAdded(User User) : IDomainEvent;
    
}
