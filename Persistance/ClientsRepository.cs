using NextSugarCat.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NextSugarCat.Core;

namespace NextSugarCat.Persistance
{
    public class ClientsRepository : IClientRepository
    {
        private readonly BakeryDbContext context;

        public ClientsRepository(BakeryDbContext context)
        {
            this.context = context;
        }
        public async Task<Client> GetClientAsync(string id)
        {
            return await context.Clients
                .Include(c => c.Identity)
                .SingleOrDefaultAsync(c => c.Identity.Id == id);
        }

        public async Task<ICollection<Client>> GetClientsAsync()
        {
            return await context.Clients
                .Include(c => c.Identity)
                .ToArrayAsync();
        }
    }
}
