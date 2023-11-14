using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class User
    {
        private int id;
        private string firstName;
        private string lastName;
        private string username;
        private string email;
        private string password;
        private Gender gender;
        private string profileDescription;
        private List<MediaItem> favoriteMediaItems;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; } 

        public string Email { get; }
        public Gender Gender { get; set; }
        public string ProfileDescription { get; set; }
        public FavoriteMediaItem FavoriteMediaItem { get; set; }

        public User() { }
        public User(string firstName, string lastName, string username, string email, string password, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            Gender = gender;
            FavoriteMediaItem = new FavoriteMediaItem(username);
        }
        public User(string firstName, string lastName, string username, string email, string password, string salt,  Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            Salt = salt;
            Gender = gender;
            FavoriteMediaItem = new FavoriteMediaItem(username);
        }
        public User(string firstName, string lastName, string username, string email, string password, string salt, Gender gender, string profileDescription)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            Salt = salt;
            Gender = gender;
            ProfileDescription = profileDescription;
            FavoriteMediaItem = new FavoriteMediaItem(username);
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
            return $"{this.GetId()}: {Username} - {FirstName} {LastName}";
        }
     }
}
