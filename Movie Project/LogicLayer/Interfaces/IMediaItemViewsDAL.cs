using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IMediaItemViewsDAL
    {
        void UpdateViewsCount(int mediaID, DateTime currentDate);
        Dictionary<DateTime, int> GetAllViewsByMediaItem(int mediaID);
        string RemoveMediaItemViews(int mediaID);

    }
}
