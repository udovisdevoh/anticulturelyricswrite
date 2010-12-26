using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ac.Lw.View
{
    public partial class MainWindow : Form
    {
        #region Fields
        Model.ThemeBase themeBase;

        TextInputDialog inputExistingLyricsWindow;
        #endregion

        #region Events
        public event EventHandler<ThemeSelectionEventArgs> UserChangeTheme;
        public event EventHandler<TextEventArgs> UserClickBuild;
        public event EventHandler<TextEventArgs> UserClickRandomize;
        public event EventHandler<TextEventArgs> UserClickDefault;
        public event EventHandler<TextEventArgs> UserClickPlay;
        public event EventHandler<TextEventArgs> UserClickStop;
        public event EventHandler<TextEventArgs> UserScrollTrackBarVerseLength;
        public event EventHandler<TextEventArgs> UserScrollTrackBarVerseLengthEntropy;
        public event EventHandler<TextEventArgs> UserChangeCheckBoxChorusMode;
        public event EventHandler<TextEventArgs> UserChangeVoiceVolume;
        public event EventHandler<TextEventArgs> UserClickInterpret;
        public event EventHandler<TextEventArgs> UserChangeSpeed;
        public event EventHandler<TextEventArgs> UserChangeCheckBoxEnableSolo;
        public event EventHandler<TextEventArgs> UserChangeCheckBoxEnableIntro;
        public event EventHandler<TextEventArgs> UserChangeSplitChannelSplit;
        public event EventHandler<TextEventArgs> UserChangeSpeedRegulation;
        public event EventHandler<TextEventArgs> UserChangeThemeFidelity;
        public event EventHandler<TextEventArgs> UserChangeMidiVolume;
        public event EventHandler<TextEventArgs> UserChangeVocoderMode;
        public event EventHandler<TextEventArgs> UserChangeGenerateVideo;

        private void OnUserChangeTheme(bool isDesired, int id, string newThemeName)
        {
            if (UserChangeTheme != null) UserChangeTheme(this, new ThemeSelectionEventArgs(isDesired, id, newThemeName));
        }

        private void OnUserClickBuild()
        {
            if (UserClickBuild != null) UserClickBuild(this, new TextEventArgs(""));
        }

        private void OnUserClickPlay()
        {
            if (UserClickPlay != null) UserClickPlay(this, new TextEventArgs(""));
        }

        private void OnUserClickStop()
        {
            if (UserClickStop != null) UserClickStop(this, new TextEventArgs(""));
        }

        private void OnUserClickRandomize()
        {
            Random random = new Random();

            comboBoxDesiredTheme0.SelectedIndex = random.Next(0, themeBase.Keys.Count);
            comboBoxDesiredTheme1.SelectedIndex = random.Next(0, themeBase.Keys.Count);
            comboBoxDesiredTheme2.SelectedIndex = random.Next(0, themeBase.Keys.Count);
            comboBoxDesiredTheme3.SelectedIndex = 0;
            comboBoxDesiredTheme4.SelectedIndex = 0;
            comboBoxDesiredTheme5.SelectedIndex = 0;
            comboBoxDesiredTheme6.SelectedIndex = 0;
            comboBoxDesiredTheme7.SelectedIndex = 0;
            comboBoxDesiredTheme8.SelectedIndex = 0;
            comboBoxDesiredTheme9.SelectedIndex = 0;

            comboBoxUndesiredTheme0.SelectedIndex = random.Next(0, themeBase.Keys.Count);
            comboBoxUndesiredTheme1.SelectedIndex = random.Next(0, themeBase.Keys.Count);
            comboBoxUndesiredTheme2.SelectedIndex = random.Next(0, themeBase.Keys.Count);
            comboBoxUndesiredTheme3.SelectedIndex = 0;
            comboBoxUndesiredTheme4.SelectedIndex = 0;
            comboBoxUndesiredTheme5.SelectedIndex = 0;
            comboBoxUndesiredTheme6.SelectedIndex = 0;
            comboBoxUndesiredTheme7.SelectedIndex = 0;
            comboBoxUndesiredTheme8.SelectedIndex = 0;
            comboBoxUndesiredTheme9.SelectedIndex = 0;

            //if (random.Next(2) == 1)
            //    checkBoxChorusMode.Checked = !checkBoxChorusMode.Checked;

            if (UserClickRandomize != null) UserClickRandomize(this, new TextEventArgs(""));
        }

        private void OnUserClickDefault()
        {
            comboBoxDesiredTheme0.SelectedIndex = 0;
            comboBoxDesiredTheme1.SelectedIndex = 0;
            comboBoxDesiredTheme2.SelectedIndex = 0;
            comboBoxDesiredTheme3.SelectedIndex = 0;
            comboBoxDesiredTheme4.SelectedIndex = 0;
            comboBoxDesiredTheme5.SelectedIndex = 0;
            comboBoxDesiredTheme6.SelectedIndex = 0;
            comboBoxDesiredTheme7.SelectedIndex = 0;
            comboBoxDesiredTheme8.SelectedIndex = 0;
            comboBoxDesiredTheme9.SelectedIndex = 0;

            comboBoxUndesiredTheme0.SelectedIndex = 0;
            comboBoxUndesiredTheme1.SelectedIndex = 0;
            comboBoxUndesiredTheme2.SelectedIndex = 0;
            comboBoxUndesiredTheme3.SelectedIndex = 0;
            comboBoxUndesiredTheme4.SelectedIndex = 0;
            comboBoxUndesiredTheme5.SelectedIndex = 0;
            comboBoxUndesiredTheme6.SelectedIndex = 0;
            comboBoxUndesiredTheme7.SelectedIndex = 0;
            comboBoxUndesiredTheme8.SelectedIndex = 0;
            comboBoxUndesiredTheme9.SelectedIndex = 0;

            if (UserClickDefault != null) UserClickDefault(this, new TextEventArgs(""));
        }

        private void OnScrollTrackBarVerseLength()
        {
            if (UserScrollTrackBarVerseLength != null) UserScrollTrackBarVerseLength(this, new TextEventArgs(""));
        }

        private void OnScrollTrackBarVerseLengthEntropy()
        {
            if (UserScrollTrackBarVerseLength != null) UserScrollTrackBarVerseLengthEntropy(this, new TextEventArgs(""));
        }

        private void OnUserChangeCheckBoxChorusMode()
        {
            if (UserChangeCheckBoxChorusMode != null) UserChangeCheckBoxChorusMode(this, new TextEventArgs(""));
        }

        private void OnUserChangeVoiceVolume()
        {
            if (UserChangeVoiceVolume != null) UserChangeVoiceVolume(this, new TextEventArgs(""));
        }

        private void OnUserClickInterpret()
        {
            if (UserClickInterpret != null) UserClickInterpret(this, new TextEventArgs(""));
        }

        private void OnUserChangeSpeed()
        {
            if (UserChangeSpeed != null) UserChangeSpeed(this, new TextEventArgs(""));
        }

        private void OnUserChangeCheckBoxEnableSolo()
        {
            if (UserChangeCheckBoxEnableSolo != null) UserChangeCheckBoxEnableSolo(this, new TextEventArgs(""));
        }

        private void OnUserChangeCheckBoxEnableIntro()
        {
            if (UserChangeCheckBoxEnableIntro != null) UserChangeCheckBoxEnableIntro(this, new TextEventArgs(""));
        }

        private void OnUserChangeSplitChannelSplit()
        {
            if (UserChangeSplitChannelSplit != null) UserChangeSplitChannelSplit(this, new TextEventArgs(""));
        }

        private void OnUserChangeSpeedRegulation()
        {
            if (UserChangeSpeedRegulation != null) UserChangeSpeedRegulation(this, new TextEventArgs(""));
        }

        private void OnUserChangeThemeFidelity()
        {
            if (UserChangeThemeFidelity != null) UserChangeThemeFidelity(this, new TextEventArgs(""));
        }

        private void OnUserChangeMidiVolume()
        {
            if (UserChangeMidiVolume != null) UserChangeMidiVolume(this, new TextEventArgs(""));
        }

        private void OnUserChangeVocoderMode()
        {
            if (UserChangeVocoderMode != null) UserChangeVocoderMode(this, new TextEventArgs(""));
        }

        private void OnUserChangeGenerateVideo()
        {
            if (UserChangeGenerateVideo != null) UserChangeGenerateVideo(this, null);
        }
        #endregion

        #region Constructor
        public MainWindow(Model.ThemeBase themeBase, int voiceVolume)
        {
            this.themeBase = themeBase;

            InitializeComponent();

            comboBoxDesiredTheme0.DataSource = themeBase.Keys;
            comboBoxDesiredTheme1.DataSource = themeBase.Keys;
            comboBoxDesiredTheme2.DataSource = themeBase.Keys;
            comboBoxDesiredTheme3.DataSource = themeBase.Keys;
            comboBoxDesiredTheme4.DataSource = themeBase.Keys;
            comboBoxDesiredTheme5.DataSource = themeBase.Keys;
            comboBoxDesiredTheme6.DataSource = themeBase.Keys;
            comboBoxDesiredTheme7.DataSource = themeBase.Keys;
            comboBoxDesiredTheme8.DataSource = themeBase.Keys;
            comboBoxDesiredTheme9.DataSource = themeBase.Keys;

            comboBoxUndesiredTheme0.DataSource = themeBase.Keys;
            comboBoxUndesiredTheme1.DataSource = themeBase.Keys;
            comboBoxUndesiredTheme2.DataSource = themeBase.Keys;
            comboBoxUndesiredTheme3.DataSource = themeBase.Keys;
            comboBoxUndesiredTheme4.DataSource = themeBase.Keys;
            comboBoxUndesiredTheme5.DataSource = themeBase.Keys;
            comboBoxUndesiredTheme6.DataSource = themeBase.Keys;
            comboBoxUndesiredTheme7.DataSource = themeBase.Keys;
            comboBoxUndesiredTheme8.DataSource = themeBase.Keys;
            comboBoxUndesiredTheme9.DataSource = themeBase.Keys;

            this.trackWavVolume.Value = voiceVolume;
        }
        #endregion

        #region Methods
        #region Actions
        public void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        public string GetInputTextExistingLyrics()
        {
            inputExistingLyricsWindow = new TextInputDialog("Please copy and paste your song's lyrics here");
            inputExistingLyricsWindow.ShowDialog();
            return inputExistingLyricsWindow.UserInput;
        }
        #endregion
        #endregion

        #region Handlers
        private void comboBoxDesiredTheme0_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(true, 0, comboBoxDesiredTheme0.SelectedItem.ToString());
        }

        private void comboBoxDesiredTheme1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(true, 1, comboBoxDesiredTheme1.SelectedItem.ToString());
        }

        private void comboBoxDesiredTheme2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(true, 2, comboBoxDesiredTheme2.SelectedItem.ToString());
        }

        private void comboBoxDesiredTheme3_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(true, 3, comboBoxDesiredTheme3.SelectedItem.ToString());
        }

        private void comboBoxDesiredTheme4_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(true, 4, comboBoxDesiredTheme4.SelectedItem.ToString());
        }

        private void comboBoxDesiredTheme5_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(true, 5, comboBoxDesiredTheme5.SelectedItem.ToString());
        }

        private void comboBoxDesiredTheme6_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(true, 6, comboBoxDesiredTheme6.SelectedItem.ToString());
        }

        private void comboBoxDesiredTheme7_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(true, 7, comboBoxDesiredTheme7.SelectedItem.ToString());
        }

        private void comboBoxDesiredTheme8_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(true, 8, comboBoxDesiredTheme8.SelectedItem.ToString());
        }

        private void comboBoxDesiredTheme9_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(true, 9, comboBoxDesiredTheme9.SelectedItem.ToString());
        }

        private void comboBoxUndesiredTheme0_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(false, 0, comboBoxUndesiredTheme0.SelectedItem.ToString());
        }

        private void comboBoxUndesiredTheme1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(false, 1, comboBoxUndesiredTheme1.SelectedItem.ToString());
        }

        private void comboBoxUndesiredTheme2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(false, 2, comboBoxUndesiredTheme2.SelectedItem.ToString());
        }

        private void comboBoxUndesiredTheme3_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(false, 3, comboBoxUndesiredTheme3.SelectedItem.ToString());
        }

        private void comboBoxUndesiredTheme4_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(false, 4, comboBoxUndesiredTheme4.SelectedItem.ToString());
        }

        private void comboBoxUndesiredTheme5_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(false, 5, comboBoxUndesiredTheme5.SelectedItem.ToString());
        }

        private void comboBoxUndesiredTheme6_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(false, 6, comboBoxUndesiredTheme6.SelectedItem.ToString());
        }

        private void comboBoxUndesiredTheme7_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(false, 7, comboBoxUndesiredTheme7.SelectedItem.ToString());
        }

        private void comboBoxUndesiredTheme8_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(false, 8, comboBoxUndesiredTheme8.SelectedItem.ToString());
        }

        private void comboBoxUndesiredTheme9_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUserChangeTheme(false, 9, comboBoxUndesiredTheme9.SelectedItem.ToString());
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            OnUserClickBuild();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnUserClickRandomize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnUserClickDefault();
        }

        private void trackBarVerseLength_Scroll(object sender, EventArgs e)
        {
            OnScrollTrackBarVerseLength();
        }

        private void trackBarVerseLengthEntropy_Scroll(object sender, EventArgs e)
        {
            OnScrollTrackBarVerseLengthEntropy();
        }

        private void play_Click(object sender, EventArgs e)
        {
            OnUserClickPlay();
        }

        private void checkBoxChorusMode_CheckedChanged(object sender, EventArgs e)
        {
            OnUserChangeCheckBoxChorusMode();
        }

        private void checkBoxEnableSolo_CheckedChanged(object sender, EventArgs e)
        {
            OnUserChangeCheckBoxEnableSolo();
        }

        private void checkBoxEnableIntro_CheckedChanged(object sender, EventArgs e)
        {
            OnUserChangeCheckBoxEnableIntro();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            OnUserClickStop();
        }

        private void trackWavVolume_Scroll(object sender, EventArgs e)
        {
            OnUserChangeVoiceVolume();
        }

        private void interpretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnUserClickInterpret();
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            OnUserChangeSpeed();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBoxSplitChannels_CheckedChanged(object sender, EventArgs e)
        {
            OnUserChangeSplitChannelSplit();
        }

        private void enableSpeedRegulation_CheckedChanged(object sender, EventArgs e)
        {
            OnUserChangeSpeedRegulation();
        }

        private void trackBarThemeFidelity_ValueChanged(object sender, EventArgs e)
        {
            OnUserChangeThemeFidelity();
        }

        private void trackBarMidiVolume_ValueChanged(object sender, EventArgs e)
        {
            OnUserChangeMidiVolume();
        }

        private void checkBoxPlayForVocoder_CheckedChanged(object sender, EventArgs e)
        {
            OnUserChangeVocoderMode();
        }

        private void checkBoxGenerateVideo_CheckedChanged(object sender, EventArgs e)
        {
            OnUserChangeGenerateVideo();
        }
        #endregion

        #region Properties
        public string LyricText
        {
            set { richTextBoxOutputField.Text = value; }
            get { return richTextBoxOutputField.Text; }
        }

        public double TrackBarVerseLength
        {
            get { return (double)(trackBarVerseLength.Value) / 32767;}
            set { trackBarVerseLength.Value = (int)(value * 32767);}
        }

        public double TrackBarVerseLengthEntropy
        {
            get { return (double)(trackBarVerseLengthEntropy.Value) / 32767; }
            set { trackBarVerseLengthEntropy.Value = (int)(value * 32767); }
        }

        public bool CheckBoxChorusMode
        {
            get { return checkBoxChorusMode.Checked; }
            set { checkBoxChorusMode.Checked = value; }
        }

        public int VoiceVolume
        {
            get { return trackWavVolume.Value; }
            set { trackWavVolume.Value = value; }
        }

        public int Speed
        {
            get { return trackBarSpeed.Value; }
            set { trackBarSpeed.Value = value; }
        }

        public bool EnableSolo
        {
            get { return checkBoxEnableSolo.Checked; }
            set { checkBoxEnableSolo.Checked = value; }
        }

        public bool EnableIntro
        {
            get { return checkBoxEnableIntro.Checked; }
            set { checkBoxEnableIntro.Checked = value; }
        }

        public bool FlagSpeedRegulation
        {
            get { return checkBoxModerateSpeed.Checked; }
            set { checkBoxModerateSpeed.Checked = value; }
        }

        public int ThemeFidelity
        {
            get { return trackBarThemeFidelity.Value; }
            set { trackBarThemeFidelity.Value = value; }
        }

        public int MidiVolume
        {
            get { return trackBarMidiVolume.Value; }
            set { trackBarMidiVolume.Value = value; }
        }

        public bool FlagVocoderMode
        {
            get { return checkBoxPlayForVocoder.Checked; }
            set { checkBoxPlayForVocoder.Checked = value; }
        }

        public bool FlagEnableVideo
        {
            get { return checkBoxGenerateVideo.Checked; }
            set { checkBoxGenerateVideo.Checked = value; }
        }
        #endregion
    }
}
