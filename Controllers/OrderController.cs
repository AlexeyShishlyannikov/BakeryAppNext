using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NextSugarCat.Controllers.Resources;
using NextSugarCat.Core;
using NextSugarCat.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers
{
    [Route("/api/orders")]
    public class OrderController : Controller
    {
        private readonly IMenuRepository menuRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;

        public OrderController(
            IMenuRepository menuRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOrderRepository orderRepository)
        {
            this.menuRepository = menuRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrderSaveDTO orderDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = mapper.Map<OrderSaveDTO, Order>(orderDTO);

            await orderRepository.AddAsync(order);
            await unitOfWork.SaveChangesAsync();

            order = await orderRepository.GetOrderAsync(order.IdentityId);

            var result = mapper.Map<Order, OrderDTO>(order);

            return Ok(result);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetUserOrders(string clientId)
        {
            var orders = await orderRepository.GetUserOrdersAsync(clientId);

            if (orders == null)
                return NotFound("You have no orders");

            return Ok(mapper.Map<ICollection<Order>, ICollection<OrderDTO>>(orders));
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteOrder(string clientId)
        {
            var order = await orderRepository.GetOrderAsync(clientId);

            if (order == null)
                return NotFound("Order was not found");

            orderRepository.Remove(order);
            await unitOfWork.SaveChangesAsync();

            return Ok($"Order {order.Id} was deleted.");
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetOrder(string clientId)
        {
            var order = await orderRepository.GetOrderAsync(clientId);

            if (order == null)
                return NotFound("Order was not found");

            var result = mapper.Map<Order, OrderDTO>(order);

            return Ok(result);
        }
    }
}
