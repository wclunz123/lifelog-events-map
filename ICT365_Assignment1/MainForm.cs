using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    public partial class MainForm : Form
    {
        public static MainForm instance;

        public static Dictionary<string, Event> result = new Dictionary<string, Event>();
        
        public static Event selectedEvent;

        private Location selectedLocation;

        GMapOverlay polyOverlay = new GMapOverlay("polygons");

        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            MinimumSize = this.Size;
            MaximumSize = this.Size;
            instance = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                XDocument xdocument = XDocument.Load(@"lifelog-events.xml");
                XNamespace nFc = "http://www.xyz.org/lifelogevents";
                string nFcString = "http://www.xyz.org/lifelogevents";

                IEnumerable<XElement> xElements = xdocument.Descendants(nFc + "Event");
                foreach (XElement ex in xElements)
                {
                    var eventId = ex.Element(nFc + "eventid").Value;
                    IEnumerable<XElement> eventTypes = from itemType in ex.Elements(nFc + "eventid").FirstOrDefault().ElementsAfterSelf()
                                                        select itemType;
                    foreach (XElement eventTypeXML in eventTypes)
                    {
                        var tweetXName = ex.Element(XName.Get("tweet", nFcString));
                        var fbXName = ex.Element(XName.Get("facebook-status-update", nFcString));
                        var photoXName = ex.Element(XName.Get("photo", nFcString));
                        var videoXName = ex.Element(XName.Get("video", nFcString));
                        var tracklogXName = ex.Element(XName.Get("tracklog", nFcString));

                        EventFactory.EventType currEventType;
                        if (tweetXName != null)
                        {
                            currEventType = EventFactory.EventType.Twitter;
                        }
                        else if (fbXName != null)
                        {
                            currEventType = EventFactory.EventType.Facebook;
                        }
                        else if (photoXName != null)
                        {
                            currEventType = EventFactory.EventType.Photo;
                        }
                        else if (videoXName != null)
                        {
                            currEventType = EventFactory.EventType.Video;
                        }
                        else
                        {
                            currEventType = EventFactory.EventType.Tracklog;
                        }

                        var serializer = new XmlSerializer(EventFactory.GetEvent(currEventType).GetType());
                        Event currEvent = serializer.Deserialize(eventTypeXML.CreateReader()) as Event;
                        currEvent.EventID = eventId.ToString();
                        result.Add(eventId, currEvent);
                    }
                }
                PlotMarkerOnMap(result);
                RefreshMap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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

                PlotPolylineToNearestMarker(nearestEvent, clickedLoc);
                RefreshMap();
            }
        }

        private void gMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            selectedEvent = (Event)item.Tag;
            if (selectedEvent == null)
            {
                MessageBox.Show("Please select an event.", "Error Message");
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
                MessageBox.Show("Please select the location before adding an event.", "Error Message");
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
                MessageBox.Show("Please select an event.", "Error Message");
            } 
            else
            {
                RetrieveEventForm retrieveEventForm = new RetrieveEventForm(selectedEvent);
                retrieveEventForm.ShowDialog();
            }
        }
        public void PlotNewMarker(Event newEvent)
        {
            polyOverlay.Polygons.RemoveAt(0);
            try
            {
                if (newEvent is FacebookEvent)
                {
                    Bitmap fbIcon = (Bitmap)Image.FromFile("img/facebook.png");
                    CreateMarkerWithImage((FacebookEvent)newEvent, fbIcon);
                }
                else if (newEvent is TwitterEvent)
                {
                    Bitmap twitterIcon = (Bitmap)Image.FromFile("img/twitter.png");
                    CreateMarkerWithImage((TwitterEvent)newEvent, twitterIcon);
                }
                else if (newEvent is PhotoEvent)
                {
                    Bitmap imageIcon = (Bitmap)Image.FromFile("img/photo.png");
                    CreateMarkerWithImage((PhotoEvent)newEvent, imageIcon);
                }
                else if (newEvent is VideoEvent)
                {
                    Bitmap videoIcon = (Bitmap)Image.FromFile("img/video.png");
                    CreateMarkerWithImage((VideoEvent)newEvent, videoIcon);
                }
                RefreshMap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlotMarkerOnMap(Dictionary<string, Event> result)
        {
            try
            {
                foreach (KeyValuePair<string, Event> kvp in result)
                {
                    if (kvp.Value is FacebookEvent)
                    {
                        Bitmap fbIcon = (Bitmap)Image.FromFile("img/facebook.png");
                        CreateMarkerWithImage((FacebookEvent)kvp.Value, fbIcon);
                    }
                    else if (kvp.Value is TwitterEvent)
                    {
                        Bitmap twitterIcon = (Bitmap)Image.FromFile("img/twitter.png");
                        CreateMarkerWithImage((TwitterEvent)kvp.Value, twitterIcon);
                    }
                    else if (kvp.Value is PhotoEvent)
                    {
                        Bitmap imageIcon = (Bitmap)Image.FromFile("img/photo.png");
                        CreateMarkerWithImage((PhotoEvent)kvp.Value, imageIcon);
                    }
                    else if (kvp.Value is VideoEvent)
                    {
                            Bitmap videoIcon = (Bitmap)Image.FromFile("img/video.png");
                            CreateMarkerWithImage((VideoEvent)kvp.Value, videoIcon);
                    }
                    else
                    {
                        //Bitmap tracklogIcon = (Bitmap)Image.FromFile("img/tracklog.png");
                        //CreateMarkerWithImage(kvp.Value, tracklogIcon);
                    }
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Failed to locate file exception: " + ex.Message.ToString());
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

        private void PlotPolylineToNearestMarker(Event nearestEvent, PointLatLng clickedLoc)
        {
            
            if (polyOverlay.Polygons.Count > 0)
            {
                polyOverlay.Polygons.RemoveAt(0);
            }
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(clickedLoc);
            points.Add(new PointLatLng(nearestEvent.GetLocation().Latitude, nearestEvent.GetLocation().Longitude));

            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            polygon.Stroke = new Pen(Color.Black, 5);
            polyOverlay.Polygons.Add(polygon);
            gMapControl.Overlays.Add(polyOverlay);
        }

        private double GetDistance(PointLatLng p1, PointLatLng p2)
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
