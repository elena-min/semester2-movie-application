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
        public SearchFilterStrategy(string _searchLine, Genre? _searchGenre)
        {
            this.searchLine = _searchLine;
            this.searchGenre = _searchGenre;
        }
        public MediaItem[] GetFilteredMediaItems(List<MediaItem> mediaItems)
        {
            List<MediaItem> filteredMediaItems = mediaItems.FindAll(product =>
                           (string.IsNullOrEmpty(searchLine) ||
                               ((product is Serie serie &&
                               (serie.Title.IndexOf(searchLine, StringComparison.OrdinalIgnoreCase) >= 0))) ||
                               (product is Movie movie &&
                               (movie.Title.IndexOf(searchLine, StringComparison.OrdinalIgnoreCase) >= 0 ||
                               movie.Director.IndexOf(searchLine, StringComparison.OrdinalIgnoreCase) >= 0))) &&
                           (!searchGenre.HasValue || product.GetAllGenres().Contains(searchGenre.Value)));

            return filteredMediaItems.ToArray();
        }
    }
}
