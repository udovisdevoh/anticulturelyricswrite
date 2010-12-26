using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ac.Lw.Controller
{
    class Lyric : IEnumerable
    {
        #region Fields
        private static Regex notALetter = new Regex("[^a-zA-Z]");

        private Model.ThemeBase themeBase;

        private List<Model.Theme> musicalTheme;

        private List<string> verseList;

        private List<int> midiInstruments;

        private List<int> punctuationType;

        private List<int> modulationOffset;

        private List<SpeechLib.SpObjectToken> voicesListByVerse;

        private string title;

        private int voiceChangingRate;

        private int keySignature;

        private int speed;

        private int soloTimePosition;

        private bool enableSolo;

        private bool enableIntro;

        private bool flagAddMoreEntropyAtTheEnd = true;

        private int introBarCount;

        private int soloBarCount;

        private View.WebPicturePool webPicturePool;

        private int imageWidth = 400;

        private int imageHeight = 300;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a lyric object from existing lyric string
        /// </summary>
        /// <param name="existingTextContent">existing song lyrics</param>
        /// <param name="themeBase">program's theme database</param>
        public Lyric(string existingTextContent, Model.ThemeBase themeBase, int speed, bool enableSolo, int soloTimePosition, bool enableIntro, bool flagGenerateVideo)
        {
            this.enableSolo = enableSolo;

            this.enableIntro = enableIntro;

            this.soloTimePosition = soloTimePosition;

            this.speed = speed;

            this.themeBase = themeBase;

            verseList = GetVerseFromExistingContent(existingTextContent);

            List<Model.Theme> desiredThemes = themeBase.ExtractThemeFromWordList(GetWordsFromLine(existingTextContent));

            musicalTheme = GetMusicalTheme(desiredThemes);

            midiInstruments = GetRandomMidiInstrumentsFrom(musicalTheme);

            punctuationType = GetPunctuationType();

            modulationOffset = GetModulationOffsetList();

            voicesListByVerse = GenerateRandomVoicesForEachVerse();

            voiceChangingRate = GetRandomVoiceChangingRate();

            keySignature = GetRandomKeySignature();

            introBarCount = GetIntroBarCount(musicalTheme);

            soloBarCount = GetSoloBarCount(musicalTheme);

            if (flagGenerateVideo)
                webPicturePool = new View.WebPicturePool(verseList, imageWidth, imageHeight);
            else
                webPicturePool = null;
        }

        public Lyric(double doubleVerseLength, double verseLengthEntropy, Model.LineBase lineBase, List<Model.Theme> desiredThemes, List<Model.Theme> undesiredThemes, int sampleSize, int verseCount, Model.ThemeBase themeBase, Random random, bool chorusMode, int speed, bool enableSolo, int soloTimePosition, bool enableIntro, bool flagGenerateVideo)
        {
            this.enableSolo = enableSolo;

            this.enableIntro = enableIntro;

            this.soloTimePosition = soloTimePosition;

            this.speed = speed;

            int averageVerseLength = (int)(100 * doubleVerseLength) + 10;

            this.themeBase = themeBase;

            verseList = GetBestVerses(verseCount, sampleSize, lineBase, desiredThemes, undesiredThemes, averageVerseLength, verseLengthEntropy, random);

            musicalTheme = GetMusicalTheme(desiredThemes);

            midiInstruments = GetRandomMidiInstrumentsFrom(musicalTheme);

            punctuationType = GetPunctuationType();

            modulationOffset = GetModulationOffsetList();

            title = CreateTitleFromVerses(verseList);

            if (chorusMode)
                verseList = AddChorusStructureToVerses(verseList);

            voicesListByVerse = GenerateRandomVoicesForEachVerse();

            voiceChangingRate = GetRandomVoiceChangingRate();

            keySignature = GetRandomKeySignature();

            introBarCount = GetIntroBarCount(musicalTheme);

            soloBarCount = GetSoloBarCount(musicalTheme);

            if (flagGenerateVideo)
                webPicturePool = new View.WebPicturePool(verseList, imageWidth, imageHeight);
            else
                webPicturePool = null;
        }
        #endregion

        #region Methods
        #region Getters
        public override string ToString()
        {
            string textValue = title + "\n\n";
            int counter = 0;

            foreach (string currentVerse in verseList)
            {
                counter++;
                textValue += currentVerse + "\n";
                if (counter % 4 == 0)
                    textValue += "\n";

            }

            return textValue;
        }

        private List<string> GetVersesCloseToAverageLength(List<string> randomVerses, int averageVerseLength, int verseCountAfterTrimmedByVerseLength, Random random)
        {
            List<string> trimmedRandomVerses = new List<string>();
            SortedList<double, string> ranking = new SortedList<double, string>();
            double currentRating;

            foreach (string currentVerse in randomVerses)
            {
                currentRating = Math.Abs(currentVerse.Length - averageVerseLength) + random.NextDouble() * 0.0001;
                if (!ranking.ContainsKey(currentRating))
                    ranking.Add(currentRating, currentVerse);
            }



            int counter = 0;
            foreach (KeyValuePair<double, string> currentVerse in ranking)
            {
                trimmedRandomVerses.Add(currentVerse.Value);
                counter++;
                if (counter == verseCountAfterTrimmedByVerseLength)
                    break;
            }

            return trimmedRandomVerses;
        }

        private double GetVerseRatingForCurrentContext(string currentVerse, List<Model.Theme> desiredThemes, List<Model.Theme> undesiredThemes, HashSet<string> ignoreList, Dictionary<Model.Theme, double> themeWeightList)
        {
            double rating = 0;

            string[] currentVerseWords = currentVerse.Split(' ');
            for (int i = 0; i < currentVerseWords.Length; i++)
                currentVerseWords[i] = notALetter.Replace(currentVerseWords[i], "");


            foreach (Model.Theme currentTheme in desiredThemes)
            {
                if (currentTheme != null)
                {
                    if (currentTheme.MatchAtLeastOneWordFromVerse(currentVerseWords, ignoreList))
                    {
                        rating += themeWeightList[currentTheme];
                        themeWeightList[currentTheme] -= 0.01;
                    }
                    else if (currentTheme.MatchAtLeastOneWordFromVerse(currentVerseWords, null))
                    {
                        rating += themeWeightList[currentTheme] * 0.1;
                        themeWeightList[currentTheme] -= 0.01;
                    }
                }
            }

            foreach (Model.Theme currentTheme in undesiredThemes)
            {
                if (currentTheme != null)
                {
                    if (currentTheme.MatchAtLeastOneWordFromVerse(currentVerseWords))
                    {
                        rating--;
                    }
                }
            }


            return rating;
        }

        public int GetPunctuationTypeToLine(int lineCounter)
        {
            return punctuationType[lineCounter % 4];
        }

        public int GetModulationOffsetToLine(int lineCounter)
        {
            return modulationOffset[lineCounter % 4];
        }

        public Model.Theme GetThemeFromLineNumber(int lineNumber)
        {
            return musicalTheme[lineNumber % 4];
        }

        public SpeechLib.SpObjectToken GetVoiceFromLineNumber(int lineNumber)
        {
            //return voicesListByVerse[(lineNumber / 2) % 2];
            return voicesListByVerse[(lineNumber / voiceChangingRate) % 2];
        }
        #endregion

        #region Generators
        private string CreateTitleFromVerses(List<string> verseList)
        {
            string title = "";
            title = verseList[12];

            title = title.Trim();

            while (title.Contains(' ') && title.Length > 20)
                title = RemoveFirstWordFrom(title);

            return title.ToUpper();
        }

        private int GetRandomKeySignature()
        {
            return new Random().Next(12) - 6;
        }

        private int GetRandomVoiceChangingRate()
        {
            int rate;

            Random random = new Random();

            rate = random.Next(1, 5);
            if (rate == 3)
                rate = 8;

            return rate;
        }

        private List<Model.Theme> GetMusicalTheme(List<Model.Theme> desiredThemes)
        {
            List<Model.Theme> musicalTheme = new List<Model.Theme>();

            int desiredThemeCount = 0;
            foreach (Model.Theme currentTheme in desiredThemes)
            {
                if (currentTheme != null)
                    desiredThemeCount++;
                else
                    break;
            }

            if (desiredThemeCount >= 4)
            {
                musicalTheme.Add(desiredThemes[0]);
                musicalTheme.Add(desiredThemes[1]);
                musicalTheme.Add(desiredThemes[2]);
                musicalTheme.Add(desiredThemes[3]);
            }
            else if (desiredThemeCount == 3)
            {
                Random random = new Random();
                if (random.Next(2) == 1)
                {
                    musicalTheme.Add(desiredThemes[0]);
                    musicalTheme.Add(desiredThemes[1]);
                    musicalTheme.Add(desiredThemes[0]);
                    musicalTheme.Add(desiredThemes[2]);
                }
                else
                {
                    musicalTheme.Add(desiredThemes[1]);
                    musicalTheme.Add(desiredThemes[0]);
                    musicalTheme.Add(desiredThemes[2]);
                    musicalTheme.Add(desiredThemes[0]);
                }
            }
            else if (desiredThemeCount == 2)
            {
                musicalTheme.Add(desiredThemes[0]);
                musicalTheme.Add(desiredThemes[1]);
                musicalTheme.Add(desiredThemes[0]);
                musicalTheme.Add(desiredThemes[1]);
            }
            else if (desiredThemeCount == 1)
            {
                musicalTheme.Add(desiredThemes[0]);
                musicalTheme.Add(desiredThemes[0]);
                musicalTheme.Add(desiredThemes[0]);
                musicalTheme.Add(desiredThemes[0]);
            }
            else
            {
                musicalTheme.Add(themeBase.GetRandomTheme());
                musicalTheme.Add(themeBase.GetRandomTheme());
                musicalTheme.Add(themeBase.GetRandomTheme());
                musicalTheme.Add(themeBase.GetRandomTheme());
            }

            return musicalTheme;
        }

        private List<int> GetRandomMidiInstrumentsFrom(List<Model.Theme> musicalTheme)
        {
            Random random = new Random();
            List<int> selectedInstruments = new List<int>();

            List<int> melodyInstruments = new List<int>(musicalTheme[0].MidiInstruments[0]);
            melodyInstruments.AddRange(musicalTheme[1].MidiInstruments[0]);
            melodyInstruments.AddRange(musicalTheme[2].MidiInstruments[0]);
            melodyInstruments.AddRange(musicalTheme[3].MidiInstruments[0]);

            List<int> accompInstruments = new List<int>(musicalTheme[0].MidiInstruments[1]);
            accompInstruments.AddRange(musicalTheme[1].MidiInstruments[1]);
            accompInstruments.AddRange(musicalTheme[2].MidiInstruments[1]);
            accompInstruments.AddRange(musicalTheme[3].MidiInstruments[1]);

            selectedInstruments.Add(melodyInstruments[random.Next(melodyInstruments.Count)]);
            selectedInstruments.Add(accompInstruments[random.Next(accompInstruments.Count)]);

            return selectedInstruments;
        }

        private List<SpeechLib.SpObjectToken> GenerateRandomVoicesForEachVerse()
        {
            List<SpeechLib.SpObjectToken> voiceByVerse = new List<SpeechLib.SpObjectToken>();
            List<SpeechLib.ISpeechObjectToken> voicesList = new List<SpeechLib.ISpeechObjectToken>();
            Random random = new Random();

            SpeechLib.SpVoice tts = new SpeechLib.SpVoice();
            SpeechLib.ISpeechObjectTokens speechObjectTokens = tts.GetVoices(string.Empty, string.Empty);

            foreach (SpeechLib.ISpeechObjectToken token in speechObjectTokens)
                if (token.GetDescription(49).Contains("Microsoft"))
                    voicesList.Add(token);

            for (int i = 0; i < 2; i++)
                voiceByVerse.Add((SpeechLib.SpObjectToken)(voicesList[random.Next(voicesList.Count)]));

            while (voicesList.Count > 1 && voiceByVerse[0] == voiceByVerse[1])
                voiceByVerse[1] = (SpeechLib.SpObjectToken)(voicesList[random.Next(voicesList.Count)]);

            return voiceByVerse;
        }

        private List<int> GetModulationOffsetList()
        {
            List<int> modulationOffsetList = new List<int>();
            int modulationOffsetType;

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                modulationOffsetType = random.Next(5);
                if (modulationOffsetType == 0)
                    modulationOffsetList.Add(0);
                else if (modulationOffsetType == 1)
                    modulationOffsetList.Add(5);
                else if (modulationOffsetType == 2)
                    modulationOffsetList.Add(7);
                else if (modulationOffsetType == 3)
                    modulationOffsetList.Add(-5);
                else if (modulationOffsetType == 4)
                    modulationOffsetList.Add(-7);
            }

            return modulationOffsetList;
        }

        private List<string> GetBestVerses(int verseCount, int sampleSize, Model.LineBase lineBase, List<Model.Theme> desiredThemes, List<Model.Theme> undesiredThemes, int averageVerseLength, double verseLengthEntropy, Random random)
        {
            if (sampleSize < verseCount)
                sampleSize = verseCount;

            int verseCountAfterTrimmedByVerseLength = (int)(sampleSize * verseLengthEntropy) + verseCount;
            if (verseCountAfterTrimmedByVerseLength > sampleSize)
                verseCountAfterTrimmedByVerseLength = sampleSize;

            List<string> randomVerses = lineBase.GetRandomVerse(sampleSize, random);

            //We only keep the verses with proper length
            randomVerses = GetVersesCloseToAverageLength(randomVerses, averageVerseLength, verseCountAfterTrimmedByVerseLength, random);

            return GetBestVerses(verseCount, randomVerses, desiredThemes, undesiredThemes, random);
        }

        private List<string> GetBestVerses(int verseCount, List<string> randomVerses, List<Model.Theme> desiredThemes, List<Model.Theme> undesiredThemes, Random random)
        {
            SortedList<double, string> ranking = new SortedList<double, string>();
            SortedList<double, string> trimmedRanking = new SortedList<double, string>();
            List<string> bestVerses = new List<string>();
            List<string> bestVersesInvertedList = new List<string>();
            HashSet<string> ignoreList = new HashSet<string>();
            Dictionary<Model.Theme, double> themeWeightList = new Dictionary<Ac.Lw.Model.Theme, double>();

            foreach (Model.Theme currentTheme in desiredThemes)
                if (currentTheme != null)
                    if (!themeWeightList.ContainsKey(currentTheme))
                        themeWeightList.Add(currentTheme, 32);


            double currentRating;
            int counter;

            foreach (string currentVerse in randomVerses)
            {
                currentRating = -1 * GetVerseRatingForCurrentContext(currentVerse, desiredThemes, undesiredThemes, ignoreList, themeWeightList) + random.NextDouble() * 0.0001;
                if (!ranking.ContainsKey(currentRating))
                    ranking.Add(currentRating, currentVerse);
            }

            counter = 0;
            foreach (KeyValuePair<double, string> currentVerse in ranking)
            {
                trimmedRanking.Add(currentVerse.Key, currentVerse.Value);
                counter++;
                if (counter == verseCount)
                    break;
            }

            foreach (string currentVerse in trimmedRanking.Values)
                bestVerses.Add(currentVerse);

            for (int i = verseCount - 1; i >= 0; i--)
                bestVersesInvertedList.Add(bestVerses[i]);

            return bestVersesInvertedList;
        }

        private List<int> GetPunctuationType()
        {
            List<int> punctuationType = new List<int>();

            Random random = new Random();

            int punctuationCycleType = random.Next(2);

            if (punctuationCycleType == 0)
            {
                punctuationType.Add(2);
                punctuationType.Add(3);
                punctuationType.Add(2);
                punctuationType.Add(1);
            }
            else
            {
                punctuationType.Add(3);
                punctuationType.Add(2);
                punctuationType.Add(3);
                punctuationType.Add(1);
            }

            return punctuationType;
        }

        private List<string> GetVerseFromExistingContent(string existingTextContent)
        {
            existingTextContent = existingTextContent.Replace('\t', ' ');
            
            while (existingTextContent.Contains("  "))
                existingTextContent = existingTextContent.Replace("  ", " ");

            while (existingTextContent.Contains("\n "))
                existingTextContent = existingTextContent.Replace("\n ", "\n");

            while (existingTextContent.Contains(" \n"))
                existingTextContent = existingTextContent.Replace(" \n", "\n");

            while (existingTextContent.Contains("\n\n"))
                existingTextContent = existingTextContent.Replace("\n\n", "\n");

            existingTextContent = existingTextContent.Trim();

            return new List<string>(existingTextContent.Split('\n'));
        }

        private string[] GetWordsFromLine(string existingTextContent)
        {
            existingTextContent = existingTextContent.Replace('\t', ' ');

            while (existingTextContent.Contains("\n "))
                existingTextContent = existingTextContent.Replace("\n ", "\n");

            while (existingTextContent.Contains(" \n"))
                existingTextContent = existingTextContent.Replace(" \n", "\n");

            while (existingTextContent.Contains("\n\n"))
                existingTextContent = existingTextContent.Replace("\n\n", "\n");

            while (existingTextContent.Contains("  "))
                existingTextContent = existingTextContent.Replace("  ", "\n");

            existingTextContent = existingTextContent.Trim();

            return existingTextContent.Split(' ');
        }

        private int GetSoloBarCount(List<Model.Theme> musicalThemeList)
        {
            Random random = new Random();
            return musicalThemeList[random.Next(musicalThemeList.Count)].SoloBarCount;
        }

        private int GetIntroBarCount(List<Model.Theme> musicalThemeList)
        {
            Random random = new Random();
            return musicalThemeList[random.Next(musicalThemeList.Count)].IntroBarCount;
        }
        #endregion

        #region Mutators
        private string RemoveFirstWordFrom(string text)
        {
            string[] words = text.Split(' ');
            string newText = "";

            for (int i = 1; i < words.Length; i++)
                newText += words[i] + " ";

            newText = newText.Trim();

            return newText;
        }

        private List<string> AddChorusStructureToVerses(List<string> verseList)
        {
            if (verseList.Count == 16)
            {
                List<string> newVerseList = new List<string>();

                newVerseList.Add(verseList[0]);
                newVerseList.Add(verseList[1]);
                newVerseList.Add(verseList[2]);
                newVerseList.Add(verseList[3]);
                newVerseList.Add(verseList[12]);
                newVerseList.Add(verseList[13]);
                newVerseList.Add(verseList[14]);
                newVerseList.Add(verseList[15]);
                newVerseList.Add(verseList[4]);
                newVerseList.Add(verseList[5]);
                newVerseList.Add(verseList[6]);
                newVerseList.Add(verseList[7]);
                newVerseList.Add(verseList[12]);
                newVerseList.Add(verseList[13]);
                newVerseList.Add(verseList[14]);
                newVerseList.Add(verseList[15]);
                newVerseList.Add(verseList[8]);
                newVerseList.Add(verseList[9]);
                newVerseList.Add(verseList[10]);
                newVerseList.Add(verseList[11]);
                newVerseList.Add(verseList[12]);
                newVerseList.Add(verseList[13]);
                newVerseList.Add(verseList[14]);
                newVerseList.Add(verseList[15]);
                newVerseList.Add(verseList[12]);
                newVerseList.Add(verseList[13]);
                newVerseList.Add(verseList[14]);
                newVerseList.Add(verseList[15]);

                return newVerseList;
            }

            return verseList;
        }

        #region Line splitter
        private int GetSpaceMidPoint(string currentLine)
        {
            int center = currentLine.Length / 2;
            int rightPosition = 0;
            int leftPosition = 0;

            for (rightPosition = center; rightPosition < currentLine.Length - 1; rightPosition++)
                if (currentLine[rightPosition] == ' ')
                    break;

            for (leftPosition = center; leftPosition > 0; leftPosition--)
                if (currentLine[leftPosition] == ' ')
                    break;

            if (leftPosition == 0)
                leftPosition = -1;
            if (rightPosition == currentLine.Length - 1)
                rightPosition = -1;

            if (leftPosition < rightPosition)
                return leftPosition;
            else
                return rightPosition;
        }

        public void SplitLines()
        {
            List<string> newLines = new List<string>();
            string part1, part2;

            foreach (string currentLine in this)
            {
                SplitLine(currentLine, out part1, out part2);
                newLines.Add(part1);
                newLines.Add(part2);
            }

            this.verseList = newLines;

            this.voiceChangingRate *= 2;
        }

        private void SplitLine(string currentLine, out string part1, out string part2)
        {
            int midPoint = GetMidPoint(currentLine);
            part1 = currentLine.Substring(0, midPoint);
            part2 = currentLine.Substring(midPoint);
        }

        private int GetMidPoint(string currentLine)
        {
            int midPoint = GetSpaceMidPoint(currentLine);

            if (midPoint == -1)
                midPoint = currentLine.Length / 2;

            return midPoint;
        }
        #endregion
        #endregion

        #region Implements
        public IEnumerator GetEnumerator()
        {
            return verseList.GetEnumerator();
        }
        #endregion
        #endregion

        #region Properties
        public int Count
        {
            get { return verseList.Count; }
        }

        public List<int> MidiInstruments
        {
            get { return midiInstruments; }
        }

        public int KeySignature
        {
            get { return keySignature; }
        }

        public int Speed
        {
            get { return speed; }
        }

        public int SoloTimePosition
        {
            get { return soloTimePosition; }
        }

        public bool FlagAddMoreEntropyAtTheEnd
        {
            get { return flagAddMoreEntropyAtTheEnd; }
        }

        public bool EnableSolo
        {
            get { return enableSolo; }
        }

        public bool EnableIntro
        {
            get { return enableIntro; }
        }

        public int IntroBarCount
        {
            get { return introBarCount; }
        }

        public int SoloBarCount
        {
            get { return soloBarCount; }
        }

        public View.WebPicturePool WebPicturePool
        {
            get { return webPicturePool; }
        }

        public string Title
        {
            get { return title; }
        }
        #endregion
    }
}
