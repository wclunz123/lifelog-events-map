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
    public partial class AddEventForm : Form
    {
        public AddEventForm()
        {
            InitializeComponent();
        }

        public AddEventForm(double lat, double lng)
        {
            
        }

        private void addEventNextButton_Click(object sender, EventArgs e)
        {

        }

        private void addEventCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
