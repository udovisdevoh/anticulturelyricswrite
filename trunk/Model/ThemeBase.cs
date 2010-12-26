using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ac.Lw.Model
{
    public class ThemeBase
    {
        #region Fields
        private Dictionary<string, Theme> themeDictionary;
        #endregion

        #region Constructor
        public ThemeBase(string fileName)
        {
            themeDictionary = GetThemesFromFile(fileName);
        }
        #endregion

        #region Methods
        #region Construction
        private Dictionary<string, Theme> GetThemesFromFile(string fileName)
        {
            return GetThemesFromString(GetFileContent(fileName));
        }

        private Dictionary<string, Theme> GetThemesFromString(string text)
        {
            Dictionary<string, Theme> themeDictionary = new Dictionary<string, Theme>();
            string[] rawThemeData = text.Split('<');

            foreach (string currentRawThemeData in rawThemeData)
            {
                if (currentRawThemeData.Length > 10)
                {
                    Theme currentTheme = new Theme(currentRawThemeData);
                    themeDictionary.Add(currentTheme.Name, currentTheme);
                }
            }

            return themeDictionary;
        }

        private string GetFileContent(string fileName)
        {
            TextReader handle = new StreamReader(fileName);
            string content = "";
            string line;

            do
            {
                line = handle.ReadLine();
                if (line != null)
                    content += line;
            } while (line != null);

            return content;
        }
        #endregion

        #region Getters
        public Theme GetTheme(string name)
        {
            if (name != "")
                return themeDictionary[name];
            else
                return null;
        }

        public bool Contains(string[] words)
        {
            foreach (Theme currentTheme in themeDictionary.Values)
                if (currentTheme.MatchAtLeastOneWordFromVerse(words))
                    return true;

            return false;
        }

        public Theme GetRandomTheme()
        {
            Random random = new Random();
            int themeId = random.Next(themeDictionary.Count);
            return GetThemeFromId(themeId);
        }

        private Theme GetThemeFromId(int themeId)
        {
            int i = 0;
            foreach (string key in themeDictionary.Keys)
            {
                if (i == themeId)
                    return themeDictionary[key];
                i++;
            }
            return null;
        }

        public List<Theme> ExtractThemeFromWordList(string[] words)
        {
            List<Theme> matchingThemes = new List<Theme>();

            foreach (Theme currentTheme in this.themeDictionary.Values)
            {
                currentTheme.MatchAtLeastOneWordFromVerse(words);
                matchingThemes.Add(currentTheme);
            }

            if (matchingThemes.Count < 1)
                matchingThemes.Add(GetRandomTheme());

            return matchingThemes;
        }
        #endregion
        #endregion

        #region Properties
        public List<string> Keys
        {
            get
            {
                List<string> keys = new List<string>(themeDictionary.Keys);
                keys.Add("");
                keys.Sort();
                return keys;
            }
        }
        #endregion
    }
}
