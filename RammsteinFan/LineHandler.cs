using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RammsteinFan
{
    public class LineHandler
    {
        readonly static public char Separator = '/';
        readonly static public string TypeMembers = "members";

        /// <summary>
        /// Удаляет пробелы после запятых и разделяет строку по запятым
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public static List<string> SplitSpaces(string inputText)
        {
            var text = inputText;
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == ' ' & text[i - 1] == ';')
                {
                    text = text.Remove(i, 1);
                }
            }
            return text.Split(';').ToList();
        }

        public static int GetNumberOfPhotos(string PhotoGalery, string titlePhotoAlbum)
        {
            List<string> PhotoAlbums = SplitSpaces(PhotoGalery);
            var result = PhotoAlbums.Where(p => p.StartsWith(titlePhotoAlbum)).DefaultIfEmpty("-00").First();
            result = result.Substring(result.Length - 2, 2);
            return Int32.Parse(result);
        }
    }
}
