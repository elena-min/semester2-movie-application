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
        bool AddMediaItem(MediaItem newMediaItem, byte[] pictureBytes, byte[] pictureBytesCompressed);
        MediaItem[] GetAll();
        MediaItem GetMediaItem(string title);
        MediaItem GetMediaItemById(int id);
        int[] GetAllGivenRatings(MediaItem mediaItem);
        string GetMediaItemImageByID(MediaItem mediaItem);
        string GetMediaItemCompressedImageByID(MediaItem mediaItem);

        bool UpdateMediaItem(MediaItem mediaItem, byte[] pictureBytes);
        bool RemoveMediaItem(MediaItem mediaItem);

    }
}
