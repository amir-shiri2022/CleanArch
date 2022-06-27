using CleanArch.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Exceptions
{
    public class UserAddressAlreadyExistsException : CleanArchException
    {
        public UserAddressAlreadyExistsException(string userName,string addressName)
            : base($"User name :'{userName}' already defined address '{addressName}'")
        {
            UserName = userName;
            AddressName = addressName;
        }

        public string UserName { get; }
        public string AddressName { get; }
    }
}
