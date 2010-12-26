using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;


namespace Ac.Lw.Third
{
    abstract class Third
    {
        #region Methods
        protected static string GetPageContent(string url)
        {
            // used to build entire input
            StringBuilder content = new StringBuilder();
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            // used on each read operation
            byte[] buf = new byte[8192];


            request = (HttpWebRequest)WebRequest.Create(url);
            if (request != null)
            {
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch
                {
                }
            }

            if (response != null)
            {
                Stream resStream = response.GetResponseStream();


                string tempString = null;
                int count = 0;

                do
                {
                    // fill the buffer with data
                    count = resStream.Read(buf, 0, buf.Length);

                    // make sure we read some data
                    if (count != 0)
                    {
                        // translate from bytes to ASCII text
                        tempString = Encoding.ASCII.GetString(buf, 0, count);

                        // continue building the string
                        content.Append(tempString);
                    }
                }
                while (count > 0); // any more data to read?
            }

            return content.ToString();
        }
        #endregion
    }
}
