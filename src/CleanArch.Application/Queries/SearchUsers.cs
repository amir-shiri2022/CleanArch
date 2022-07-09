using CleanArch.Application.Dto;
using CleanArch.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Queries
{
    public class SearchUsers : IQuery<IEnumerable<SearchUsersResultDto>>
    {
        public string SearchPhrase { get; set; }
    }
}
