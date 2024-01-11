using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Controllers
{
    public class MediaItemController
    {
        private IMediaItemDAL imediaItemDAL;
        public MediaItemController(IMediaItemDAL mediaItemDAL)
        {
            this.imediaItemDAL = mediaItemDAL;
        }
        public bool AddMediaItem(MediaItem newMediaItem, byte[] pictureBytes, byte[] pictureBytesCompressed)
        {
            return imediaItemDAL.AddMediaItem(newMediaItem, pictureBytes, pictureBytesCompressed);
        }
        public MediaItem[] GetAll()
        {
            return imediaItemDAL.GetAll().ToArray();
        }
        public MediaItem GetMediaItem(string title)
        {
            return imediaItemDAL.GetMediaItem(title);
        }
        public MediaItem GetMediaItemById(int id)
        {
            return imediaItemDAL.GetMediaItemById(id);
        }
        public int[] GetAllGivenRatings(MediaItem mediaItem)
        {
            return imediaItemDAL.GetAllGivenRatings(mediaItem);
        }
        public string GetMediaItemImageByID(MediaItem mediaItem)
        {
            return imediaItemDAL.GetMediaItemImageByID(mediaItem);
        }
        public string GetMediaItemCompressedImageByID(MediaItem mediaItem)
        {
            return imediaItemDAL.GetMediaItemCompressedImageByID(mediaItem);
        }

        public bool UpdateMediaItem(MediaItem mediaItem, byte[] pictureBytes)
        {
            return imediaItemDAL.UpdateMediaItem(mediaItem, pictureBytes); 
        }
        public bool RemoveMediaItem(MediaItem mediaItem)
        {
            return imediaItemDAL.RemoveMediaItem(mediaItem);
        }

    }
}
