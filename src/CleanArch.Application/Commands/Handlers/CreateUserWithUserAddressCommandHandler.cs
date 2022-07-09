using CleanArch.Domain.Factories;
using CleanArch.Domain.Repositories;
using CleanArch.Domain.ValueObjects;
using CleanArch.Shared.Abstractions.Commands;

namespace CleanArch.Application.Commands.Handlers
{
    public class CreateUserWithUserAddressCommandHandler : ICommandHandler<CreateUserWithAddress>
    {
        private readonly IUserRepository _repository;
        private readonly IUserFactory _factory;
        public CreateUserWithUserAddressCommandHandler(IUserRepository repository, IUserFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task HandleAsync(CreateUserWithAddress command)
        {
            var (id, name, userAddressModel) = command;
            var userAddress = new UserAddress(userAddressModel.Address, userAddressModel.City, userAddressModel.PostalCode);
            var user = _factory.CreateWithAddress(id, name, userAddress);
            await _repository.AddAsync(user);
        }
    }
}
