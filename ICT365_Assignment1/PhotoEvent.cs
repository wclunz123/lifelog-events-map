using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    [XmlRoot(Namespace = "http://www.xyz.org/lifelogevents", ElementName = "photo", DataType = "string", IsNullable = true)]
    public class PhotoEvent : Event
    {
        [XmlElement("filepath", Namespace = "http://www.xyz.org/lifelogevents")]
        public string Path { get; set; }

        [XmlElement("location", Namespace = "http://www.xyz.org/lifelogevents")]
        public Location Location { get; set; }

        public override Location GetLocation()
        {
            return this.Location;
        }

        public PhotoEvent() : base()
        {
            this.Path = "";
            this.Location = new Location();
        }

        public PhotoEvent(String eventID) : base(eventID)
        {
            this.Path = "";
            this.Location = new Location();
        }
    }
}
