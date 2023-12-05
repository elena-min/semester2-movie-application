using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IFavoritesDAL
    {
        bool AddProductToFavorite(MediaItem mediaItem, User user);
        bool CheckIfProductIsInFavorites(MediaItem mediaItem, User user);
        MediaItem[] GetAllFavorites(User user);
        MediaItem[] GetAllFavoriteMovies(User user);
        string RemoveFromFavorites(MediaItem mediaItem, User user);
        bool DeletedMediaItem(MediaItem mediaItem);
        bool DeletedUser(User user);
    }
}
