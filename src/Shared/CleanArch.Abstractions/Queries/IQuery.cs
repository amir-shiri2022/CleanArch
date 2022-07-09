using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Shared.Abstractions.Queries
{
    //marker
    public interface IQuery { }

    public interface IQuery<TResult> : IQuery { }
}
