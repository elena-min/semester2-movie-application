using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class FavoriteMediaItem
    {
        private List<MediaItem> favoriteMediaItems;
        public string Username { get; private set; }
        public FavoriteMediaItem(string username)
        {
            favoriteMediaItems = new List<MediaItem>();
            Username = username;    
        }
        public void AddToFavoroites(MediaItem mediaItem)
        {
            favoriteMediaItems.Add(mediaItem);
        }
        public void RemoveFromFavorites(MediaItem mediaItem)
        {
            favoriteMediaItems.Remove(mediaItem);
        }
        public MediaItem[] GetAllFavorite()
        {
            return favoriteMediaItems.ToArray();    
        }
        public Genre[] GetFavoriteGenres()
        {
            List<Genre> favoriteGenres = new List<Genre>();

            if (favoriteMediaItems != null && favoriteMediaItems.Count > 0)
            {
                foreach (MediaItem product in favoriteMediaItems)
                {
                    favoriteGenres.AddRange(product.GetAllGenres());
                }

                return favoriteGenres.ToArray();
            }
            else
            {
                return null;
            }
        }
        public override string ToString()
        {
            List<string> mediaItemNames = favoriteMediaItems.Select(mediaItem => mediaItem.Title).ToList();

            return string.Join(", ", mediaItemNames);
        }

    }
}
