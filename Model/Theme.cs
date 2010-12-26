using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ac.Lw.Model
{
    public class Theme
    {
        #region Fields
        private string name;

        private HashSet<string> data;

        private List<int> musicIntervals;

        private static List<Model.MusicInterval> availableMusicIntervals = BuildAvailableMusicIntervals();

        private int ternaryBeatSetting;

        private List<List<int>> midiInstruments;

        private bool isDoubleBeatFrequency;

        private int introBarCount;

        private int soloBarCount;
        #endregion

        #region Construction
        public Theme()
        {
            name = "";
            musicIntervals = new List<int>();
        }

        public Theme(string rawData)
        {
            name = GetPropertyFromRawData("name",rawData);
            musicIntervals = GetMusicIntervalsFromRawData(rawData);
            midiInstruments = GetMidiInstrumentsFromRawData(rawData);
            isDoubleBeatFrequency = GetWheterOrNotDoubleBeatFrequency(rawData);
            ternaryBeatSetting = int.Parse(GetPropertyFromRawData("ternary", rawData));
            soloBarCount = int.Parse(GetPropertyFromRawData("solobarcount", rawData));
            introBarCount = int.Parse(GetPropertyFromRawData("introbarcount", rawData));
            data = Refine(rawData);
        }
        #endregion

        #region Methods
        #region Getters
        public bool Contains(string word)
        {
            return data.Contains(word);
        }

        public bool MatchAtLeastOneWordFromVerse(string[] currentVerseWords)
        {
            return MatchAtLeastOneWordFromVerse(currentVerseWords, null);
        }

        public bool MatchAtLeastOneWordFromVerse(string[] currentVerseWords, HashSet<string> ignoreList)
        {
            foreach (string word in currentVerseWords)
                if (ignoreList == null || !ignoreList.Contains(word))
                    if (Contains(word))
                    {
                        if (ignoreList != null)
                            ignoreList.Add(word);
                        return true;
                    }

            return false;
        }
        #endregion

        #region Mutators
        public void AddRange(Theme otherTheme)
        {
            musicIntervals.AddRange(otherTheme.MusicIntervals);
        }
        #endregion

        #region Generators
        private List<List<int>> GetMidiInstrumentsFromRawData(string rawData)
        {
            List<List<int>> midiInstruments = new List<List<int>>();

            string midiInstrument1 = GetPropertyFromRawData("melodyinstru", rawData);
            string[] midiInstrument1List = midiInstrument1.Split(',');

            string midiInstrument2 = GetPropertyFromRawData("accompinstru", rawData);
            string[] midiInstrument2List = midiInstrument2.Split(',');

            midiInstruments.Add(new List<int>());
            midiInstruments.Add(new List<int>());

            foreach (string currentInstrumentNumber in midiInstrument1List)
                midiInstruments[0].Add(int.Parse(currentInstrumentNumber));

            foreach (string currentInstrumentNumber in midiInstrument2List)
                midiInstruments[1].Add(int.Parse(currentInstrumentNumber));

            return midiInstruments;
        }

        private List<int> GetMusicIntervalsFromRawData(string rawData)
        {
            List<int> musicIntervals = new List<int>();

            string musicIntervalInfo = GetPropertyFromRawData("intervals", rawData);

            string[] musicIntervalInfoList = musicIntervalInfo.Split(',');

            foreach (string currentInfo in musicIntervalInfoList)
                musicIntervals.Add(int.Parse(currentInfo));

            return musicIntervals;
        }

        private bool GetWheterOrNotDoubleBeatFrequency(string rawData)
        {
            if (GetPropertyFromRawData("doublebeat", rawData) == "1")
                return true;
            return false;
        }

        private HashSet<string> Refine(string rawData)
        {
            rawData = rawData.Substring(rawData.IndexOf('>') + 1);

            string[] wordList = rawData.Split(',');

            for (int i = 0; i < wordList.Length; i++)
            {
                wordList[i] = wordList[i].Trim();
            }

            HashSet<string> data = new HashSet<string>(wordList);
            return data;
        }

        private string GetPropertyFromRawData(string propertyName, string rawData)
        {
            rawData = rawData.Substring(rawData.IndexOf(" " + propertyName + "="));

            rawData = rawData.Substring(rawData.IndexOf('"') + 1);

            rawData = rawData.Substring(0, rawData.IndexOf('"'));

            return rawData;
        }

        private static List<MusicInterval> BuildAvailableMusicIntervals()
        {
            List<MusicInterval> musicIntervalList = new List<MusicInterval>();

            musicIntervalList.Add(new MusicInterval(0, 1, 0));
            musicIntervalList.Add(new MusicInterval(1, -0.8, 0));
            musicIntervalList.Add(new MusicInterval(2, -0.2, 0));
            musicIntervalList.Add(new MusicInterval(3, 0.2, -1));
            musicIntervalList.Add(new MusicInterval(4, 0.2, 1));
            musicIntervalList.Add(new MusicInterval(5, 0.6, 0));
            musicIntervalList.Add(new MusicInterval(6, -1, 0));
            musicIntervalList.Add(new MusicInterval(7, 0.6, 0));
            musicIntervalList.Add(new MusicInterval(8, -0.6, 0));
            musicIntervalList.Add(new MusicInterval(9, -0.6, 0));
            musicIntervalList.Add(new MusicInterval(10, -0.2, 0));
            musicIntervalList.Add(new MusicInterval(11, -0.8, 0));
            musicIntervalList.Add(new MusicInterval(12, 1, 0));

            return musicIntervalList;
        }
        #endregion
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
        }

        public List<int> MusicIntervals
        {
            get { return musicIntervals; }
        }

        public int TernaryBeatSetting
        {
            get { return ternaryBeatSetting; }
        }

        public List<List<int>> MidiInstruments
        {
            get { return midiInstruments; }
        }

        public bool IsDoubleBeatFrequency
        {
            get { return isDoubleBeatFrequency; }
        }

        public int IntroBarCount
        {
            get { return introBarCount; }
        }

        public int SoloBarCount
        {
            get { return soloBarCount; }
        }
        #endregion
    }
}
