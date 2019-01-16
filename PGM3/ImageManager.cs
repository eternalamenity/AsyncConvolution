using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PGM3
{

    class ImageManager
    {
        public static void saveImage(string path, MyImage image)
        {
            var stream = File.Open(path, FileMode.OpenOrCreate);

            StringBuilder sb = new StringBuilder();
            sb = sb.Append("P2\n");
            sb = sb.Append(image.Size[0]);
            sb = sb.Append(" ");
            sb = sb.Append(image.Size[1]);
            sb = sb.Append("\n");
            sb = sb.Append("255\n");
            for (int i = 0; i < image.Size[0] * image.Size[1]; i++)
            {
                sb = sb.Append(Math.Floor(image.Values[i] * 255));
                sb = sb.Append(" ");

            }
            stream.Write(Encoding.ASCII.GetBytes(sb.ToString()), 0, sb.Length);
            stream.Close();

        }
    }
}