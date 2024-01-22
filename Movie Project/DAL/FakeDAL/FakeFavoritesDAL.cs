using LogicLayer;
using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.FakeDAL
{
    public class FakeFavoritesDAL :IFavoritesDAL
    {
        public Person User { get; set; }
        public List<MediaItem> favMediaItems;

        public FakeFavoritesDAL()
        {       
            favMediaItems = new List<MediaItem>();
        }

        public bool AddProductToFavorite(MediaItem mediaItem, User user)
        {
            if(user != null)
            {
                if(mediaItem != null)
                {
                    if (!CheckIfProductIsInFavorites(mediaItem, user))
                    {
                        favMediaItems.Add(mediaItem);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("Database error");

                }
            }
            else
            {
                throw new Exception("Database error");

            }

        }
        public bool CheckIfProductIsInFavorites(MediaItem mediaItem, User user)
        {
            if (user != null)
            {
                if (mediaItem != null)
                {
                    if (favMediaItems.Contains(mediaItem))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("Database error");

                }
            }
            else
            {
                throw new Exception("Database error");

            }
        }
        public MediaItem[] GetAllFavorites(User user)
        {
            return favMediaItems.ToArray();
        }

        public string RemoveFromFavorites(MediaItem mediaItem, User user)
        {
            if (user != null)
            {
                if (mediaItem != null)
                {
                    MediaItem itemToRemove = favMediaItems.FirstOrDefault(f => f.GetId() == mediaItem.GetId());
                    if (itemToRemove != null)
                    {
                        favMediaItems.Remove(itemToRemove);
                        return "Removed successfully";
                    }
                    else
                    {
                        return "No data found.";
                    }
                }
                else
                {
                    throw new Exception("Database error");

                }
            }
            else
            {
                throw new Exception("Database error");

            }
        }

        public bool DeletedMediaItem(MediaItem mediaItem)
        {
            if (mediaItem != null)
            {
                int initialCount = favMediaItems.Count;
                favMediaItems.RemoveAll(f => f.GetId() == mediaItem.GetId());
                return initialCount > favMediaItems.Count;
            }
            else
            {
                throw new Exception("Database error");

            }
            
        }

        public bool DeletedUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
