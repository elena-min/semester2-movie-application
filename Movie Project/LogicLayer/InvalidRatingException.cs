using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class InvalidRatingException : Exception
    {
        //This is set as a default message
        public InvalidRatingException() : base("Invalid rating. Rating must be between 1 and 10.")
        {
        }

        //This constructor lets me create a custom message when calling it
        public InvalidRatingException(string message) : base(message)
        {
        }
    }
}
