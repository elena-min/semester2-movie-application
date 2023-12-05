using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Controllers
{
    public class MediaItemViewsController
    {
        private IMediaItemViewsDAL imediaItemViewsDAL;
        public MediaItemViewsController(IMediaItemViewsDAL mediaItemViewsDAL)
        {
            this.imediaItemViewsDAL = mediaItemViewsDAL;
        }

        public void UpdateViewsCount(MediaItem mediaItem, DateTime currentDate)
        {
            this.imediaItemViewsDAL.UpdateViewsCount(mediaItem, currentDate);
        }
        public Dictionary<DateTime, int> GetAllViewsByMediaItem(MediaItem mediaItem)
        {
            return this.imediaItemViewsDAL.GetAllViewsByMediaItem(mediaItem);
        }
        public string RemoveMediaItemViews(MediaItem mediaItem)
        {
            return this.imediaItemViewsDAL.RemoveMediaItemViews(mediaItem);
        }

    }
}
