using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Strategy
{
    public class TrendingFilterStrategy : IFilterStrategy
    {
        public MediaItem[] GetFilteredMediaItems(List<MediaItem> mediaItems)
        {
            //Using this loop the PopularityScore is being calculated and assigned for each media item
            foreach (var movie in mediaItems)
            {
                movie.CalculatePopularityScore();
            }

            //Orders the list descedning by the PopularityScore
            mediaItems = mediaItems.OrderByDescending(movie => movie.PopularityScore).ToList();

            //Takes the score of the first media item which is the highest in the list
            double maxPopularityScore = mediaItems.First().PopularityScore; 
            //It turns each score into a percent between 1-100. The highest score is set as 100% and the others are below it.
            mediaItems.ForEach(movie => movie.PopularityScore = (movie.PopularityScore / maxPopularityScore) * 100);

            //It takes the media items with a score above 55%
            List<MediaItem> filteredMediaItems = new List<MediaItem>();
            foreach (var movie in mediaItems) 
            { 
                if(movie.PopularityScore > 55)
                {
                    filteredMediaItems.Add(movie);
                }
            }
            //List<MediaItem> filteredMediaItems = mediaItems.Where(mediaItem => mediaItem.PopularityScore > 55).ToList();

            return filteredMediaItems.ToArray();
        }

    }
}
