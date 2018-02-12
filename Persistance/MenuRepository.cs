using Microsoft.EntityFrameworkCore;
using NextSugarCat.Core;
using NextSugarCat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Persistance
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BakeryDbContext context;

        public MenuRepository(BakeryDbContext context)
        {
            this.context = context;
        }
        public async Task<MenuItem> GetMenuItem(int id)
        {
            return await context.MenuItems
                .Include(i => i.Ingredients)
                    .ThenInclude(mi => mi.Ingredient)
                .Include(i => i.Price)
                    .ThenInclude(p => p.PricePerSet)
                .Include(i => i.Photos)
                .SingleOrDefaultAsync(i => i.Id == id);
        }
        public async Task Add(MenuItem item)
        {
            await context.MenuItems.AddAsync(item);
        }
        public void Remove(MenuItem item)
        {
            context.Remove(item);
        }
        public async Task<List<MenuItem>> GetMenu()
        {
            return await context.MenuItems
                .Include(i => i.Ingredients)
                    .ThenInclude(mi => mi.Ingredient)
                .Include(i => i.Price)
                    .ThenInclude(p => p.PricePerSet)
                .Include(i => i.Photos)
                .ToListAsync();
        }
    }
}
