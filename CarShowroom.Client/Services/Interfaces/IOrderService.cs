using CarShowroom.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrders();
        Task<OrderDTO> GetOrderById(int id);
        Task<bool> CreateOrder(OrderDTO order);
        Task<bool> UpdateOrder(int orderId, OrderDTO order);
        Task<bool> DeleteOrder(int id);
    }
}
