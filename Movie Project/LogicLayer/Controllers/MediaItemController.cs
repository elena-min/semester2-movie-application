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
        public bool AddMediaItem(MediaItem newMediaItem, byte[] pictureBytes)
        {
            return imediaItemDAL.AddMediaItem(newMediaItem, pictureBytes);
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
        public int[] GetAllGivenRatings(int id)
        {
            return imediaItemDAL.GetAllGivenRatings(id);
        }
        public string GetMediaItemImageByID(int id)
        {
            return imediaItemDAL.GetMediaItemImageByID((int)id);
        }
        public bool UpdateMediaItem(MediaItem mediaItem, byte[] pictureBytes)
        {
            return imediaItemDAL.UpdateMediaItem(mediaItem, pictureBytes); 
        }
        public string RemoveMediaItem(int id)
        {
            return imediaItemDAL.RemoveMediaItem(id);
        }
    }
}
