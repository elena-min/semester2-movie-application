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
        void UpdateViewsCount(MediaItem mediaItem, DateTime currentDate);
        Dictionary<DateTime, int> GetAllViewsByMediaItem(MediaItem mediaItem);
        string RemoveMediaItemViews(MediaItem mediaItem);

    }
}
