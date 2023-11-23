using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class Employee : Person
    {

        private int age;
        public int Age { get; set; }
        public byte[] ProfilePicture { get; set; }


        public Employee() { }

        public Employee(string firstName, string lastName, string username, string email, string password, Gender gender, int age) : base(firstName, lastName, username, email, password, gender)
        {
            Age = age;
            Role = "Employee";
        }
        public Employee(string firstName, string lastName, string username, string email, string password, Gender gender, int age, string salt) : base(firstName, lastName, username, email, password, gender, salt)
        {
            Age = age;
            Role = "Employee";
        }
        public override string ToString()
        {
            return $"{this.GetId()}- {Username} - {FirstName} {LastName}";
        }
    }
}
