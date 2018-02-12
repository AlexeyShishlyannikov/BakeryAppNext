using Microsoft.EntityFrameworkCore;
using NextSugarCat.Core;
using NextSugarCat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Persistance
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BakeryDbContext context;

        public OrderRepository(BakeryDbContext context)
        {
            this.context = context;
        }

        public async Task<Order> GetOrderAsync(string id)
        {
            return await context.Orders
                .Include(o => o.Client)
                .Include(o => o.MenuItems)
                .SingleOrDefaultAsync(o => o.Client.IdentityId == id);
        }

        public async Task<ICollection<Order>> GetUserOrdersAsync(string id)
        {
            return await context.Orders
                .Include(o => o.Client)
                .Where(o => o.Client.IdentityId == id)
                .Include(o => o.MenuItems)
                .ToArrayAsync();
        }

        public async Task AddAsync(Order order)
        {
            await context.Orders.AddAsync(order);
        }

        public void Remove(Order order)
        {
            context.Remove(order);
        }

        public async Task<ICollection<Order>> GetOrdersAsync()
        {
            return await context.Orders
                .Include(o => o.MenuItems)
                .Include(o => o.Client)
                .ToArrayAsync();
        }
    }
}
