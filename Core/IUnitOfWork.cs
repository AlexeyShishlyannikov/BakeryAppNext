using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Core
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
