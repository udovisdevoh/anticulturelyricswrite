using System;

using System.Collections.Generic;

namespace Ac.Lw.View
{
    /// <summary>
    /// Stores arguments related to events involving strings.
    /// </summary>
    public class TextEventArgs : EventArgs
    {
        #region Constructors
        public TextEventArgs(string text)
        {
            this.text = text;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the string associated with this event.
        /// </summary>
        public string text { get; private set; }
        #endregion
    }
}
