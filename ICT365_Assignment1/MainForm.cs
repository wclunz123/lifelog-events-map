using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            MinimumSize = this.Size;
            MaximumSize = this.Size;

            Dictionary<string, Event> result = new Dictionary<string, Event>();
            XDocument xdocument = XDocument.Load("lifelog-events.xml");
            XNamespace nFc = "http://www.xyz.org/lifelogevents";
            IEnumerable<XElement> xElements = xdocument.Descendants(nFc + "Event");
            foreach (XElement ex in xElements)
            {
                var eventId = ex.Element(nFc + "eventid").Value;
                IEnumerable<XElement> eventTypes = from itemType in ex.Elements(nFc + "eventid").FirstOrDefault().ElementsAfterSelf()
                                                   select itemType;
                foreach (XElement eventType in eventTypes)
                {
                    var tweetXName = ex.Element(XName.Get("tweet", "http://www.xyz.org/lifelogevents"));
                    var fbXName = ex.Element(XName.Get("facebook-status-update", "http://www.xyz.org/lifelogevents"));
                    var photoXName = ex.Element(XName.Get("photo", "http://www.xyz.org/lifelogevents"));
                    var videoXName = ex.Element(XName.Get("video", "http://www.xyz.org/lifelogevents"));
                    var tracklogXName = ex.Element(XName.Get("tracklog", "http://www.xyz.org/lifelogevents"));

                    if (tweetXName != null)
                    {
                        var twSerial = new XmlSerializer(typeof(TwitterEvent));
                        TwitterEvent twitterEvent = twSerial.Deserialize(eventType.CreateReader()) as TwitterEvent;
                        twitterEvent.EventID = eventId.ToString();
                        result.Add(eventId, twitterEvent);
                        //MessageBox.Show(twitterEvent.ToString());
                    }
                    else if (fbXName != null)
                    {
                        var fbSerial = new XmlSerializer(typeof(FacebookEvent));
                        FacebookEvent fbEvent = fbSerial.Deserialize(eventType.CreateReader()) as FacebookEvent;
                        fbEvent.EventID = eventId.ToString();
                        result.Add(eventId, fbEvent);
                        //MessageBox.Show(fbEvent.ToString());
                    }
                    else if (photoXName != null)
                    {
                        var photoSerial = new XmlSerializer(typeof(PhotoEvent));
                        PhotoEvent photoEvent = photoSerial.Deserialize(eventType.CreateReader()) as PhotoEvent;
                        photoEvent.EventID = eventId.ToString();
                        result.Add(eventId, photoEvent);
                        //MessageBox.Show(photoEvent.ToString());
                    }
                    else if (videoXName != null)   
                    {
                        var videoSerial = new XmlSerializer(typeof(VideoEvent));
                        VideoEvent videoEvent = videoSerial.Deserialize(eventType.CreateReader()) as VideoEvent;
                        videoEvent.EventID = eventId.ToString();
                        result.Add(eventId, videoEvent);
                        //MessageBox.Show(videoEvent.ToString());
                    }
                    else
                    {
                        var tracklogSerial = new XmlSerializer(typeof(TracklogEvent));
                        TracklogEvent tracklogEvent = tracklogSerial.Deserialize(eventType.CreateReader()) as TracklogEvent;
                        tracklogEvent.EventID = eventId.ToString();
                        result.Add(eventId, tracklogEvent);
                        //MessageBox.Show(tracklogEvent.ToString());
                    }
                }
            }

            foreach (KeyValuePair<string, Event> kvp in result)
            {
                
                if (kvp.Value.GetLocation() != null)
                {
                    if (kvp.Value is FacebookEvent)
                    {
                        Bitmap fbIcon = (Bitmap)Image.FromFile("img/facebook.png");
                        createMarkerWithImage(kvp.Value.GetLocation().Latitude, kvp.Value.GetLocation().Longitude, fbIcon);
                    }
                    else if (kvp.Value is TwitterEvent)
                    {
                        Bitmap twitterIcon = (Bitmap)Image.FromFile("img/twitter.png");
                        createMarkerWithImage(kvp.Value.GetLocation().Latitude, kvp.Value.GetLocation().Longitude, twitterIcon);
                    }
                    else 
                    {
                        createMarker(kvp.Value.GetLocation().Latitude, kvp.Value.GetLocation().Longitude, GMarkerGoogleType.blue_pushpin);
                    }
                        
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void gMapControl_Load(object sender, EventArgs e)
        {
            gMapControl.MapProvider = GMapProviders.GoogleMap;
            gMapControl.ShowCenter = false;
            gMapControl.Position = new PointLatLng(1.369931, 103.812619);
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.MinZoom = 5;
            gMapControl.MaxZoom = 50;
            gMapControl.Zoom = 11;
        }

        private void gMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                double lat = gMapControl.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gMapControl.FromLocalToLatLng(e.X, e.Y).Lng;
                txtLatitude.Text = lat.ToString();
                txtLongitude.Text = lng.ToString();
            }
        }

        private void gMapControl_OnMarkerClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Clicked!");
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            AddEventForm addEventForm = new AddEventForm();
            addEventForm.ShowDialog();
        }

        private void retrieveEventButton_Click(object sender, EventArgs e)
        {
            RetrieveEventForm retrieveEventForm = new RetrieveEventForm();
            retrieveEventForm.ShowDialog();
        }

        private void createMarker(double lat, double lng, GMarkerGoogleType icon)
        {
            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarker marker = new GMarkerGoogle(point, icon);
            GMapOverlay overlay = new GMapOverlay("markers");
            overlay.Markers.Add(marker);
            gMapControl.Overlays.Add(overlay);
        }

        private void createMarkerWithImage(double lat, double lng, Bitmap img)
        {
            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarker marker = new GMarkerGoogle(point, img);
            GMapOverlay overlay = new GMapOverlay("markers");
            overlay.Markers.Add(marker);
            gMapControl.Overlays.Add(overlay);
        }


        public List<string> Convert(IEnumerable<XElement> items)
        {
            return items.Select(item => item.Value.ToString()).ToList();
        }
    }
}
