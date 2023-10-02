using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : IUserDAL
    {
        public void InsertUser(User newUser)
        {
        }
        public User GetUserByID(int id)
        {
            return new User();
        }
        public User GetUserByUsername(string username)
        {
            return new User();

        }
        public User GetUserByEmail(string email)
        {
            return new User();

        }
        public User[] GetAll()
        {
            return new User[6];
        }

        public void UpdateUser(User user)
        {
        }
        public void DeleteUser(int id)
        {
        }
    }
}
