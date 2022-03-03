using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    public partial class MainForm : Form
    {
        public Dictionary<string, Event> result = new Dictionary<string, Event>();
        public Location selectedLocation;
        public Event selectedEvent;
        public int polylineCounter;

        public MainForm()
        {
            InitializeComponent();
            //WindowState = FormWindowState.Maximized;
            //MinimumSize = this.Size;
            //MaximumSize = this.Size;

            //Dictionary<string, Event> result = new Dictionary<string, Event>();
            XDocument xdocument = XDocument.Load(@"lifelog-events.xml");
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
                        Event twitterEvent = twSerial.Deserialize(eventType.CreateReader()) as Event;
                        twitterEvent.EventID = eventId.ToString();
                        result.Add(eventId, twitterEvent);
                    }
                    else if (fbXName != null)
                    {
                        var fbSerial = new XmlSerializer(typeof(FacebookEvent));
                        Event fbEvent = fbSerial.Deserialize(eventType.CreateReader()) as Event;
                        fbEvent.EventID = eventId.ToString();
                        result.Add(eventId, fbEvent);
                    }
                    else if (photoXName != null)
                    {
                        var photoSerial = new XmlSerializer(typeof(PhotoEvent));
                        Event photoEvent = photoSerial.Deserialize(eventType.CreateReader()) as Event;
                        photoEvent.EventID = eventId.ToString();
                        result.Add(eventId, photoEvent);
                    }
                    else if (videoXName != null)   
                    {
                        var videoSerial = new XmlSerializer(typeof(VideoEvent));
                        Event videoEvent = videoSerial.Deserialize(eventType.CreateReader()) as Event;
                        videoEvent.EventID = eventId.ToString();
                        result.Add(eventId, videoEvent);
                    }
                    else
                    {
                        var tracklogSerial = new XmlSerializer(typeof(TracklogEvent));
                        Event tracklogEvent = tracklogSerial.Deserialize(eventType.CreateReader()) as Event;
                        tracklogEvent.EventID = eventId.ToString();
                        result.Add(eventId, tracklogEvent);
                    }
                }
            }
            PlotMarkerOnMap(result);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void gMapControl_Load(object sender, EventArgs e)
        {
            gMapControl.MapProvider = GMapProviders.GoogleMap;
            gMapControl.ShowCenter = false;
            gMapControl.Position = new PointLatLng(1.391519, 103.784654);
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
                selectedLocation = new Location(lat, lng);
                PointLatLng clickedLoc = new PointLatLng(lat, lng);
                Event nearestEvent = FindNearestMarker(result, clickedLoc);
                selectedEvent = nearestEvent;

                RemoveLastPolyline();
                PlotPolylineToNearestMarker(nearestEvent, clickedLoc);
                RefreshMap();
            }
        }

        private void gMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            //MessageBox.Show(item.Tag.ToString());
            selectedEvent = (Event)item.Tag;
            if (selectedEvent == null)
            {
                MessageBox.Show("Please select an event.");
            }
            else
            {
                RetrieveEventForm retrieveEventForm = new RetrieveEventForm(selectedEvent);
                retrieveEventForm.ShowDialog();
            }
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            if (selectedLocation == null)
            {
                MessageBox.Show("Please select the location before adding an event.");
            }
            else
            {
                AddEventForm addEventForm = new AddEventForm(selectedLocation);
                addEventForm.ShowDialog();
            }
        }

        private void retrieveEventButton_Click(object sender, EventArgs e)
        {

            // Find nearest event
            if (selectedEvent == null)
            {
                MessageBox.Show("Please select an event.");
            } 
            else
            {
                RetrieveEventForm retrieveEventForm = new RetrieveEventForm(selectedEvent);
                retrieveEventForm.ShowDialog();
            }

            
        }

        private void CreateMarkerWithImage(Event ev, Bitmap img)
        {
            PointLatLng point = new PointLatLng(ev.GetLocation().Latitude, ev.GetLocation().Longitude);
            GMapMarker marker = new GMarkerGoogle(point, img);
            GMapOverlay overlay = new GMapOverlay("markers");
            overlay.Markers.Add(marker);
            marker.Tag = ev;
            gMapControl.Overlays.Add(overlay);

        }


        private void PlotMarkerOnMap(Dictionary<string, Event> result)
        {
            foreach (KeyValuePair<string, Event> kvp in result)
            {
                if (kvp.Value.GetLocation() != null)
                {
                    if (kvp.Value is FacebookEvent)
                    {
                        Bitmap fbIcon = (Bitmap)Image.FromFile("img/facebook.png");
                        CreateMarkerWithImage(kvp.Value, fbIcon);
                    }
                    else if (kvp.Value is TwitterEvent)
                    {
                        Bitmap twitterIcon = (Bitmap)Image.FromFile("img/twitter.png");
                        CreateMarkerWithImage(kvp.Value, twitterIcon);
                    }
                    else if (kvp.Value is PhotoEvent)
                    {
                        if (kvp.Value.GetPath() != null)
                        {
                            Bitmap imageIcon = (Bitmap)Image.FromFile("img/photo.png");
                            CreateMarkerWithImage(kvp.Value, imageIcon);
                        }
                    }
                    else if (kvp.Value is VideoEvent)
                    {
                        if (kvp.Value.GetPath() != null)
                        {
                            Bitmap videoIcon = (Bitmap)Image.FromFile("img/video.png");
                            CreateMarkerWithImage(kvp.Value, videoIcon);
                        }
                    }
                    else
                    {
                        Bitmap tracklogIcon = (Bitmap)Image.FromFile("img/tracklog.png");
                        CreateMarkerWithImage(kvp.Value, tracklogIcon);
                    }

                }
            }
        }
        
        private void PlotPolylineToNearestMarker(Event nearestEvent, PointLatLng clickedLoc)
        {
            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(clickedLoc);
            points.Add(new PointLatLng(nearestEvent.GetLocation().Latitude, nearestEvent.GetLocation().Longitude));

            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            polygon.Stroke = new Pen(Color.Black, 5);
            polyOverlay.Polygons.Add(polygon);
            gMapControl.Overlays.Add(polyOverlay);
        }

        private void RemoveLastPolyline()
        {
            var overlaySize = gMapControl.Overlays.ToList().Count;
            if (polylineCounter > 0)
            {
                gMapControl.Overlays.RemoveAt(overlaySize - 1);
            }
            polylineCounter++;
        }

        public double GetDistance(PointLatLng p1, PointLatLng p2)
        {
            GMapRoute route = new GMapRoute("getDistance");
            route.Points.Add(p1);
            route.Points.Add(p2);
            double distance = route.Distance;
            route.Clear();
            route = null;

            return distance;
        }

        private Event FindNearestMarker(Dictionary<string, Event> kvp, PointLatLng clickedPoint)
        {
            Event nearestEvent = null;
            var nearestDistance = Double.PositiveInfinity;
            foreach (var item in kvp)
            {
                if (item.Value.GetLocation() != null)
                {
                    PointLatLng currPoint = new PointLatLng(item.Value.GetLocation().Latitude, item.Value.GetLocation().Longitude);
                    var distance = GetDistance(currPoint, clickedPoint);

                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        nearestEvent = item.Value;
                    }
                }
            }

            if (double.IsPositiveInfinity(nearestDistance))
            {
                return null;
            }
            else
            {
                return nearestEvent;
            }
        }

        private void RefreshMap()
        {
            gMapControl.Zoom--;
            gMapControl.Zoom++;
        }
    }
}
