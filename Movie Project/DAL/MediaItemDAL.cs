using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MediaItemDAL : IMediaItemDAL
    {
        public void AddMediaItem(MediaItem newMediaItem, byte[] pictureBytes)
        {
        }

        public MediaItem[] GetAll()
        {
            return new MediaItem[0];

        }

        public int[] GetAllGivenRatings(int id)
        {
            return new int[] { 0 };
        }

        public MediaItem GetMediaItem(string title)
        {
            return new MediaItem();
        }

        public MediaItem GetMediaItemById(int id)
        {
            return new MediaItem();
        }

        public string GetMediaItemImageByID(int id)
        {
            return "";
        }

        public void RemoveMediaItem(int id)
        {
        }

        public void UpdateMediaItem(MediaItem mediaItem, byte[] pictureBytes)
        {
        }
    }
}
