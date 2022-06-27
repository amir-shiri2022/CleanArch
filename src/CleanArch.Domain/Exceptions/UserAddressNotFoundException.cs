using CleanArch.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Exceptions
{
    public class UserAddressNotFoundException : CleanArchException
    {
        public UserAddressNotFoundException(string address) : base($"User address '{address}' was not found.")
        {
            Address = address;
        }

        public string Address { get; }
    }
}
