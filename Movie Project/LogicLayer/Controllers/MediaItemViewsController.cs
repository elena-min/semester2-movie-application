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

        public void UpdateViewsCount(int mediaID, DateTime currentDate)
        {
            this.imediaItemViewsDAL.UpdateViewsCount(mediaID, currentDate);
        }
        public Dictionary<DateTime, int> GetAllViewsByMediaItem(int mediaID)
        {
            return this.imediaItemViewsDAL.GetAllViewsByMediaItem(mediaID);
        }
        public string RemoveMediaItemViews(int mediaID)
        {
            return this.imediaItemViewsDAL.RemoveMediaItemViews(mediaID);
        }

    }
}
