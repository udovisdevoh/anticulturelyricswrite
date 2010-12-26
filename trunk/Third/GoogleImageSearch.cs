using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Ac.Lw.Third
{
    class GoogleImageSearch : Third
    {
        #region Methods
        #region Generators
        public static string GetSearchBestImageUrlFromKeyword(string keyword, int desiredWidth, int desiredHeight)
        {
            string pageContent = GetPageContent("http://images.google.com/images?as_q=" + keyword + "&um=1&hl=fr&btnG=Recherche+Google&as_epq=&as_oq=&as_eq=&imgtype=&imgsz=small|medium|large|xlarge&as_filetype=&imgc=&as_sitesearch=&safe=images&as_st=y");
            List<string> imageUrlList = GetImageUrlList(pageContent);
            return GetRandomImageUrl(imageUrlList);
        }

        public static string GetSearchBestImageUrlFromKeyword(string line, string searchType)
        {
            string keyword = line;

            if (searchType == "firstWord")
                keyword = GetFirstWordFromLine(line);
            else if (searchType == "lastWord")
                keyword = GetLastWordFromLine(line);

            string pageContent = GetPageContent("http://images.google.com/images?as_q=" + keyword + "&um=1&hl=fr&btnG=Recherche+Google&as_epq=&as_oq=&as_eq=&imgtype=&imgsz=small|medium|large|xlarge&as_filetype=&imgc=&as_sitesearch=&safe=images&as_st=y");
            List<string> imageUrlList = GetImageUrlList(pageContent);
            return GetRandomImageUrl(imageUrlList);
        }
        #endregion

        #region Getters
        private static string GetRandomImageUrl(List<string> imageUrlList)
        {
            if (imageUrlList.Count > 0)
            {
                Random random = new Random();
                return imageUrlList[random.Next(imageUrlList.Count)];
            }
            else
            {
                return null;
            }
        }

        private static List<string> GetImageUrlList(string pageContent)
        {
            string[] separator = new string[1];
            separator[0] = "imgurl=";

            List<string> imageUrls = new List<string>(pageContent.Split(separator, 100, 0));
            List<string> finalList = new List<string>();

            for (int i = 0; i < imageUrls.Count; i++)
            {
                int endPosition = imageUrls[i].IndexOf('&');
                imageUrls[i] = imageUrls[i].Substring(0, endPosition);

                imageUrls[i] = imageUrls[i].Replace("%2520", " ");


                if (!imageUrls[i].Contains('%') && (imageUrls[i].EndsWith(".jpg") || imageUrls[i].EndsWith(".jpeg") || imageUrls[i].EndsWith(".png") || imageUrls[i].EndsWith(".gif")))
                    finalList.Add(imageUrls[i]);
            }

            return finalList;
        }
        #endregion

        #region Mutators
        private static string GetLastWordFromLine(string line)
        {
            line = line.Trim();
            string word;
            word = line.Substring(line.LastIndexOf(' '));
            line = line.Substring(0, line.LastIndexOf(' ')).Trim();

            if (word.Length < 4 && line.Contains(' '))
                word = GetLastWordFromLine(line);

            return word;
        }

        private static string GetFirstWordFromLine(string line)
        {
            line = line.Trim();
            string word;
            word = line.Substring(0, line.IndexOf(' '));
            line = line.Substring(line.IndexOf(' ')).Trim();

            if (word.Length < 4 && line.Contains(' '))
                word = GetFirstWordFromLine(line);

            return word;
        }
        #endregion
        #endregion
    }
}
