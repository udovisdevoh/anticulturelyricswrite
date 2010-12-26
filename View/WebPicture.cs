using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Ac.Lw.View
{
    public class WebPicture
    {
        #region Fields
        private string imageUrl;
        #endregion

        #region Constructor
        public WebPicture(string word, int desiredWidth, int desiredHeight)
        {
            imageUrl = Third.GoogleImageSearch.GetSearchBestImageUrlFromKeyword(word, desiredWidth, desiredHeight);
        }

        public WebPicture(string word, string searchType)
        {
            imageUrl = Third.GoogleImageSearch.GetSearchBestImageUrlFromKeyword(word, searchType);
        }
        #endregion

        #region Properties
        public string ImageUrl
        {
            get { return imageUrl; }
        }
        #endregion
    }
}
