using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ac.Lw.View
{
    public partial class VideoWindow : Form
    {
        public VideoWindow()
        {
            InitializeComponent();
        }

        #region Methods
        #region Actions
        public void PlayImage(string line, List<WebPicture> webPictureList)
        {
            webBrowser.Url = GetTemporaryHtmlFileFromImageAndText(webPictureList, line);
        }

        private Uri GetTemporaryHtmlFileFromImageAndText(List<WebPicture> webPictureList, string textContent)
        {
            //throw new NotImplementedException();
            string fileContent = string.Empty;
            fileContent += "<html><head><style>h1{font:50px arial;font-weight:bold} h2{font:40px arial;font-weight:bold}</style></head><body style='margin:0px;background-color:#000'>";
            fileContent += "<div align='center' style='color:#FFF;background-color:#000'>";

            fileContent += textContent.ToUpper();

            if (webPictureList != null)
            {
                fileContent += "<table border='0' cellpadding='0' cellspacing='0'><tr>";
                foreach (WebPicture currentPicture in webPictureList)
                    fileContent += "<td valign='top'><img src='" + currentPicture.ImageUrl + "'></td>";
                fileContent += "</tr><table>";
            }

            fileContent += "</div></body></html>";

            writeFile("video.html", fileContent);

            return new Uri(Application.StartupPath + @"\video.html");
        }

        private void writeFile(string fileName, string fileContent)
        {
            TextWriter handle = new StreamWriter(fileName);
            handle.WriteLine(fileContent);
            handle.Close();
        }

        internal void CachePictures(Dictionary<string, List<WebPicture>> data)
        {
            List<WebPicture> picturesToCache = new List<WebPicture>();

            foreach (List<WebPicture> currentPictureList in data.Values)
                picturesToCache.AddRange(currentPictureList);

            webBrowser.Url = GetTemporaryHtmlFileFromImageAndText(picturesToCache, "");
        }
        #endregion
        #endregion
    }
}
