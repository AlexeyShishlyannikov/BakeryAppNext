using NextSugarCat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BakeryDbContext context;

        public UnitOfWork(BakeryDbContext context)
        {
            this.context = context;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
