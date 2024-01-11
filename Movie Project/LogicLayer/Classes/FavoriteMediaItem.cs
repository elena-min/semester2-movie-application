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
        public Person User { get; private set; }
        public List<MediaItem> FavoriteMediaItems { get; private set; }

        public FavoriteMediaItem(Person user)
        {
            FavoriteMediaItems = new List<MediaItem>();
            User = user;    
        }
        public void AddToFavorites(MediaItem mediaItem)
        {
            if (mediaItem != null && !FavoriteMediaItems.Contains(mediaItem))
            {
                FavoriteMediaItems.Add(mediaItem);
            }
        }
        public void RemoveFromFavorites(MediaItem mediaItem)
        {
            if(mediaItem != null && FavoriteMediaItems.Contains(mediaItem))
            {
                FavoriteMediaItems.Remove(mediaItem);
            }
        }
        public MediaItem[] GetAllFavorite()
        {
            return FavoriteMediaItems.ToArray();    
        }
        public Genre[] GetFavoriteGenres()
        {
            List<Genre> favoriteGenres = new List<Genre>();

            if (FavoriteMediaItems != null && FavoriteMediaItems.Count > 0)
            {
                foreach (MediaItem product in FavoriteMediaItems)
                {
                    List<Genre> profuctGenres = product.GetAllGenres().ToList();
                    foreach(Genre genre in profuctGenres)
                    {
                        if(!favoriteGenres.Contains(genre))
                        {
                            favoriteGenres.Add(genre);
                        }
                    }
                    //favoriteGenres.AddRange(product.GetAllGenres());
                }

                return favoriteGenres.ToArray();
            }
            else
            {
                return new Genre[0];
            }
        }
        public override string ToString()
        {
            List<string> mediaItemNames = FavoriteMediaItems.Select(mediaItem => mediaItem.Title).ToList();

            return string.Join(", ", mediaItemNames);
        }

    }
}
