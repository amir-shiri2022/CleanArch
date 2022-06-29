using CleanArch.Shared.Abstractions.Domain;
using CleanArch.Domain.ValueObjects;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Events;

namespace CleanArch.Domain.Entities
{
    public class User : AggregateRoot<UserId>
    {
        public UserId Id { get; }
        private UserName _name;
        private readonly LinkedList<UserAddress> _addresses = new();
        private User() { }
        private User(UserId id, UserName name,LinkedList<UserAddress> addresses) : this(id, name)
        {
            _addresses = addresses;
        }
        internal User(UserId id, UserName name)
        {
            Id = id;
            _name = name;
        }
        public void AddAddress(UserAddress userAddress)
        {
            var alreadyExists = _addresses.Any(a => a.Address == userAddress.Address);
            if (alreadyExists)
                throw new UserAddressAlreadyExistsException(_name, userAddress.Address);
            _addresses.AddLast(userAddress);
            AddEvents(new UserAddressAdded(this, userAddress));
        }
        public void AddAddresses(IEnumerable<UserAddress> userAddress)
        {
            foreach (var address in userAddress)
            {
                AddAddress(address);
            }
        }
        public void RemoveAddress(string address)
        {
            var userAddress = GetAdderss(address);
            _addresses.Remove(userAddress);
            AddEvents(new UserAddressRemoved(this,userAddress));
        }
        
        private UserAddress GetAdderss(string address)
        {
            var userAddress = _addresses.SingleOrDefault(a => a.Address == address);
            if (userAddress is null)
                throw new UserAddressNotFoundException(address);

            return userAddress;
        }
    }
}
