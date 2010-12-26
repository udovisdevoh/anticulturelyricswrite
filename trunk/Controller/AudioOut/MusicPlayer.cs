using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;

namespace Ac.Lw.Controller.AudioOut
{
    class MusicPlayer
    {
        #region Imports
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
        #endregion

        #region Fields
        private Lyric lyric;

        private Model.ThemeBase themeBase;

        private Talker talker = new Talker();

        private MidiPlayer midiPlayer = new MidiPlayer();

        private static Regex notALetterNorASpace = new Regex("[^a-zA-Z0-9-' ]");

        private const int latency = 0;

        private const int voiceTimeMultiplicator = 60;//60

        private bool flagVocoderMode;

        private View.VideoWindow videoWindow = new View.VideoWindow();
        #endregion

        #region Constructor
        public MusicPlayer(Model.ThemeBase themeBase)
        {
            this.themeBase = themeBase;
        }
        #endregion

        #region Methods
        #region Actions
        public void Play()
        {
            if (flagVocoderMode)
            {
                midiPlayer.PanChannel(0, 0);
                midiPlayer.PanChannel(1, 0);
                midiPlayer.PanChannel(9, 0);
                midiPlayer.PanChannel(2, 127);
                PanWave(0);
            }
            else
            {
                midiPlayer.PanChannel(0, 32);
                midiPlayer.PanChannel(1, 96);
                midiPlayer.PanChannel(9, 64);
                PanWave(64);
            }

            int soloTimePosition;
            talker.Speed = lyric.Speed;

            while (GetMaxCharLength(lyric) >= GetMaxCharLengthPerLineFromSpeed(lyric.Speed))
                lyric.SplitLines();

            int msAverageLength = GetMsAverageLength(lyric, lyric.Speed);

            if (lyric.Count <= 16)
                soloTimePosition = 7;
            else
                soloTimePosition = lyric.SoloTimePosition * lyric.Count / 28;

            int lineCounter = 0;


            if (lyric.WebPicturePool != null)
                videoWindow.PlayImage("<h1>" + lyric.Title + "</h1><h2>This video clip, music and lyrical content was created entirely by a machine. Please visit us at</h2><h1>www.anticulture.net</h1>", null);


            if (lyric.EnableIntro)
                PlayIntro(msAverageLength, lyric.IntroBarCount);

            foreach (string line in lyric)
            {
                if (lyric.FlagAddMoreEntropyAtTheEnd && lineCounter >= soloTimePosition)
                {
                    if (lyric.EnableSolo && lineCounter == soloTimePosition)
                        PlaySolo(msAverageLength,lineCounter, lyric.SoloBarCount);

                    //Display the image
                    if (lyric.WebPicturePool != null)
                        videoWindow.PlayImage("<h1>" + notALetterNorASpace.Replace(line, "") + "</h1>", lyric.WebPicturePool.GetBestImages(line));

                    //Play this bar with more interval entropy
                    PlayLine(notALetterNorASpace.Replace(line, ""), msAverageLength, lineCounter, lyric, lyric.GetPunctuationTypeToLine(lineCounter), lyric.GetModulationOffsetToLine(lineCounter),true, true);
                }
                else
                {
                    //Display the image
                    if (lyric.WebPicturePool != null)
                        videoWindow.PlayImage("<h1>" + notALetterNorASpace.Replace(line, "") + "</h1>", lyric.WebPicturePool.GetBestImages(line));

                    //Play this bar the normal way
                    PlayLine(notALetterNorASpace.Replace(line, ""), msAverageLength, lineCounter, lyric, lyric.GetPunctuationTypeToLine(lineCounter), lyric.GetModulationOffsetToLine(lineCounter), false, true);
                }
                lineCounter++;
            }

            if (lyric.WebPicturePool != null)
                videoWindow.PlayImage("<h2>This video clip, music and lyrical content was created entirely by a machine. Please visit us at</h2><h1>www.anticulture.net</h1>", null);

            PlayOutro(msAverageLength,lineCounter);
            Stop();
        }

