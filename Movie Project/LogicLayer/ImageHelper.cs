using SixLabors.ImageSharp.Formats.Jpeg;
using System.Drawing;
using SixLabors.ImageSharp;


namespace LogicLayer
{
    public static class ImageHelper
    {
        public static byte[] CompressImageToByteArray(SixLabors.ImageSharp.Image image, int targetSizeInBytes)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                int quality = 80; 

                do
                {
                    // Save the image to the MemoryStream with the current quality
                    image.Save(stream, new JpegEncoder { Quality = quality });

                    //If we have reached a compression to the target size, the loop stops
                    if (stream.Length <= targetSizeInBytes)
                    {
                        break;
                    }

                    //If the file is stilll larger than the targeted size, then the quality is reduced by 5
                    quality -= 5; 

                    // Clear the stream for the next iteration
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.SetLength(0);
                } while (quality > 0);

                //If the file is too big of a size, it will not be compressed with the loop and will throw an exception
                if (quality <= 0)
                {
                    throw new InvalidOperationException($"Image compression failed. Target size: {targetSizeInBytes} bytes");
                }

                return stream.ToArray();
            }
        }
    }
}
