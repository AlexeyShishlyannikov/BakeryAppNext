using NextSugarCat.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextSugarCat.Core
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderAsync(string id);
        Task AddAsync(Order order);
        void Remove(Order order);
        Task<ICollection<Order>> GetUserOrdersAsync(string id);
        Task<ICollection<Order>> GetOrdersAsync();
    }
}
