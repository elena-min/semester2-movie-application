using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IMediaItemDAL
    {
        bool AddMediaItem(MediaItem newMediaItem, byte[] pictureBytes);
        MediaItem[] GetAll();
        MediaItem GetMediaItem(string title);
        MediaItem GetMediaItemById(int id);
        int[] GetAllGivenRatings(int id);
        string GetMediaItemImageByID(int id);
        bool UpdateMediaItem(MediaItem mediaItem, byte[] pictureBytes);
        string RemoveMediaItem(int id);

    }
}
