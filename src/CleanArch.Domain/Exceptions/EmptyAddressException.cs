using CleanArch.Shared.Abstractions.Exceptions;

namespace CleanArch.Domain.Exceptions
{
    public class EmptyAddressException : CleanArchException
    {
        public EmptyAddressException() : base("User Address cannot be empty.")
        {
        }
    }
}
