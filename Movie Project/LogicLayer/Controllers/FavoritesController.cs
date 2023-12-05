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
        
        public bool AddProductToFavorite(MediaItem mediaItem, User user)
        {
            return iFavoritesDAL.AddProductToFavorite(mediaItem, user);
        }
        public bool CheckIfProductIsInFavorites(MediaItem mediaItem, User user)
        {
            return iFavoritesDAL.CheckIfProductIsInFavorites(mediaItem, user);
        }
        public MediaItem[] GetAllFavorites(User user)
        {
            return iFavoritesDAL.GetAllFavorites(user);
        }

        public string RemoveFromFavorites(MediaItem mediaItem, User user)
        {
            return iFavoritesDAL.RemoveFromFavorites(mediaItem, user);
        }
        public bool DeletedMediaItem(MediaItem mediaItem)
        {
            return iFavoritesDAL.DeletedMediaItem(mediaItem);
        }
        public bool DeletedUser(User user)
        {
            return iFavoritesDAL.DeletedUser(user);
        }
    }
}
