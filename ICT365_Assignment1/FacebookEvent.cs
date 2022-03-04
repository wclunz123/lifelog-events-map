using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    [Serializable]
    [XmlRoot(Namespace = "http://www.xyz.org/lifelogevents", ElementName = "facebook-status-update", DataType = "string", IsNullable = true)]
    public class FacebookEvent : Event
    {
        [XmlElement("text", Namespace = "http://www.xyz.org/lifelogevents")]
        public string Text { get; set; }

        [XmlElement("location", Namespace = "http://www.xyz.org/lifelogevents")]
        public Location Location { get; set; }

        [XmlElement("datetimestamp", Namespace = "http://www.xyz.org/lifelogevents")]
        public string DateTimeString { get; set; }

        public DateTime DateTime
        {
            get
            {
                return DateTime.ParseExact(this.DateTimeString, "yyyyMMddHHmmss", null);
            }
        }

        public EventFactory.EventType EventType = EventFactory.EventType.Facebook;

        public FacebookEvent() : base()
        {
            this.Text = "";
            this.Location = new Location();
            this.DateTimeString = "";
        }

        public FacebookEvent(string eventID) : base(eventID)
        {
            this.Text = "";
            this.Location = new Location();
            this.DateTimeString = "";
        }

        public FacebookEvent(string eventID, string text, Location loc, string datetime) : base(eventID)
        {
            this.Text = text;
            this.Location = loc;
            this.DateTimeString = datetime;
        }
        public override Location GetLocation()
        {
            return this.Location;
        }
    }
}
