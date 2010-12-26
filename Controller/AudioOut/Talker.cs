using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ac.Lw.Controller.AudioOut
{
    class Talker
    {
        #region Fields
        private SpeechLib.SpVoice tts;

        private bool flagEnableSpeedRegulation = false;
        #endregion

        #region Constructor
        public Talker()
        {
            tts = new SpeechLib.SpVoice();
        }
        #endregion

        #region Methods
        #region Actions
        public void Speak(string text)
        {
            text = text.ToLower();
            text = text.Replace("_", " ");
            text = text.Replace(" isa ", " is a ");
            text = text.Replace(" madeby ", " made by ");
            text = text.Replace(" lovedby ", " loved by ");
            text = text.Replace(" sadby ", " sad by ");
            text = text.Replace(" makesad ", " make sad ");
            text = text.Replace(" angerat ", " anger at ");
            text = text.Replace(" makeanger ", " make anger ");
            text = text.Replace(" someare ", " some are ");
            text = text.Replace(" whatis ", " what is ");
            text = text.Replace(" aliasof ", " alias of ");
            text = text.Replace(" partof ", " part of ");
            text = text.Replace(" isa,", " is a,");
            text = text.Replace(" madeby,", " made by,");
            text = text.Replace(" someare,", " some are,");
            text = text.Replace(" whatis,", " what is,");
            text = text.Replace(" aliasof,", " alias of,");
            text = text.Replace(" partof,", " part of,");
            text = text.Replace("guillaume", "ghee home");
            text = text.Replace("maxime", "maxim");
            text = text.Replace("ucka", "ucker");
            text = text.Replace("mutha", "mother");
            text = text.Replace(" im ", " i'm ");
            text = text.Replace(" wannabe ", " wanna be ");


            tts.Speak(text, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        public void Stop()
        {
            tts.Speak("", SpeechLib.SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
        }
        #endregion

        #region Getters
        public bool IsTalking()
        {
            return !tts.WaitUntilDone(1);
        }
        #endregion
        #endregion

        #region Properties
        public int Volume
        {
            get { return tts.Volume; }
            set { tts.Volume = value; }
        }

        public SpeechLib.SpObjectToken Voice
        {
            get { return tts.Voice; }
            set { tts.Voice = value; }
        }

        public int Speed
        {
            set { tts.Rate = value; }
            get { return tts.Rate; }
        }

        public bool FlagEnableSpeedRegulation
        {
            get { return flagEnableSpeedRegulation; }
            set { flagEnableSpeedRegulation = value; }
        }
        #endregion
    }
}