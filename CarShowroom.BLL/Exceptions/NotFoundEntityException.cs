using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.BLL.Exceptions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException() : base() { }
        public NotFoundEntityException(string message) : base(message) { }
    }
}
