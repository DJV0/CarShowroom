using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.BLL.Interfaces
{
    public interface IHttpClientServiceImplementation
    {
        Task<string> GetCarImageUrl(string carName);
    }
}
