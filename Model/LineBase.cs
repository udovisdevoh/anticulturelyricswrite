using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ac.Lw.Model
{
    class LineBase
    {
        #region Fields
        private string fileName;
        #endregion

        #region Constructor
        public LineBase(string fileName)
        {
            this.fileName = fileName;
        }
        #endregion

        #region Methods
        #region Generators
        public List<string> GetRandomVerse(int howManyVerse, Random random)
        {
            List<string> randomLines = new List<string>();
            for (int i = 0; i < howManyVerse; i++)
                randomLines.Add(GetRandomVerse(random));

            return randomLines;
        }

        private string GetRandomVerse(Random random)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);

            string line = string.Empty;
            long position = (long)(random.NextDouble() * fileStream.Length - 300);

            if (position < 0)
                position = 0;

            fileStream.Seek(position, 0);

            line = streamReader.ReadLine();
            line = streamReader.ReadLine();

            return line;
        }
        #endregion
        #endregion
    }
}
