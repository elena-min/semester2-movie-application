﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class Person
    {
        protected int id;
        protected string firstName;
        protected string lastName;
        protected string username;
        protected string email;
        protected string password;
        protected Gender gender;
        //public List<string> ValidationErrors { get; } = new List<string>();

        public string FirstName
        {
            get => firstName;
            set
            {
               // ValidationErrors.Clear(); 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name should not be empty!!!!!!");
                }
                 
                if (!value.Any(char.IsLetter))
                {
                    throw new ArgumentException("First name should contain at least one letter!");  }

                firstName = value;

                //if (ValidationErrors.Any())
                //{
                //    throw new ValidationException(ValidationErrors);
                //}
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name should not be empty!");
                }

                if (!value.Any(char.IsLetter))
                {
                    throw new ArgumentException("Last name should contain at least one letter!");
                }

                lastName = value;

                //if (ValidationErrors.Any())
                //{
                //    throw new ValidationException(ValidationErrors);
                //}
            }
        }
        public string Username
        {
            get => username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Username should not be empty!");
                }

                if (value.Length < 2)
                {
                    throw new Exception("Username should be at least 2 characters long.");
                }
                username = value;
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password should not be empty!");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentException("Password should be at least 2 characters long.");
                }
                password = value;
            }
        }
        public string Salt { get; set; }
        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email should not be empty!");
                }

                string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
                if (!Regex.IsMatch(value, emailPattern))
                {
                    throw new ArgumentException("Please enter a valid email address.");
                }

                email = value;
            }
        }
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
        public Person(string firstName, string lastName, string username, string email, string password, string salt, Gender gender)
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
