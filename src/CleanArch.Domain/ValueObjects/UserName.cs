using CleanArch.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.ValueObjects
{
    public record UserName
    {
        public string Value { get; }
        public UserName(string value)
        {
            if (value == null)
                throw new EmptyUserNameException();
            Value = value;
        }
        public static implicit operator string(UserName name)
            => name.Value;
        public static implicit operator UserName(string name)
            => new(name);
    }
}
