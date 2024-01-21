using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.FakeDAL
{
    public class FakeBannedUserDAL : IBannedUserDAL
    {
        private List<User> bannedUsers;
        public FakeBannedUserDAL()
        {
            bannedUsers = new List<User>();
        }

        public bool BanUserAccount(User user, string reasonForBanning)
        {
            if (user != null)
            {
                if (!bannedUsers.Contains(user))
                {
                    user.SetUserAsBanned(reasonForBanning);
                    bannedUsers.Add(user);
                    return true;
                }
                else
                { return false; }
            }
            else
            {
                throw new Exception("Database error");

            }
            
        }

        public bool CheckIfUserIsBanned(User user)
        {
            if(user != null)
            {
                if (bannedUsers.FirstOrDefault(x => x.GetId() == user.GetId()) != null)
                {
                    return true;
                }
                else
                { return false; }
            }
            else
            {
                throw new Exception("Database error");

            }
        }
        
        public string GetReasonForBanning(User user)
        {
            if (user != null)
            {
                var selcteduser = bannedUsers.FirstOrDefault(u => u == user);

                if (selcteduser != null && selcteduser.ReasonForDeleting != null)
                {
                    return selcteduser.ReasonForDeleting;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception("Database error");

            }
        }

        public DateTime? GetDateOfBanning(User user)
        {
            throw new NotImplementedException();
        }

        public string UnBanUserAccount(User user)
        {
            if (user != null)
            {
                if (bannedUsers.FirstOrDefault(x => x.GetId() == user.GetId()) != null)
                {
                    user.SetUserAsUnBanned();
                    bannedUsers.Remove(user);
                    return "User unbanned successfully";
                }
                else
                {
                    return "No data found.";
                }
            }
            else
            {
                throw new Exception("Database error");

            }
            
        }

        public User[] GetAllBannedUser()
        {
            return bannedUsers.ToArray();
        }
    }
}
