using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.SortingStrategy
{
    public class RatingSortingStrategy : ISortingStrategy
    {
        public RatingSortingStrategy() { }


        public MediaItem[] GetSortedMediaItems(List<MediaItem> mediaItems)
        {
            return mediaItems.OrderByDescending(item => item.CalculateAverageRating()).ToArray();

        }
    }
}
