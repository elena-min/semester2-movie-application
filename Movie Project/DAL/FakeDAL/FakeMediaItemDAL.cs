using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.FakeDAL
{
    public class FakeMediaItemDAL : IMediaItemDAL
    {
        private List<MediaItem> mediaItems;
        private int nextId = 1;
        public FakeMediaItemDAL()
        {
            mediaItems = new List<MediaItem>();
        }

        public bool AddMediaItem(MediaItem newMediaItem, byte[] pictureBytes)
        {
            newMediaItem.SetId(nextId++);
            mediaItems.Add(newMediaItem);
            return true;
        }

        public MediaItem[] GetAll()
        {
            return mediaItems.ToArray();
        }

        public int[] GetAllGivenRatings(int id)
        {
            MediaItem medaiItem =  mediaItems.Find(item => item.GetId() == id);
            int[] ratings;
            if (medaiItem != null)
            {
                ratings = medaiItem.GetAllRatings();
                return ratings;
            }
            else
            {
                return null;
            }
        }

        public MediaItem GetMediaItem(string title)
        {
            return mediaItems.Find(item => item.Title == title);
        }

        public MediaItem GetMediaItemById(int id)
        {
            return mediaItems.Find(item => item.GetId() == id);
        }

        public string GetMediaItemImageByID(int id)
        {
            var mediaItem = mediaItems.FirstOrDefault(u => u.GetId() == id);

            if (mediaItem != null && mediaItem.Picture != null)
            {
                return Convert.ToBase64String(mediaItem.Picture);
            }
            else
            {
                return null;
            }
        }
        public bool RemoveMediaItem(int id)
        {
            MediaItem mediaItemToRemove = mediaItems.Find(item => item.GetId() == id);
            if (mediaItemToRemove != null)
            {
                mediaItems.Remove(mediaItemToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateMediaItem(MediaItem mediaItem, byte[] pictureBytes)
        {
            MediaItem existingItem = mediaItems.Find(item => item.GetId() == mediaItem.GetId());
            if (existingItem != null)
            {
                mediaItems.Remove(existingItem);
                mediaItem.SetId(existingItem.GetId());
                mediaItems.Add(mediaItem);

                return true;
            }
            else
            {
                return false;
            }
        }
        public void RecordView(MediaItem mediaItem)
        {
            throw new NotImplementedException();
        }

        
    }
}
