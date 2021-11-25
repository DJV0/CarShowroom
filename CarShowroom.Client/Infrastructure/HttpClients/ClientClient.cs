using CarShowroom.Client.DTOs;
using CarShowroom.Client.Infrastructure.HttpClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarShowroom.Client.Infrastructure.HttpClients
{
    public class ClientClient : GenericClient<ClientDTO>, IClientClient
    {
        public ClientClient(HttpClient httpClient) : base(httpClient, "client")
        {

        }
    }
}
