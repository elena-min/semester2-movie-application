using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class User : Person
    {
       
        private string profileDescription;
        private List<MediaItem> favoriteMediaItems;
        public string ProfileDescription { get; set; }
        public byte[] ProfilePicture { get; set; }
        public FavoriteMediaItem FavoriteMediaItem { get; set; }

        public bool IsBanned { get; set; }
        public string ReasonForDeleting { get; set; }

        public User() { }
        public User(string firstName, string lastName, string username, string email, string password, Gender gender) : base(firstName, lastName, username, email, password, gender)
        {
            Role = "User";
            IsBanned = false;
        }

        public User(string firstName, string lastName, string username, string email, string password, string salt,  Gender gender) : base(firstName, lastName, username, email, password, salt, gender)
        {
            Role = "User";
            IsBanned = false;
        }
        public User(string firstName, string lastName, string username, string email, string password, string salt, Gender gender, string profileDescription) : base(firstName, lastName, username, email, password,salt, gender)
        {

            ProfileDescription = profileDescription;
            Role = "User";
            IsBanned = false;
        }

        public void SetUserAsBanned(string reason)
        {
            IsBanned = true;
            ReasonForDeleting = reason;
        }
        public override string ToString()
        {
            return $"{this.GetId()}- {Username} - {FirstName} {LastName}";
        }
     }
}
