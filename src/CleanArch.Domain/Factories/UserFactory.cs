using CleanArch.Domain.Entities;
using CleanArch.Domain.ValueObjects;

namespace CleanArch.Domain.Factories
{
    public class UserFactory : IUserFactory
    {
        public User Create(UserId id, UserName userName)
       => new(id, userName);
        public User CreateWithAddress(UserId id, UserName userName, UserAddress addresses)
        {
            var user = new User(id, userName);
            user.AddAddress(addresses);
             return user;
        }
        public User CreateWithAddresses(UserId id, UserName userName, LinkedList<UserAddress> addresseses)
        {
            var user = new User(id, userName);
            user.AddAddresses(addresseses);
            return user;
        }
    }


}
