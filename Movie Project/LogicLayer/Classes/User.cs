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

        public string FirstName { get; }
        public string LastName { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; }
        public Gender Gender { get;  }
        public string ProfileDescription { get; }  

        public User() { }
        public User(string firstName, string lastName, string username, string email, string password, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            Gender = gender;
        }
        public User(string firstName, string lastName, string username, string email, string password, Gender gender, string profileDescription)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            Gender = gender;
            ProfileDescription = profileDescription;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return this.id;
        }
        public void AddFavoriteMediaItem(MediaItem mediaItem)
        {
            if (!favoriteMediaItems.Contains(mediaItem))
            {
                favoriteMediaItems.Add(mediaItem);
            }
        }
        public void RemoveFavoriteMediaItem(int mediaItemID)
        {
            foreach(MediaItem mediaItem in favoriteMediaItems)
            {
                if(mediaItem.GetId() == mediaItemID)
                {
                    favoriteMediaItems.Remove(mediaItem);
                }
            }
        }
        public MediaItem[] GetAllFavorite()
        {
            return favoriteMediaItems.ToArray();
        }

        public override string ToString()
        {
            return $"{this.GetId()}: {this.username} - {this.firstName} {this.lastName}";
        }
     }
}
