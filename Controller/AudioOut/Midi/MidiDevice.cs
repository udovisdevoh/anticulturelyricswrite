using System;
using System.Runtime.InteropServices;
using System.Threading;
using Sanford.Multimedia;

namespace Ac.Lw.Controller.AudioOut.Midi
{
	/// <summary>
	/// The base class for all MIDI devices.
	/// </summary>
	public abstract class MidiDevice : Device
	{
        #region MidiDevice Members

        #region Win32 Midi Device Functions

        [DllImport("winmm.dll")]
        private static extern int midiConnect(int handleA, int handleB, int reserved);         

        [DllImport("winmm.dll")]
        private static extern int midiDisconnect(int handleA, int handleB, int reserved);             

        #endregion

        // Size of the MidiHeader structure.
        protected static readonly int SizeOfMidiHeader;

        static MidiDevice()
        {
            SizeOfMidiHeader = Marshal.SizeOf(typeof(MidiHeader));
        }

        public MidiDevice(int deviceID) : base(deviceID)
        {            
        }
        
        /// <summary>
        /// Connects a MIDI InputDevice to a MIDI thru or OutputDevice, or 
        /// connects a MIDI thru device to a MIDI OutputDevice. 
        /// </summary>
        /// <param name="handleA">
        /// Handle to a MIDI InputDevice or a MIDI thru device (for thru 
        /// devices, this handle must belong to a MIDI OutputDevice).
        /// </param>
        /// <param name="handleB">
        /// Handle to the MIDI OutputDevice or thru device.
        /// </param>
        /// <exception cref="DeviceException">
        /// If an error occurred while connecting the two devices.
        /// </exception>
        public static void Connect(int handleA, int handleB)
        {
            int result = midiConnect(handleA, handleB, 0);

            if(result != MidiDeviceException.MMSYSERR_NOERROR)
            {
                throw new MidiDeviceException(result);
            }
        }

        /// <summary>
        /// Disconnects a MIDI InputDevice from a MIDI thru or OutputDevice, or 
        /// disconnects a MIDI thru device from a MIDI OutputDevice. 
        /// </summary>
        /// <param name="handleA">
        /// Handle to a MIDI InputDevice or a MIDI thru device.
        /// </param>
        /// <param name="handleB">
        /// Handle to the MIDI OutputDevice to be disconnected. 
        /// </param>
        /// <exception cref="DeviceException">
        /// If an error occurred while disconnecting the two devices.
        /// </exception>
        public static void Disconnect(int handleA, int handleB)
        {
            int result = midiDisconnect(handleA, handleB, 0);

            if(result != MidiDeviceException.MMSYSERR_NOERROR)
            {
                throw new MidiDeviceException(result);
            }
        }        

        #endregion        
    }
}
