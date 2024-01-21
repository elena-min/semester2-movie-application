using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IBannedUserDAL
    {
        bool CheckIfUserIsBanned(User user);

        string GetReasonForBanning(User user);
        DateTime? GetDateOfBanning(User user);

        bool BanUserAccount(User user, string reasonForBanning);
        string UnBanUserAccount(User user);
        User[] GetAllBannedUser();

    }
}
