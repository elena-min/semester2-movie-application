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
        bool AddProductToFavorite(int mediaID, int userID);
        bool CheckIfProductIsInFavorites(int mediaID, int userID);
        MediaItem[] GetAllFavorites(int userID);
        MediaItem[] GetAllFavoriteMovies(int userID);
        string RemoveFromFavorites(int mediaID, int userID);
    }
}
