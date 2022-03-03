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
    public partial class FillEventDetailForm : Form
    {
        public Location SelectedLocation;
        public FillEventDetailForm(string EventString, Location SelectedLocation)
        {
            InitializeComponent();
            txtEventId.Text = "ID1234";
            this.SelectedLocation = SelectedLocation;
            txtEventType.Text = EventString;
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            uploadFileButton.Hide();

            if (EventString == "Twitter")
            {
                TwitterEvent newEvent = new TwitterEvent();
                label1.Text = "Text";
                label2.Text = "Location";
                textBox2.Text = SelectedLocation.Latitude + ", " + SelectedLocation.Longitude;
                textBox2.Enabled = false;
                label3.Text = "Timestamp";
                textBox3.Dispose();
                dateTimePicker1.Show();
    
                label4.Hide();
                textBox4.Hide();
            }
            else if (EventString == "Facebook")
            {
                FacebookEvent newEvent = new FacebookEvent();
                label1.Text = "Text";
                label2.Text = "Location";
                textBox2.Text = SelectedLocation.Latitude + ", " + SelectedLocation.Longitude;
                textBox2.Enabled = false;
                label3.Text = "Timestamp";
                textBox3.Dispose();
                dateTimePicker1.Show();

                label4.Hide();
                textBox4.Hide();
            }
            else if (EventString == "Photo")
            {
                PhotoEvent newEvent = new PhotoEvent();
                label1.Text = "Filepath";
                textBox1.Dispose();
                uploadFileButton.Show();
                uploadFileButton.Text = "Upload Photo (.png .jpg .jpeg)";
                uploadFileButton.Click += (sender, e) =>
                {
                    OpenFileDialog file = new OpenFileDialog();
                    file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                    file.Title = "Select an image: ";
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        var filePath = file.FileName;
                        uploadFileButton.Text = filePath.ToString();
                    }
                };

                label2.Text = "Location";
                textBox2.Text = SelectedLocation.Latitude + ", " + SelectedLocation.Longitude;
                textBox2.Enabled = false;

                label3.Hide();
                textBox3.Hide();
                label4.Hide();
                textBox4.Hide();
            }
            else if (EventString == "Video")
            {
                VideoEvent newEvent = new VideoEvent();
                label1.Text = "Filepath";
                textBox1.Dispose();
                uploadFileButton.Text = "Upload Video (.mp4)";
                uploadFileButton.Show();
                uploadFileButton.Click += (sender, e) =>
                {
                    try
                    {
                        OpenFileDialog file = new OpenFileDialog();
                        file.Filter = "Media Files|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3|All Files|*.*";
                        file.Title = "Select a video: ";
                        if (file.ShowDialog() == DialogResult.OK)
                        {
                            var filePath = file.FileName;
                            uploadFileButton.Text = filePath.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                };

                label2.Text = "Location";
                textBox2.Text = SelectedLocation.Latitude + ", " + SelectedLocation.Longitude;
                textBox2.Enabled = false;

                label3.Text = "Start Time";
                textBox3.Dispose();
                dateTimePicker1.Show();

                label4.Text = "End Time";
                textBox4.Dispose();
                dateTimePicker2.Show();
            }
            else if (EventString == "Tracklog")
            {
                TracklogEvent newEvent = new TracklogEvent();
                label1.Text = "Filepath";
                textBox1.Dispose();
                uploadFileButton.Text = "Upload Tracklog (.gpx)";
                uploadFileButton.Show();
                label2.Text = "Data";

                label3.Text = "Start Time";
                textBox3.Dispose();
                dateTimePicker1.Show();

                label4.Text = "End Time";
                textBox4.Dispose();
                dateTimePicker2.Show();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            // Manage hide and close please
            this.Hide();
            this.Close();
            AddEventForm addEventForm = new AddEventForm(SelectedLocation);
            addEventForm.ShowDialog();
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Added");

            this.Close();
        }
    }
}
