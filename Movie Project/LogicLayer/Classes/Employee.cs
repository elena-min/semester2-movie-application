using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class Employee
    {
        private int id;
        private string firstName;
        private string lastName;
        private string username;
        private string email;
        private string password;
        private Gender gender;


        public Employee() { }

        public Employee(string firstName, string lastName, string username, string email, string password, Gender gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.email = email;
            this.password = password;
            this.gender = gender;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return this.id;
        }
    
        public override string ToString()
        {
            return $"{this.GetId()}: {this.username} - {this.firstName} {this.lastName}";
        }
    }
}
