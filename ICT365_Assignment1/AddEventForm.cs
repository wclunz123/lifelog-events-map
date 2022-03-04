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
        public EventFactory.EventType SelectedEvent;
        public Location SelectedLocation;
        public AddEventForm(Location selectedLocationVal)
        {
            InitializeComponent();
            this.SelectedLocation = selectedLocationVal;
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {
            radioButton1.Text = EventFactory.EventType.Twitter.ToString();
            radioButton1.Tag = EventFactory.EventType.Twitter;

            radioButton2.Text = EventFactory.EventType.Facebook.ToString();
            radioButton2.Tag = EventFactory.EventType.Facebook;

            radioButton3.Text = EventFactory.EventType.Photo.ToString();
            radioButton3.Tag = EventFactory.EventType.Photo;

            radioButton4.Text = EventFactory.EventType.Video.ToString();
            radioButton4.Tag = EventFactory.EventType.Video;

            radioButton5.Text = EventFactory.EventType.Tracklog.ToString();
            radioButton5.Tag = EventFactory.EventType.Tracklog;
        }

        private void addEventNextButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FillEventDetailForm form = new FillEventDetailForm(SelectedEvent, SelectedLocation);
            form.ShowDialog();
        }

        private void addEventCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SelectedEvent = (EventFactory.EventType)radioButton1.Tag;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SelectedEvent = (EventFactory.EventType)radioButton2.Tag;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SelectedEvent = (EventFactory.EventType)radioButton3.Tag;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SelectedEvent = (EventFactory.EventType)radioButton4.Tag;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SelectedEvent = (EventFactory.EventType)radioButton5.Tag;
        }
    }
}
