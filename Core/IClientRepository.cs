using NextSugarCat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Core
{
    public interface IClientRepository
    {
        Task<Client> GetClientAsync(string id);
        Task<ICollection<Client>> GetClientsAsync();
    }
}
