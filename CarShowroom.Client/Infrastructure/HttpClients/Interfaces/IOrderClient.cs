using CarShowroom.Client.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Client.Infrastructure.HttpClients.Interfaces
{
    public interface IOrderClient : IGenericClient<OrderDTO>
    {
    }
}
