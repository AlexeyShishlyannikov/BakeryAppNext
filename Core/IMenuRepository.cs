using NextSugarCat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Core
{
    public interface IMenuRepository
    {
        Task<MenuItem> GetMenuItem(int id);
        Task Add(MenuItem item);
        void Remove(MenuItem item);
        Task<ICollection<MenuItem>> GetMenu();
    }
}
