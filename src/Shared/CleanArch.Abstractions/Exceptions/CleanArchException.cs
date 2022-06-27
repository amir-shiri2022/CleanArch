using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Shared.Abstractions.Exceptions
{
    public class CleanArchException : Exception
    {
        protected CleanArchException(string message) : base(message) { }
    }
}
