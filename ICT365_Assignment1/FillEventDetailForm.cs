using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    public partial class FillEventDetailForm : Form
    {
        public EventFactory.EventType EventType;
        public Location SelectedLocation;
        public FillEventDetailForm(EventFactory.EventType EventType, Location SelectedLocation)
        {
            InitializeComponent();
            txtEventId.Text = "ID1234";
            this.SelectedLocation = SelectedLocation;
            this.EventType = EventType;
        }

        private void FillEventDetailForm_Load(object sender, EventArgs e)
        {
            txtEventType.Text = EventType.ToString();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            uploadFileButton.Hide();

            if (EventType == EventFactory.EventType.Twitter)
            {
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
            else if (EventType == EventFactory.EventType.Facebook)
            {
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
            else if (EventType == EventFactory.EventType.Photo)
            {

                label1.Text = "Filepath";
                textBox1.Hide();
                uploadFileButton.Show();
                uploadFileButton.Text = "Upload Photo (.png .jpg .jpeg)";
                uploadFileButton.Click += (send, eve) =>
                {
                    try
                    {
                        OpenFileDialog file = new OpenFileDialog();
                        file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                        file.Title = "Select an image: ";
                        if (file.ShowDialog() == DialogResult.OK)
                        {
                            var filePath = file.FileName;
                            uploadFileButton.Hide();
                            textBox1.Show();
                            textBox1.Text = filePath.ToString();
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

                label3.Hide();
                textBox3.Hide();
                label4.Hide();
                textBox4.Hide();
            }
            else if (EventType == EventFactory.EventType.Video)
            {
                label1.Text = "Filepath";
                textBox1.Hide();
                uploadFileButton.Text = "Upload Video (.mp4)";
                uploadFileButton.Show();
                uploadFileButton.Click += (send, eve) =>
                {
                    try
                    {
                        OpenFileDialog file = new OpenFileDialog();
                        file.Filter = "Media Files|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3|All Files|*.*";
                        file.Title = "Select a video: ";
                        if (file.ShowDialog() == DialogResult.OK)
                        {
                            var filePath = file.FileName;
                            uploadFileButton.Hide();
                            textBox1.Show();
                            textBox1.Text = filePath.ToString();
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
            else if (EventType == EventFactory.EventType.Tracklog)
            {
                label1.Text = "Filepath";
                textBox1.Hide();
                uploadFileButton.Text = "Upload Tracklog (.gpx)";
                uploadFileButton.Show();
                uploadFileButton.Click += (send, eve) =>
                {
                    try
                    {
                        OpenFileDialog file = new OpenFileDialog();
                        file.Filter = "Media Files|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3|All Files|*.*";
                        file.Title = "Select a video: ";
                        if (file.ShowDialog() == DialogResult.OK)
                        {
                            var filePath = file.FileName;
                            uploadFileButton.Hide();
                            textBox1.Show();
                            textBox1.Text = filePath.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                };

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

            Event newEvent;
            if (txtEventType.Text == "Twitter")
            {
                string dateTime = dateTimePicker1.Value.ToString("yyyyMMddHHmmss");
                newEvent = new TwitterEvent(txtEventId.Text, textBox1.Text, SelectedLocation, dateTime);
            }
            else if (txtEventType.Text == "Facebook")
            {
                string dateTime = dateTimePicker1.Value.ToString("yyyyMMddHHmmss");
                newEvent = new FacebookEvent(txtEventId.Text, textBox1.Text, SelectedLocation, dateTime);
            }
            else if (txtEventType.Text == "Photo")
            {
                newEvent = new PhotoEvent(txtEventId.Text, textBox1.Text, SelectedLocation);
            }
            else if (txtEventType.Text == "Video")
            {
                string startTime = dateTimePicker1.Value.ToString("yyyyMMddHHmmss");
                string endTime = dateTimePicker2.Value.ToString("yyyyMMddHHmmss");
                newEvent = new VideoEvent(txtEventId.Text, textBox1.Text, SelectedLocation, startTime, endTime);
            }
            else
            {
                string startTime = dateTimePicker1.Value.ToString("yyyyMMddHHmmss");
                string endTime = dateTimePicker2.Value.ToString("yyyyMMddHHmmss");
                newEvent = new TracklogEvent(txtEventId.Text, textBox1.Text, textBox2.Text, startTime, endTime);
            }

            MessageBox.Show(newEvent.ToString());


            XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
            xmlNameSpace.Add("lle", "http://www.xyz.org/lifelogevents");

            XmlSerializer serializer = new XmlSerializer(typeof(Event));
            XmlSerializer childSerializer = new XmlSerializer(newEvent.GetType());

            // Create a FileStream to write with.
            Stream writer = new FileStream("lifelog-events.xml", FileMode.Append);

            //childSerializer.Serialize(writer, newEvent, xmlNameSpace);
            // Serialize the object, and close the TextWriter
            serializer.Serialize(writer, newEvent, xmlNameSpace);
            writer.Close();


            //XmlDocument xdoc = new XmlDocument();
            //xdoc.Load("lifelog-events.xml");

            //XmlNode parentNode = xdoc.DocumentElement;
            //XmlNode childNode = xdoc.CreateElement(nFc + "Event");
            //childNode.InnerText = txtEventId.Text;

            //parentNode.AppendChild(childNode);
            //xdoc.Save("lifelog-events.xml");

            this.Close();
        }
    }
}
