﻿using System;
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
    public partial class RetrieveEventForm : Form
    {
        public RetrieveEventForm(Event ev)
        {
            InitializeComponent();

            txtEventId.Text = ev.EventID.ToString();


            if (ev is TwitterEvent twitterEvent)
            {
                txtEventType.Text = "Twitter";

                label1.Text = "Timestamp";
                textBox1.Text = twitterEvent.DateTime;

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
            else if (ev is FacebookEvent facebookEvent)
            {
                txtEventType.Text = "Facebook";

                label1.Text = "Timestamp";
                textBox1.Text = facebookEvent.DateTime;

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
            else if (ev is PhotoEvent photoEvent)
            {
                txtEventType.Text = "Photo";

                label1.Text = "Filepath";
                textBox1.Text = photoEvent.Path;

                label2.Text = "Location";
                textBox2.Text = photoEvent.GetLocation().Latitude + ", " + photoEvent.GetLocation().Longitude;
                textBox2.Click += new System.EventHandler(this.textBox2_Click);

                label5.Hide();
                textBox5.Hide();

                label4.Hide();
                textBox4.Hide();

                label3.Text = "Linked Event: ";
                textBox3.Text = "N/A";
            }
            else if (ev is VideoEvent videoEvent)
            {
                txtEventType.Text = "Video";

                label1.Text = "Filepath";
                textBox1.Text = videoEvent.Path;

                label2.Text = "Location";
                textBox2.Text = videoEvent.GetLocation().Latitude + ", " + videoEvent.GetLocation().Longitude;

                label3.Text = "Start Time";
                textBox3.Text = videoEvent.StartTime;

                label4.Text = "End Time";
                textBox4.Text = videoEvent.EndTime;

                textBox5.Text = "N/A";
            }
            else if (ev is TracklogEvent tracklogEvent)
            {
                txtEventType.Text = "Tracklog";

                label1.Text = "Filepath";
                textBox1.Text = tracklogEvent.Path;

                label2.Text = "Data";
                textBox2.Text = tracklogEvent.Data;

                label3.Text = "Start Time";
                textBox3.Text = tracklogEvent.StartTime;

                label4.Text = "End Time";
                textBox4.Text = tracklogEvent.EndTime;

                textBox5.Text = "N/A";
            }
        }

        private void RetrieveEventForm_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi");
        }
    }
}
