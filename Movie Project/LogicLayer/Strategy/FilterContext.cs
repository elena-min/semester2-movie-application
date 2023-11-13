using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Strategy
{
    public class FilterContext
    {
        private IFilterStrategy filterStrategy;

        public void SetFilterStrategy(IFilterStrategy strategy)
        {
            filterStrategy = strategy;
        }

        public MediaItem[] GetFilteredMediaItems(List<MediaItem> mediaItems)
        {
            return filterStrategy.GetFilteredMediaItems(mediaItems);
        }
    }
}
