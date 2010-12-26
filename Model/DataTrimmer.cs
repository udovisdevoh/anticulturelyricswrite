using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Ac.Lw.Model
{
    class DataTrimmer
    {
        #region Fields
        private static Regex notALetter = new Regex("[^a-zA-Z]");
        #endregion

        #region Methods
        public static void TrimData(string inputFileName, string outputFileName, ThemeBase themeBase)
        {
            FileStream inputFileStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(inputFileStream);

            FileStream outputFileStream = new FileStream(outputFileName, FileMode.Open, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(outputFileStream);

            string line;
            string[] wordList;

            do
            {
                line = streamReader.ReadLine();
                if (line == null)
                    break;

                wordList = line.Split(' ');

                for (int i = 0; i < wordList.Length; i++)
                    wordList[i] = notALetter.Replace(wordList[i], "");

                if (themeBase.Contains(wordList))
                    streamWriter.WriteLine(line);

            } while (line != null);

            
        }
        #endregion
    }
}
