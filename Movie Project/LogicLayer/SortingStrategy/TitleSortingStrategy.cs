using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.SortingStrategy
{
    public class TitleSortingStrategy : ISortingStrategy
    {
        private readonly bool _descending;
        public TitleSortingStrategy(bool descending = false)
        {
            _descending = descending;
        }

        public MediaItem[] GetSortedMediaItems(List<MediaItem> mediaItems)
        {
            if (_descending)
            {
                return mediaItems.OrderByDescending(item => item.Title).ToArray();
            }
            else
            {
                return mediaItems.OrderBy(item => item.Title).ToArray();
            }
        }
    }
}
