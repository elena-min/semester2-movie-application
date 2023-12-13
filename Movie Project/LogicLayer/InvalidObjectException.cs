using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class InvalidObjectException : Exception
    {
        public InvalidObjectException(string message, Exception innerException)
        : base(message, innerException)
        {
        }
    }
}