        private void PlayIntro(int lengthByPar, int barCount)
        {
            for (int i = 0; i < barCount; i ++)
                PlayLine("", lengthByPar, 0, lyric, 0, lyric.GetModulationOffsetToLine(i), false, false);
        }

        private void PlayOutro(int msAverageLength, int lineCounter)
        {
            for (int i = 0 ; i < 4; i++)
                PlayRiff(lyric.GetThemeFromLineNumber(i).MusicIntervals, msAverageLength / 8, latency, 8, -1, lyric.MidiInstruments, false, false, false, lineCounter, true, true);
            PlayRiff(lyric.GetThemeFromLineNumber(0).MusicIntervals, msAverageLength / 2, latency, 8, -1, lyric.MidiInstruments, false, false, false, lineCounter, false, true);
        }

        private void PlaySolo(int lengthByPar, int lineCounter, int barCount)
        {
            for (int i = 0; i < barCount; i++)
                PlayLine("", lengthByPar, lineCounter + i, lyric, 0, lyric.GetModulationOffsetToLine(lineCounter), true, true);
        }
               
        private void PlayRiff(List<int> musicIntervals, int msLength, int latency, int timeDivision, int ternaryBeatSetting, List<int> midiInstruments, bool isDoubleBeatFrequency, bool playKickNow, bool playSnareNow, int lineNumber, bool playMoreNote, bool playMelodyInstrument)
        {
            #warning Must split long sentences before , they and a my your you he she when where while at the etc... if it's not to far from the middle or just ajust playback rate
            #warning Must pre-render by-theme lyrics file
            #warning ?Build song in another thread, add process bar to status car, press esc or click cancel to cancel build, reclick on build to cancel and build again?
            #warning Enable language selection
            #warning From the pool, delete pictures that can't be found
            #warning no picture found?: get random picture from the pool

            Random random = new Random();
            int rythmType = random.Next(4);
            int ternaryProbability;
            int beatDoubler = 1;
            if (isDoubleBeatFrequency)
                beatDoubler = 2;


            if (msLength / 2 < latency || timeDivision >= 12)
                rythmType = 1;
            else if (timeDivision < 4)
                rythmType = 2;
            else if (playMoreNote && timeDivision < 4 * beatDoubler)
                rythmType = 2;


            if (rythmType == 1)
            {
                midiPlayer.Play(musicIntervals, midiInstruments, playKickNow, playSnareNow, lyric.KeySignature, playMelodyInstrument); //Play midi in background
                Thread.Sleep(msLength - latency); //We wait for a definite amount of time
                midiPlayer.Stop();
            }
            else
            {
                if (ternaryBeatSetting == -1)
                    ternaryProbability = 6;
                else if (ternaryBeatSetting == 0)
                    ternaryProbability = 3;
                else
                    ternaryProbability = 2;

                if (random.Next(ternaryProbability) == 1 && (timeDivision == 8) && msLength / 3 >= latency && (ternaryBeatSetting == 0 || ternaryBeatSetting == 1))
                {
                    PlayRiff(musicIntervals, msLength / 3, 0, timeDivision * 3, ternaryBeatSetting, midiInstruments, isDoubleBeatFrequency, playKickNow, playSnareNow, lineNumber, playMoreNote, playMelodyInstrument);

                    if (timeDivision > 1 * beatDoubler)
                    {
                        playKickNow = false;
                        if (timeDivision == 2 * beatDoubler)
                            playSnareNow = true;
                        else
                            playSnareNow = false;
                    }


                    PlayRiff(musicIntervals, msLength / 3, 0, timeDivision * 3, ternaryBeatSetting, midiInstruments, isDoubleBeatFrequency, playKickNow, playSnareNow, lineNumber, playMoreNote, playMelodyInstrument);
                    PlayRiff(musicIntervals, msLength / 3, latency, timeDivision * 3, ternaryBeatSetting, midiInstruments, isDoubleBeatFrequency, playKickNow, playSnareNow, lineNumber, playMoreNote, playMelodyInstrument);
                }
                else
                {
                    PlayRiff(musicIntervals, msLength / 2, 0, timeDivision * 2, ternaryBeatSetting, midiInstruments, isDoubleBeatFrequency, playKickNow, playSnareNow, lineNumber, playMoreNote, playMelodyInstrument);

                    if (timeDivision > 1 * beatDoubler)
                    {
                        playKickNow = false;
                        if (timeDivision == 2 * beatDoubler)
                            playSnareNow = true;
                        else
                            playSnareNow = false;
                    }

                    PlayRiff(musicIntervals, msLength / 2, latency, timeDivision * 2, ternaryBeatSetting, midiInstruments, isDoubleBeatFrequency, playKickNow, playSnareNow, lineNumber, playMoreNote, playMelodyInstrument);
                }
            }
        }

