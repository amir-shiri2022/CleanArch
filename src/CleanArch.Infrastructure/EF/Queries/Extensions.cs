using CleanArch.Application.Dto;
using CleanArch.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.EF.Queries
{
    public static class Extensions
    {
        public static SearchUsersResultDto AsDto(this UserReadModel readModel)
        {
            return new()
            {
                Name = readModel.Name
            };
        }
    }
}
