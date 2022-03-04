using System;
using System.Drawing;
using System.Windows.Forms;

namespace ICT365_Assignment1
{
    public partial class RetrieveEventForm : Form
    {
        public Event currEvent;
        public RetrieveEventForm(Event ev)
        {
            InitializeComponent();
            this.currEvent = ev;
        }

        private void RetrieveEventForm_Load(object sender, EventArgs e)
        {
            txtEventId.Text = currEvent.EventID.ToString();
            if (currEvent is TwitterEvent twitterEvent)
            {
                txtEventType.Text = twitterEvent.EventType.ToString();

                label1.Text = "Timestamp";
                textBox1.Text = twitterEvent.DateTime.ToString();
                filepathButton.Dispose();

                label2.Text = "Location";
                textBox2.Text = twitterEvent.GetLocation().Latitude + ", " + twitterEvent.GetLocation().Longitude;

                label3.Text = "Text";
                textBox3.Text = twitterEvent.Text;
                textBox3.WordWrap = true;
                textBox3.AutoSize = true;

                label5.Hide();
                textBox5.Hide();

                label4.Text = "Linked Event: ";
                textBox4.Text = "N/A";
            }
            else if (currEvent is FacebookEvent facebookEvent)
            {
                txtEventType.Text = facebookEvent.EventType.ToString();

                label1.Text = "Timestamp";
                textBox1.Text = facebookEvent.DateTime.ToString();
                filepathButton.Dispose();

                label2.Text = "Location";
                textBox2.Text = facebookEvent.GetLocation().Latitude + ", " + facebookEvent.GetLocation().Longitude;

                label3.Text = "Text";
                textBox3.Text = facebookEvent.Text;
                textBox3.WordWrap = true;
                textBox3.AutoSize = true;

                label5.Hide();
                textBox5.Hide();

                label4.Text = "Linked Event: ";
                textBox4.Text = "N/A";

            }
            else if (currEvent is PhotoEvent photoEvent)
            {
                txtEventType.Text = photoEvent.EventType.ToString();

                label1.Text = "Filepath";
                textBox1.Dispose();
                filepathButton.Text = photoEvent.Path.ToString();
                filepathButton.Click += (send, eve) => {
                    try
                    {
                        Bitmap img = new Bitmap(photoEvent.Path);
                        DisplayPhotoForm displayPhotoForm = new DisplayPhotoForm(img);
                        displayPhotoForm.ShowDialog();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to display photo: " + ex.Message.ToString());
                    }
                };

                label2.Text = "Location";
                textBox2.Text = photoEvent.GetLocation().Latitude + ", " + photoEvent.GetLocation().Longitude;

                label5.Hide();
                textBox5.Hide();

                label4.Hide();
                textBox4.Hide();

                label3.Text = "Linked Event: ";
                textBox3.Text = "N/A";
                textBox3.Height = 20;
            }
            else if (currEvent is VideoEvent videoEvent)
            {
                txtEventType.Text = videoEvent.EventType.ToString();

                label1.Text = "Filepath";
                textBox1.Dispose();
                filepathButton.Text = videoEvent.Path.ToString();
                filepathButton.Click += (send, eve) => {
                    try
                    {
                        DisplayVideoForm displayPhotoForm = new DisplayVideoForm(videoEvent.Path.ToString());
                        displayPhotoForm.ShowDialog();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to display video: " + ex.Message.ToString());
                    }
                };

                label2.Text = "Location";
                textBox2.Text = videoEvent.GetLocation().Latitude + ", " + videoEvent.GetLocation().Longitude;

                label3.Text = "Start Time";
                textBox3.Text = videoEvent.StartDateTime.ToString();
                textBox3.Height = 20;

                label4.Text = "End Time";
                textBox4.Text = videoEvent.EndDateTime.ToString();

                textBox5.Text = "N/A";
            }
            else if (currEvent is TracklogEvent tracklogEvent)
            {
                txtEventType.Text = tracklogEvent.EventType.ToString();

                label1.Text = "Filepath";
                textBox1.Dispose();
                filepathButton.Text = tracklogEvent.Path.ToString();

                label2.Text = "Data";
                textBox2.Text = tracklogEvent.Data;

                label3.Text = "Start Time";
                textBox3.Text = tracklogEvent.StartDateTime.ToString();
                textBox3.Height = 20;

                label4.Text = "End Time";
                textBox4.Text = tracklogEvent.EndDateTime.ToString();

                textBox5.Text = "N/A";
            }
        }
    }
}
