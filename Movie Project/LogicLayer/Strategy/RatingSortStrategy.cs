using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Strategy
{
    public class RatingSortStrategy : IFilterStrategy
    {
        public RatingSortStrategy() { }

        public MediaItem[] GetFilteredMediaItems(List<MediaItem> mediaItems)
        {
            return mediaItems.OrderByDescending(item => item.CalculateAverageRating()).ToArray();
        }
    }
}
