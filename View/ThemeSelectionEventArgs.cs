using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ac.Lw.View
{
    /// <summary>
    /// Stores arguments related to events involving theme selections.
    /// </summary>
    public class ThemeSelectionEventArgs : EventArgs
    {
        #region Constructors
        public ThemeSelectionEventArgs(bool isDesired, int id, string newThemeName)
        {
            this.isDesired = isDesired;
            this.id = id;
            this.name = newThemeName;
        }
        #endregion

        #region Properties
        public bool isDesired { get; private set; }

        public int id { get; private set; }

        public string name { get; private set; }
        #endregion
    }
}
