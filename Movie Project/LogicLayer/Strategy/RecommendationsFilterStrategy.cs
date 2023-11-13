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
    public class RecommendationsFilterStrategy /*: IFilterStrategy*/
    {
        private User currentUser;
        private UserController userController;
        private IUserDAL iUserdal;

        //public RecommendationsFilterStrategy(User _currentUser)
        //{
        //    this.currentUser = _currentUser;
        //    iUserdal = new UserDAL();
        //    userController = new UserController(iUserdal);
        //}
        //public MediaItem[] GetFilteredMediaItems(List<MediaItem> mediaItems)
        //{
        //    Dictionary<MediaItem, int> matchedGenreCounts = new Dictionary<MediaItem, int>();

        //    foreach (MediaItem mediaItem in mediaItems)
        //    {
        //        int matchedGenreCount = 0;

        //        foreach (Genre mediaGenre in mediaItem.GetAllGenres())
        //        {
        //            if (favoriteMediaManager.GetFavoriteGenres(currentUser).Contains(mediaGenre))
        //            {
        //                matchedGenreCount++;
        //            }
        //        }

        //        if (matchedGenreCount > 0 && !IsMediaItemInFavorites(mediaItem))
        //        {
        //            matchedGenreCounts[mediaItem] = matchedGenreCount;
        //        }
        //    }

        //    List<MediaItem> recommendations = matchedGenreCounts.Keys.ToList();

        //    recommendations.Sort((mediaItem1, mediaItem2) =>
        //        matchedGenreCounts[mediaItem2].CompareTo(matchedGenreCounts[mediaItem1]));

        //    return recommendations.ToArray();
        //}

        //private bool IsMediaItemInFavorites(MediaItem mediaItem)
        //{
        //    foreach (MediaItem favMediaItem in favoriteMediaManager.GetFavorites(currentUser))
        //    {
        //        if (favMediaItem.GetId() == mediaItem.GetId())
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}


    }
}


