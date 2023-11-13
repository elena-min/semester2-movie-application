using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Strategy
{
    public class SearchFilterStrategy : IFilterStrategy
    {
        private string searchLine;
        private Genre? searchGenre;
        public SearchFilterStrategy(string _searchLine, Genre _searchGenre)
        {
            this.searchLine = _searchLine;
            this.searchGenre = _searchGenre;
        }
        public MediaItem[] GetFilteredMediaItems(List<MediaItem> mediaItems)
        {
            throw new NotImplementedException();
        }
    }
}
