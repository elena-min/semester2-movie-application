using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.SortingStrategy
{
    public interface ISortingStrategy
    {
        MediaItem[] GetSortedMediaItems(List<MediaItem> mediaItems);
    }
}
