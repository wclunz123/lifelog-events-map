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
        public string SelectedEventString;
        public Location SelectedLocation;
        public AddEventForm(Location selectedLocationVal)
        {
            InitializeComponent();
            this.SelectedLocation = selectedLocationVal;
        }

        private void addEventNextButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FillEventDetailForm form = new FillEventDetailForm(SelectedEventString, SelectedLocation);
            form.ShowDialog();
        }

        private void addEventCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SelectedEventString = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SelectedEventString = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SelectedEventString = radioButton3.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SelectedEventString = radioButton4.Text;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SelectedEventString = radioButton5.Text;
        }
    }
}
