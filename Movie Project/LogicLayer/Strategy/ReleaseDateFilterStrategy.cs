using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Strategy
{
    public class ReleaseDateFilterStrategy : IFilterStrategy
    {

        public ReleaseDateFilterStrategy()
        {
        }
        public MediaItem[] GetFilteredMediaItems(List<MediaItem> mediaItems)
        {
            var orderedMediaItems = mediaItems.OrderByDescending(item => item.ReleaseDate);

            // Take the top 20 most recent media items
            MediaItem[] topMediaItems = orderedMediaItems.Take(20).ToArray();

            return topMediaItems;
        }
    }
}
