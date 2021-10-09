using Carshowroom.DAL;
using CarShowroom.BLL.Interfaces;
using CarShowroom.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.BLL.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        public OrderService(CarShowroomDbContext context) : base(context) { }
        public override IEnumerable<Order> GetAll()
        {
            var orderList = base.GetAll();
            foreach (var order in orderList)
            {
                context.Entry(order).Reference(o => o.Car).Load();
            }
            return orderList;
        }
        public override Order Get(int id)
        {
            var order = base.Get(id);
            context.Entry(order).Reference(o => o.Car).Load();
            return order;
        }
    }
}
