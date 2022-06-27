using CleanArch.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Exceptions
{
    public class EmptyUserIdException : CleanArchException
    {
        public EmptyUserIdException() : base("User Id cannot be empty.")
        {
        }
    }
}
