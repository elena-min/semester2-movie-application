using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private string username;
        private string email;
        private string password;
        private Gender gender;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public byte[] ProfilePicture { get; set; }

        public string Role { get; set; }
        public Person() { }

        public Person(string firstName, string lastName, string username, string email, string password, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            Gender = gender;
        }
        public Person(string firstName, string lastName, string username, string email, string password, Gender gender, string salt)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            Gender = gender;
            Salt = salt;    
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
            return $"{this.GetId()}- {Username} - {FirstName} {LastName}";
        }
    }
}
