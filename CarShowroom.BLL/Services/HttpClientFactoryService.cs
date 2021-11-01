using CarShowroom.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace CarShowroom.BLL.Services
{
    public class HttpClientFactoryService : IHttpClientServiceImplementation
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly XmlSerializer _serializer;
        public HttpClientFactoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _serializer = new XmlSerializer(typeof(string), new XmlRootAttribute() { Namespace = "http://carimagery.com/" });
        }

        public async Task<string> GetCarImageUrl(string carName)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string ImageUrl;

            using (var responce = await httpClient.GetAsync($"http://www.carimagery.com/api.asmx/GetImageUrl?searchTerm={carName}",
                HttpCompletionOption.ResponseHeadersRead))
            {
                responce.EnsureSuccessStatusCode();
                var stream = await responce.Content.ReadAsStreamAsync();
                ImageUrl = (string)_serializer.Deserialize(stream);
            }

            return ImageUrl;
        }
    }
}
