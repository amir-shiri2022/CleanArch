using CleanArch.Domain.Entities;
using CleanArch.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Factories
{
    public interface IUserFactory
    {
        User Create(UserId id, UserName userName);
        User CreateWithAddress(UserId id, UserName userName, UserAddress address);
        User CreateWithAddresses(UserId id, UserName userName, LinkedList<UserAddress> addresseses);
    }


}
