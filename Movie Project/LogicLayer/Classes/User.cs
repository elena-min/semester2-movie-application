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

        public string Username {  get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User() { }
        public User(string firstName, string lastName, string username, string email, string password, Gender gender, string profileDescription)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            Username = username;
            this.email = email;
            this.password = password;
            this.gender = gender;
            this.profileDescription = profileDescription;
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
