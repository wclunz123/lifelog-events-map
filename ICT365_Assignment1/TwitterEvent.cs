using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    [XmlRoot(Namespace = "http://www.xyz.org/lifelogevents", ElementName = "tweet", DataType = "string", IsNullable = true)]
    public class TwitterEvent : Event
    {
        [XmlElement("text", Namespace = "http://www.xyz.org/lifelogevents")]
        public string Text { get; set; }

        [XmlElement("location", Namespace = "http://www.xyz.org/lifelogevents")]
        public Location Location { get; set; }

        [XmlElement("datetimestamp", Namespace = "http://www.xyz.org/lifelogevents")]
        public String DateTime { get; set; }

        public override Location GetLocation()
        {
            return this.Location;
        }
        public override string GetPath()
        {
            return null;
        }

        public TwitterEvent() : base()
        {
            this.Text = "";
            this.Location = new Location();
            this.DateTime = "";
        }

        public TwitterEvent(String eventID) : base(eventID)
        {
            this.Text = "";
            this.Location = new Location();
            this.DateTime = "";
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
