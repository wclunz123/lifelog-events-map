using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT365_Assignment1
{
    public partial class DisplayVideoForm : Form
    {
        public DisplayVideoForm(string Path)
        {
            InitializeComponent();
            try
            {
                axWindowsMediaPlayer1.URL = Path;
                axWindowsMediaPlayer1.Size = new Size(this.ClientSize.Width - 50, this.ClientSize.Height - 50);
                axWindowsMediaPlayer1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying video: " + ex.Message);
            }
        }
    }
}
