using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Controllers
{
    public class FavoritesController
    {
        private IFavoritesDAL iFavoritesDAL;
        public FavoritesController(IFavoritesDAL FavoritesDAL)
        {
            this.iFavoritesDAL = FavoritesDAL;
        }
        
        public bool AddProductToFavorite(int mediaID, int userID)
        {
            return iFavoritesDAL.AddProductToFavorite(mediaID, userID);
        }
        public bool CheckIfProductIsInFavorites(int mediaID, int userID)
        {
            return iFavoritesDAL.CheckIfProductIsInFavorites(mediaID, userID);
        }
        public MediaItem[] GetAllFavorites(int userID)
        {
            return iFavoritesDAL.GetAllFavorites(userID);
        }

        public MediaItem[] GetAllFavoriteMovies(int userID)
        {
            return iFavoritesDAL.GetAllFavoriteMovies(userID);

        }
        public string RemoveFromFavorites(int mediaID, int userID)
        {
            return iFavoritesDAL.RemoveFromFavorites(mediaID, userID);
        }
        public bool DeletedMediaItem(int mediaID)
        {
            return iFavoritesDAL.DeletedMediaItem(mediaID);
        }
        public bool DeletedUser(User user)
        {
            return iFavoritesDAL.DeletedUser(user);
        }
    }
}
