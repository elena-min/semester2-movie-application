﻿using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IUserDAL
    {
        bool InsertUser(User newUser);
        User GetUserByID(int id);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
        User[] GetAll();
        bool UpdateUser(User user);
        string DeleteUser(User user);
        bool SetProfilePicture(User user, byte[] imageArray);
        string GetProfilePicByID(User user);
    }
}
