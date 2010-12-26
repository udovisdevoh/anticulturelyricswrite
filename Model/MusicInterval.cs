using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ac.Lw.Model
{
    class MusicInterval
    {
        #region Fields
        private double harmony;
        
        private double feeling;

        private int intervalValue;
        #endregion

        #region Constructor
        public MusicInterval(int intervalValue, double harmony, double feeling)
        {
            this.intervalValue = intervalValue;
            this.harmony = harmony;
            this.feeling = feeling;
        }
        #endregion

        #region Properties
        public int IntervalValue
        {
            get { return intervalValue; }
        }

        public double Harmony
        {
            get { return harmony; }
        }

        public double Feeling
        {
            get { return feeling; }
        }
        #endregion
    }
}
