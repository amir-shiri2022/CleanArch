using CleanArch.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.ValueObjects
{
    public record UserAddress
    {
        public string Address { get; }
        public string City { get; }
        public string PostalCode { get; }
        public UserAddress(string address,string city,string postalCode)
        {
            if(address == null)
                throw new EmptyAddressException();
            Address = address; 
            City = city;
            PostalCode = postalCode;
        }
    }
}
