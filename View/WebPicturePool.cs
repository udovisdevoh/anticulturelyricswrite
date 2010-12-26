using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ac.Lw.View
{
    class WebPicturePool : IEnumerable
    {
        #region Fields
        private Dictionary<string, List<WebPicture>> data = new Dictionary<string, List<WebPicture>>();

        private static Regex notALetterNorASpace = new Regex("[^a-zA-Z0-9-' ]");

        private VideoWindow disposableVideoWindow = new VideoWindow();
        #endregion

        #region Constructor
        public WebPicturePool(List<string> textLines,int desiredWidth,int desiredHeight)
        {
            foreach (string currentLine in textLines)
            {
                if (!data.ContainsKey(currentLine))
                {
                    List<WebPicture> currentWebPictureList = new List<WebPicture>();

                    currentWebPictureList.Add(new WebPicture(currentLine, "firstWord"));
                    currentWebPictureList.Add(new WebPicture(currentLine, "lastWord"));

                    data.Add(currentLine, currentWebPictureList);
                }
            }

            disposableVideoWindow.CachePictures(data);
        }
        #endregion

        #region Methods
        #region Generators
        private List<string> GetLongestWords(string currentLine)
        {
            Random random = new Random();
            HashSet<string> words = GetWordsFromLine(currentLine);
            SortedList<double, string> wordLengthList = new SortedList<double, string>();
            List<string> longestWords = new List<string>();

            foreach (string currentWord in words)
                wordLengthList.Add((currentWord.Length + random.NextDouble()*0.1) * -1,currentWord);

            int i = 0;
            foreach (string currentWord in wordLengthList.Values)
            {
                longestWords.Add(currentWord);
                i++;
                if (i > 4)
                    break;
            }

            return longestWords;
        }

        private HashSet<string> GetWordsFromLines(List<string> textLines)
        {
            HashSet<string> wordList = new HashSet<string>();
            foreach (string line in textLines)
            {

                string[] words = notALetterNorASpace.Replace(line,"").Split();

                foreach (string word in words)
                    if (!wordList.Contains(word) && word.Length > 3)
                        wordList.Add(word);
            }

            return wordList;
        }

        private HashSet<string> GetWordsFromLine(string line)
        {
            HashSet<string> wordList = new HashSet<string>();

            string[] words = notALetterNorASpace.Replace(line, "").Split();

            foreach (string word in words)
                if (!wordList.Contains(word) && word.Length > 3)
                    wordList.Add(word);

            return wordList;
        }
        #endregion

        #region Getters
        public List<WebPicture> GetBestImages(string textLine)
        {
            if (data.ContainsKey(textLine))
                return data[textLine];
            else
                return null;
        }
        #endregion

        #region Implements
        public IEnumerator GetEnumerator()
        {
            return data.Values.GetEnumerator();
        }
        #endregion
        #endregion
    }
}
