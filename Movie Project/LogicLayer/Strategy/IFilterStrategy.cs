using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Strategy
{
    public interface IFilterStrategy
    {
        MediaItem[] GetFilteredMediaItems(List<MediaItem> mediaItems);
    }
}
