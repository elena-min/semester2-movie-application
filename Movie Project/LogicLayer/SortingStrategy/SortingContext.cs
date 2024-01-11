using LogicLayer.Classes;
using LogicLayer.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.SortingStrategy
{
    public class SortingContext
    {
        private ISortingStrategy sortingStrategy;

        public void SetSortingStrategy(ISortingStrategy strategy)
        {
            sortingStrategy = strategy;
        }

        public MediaItem[] GetSortedMediaItems(List<MediaItem> mediaItems)
        {
            return sortingStrategy.GetSortedMediaItems(mediaItems);
        }
    }
}
