using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Ac.Lw.Controller
{
    class LyricBuilder
    {
        #region Fields
        private const int desiredThemeCount = 10;

        private double verseLength;

        private double verseLengthEntropy;

        private int totalSampleSize;

        private bool chorusMode;

        private int verseCount = 16;

        private Model.ThemeBase themeBase;

        private Model.LineBase lineBase;

        private List<Model.Theme> desiredThemes = new List<Model.Theme>(desiredThemeCount);

        private List<Model.Theme> undesiredThemes = new List<Model.Theme>(desiredThemeCount);

        private Random random = new Random();

        private AudioOut.MusicPlayer musicPlayer;

        private View.MainWindow mainWindow;

        private Lyric lyric;

        private Thread threadMusicPlay;

        private int speed;

        private bool enableSolo;

        private bool enableIntro;

        private int soloTimePosition = 20;

        private bool flagEnableVideo;
        #endregion

        #region Constructor
        public LyricBuilder()
        {
            themeBase = new Model.ThemeBase("Themes.txt");

            lineBase = new Model.LineBase("lyrics.en.txt");

            musicPlayer = new AudioOut.MusicPlayer(themeBase);

            mainWindow = new View.MainWindow(themeBase,musicPlayer.VoiceVolume);

            //We create the handlers that come from the View
            mainWindow.UserChangeTheme += UserChangeThemeHandler;
            mainWindow.UserClickBuild += UserClickBuildHandler;
            mainWindow.UserClickPlay += UserClickPlayHandler;
            mainWindow.UserClickStop += UserClickStopHandler;
            mainWindow.UserClickRandomize += UserClickRandomizeHandler;
            mainWindow.UserClickDefault += UserClickDefaultHandler;
            mainWindow.UserScrollTrackBarVerseLength += UserScrollTrackBarVerseLengthHandler;
            mainWindow.UserScrollTrackBarVerseLengthEntropy += UserScrollTrackBarVerseLengthEntropyHandler;
            mainWindow.UserChangeCheckBoxChorusMode += UserChangeCheckBoxChorusModeHandler;
            mainWindow.UserChangeVoiceVolume += UserChangeVoiceVolumeHandler;
            mainWindow.UserClickInterpret += UserClickInterpretHandler;
            mainWindow.UserChangeSpeed += UserChangeSpeedHandler;
            mainWindow.UserChangeCheckBoxEnableSolo += UserChangeCheckBoxEnableSoloHandler;
            mainWindow.UserChangeCheckBoxEnableIntro += UserChangeCheckBoxEnableIntroHandler;
            mainWindow.UserChangeSpeedRegulation += UserChangeSpeedRegulationHandler;
            mainWindow.UserChangeThemeFidelity += UserChangeThemeFidelityHandler;
            mainWindow.UserChangeMidiVolume += UserChangeMidiVolumeHandler;
            mainWindow.UserChangeVocoderMode += UserChangeVocoderModeHandler;
            mainWindow.UserChangeGenerateVideo += UserChangeGenerateVideoHandler;
            

            //We set the desired and undesired themes to null
            for (int i = 0; i < desiredThemeCount; i++)
            {
                desiredThemes.Add(null);
                undesiredThemes.Add(null);
            }


            //Create a trimmed lyric text database: Model.DataTrimmer.TrimData("lyrics.en.txt", "lyrics.en.trimmed.txt", themeBase);
            SetDefaultSettingValues();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Sets the average verse length (from 0 to 1)
        /// </summary>
        public double VerseLength
        {
            get { return verseLength; }
            set { verseLength = value; }
        }

        /// <summary>
        /// Sets the entropy of lengths for verses
        /// </summary>
        public double VerseLengthEntropy
        {
            get { return verseLengthEntropy; }
            set { verseLengthEntropy = value; }
        }

        /// <summary>
        /// Sets the amount of sampled verse while choosing the best verse
        /// </summary>
        public int SampleSize
        {
            get { return totalSampleSize; }
            set { totalSampleSize = value; }
        }

        /// <summary>
        /// Sets the amount of verse
        /// </summary>
        public int VerseCount
        {
            get { return verseCount; }
            set { verseCount = value; }
        }
        #endregion

        #region Handlers
        private void UserChangeThemeHandler(object sender, View.ThemeSelectionEventArgs e)
        {
            List<Model.Theme> affectedThemeList;

            if (e.isDesired)
                affectedThemeList = desiredThemes;
            else
                affectedThemeList = undesiredThemes;

            affectedThemeList[e.id] = themeBase.GetTheme(e.name);
        }

        private void UserClickBuildHandler(object sender, View.TextEventArgs e)
        {
            //threadBuildLyric = new Thread(Build);
            //threadBuildLyric.Start();
            lyric = Build();
            mainWindow.LyricText = lyric.ToString();
        }

        private void UserClickRandomizeHandler(object sender, View.TextEventArgs e)
        {
            Random random = new Random();

            verseLength = random.NextDouble() * 0.415 + 0.085;
            mainWindow.TrackBarVerseLength = verseLength;

            verseLengthEntropy = random.NextDouble() * 0.4 + 0.1;
            mainWindow.TrackBarVerseLengthEntropy = verseLengthEntropy;

            speed = random.Next(-1, 2);
            if (verseLength > 0.3 && speed < 1)
                speed = 1;
            mainWindow.Speed = speed;
        }

        private void UserClickDefaultHandler(object sender, View.TextEventArgs e)
        {
            SetDefaultSettingValues();
        }

        private void UserScrollTrackBarVerseLengthHandler(object sender, View.TextEventArgs e)
        {
            verseLength = mainWindow.TrackBarVerseLength;
        }

        private void UserScrollTrackBarVerseLengthEntropyHandler(object sender, View.TextEventArgs e)
        {
            verseLengthEntropy = mainWindow.TrackBarVerseLengthEntropy;
        }

        private void UserClickPlayHandler(object sender, View.TextEventArgs e)
        {
            if (lyric == null)
            {
                mainWindow.ShowErrorMessage("Please build your a song first.");
            }
            else
            {
                if (lyric.WebPicturePool != null)
                {
                    musicPlayer.VideoWindow.Show();
                }


                musicPlayer.Lyric = lyric;
                //musicPlayer.Play() (for the singlethread version)
                threadMusicPlay = new Thread(new ThreadStart(musicPlayer.Play));
                threadMusicPlay.IsBackground = true;
                threadMusicPlay.Start();
            }
        }

        private void UserClickStopHandler(object sender, View.TextEventArgs e)
        {
            musicPlayer.VideoWindow.Hide();

            musicPlayer.Stop();
            if (threadMusicPlay != null)
                threadMusicPlay.Abort();
        }

        private void UserChangeCheckBoxChorusModeHandler(object sender, View.TextEventArgs e)
        {
            chorusMode = mainWindow.CheckBoxChorusMode;
        }

        private void UserChangeVoiceVolumeHandler(object sender, View.TextEventArgs e)
        {
            musicPlayer.VoiceVolume = mainWindow.VoiceVolume;
        }

        private void UserClickInterpretHandler(object sender, View.TextEventArgs e)
        {
            lyric = Build(mainWindow.GetInputTextExistingLyrics());
            mainWindow.LyricText = lyric.ToString();
        }

        private void UserChangeSpeedHandler(object sender, View.TextEventArgs e)
        {
            speed = mainWindow.Speed;
        }

        private void UserChangeCheckBoxEnableSoloHandler(object sender, View.TextEventArgs e)
        {
            this.enableSolo = mainWindow.EnableSolo;
        }

        private void UserChangeCheckBoxEnableIntroHandler(object sender, View.TextEventArgs e)
        {
            this.enableIntro = mainWindow.EnableIntro;
        }

        private void UserChangeSpeedRegulationHandler(object sender, View.TextEventArgs e)
        {
            this.musicPlayer.FlagEnableSpeedRegulation = mainWindow.FlagSpeedRegulation;
        }

        private void UserChangeThemeFidelityHandler(object sender, View.TextEventArgs e)
        {
            this.totalSampleSize = mainWindow.ThemeFidelity;
        }

        private void UserChangeMidiVolumeHandler(object sender, View.TextEventArgs e)
        {
            this.musicPlayer.MidiVolume = mainWindow.MidiVolume;
        }

        private void UserChangeVocoderModeHandler(object sender, View.TextEventArgs e)
        {
            musicPlayer.FlagVocoderMode = mainWindow.FlagVocoderMode;
        }

        private void UserChangeGenerateVideoHandler(object sender, View.TextEventArgs e)
        {
            flagEnableVideo = mainWindow.FlagEnableVideo;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Generates a new song's text
        /// </summary>
        /// <returns>Returns a new lyric object</returns>
        public Lyric Build()
        {
            return new Lyric(verseLength, verseLengthEntropy, lineBase, desiredThemes, undesiredThemes, totalSampleSize, verseCount, themeBase, random, chorusMode, speed, enableSolo, soloTimePosition, enableIntro, flagEnableVideo);
        }

        public Lyric Build(string existingLyricText)
        {
            return new Lyric(existingLyricText, themeBase, speed, enableSolo, soloTimePosition, enableIntro, flagEnableVideo);
        }

        private void SetDefaultSettingValues()
        {
            verseLength = 0.2;
            mainWindow.TrackBarVerseLength = verseLength;

            verseLengthEntropy = 0.1;
            mainWindow.TrackBarVerseLengthEntropy = verseLengthEntropy;

            mainWindow.CheckBoxChorusMode = chorusMode = true;

            speed = 1;
            mainWindow.Speed = speed;

            enableSolo = true;
            mainWindow.EnableSolo = enableSolo;

            enableIntro = true;
            mainWindow.EnableIntro = enableIntro;

            mainWindow.FlagSpeedRegulation = false;

            totalSampleSize = 20000;
            mainWindow.ThemeFidelity = totalSampleSize;
        }

        public void RunGui()
        {
            Application.Run(mainWindow);
        }
        #endregion
    }
}