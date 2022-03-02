using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    [XmlRoot(Namespace = "http://www.xyz.org/lifelogevents", ElementName = "facebook-status-update", DataType = "string", IsNullable = true)]
    public class FacebookEvent : Event
    {
        [XmlElement("text", Namespace = "http://www.xyz.org/lifelogevents")]
        public string Text { get; set; }

        [XmlElement("location", Namespace = "http://www.xyz.org/lifelogevents")]
        public Location Location { get; set; }

        [XmlElement("datetimestamp", Namespace = "http://www.xyz.org/lifelogevents")]
        public string DateTime { get; set; }

        public override Location GetLocation()
        {
            return this.Location;
        }

        public FacebookEvent() : base()
        {
            this.Text = "";
            this.Location = new Location();
            this.DateTime = "";
        }

        public FacebookEvent(String eventID) : base(eventID)
        {
            this.Text = "";
            this.Location = new Location();
            this.DateTime = "";
        }
    }
}
