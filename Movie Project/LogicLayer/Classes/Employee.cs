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
        private int age;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email {  get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }    


        public Employee() { }

        public Employee(string firstName, string lastName, string username, string email, string password, Gender gender, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            Gender = gender;
            Age = age;
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
