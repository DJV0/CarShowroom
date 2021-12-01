using CarShowroom.Client.DTOs;
using CarShowroom.Client.Infrastructure.HttpClients.Interfaces;
using CarShowroom.Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderClient _orderClient;
        public OrderService(IOrderClient orderClient)
        {
            _orderClient = orderClient;
        }

        public async Task<bool> CreateOrder(OrderDTO order)
        {
            return await _orderClient.Create(order);
        }

        public async Task<bool> DeleteOrder(int id)
        {
            return await _orderClient.Delete(id);
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            return await _orderClient.GetById(id);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            return await _orderClient.GetAll();
        }

        public async Task<bool> UpdateOrder(int orderId, OrderDTO order)
        {
            return await _orderClient.Update(orderId, order);
        }
    }
}
