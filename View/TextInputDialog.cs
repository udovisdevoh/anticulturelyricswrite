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
    public partial class TextInputDialog : Form
    {
        #region Constructor
        public TextInputDialog(string message)
        {
            InitializeComponent();

            labelMessage.Text = message;

            this.Text = message;
        }
        #endregion

        #region Properties
        public string UserInput
        {
            get { return richTextBox1.Text.Trim(); }
        }
        #endregion
    }
}
