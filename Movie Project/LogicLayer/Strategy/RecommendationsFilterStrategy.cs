using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Strategy
{
    public class RecommendationsFilterStrategy : IFilterStrategy
    {
        private User currentUser;

        public RecommendationsFilterStrategy(User _currentUser)
        {
            this.currentUser = _currentUser;
           
        }
        public MediaItem[] GetFilteredMediaItems(List<MediaItem> mediaItems)
        {
            Dictionary<MediaItem, int> matchedGenreCounts = new Dictionary<MediaItem, int>();

            foreach (MediaItem mediaItem in mediaItems)
            {
                int matchedGenreCount = 0;

                foreach (Genre mediaGenre in mediaItem.GetAllGenres())
                {
                    if (currentUser.FavoriteMediaItem.GetFavoriteGenres().Contains(mediaGenre))
                    {
                        matchedGenreCount++;
                    }
                }

                if (matchedGenreCount > 0 && !IsMediaItemInFavorites(mediaItem))
                {
                    matchedGenreCounts[mediaItem] = matchedGenreCount;
                }
            }

            List<MediaItem> recommendations = matchedGenreCounts.Keys.ToList();

            //Makes sure the media items with most favrotite genres in them are on top of the list
            recommendations.Sort((mediaItem1, mediaItem2) =>
                matchedGenreCounts[mediaItem2].CompareTo(matchedGenreCounts[mediaItem1]));

            //Loop throught the results and keeps only those which have been released in the past 10 years
            List<MediaItem> filteredMediaItems = new List<MediaItem>();
            foreach (var movie in recommendations)
            {
                if (movie.ReleaseDate >= DateTime.Now.AddYears(-10))
                {
                    filteredMediaItems.Add(movie);
                }
            }
            return filteredMediaItems.ToArray();
        }

        private bool IsMediaItemInFavorites(MediaItem mediaItem)
        {
            foreach (MediaItem favMediaItem in currentUser.FavoriteMediaItem.GetAllFavorite())
            {
                if (favMediaItem.GetId() == mediaItem.GetId())
                {
                    return true;
                }
            }
            return false;
        }


    }
}


