namespace CleanArch.Infrastructure.EF.Models
{
    public class UserAddressReadModel
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public UserReadModel User { get; set; }
    }
}
