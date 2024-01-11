
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

        public bool AddMediaItem(MediaItem newMediaItem, byte[] pictureBytes, byte[] pictureBytesCompressed)
        {
            newMediaItem.SetId(nextId++);
            mediaItems.Add(newMediaItem);
            return true;
        }

        public MediaItem[] GetAll()
        {
            return mediaItems.ToArray();
        }

        public int[] GetAllGivenRatings(MediaItem mediaItem)
        {
            MediaItem medaiItemSelected =  mediaItems.Find(item => item== mediaItem);
            int[] ratings;
            if (medaiItemSelected != null)
            {
                ratings = medaiItemSelected.GetAllRatings();
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

        public string GetMediaItemImageByID(MediaItem mediaItem)
        {
            var mediaItemSelected = mediaItems.FirstOrDefault(u => u == mediaItem);

            if (mediaItemSelected != null && mediaItemSelected.Picture != null)
            {
                return Convert.ToBase64String(mediaItemSelected.Picture);
            }
            else
            {
                return null;
            }
        }

        public string GetMediaItemCompressedImageByID(MediaItem mediaItem)
        {
            var mediaItemSelected = mediaItems.FirstOrDefault(u => u == mediaItem);

            if (mediaItemSelected != null && mediaItemSelected.Picture != null)
            {
                return Convert.ToBase64String(mediaItemSelected.Picture);
            }
            else
            {
                return null;
            }
        }

        public bool RemoveMediaItem(MediaItem mediaItem)
        {
            MediaItem mediaItemToRemove = mediaItems.Find(item => item == mediaItem);
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
