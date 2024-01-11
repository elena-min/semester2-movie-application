using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.SortingStrategy
{
    public class ReleaseDateSortingStrategy : ISortingStrategy
    {
        private readonly bool _descending;
        public ReleaseDateSortingStrategy(bool descending = false)
        {
            _descending = descending;
        }

        public MediaItem[] GetSortedMediaItems(List<MediaItem> mediaItems)
        {
            if (_descending)
            {
                return mediaItems.OrderByDescending(item => item.ReleaseDate).ToArray();
            }
            else
            {
                return mediaItems.OrderBy(item => item.ReleaseDate).ToArray();
            }
        }
    }
}
