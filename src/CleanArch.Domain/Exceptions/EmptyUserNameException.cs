using CleanArch.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Exceptions
{
    public class EmptyUserNameException : CleanArchException
    {
        public EmptyUserNameException() : base("User name cannot be empty.")
        {
        }
    }
}
