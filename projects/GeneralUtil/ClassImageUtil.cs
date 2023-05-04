using System;
using System.Collections.Generic;


namespace ClassLibraryUtil
{
    public class ClassImageUtil
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

        const int size = 150;
        //const int quality = 75;
        /*
                public static void x (string inputPath, string outputPath)
                {
                using (var image = new MagickImage(inputPath))
        {
            image.Resize(size, size);
            image.Strip();
            image.Quality = quality;
            image.Write(outputPath);
        }


          public static byte[] compress_image(byte[] ba  ,int quality)
        {
            using (var image = new MagickImage(ba))
            {
                //image.Resize(size, size);
                image.Strip();
                image.Quality = quality;
                return image.ToByteArray();
                // image.Write(outputPath);
            }
        }

    }*/


        public static string get_image_base64(byte[] img, bool compress = true)
        {
            string result64 = "";
            if (img != null)
            {
                /*if(compress)
                ///compress
                img = ClassLibraryUtil.ClassImageUtil.compress_image(img);
*/
                var base64 = Convert.ToBase64String(img);
                result64 = String.Format("data:image/gif;base64,{0}", base64);
            }
            return result64;
        }


    }
}
