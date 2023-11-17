using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Controllers
{
    public class UserController
    {
        private IUserDAL iuserDAL;
        public UserController(IUserDAL userDAL)
        {
            this.iuserDAL = userDAL;
        }
        public bool InsertUser(User newUser)
        {
            return iuserDAL.InsertUser(newUser);   
        }
        public User GetUserByID(int id)
        {
            return iuserDAL.GetUserByID(id);
        }
        public User GetUserByUsername(string username)
        {
            return iuserDAL.GetUserByUsername(username);
        }
        public User GetUserByEmail(string email)
        {
            return iuserDAL.GetUserByEmail(email);
        }
        public User[] GetAll()
        {
            return iuserDAL.GetAll();
        }
            
        public bool UpdateUser(User user)
        {
            return iuserDAL.UpdateUser(user);
        }
        public string DeleteUser(int id)
        {
            return iuserDAL.DeleteUser(id);
        }
        public bool SetProfilePicture(int id, byte[] imageArray)
        {
            return iuserDAL.SetProfilePicture(id, imageArray);
        }
        public string GetProfilePicByID(int id)
        {
            return iuserDAL.GetProfilePicByID(id);

        }
      
    }
}