        private void PlayLine(string textLine, int msLength, int lineNumber, Lyric lyric, int punctuationType, int modulationOffset, bool playMoreNote, bool playMelodyInstrument)
        {
            textLine = AddPunctuation(textLine, punctuationType);
            Model.Theme tokenTheme = lyric.GetThemeFromLineNumber(lineNumber);
            talker.Voice = lyric.GetVoiceFromLineNumber(lineNumber);
            List<int> modulatedIntervals = AddModulation(tokenTheme.MusicIntervals, modulationOffset);


            if (flagVocoderMode)
                midiPlayer.PlayCarrier(modulatedIntervals);

            if (talker.FlagEnableSpeedRegulation && lineNumber > 0)
            {
                if (lineNumber < 8 && talker.IsTalking())
                    talker.Speed++;
                else if (lineNumber < 6)
                    talker.Speed--;
            }
            talker.Speak(textLine); //Play voice in background

            if (playMoreNote)
                modulatedIntervals = AddMoreEntropyToIntervals(modulatedIntervals);

            PlayRiff(modulatedIntervals, msLength, latency, 1, tokenTheme.TernaryBeatSetting, lyric.MidiInstruments, tokenTheme.IsDoubleBeatFrequency, true, false, lineNumber, playMoreNote, playMelodyInstrument);
        }

        public void Stop()
        {
            if (flagVocoderMode)
                PanWave(64);

            talker.Stop();
            midiPlayer.StopAll();
        }

        private void PanWave(int panValue)
        {
            uint leftVolume = GetLeftVolumeFromPanValue(panValue);
            uint rightVolume = GetRightVolumeFromPanValue(panValue);


            #warning Must refactor Pan so it works for every value and it doesn't change volume (must take original volume)

            uint combinedVolume = (((uint)leftVolume & 0x0000ffff) | ((uint)rightVolume << 16));

            waveOutSetVolume(IntPtr.Zero, combinedVolume);
        }

        private uint GetLeftVolumeFromPanValue(int panValue)
        {
            uint volume = 127 - (uint)panValue;
            volume = (uint)(volume) * 2;
            if (volume > 127)
                volume = 127;

            return volume * 320;
        }

        private uint GetRightVolumeFromPanValue(int panValue)
        {
            uint volume;
            volume = (uint)(panValue) * 2;
            if (volume > 127)
                volume = 127;

            return volume * 320;
        }
        #endregion

        #region Getters
        private int GetMaxCharLengthPerLineFromSpeed(int speed)
        {
            if (speed == -3)
                return 33;
            else if (speed == -2)
                return 39;
            else if (speed == -1)
                return 45;
            else if (speed == 0)
                return 50;
            else if (speed == 1)
                return 60;
            else if (speed == 2)
                return 70;
            else if (speed == 3)
                return 80;

            return 50;
        }

        private int GetMsAverageLength(Lyric lyric, int speed)
        {
            int averageCharLength = GetMaxCharLength(lyric);

            if (speed == -3)
                return (int)((averageCharLength * voiceTimeMultiplicator + 400) * 1.5 + latency);
            else if (speed == -2)
                return (int)((averageCharLength * voiceTimeMultiplicator + 400) * 1.333 + latency);
            else if (speed == -1)
                return (int)((averageCharLength * voiceTimeMultiplicator + 400) * 1.16 + latency);
            else if (speed == 0)
                return averageCharLength * voiceTimeMultiplicator + 400 + latency;
            else if (speed == 1)
                return (int)((averageCharLength * voiceTimeMultiplicator + 400) / 1.16 + latency);
            else if (speed == 2)
                return (int)((averageCharLength * voiceTimeMultiplicator + 400) / 1.333 + latency);
            else if (speed == 3)
                return (int)((averageCharLength * voiceTimeMultiplicator + 400) / 1.5 + latency);



            return averageCharLength * voiceTimeMultiplicator + 400 + latency;
        }

