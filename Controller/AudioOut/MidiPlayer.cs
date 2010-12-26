using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ac.Lw.Controller.AudioOut
{
    class MidiPlayer
    {
        #region Fields
        private Midi.OutputDevice outputDevice = new Midi.OutputDevice(0);

        private int keySignature;

        private int volume;
        #endregion

        #region Methods
        #region Actions
        public void Play(List<int> musicIntervals, List<int> midiInstruments, bool playKickNow, bool playSnareNow, int keySignature, bool playMelodyInstrument)
        {
            this.keySignature = keySignature;
            Random random = new Random();

            int notePitch1 = musicIntervals[random.Next(musicIntervals.Count)];
            int notePitch2 = musicIntervals[random.Next(musicIntervals.Count)];
            int notePitch3;

            if (playKickNow)
                notePitch3 = 34;
            else if (playSnareNow)
                notePitch3 = 39;
            else
                notePitch3 = random.Next(40, 52);





            //Prevent notes to go out of range
            while (notePitch1 + 60 + keySignature > 127)
                notePitch1 -= 12;
            while (notePitch2 + 48 + keySignature > 127)
                notePitch2 -= 12;


            //We set the instruments
            outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.ProgramChange, 0, midiInstruments[0], 0));
            outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.ProgramChange, 1, midiInstruments[1], 0));


            if (playMelodyInstrument)
            {
                //Melody plays
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOn, 0, keySignature + 36 + notePitch1, 75));
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOn, 0, keySignature + 48 + notePitch1, 75));
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOn, 0, keySignature + 60 + notePitch1, 75));//Test
            }

            //Accompaniment plays
            if (playKickNow || playSnareNow && random.Next(2) == 1)
            {
                for (int i = 0; i < 127; i++)
                    outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOff, 1, i, 127));

                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOn, 1, keySignature + 24 + notePitch2, 110));
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOn, 1, keySignature + 36 + notePitch2, 110));//Test
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOn, 1, keySignature + 48 + notePitch2, 110));//Test
            }

            //Drum plays
            if (playKickNow || playSnareNow)
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOn, 9, notePitch3, 127));
            else
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOn, 9, notePitch3, 75));
        }

        public void PlayCarrier(List<int> modulatedIntervals)
        {
            int currentPitch;
            int currentPitch2;
            outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.ProgramChange, 2, 81, 0));

            SetTimbre(2, 127);

            Random random = new Random();
            currentPitch = modulatedIntervals[random.Next(modulatedIntervals.Count)];

            while (currentPitch > 12)
                currentPitch -= 12;

            while (currentPitch < 0)
                currentPitch += 12;

            do
            {
                currentPitch2 = modulatedIntervals[random.Next(modulatedIntervals.Count)];

                while (currentPitch2 > 12)
                    currentPitch2 -= 12;

                while (currentPitch2 < 0)
                    currentPitch2 += 12;
            } while (currentPitch2 == currentPitch);



            for (int i = 0; i < 128; i++)
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOff, 2, i, 127));

            for (int i = 2; i < 6; i++)
            {
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOn, 2, currentPitch + i * 12, 127));
                //outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOn, 2, currentPitch2 + i * 12, 127));
            }
        }

        public void Stop()
        {
            for (int i = 0; i < 127; i++)
            {
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOff, 0, i, 127));
                //outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOff, 1, i, 127));
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOff, 9, i, 90));
            }
        }

        public void StopAll()
        {
            for (int i = 0; i < 128; i++)
            {
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOff, 0, i, 127));
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOff, 1, i, 127));
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOff, 2, i, 127));
                outputDevice.Send(new Midi.ChannelMessage(Midi.ChannelCommand.NoteOff, 9, i, 90));
            }
        }

        public void SplitMidiChannels()
        {
            PanChannel(0, 0);
            PanChannel(1, 0);
            PanChannel(9, 0);
            PanChannel(2, 127);
        }

        public void PanChannel(int channelId, int panValue)
        {
            Midi.ChannelMessageBuilder builder = new Midi.ChannelMessageBuilder();
            builder.Command = Midi.ChannelCommand.Controller;
            builder.MidiChannel = channelId;
            builder.Data1 = (int)(Midi.ControllerType.Pan);
            builder.Data2 = panValue;
            builder.Build();
            outputDevice.Send(builder.Result);
        }

        public void SetTimbre(int channelId, int value)
        {
            Midi.ChannelMessageBuilder builder = new Midi.ChannelMessageBuilder();
            builder.Command = Midi.ChannelCommand.Controller;
            builder.MidiChannel = channelId;
            builder.Data1 = (int)(Midi.ControllerType.SoundTimbre);
            builder.Data2 = value;
            builder.Build();
            outputDevice.Send(builder.Result);
        }
        #endregion
        #endregion

        #region Properties
        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;


                for (int i = 0; i < 16; i++)
                {
                    Midi.ChannelMessageBuilder builder = new Midi.ChannelMessageBuilder();
                    builder.Command = Midi.ChannelCommand.Controller;
                    builder.MidiChannel = i;
                    builder.Data1 = (int)(Midi.ControllerType.Volume);
                    builder.Data2 = value;
                    builder.Build();
                    outputDevice.Send(builder.Result);
                }
            }
        }
        #endregion
    }
}