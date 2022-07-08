using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.EF.Models
{
    public class UserReadModel
    {
        public Guid Id { get; set; }
        public int  Version { get; set; }
        public string Name { get; set; }
        public ICollection<UserAddressReadModel> UserAddresses { get; set; }
    }
}
