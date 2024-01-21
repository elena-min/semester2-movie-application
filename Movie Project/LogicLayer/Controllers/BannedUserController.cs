using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Controllers
{
    public class BannedUserController 
    {
        private IBannedUserDAL ibannedUserDAL;

        public BannedUserController(IBannedUserDAL ibannedUserDAL)
        {
            this.ibannedUserDAL = ibannedUserDAL;
        }

        public bool CheckIfUserIsBanned(User user)
        {
            return ibannedUserDAL.CheckIfUserIsBanned(user);
        }

        public string GetReasonForBanning(User user)
        {
            return ibannedUserDAL.GetReasonForBanning(user);
        }
        public DateTime? GetDateOfBanning(User user)
        {
            return ibannedUserDAL.GetDateOfBanning(user);
        }

        public bool BanUserAccount(User user, string reasonForBanning)
        {
            return ibannedUserDAL.BanUserAccount(user, reasonForBanning);
        }
        public string UnBanUserAccount(User user)
        {
            return ibannedUserDAL.UnBanUserAccount(user);

        }
        public User[] GetAllBannedUser()
        {
            return ibannedUserDAL.GetAllBannedUser();
        }

    }
}