        private int GetMaxCharLength(Lyric lyric)
        {
            int maxLength = 0;
            int currentLength;
            foreach (string line in lyric)
            {
                currentLength = notALetterNorASpace.Replace(line, "").Length;
                if (maxLength < currentLength)
                    maxLength = currentLength;
            }

            return maxLength;
        }

        private int GetAverageCharLength(Lyric lyric)
        {
            int totalLength = 0;
            foreach (string line in lyric)
                totalLength += notALetterNorASpace.Replace(line, "").Length;

            return totalLength / lyric.Count;
        }

        private List<int> GetRegularMusicIntervals()
        {
            List<int> musicIntervals = new List<int>();
            musicIntervals.Add(0);
            musicIntervals.Add(0);
            musicIntervals.Add(0);
            musicIntervals.Add(0);

            musicIntervals.Add(12);
            musicIntervals.Add(12);
            musicIntervals.Add(12);
            musicIntervals.Add(12);

            musicIntervals.Add(7);
            musicIntervals.Add(7);
            musicIntervals.Add(7);
            musicIntervals.Add(7);

            musicIntervals.Add(5);
            musicIntervals.Add(5);
            musicIntervals.Add(5);
            musicIntervals.Add(5);

            musicIntervals.Add(4);
            musicIntervals.Add(4);
            musicIntervals.Add(4);

            musicIntervals.Add(3);
            musicIntervals.Add(3);
            musicIntervals.Add(3);

            musicIntervals.Add(2);
            musicIntervals.Add(2);

            musicIntervals.Add(9);
            musicIntervals.Add(11);

            return musicIntervals;
        }
        #endregion

        #region Mutators
        private List<int> AddMoreEntropyToIntervals(List<int> modulatedIntervals)
        {
            List<int> intervalsWithMoreEntropy = new List<int>(modulatedIntervals);

            foreach (int currentInterval in modulatedIntervals)
            {
                intervalsWithMoreEntropy.Add(currentInterval + 24);
                intervalsWithMoreEntropy.Add(currentInterval + 12);
                intervalsWithMoreEntropy.Add(currentInterval + 7);
            }

            return intervalsWithMoreEntropy;
        }

        private string AddPunctuation(string textLine, int punctuationType)
        {
            if (punctuationType == 1)
                textLine += ".";
            else if (punctuationType == 2)
                textLine += "?";
            else if (punctuationType == 3)
                textLine += "!";

            return textLine;
        }

        private List<int> AddModulation(List<int> oldIntervals, int offset)
        {
            Random random = new Random();
            List<int> newInvervals = new List<int>(oldIntervals);

            for (int i = 0; i < newInvervals.Count; i++)
                newInvervals[i] += offset;

            return newInvervals;
        }
        #endregion       
        #endregion
        
        #region Properties
        public Lyric Lyric
        {
            get { return lyric; }
            set { lyric = value; }
        }

        public int VoiceVolume
        {
            get { return talker.Volume; }
            set { talker.Volume = value; }
        }

        public bool FlagEnableSpeedRegulation
        {
            get { return talker.FlagEnableSpeedRegulation; }
            set { talker.FlagEnableSpeedRegulation = value;}
        }

        public int MidiVolume
        {
            get { return midiPlayer.Volume; }
            set { midiPlayer.Volume = value; }
        }

        public bool FlagVocoderMode
        {
            get { return flagVocoderMode; }
            set { flagVocoderMode = value; }
        }

        public View.VideoWindow VideoWindow
        {
            get { return videoWindow; }
            set { videoWindow = value; }
        }
        #endregion
    }
}