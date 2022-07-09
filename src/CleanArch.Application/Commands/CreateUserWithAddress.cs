using CleanArch.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Commands
{
    public record CreateUserWithAddress(Guid id, string name,UserAddressModel userAddress) : ICommand;
    
    public record UserAddressModel(string Address, string City,string PostalCode);
}