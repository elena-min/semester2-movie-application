using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class InvalidAgeException : Exception
    {
        //This is set as a default message
        public InvalidAgeException() : base("Invalid age. Age must be between 18 and 60.")
        {
        }

        //This constructor lets me create a custom message when calling it
        public InvalidAgeException(string message) : base(message)
        {
        }
    }
}
