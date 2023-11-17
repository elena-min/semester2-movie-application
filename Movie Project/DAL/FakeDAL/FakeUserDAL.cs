using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.FakeDAL
{
    public class FakeUserDAL : IUserDAL
    {
        private List<User> users;
        public FakeUserDAL()
        {
            users = new List<User>();
        }
        public bool InsertUser(User newUser)
        {
            if (users.FirstOrDefault(x => x.Username == newUser.Username) == null)
            {
                users.Add(newUser);
                return true;
            }
            else
            { return false; }
        }
        

        public User[] GetAll()
        {
            return users.ToArray();
        }

        public User GetUserByEmail(string email)
        {
            return users.FirstOrDefault(x => x.Email == email);
        }

        public User GetUserByID(int id)
        {
            return users.FirstOrDefault(x => x.GetId() == id);
        }

        public User GetUserByUsername(string username)
        {
            return users.FirstOrDefault(x => x.Username == username);
        }

        public bool UpdateUser(User user)
        {
            var existingUser = users.FirstOrDefault(e => e.GetId() == user.GetId());
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Gender = user.Gender;
                existingUser.ProfileDescription = user.ProfileDescription;

                return true;
            }
            else
            {
                return false;
            }
        }
        public string DeleteUser(int id)
        {
            var userToDelete = users.FirstOrDefault(e => e.GetId() == id);
            if (userToDelete != null)
            {
                users.Remove(userToDelete);
                return "User deleted successfully";
            }
            else
            {
                return "No data found.";
            }
        }

        public bool SetProfilePicture(int id, byte[] imageArray)
        {
            var userToUpdate = users.FirstOrDefault(u => u.GetId() == id);

            if (userToUpdate != null && imageArray != null)
            {
                userToUpdate.ProfilePicture = imageArray;
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetProfilePicByID(int id)
        {
            var user = users.FirstOrDefault(u => u.GetId() == id);

            if (user != null && user.ProfilePicture != null)
            {
                return Convert.ToBase64String(user.ProfilePicture);
            }
            else
            {
                return null;
            }
        }

        
    }
}
