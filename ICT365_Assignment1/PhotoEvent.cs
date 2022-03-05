using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    [Serializable]
    [XmlRoot(Namespace = "http://www.xyz.org/lifelogevents", ElementName = "photo", DataType = "string", IsNullable = true)]
    public class PhotoEvent : Event
    {
        [XmlElement("filepath", Namespace = "http://www.xyz.org/lifelogevents")]
        public string Path { get; set; }

        [XmlElement("location", Namespace = "http://www.xyz.org/lifelogevents")]
        public Location Location { get; set; }

        public EventFactory.EventType EventType = EventFactory.EventType.Photo;

        public PhotoEvent() : base()
        {
            this.Path = "";
            this.Location = new Location();
        }

        public PhotoEvent(string eventID) : base(eventID)
        {
            this.Path = "";
            this.Location = new Location();
        }

        public PhotoEvent(string eventID, string path, Location loc) : base(eventID)
        {
            this.Path = path;
            this.Location = loc;
        }

        public override Location GetLocation()
        {
            return this.Location;
        }
    }
}
