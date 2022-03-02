using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    [XmlRoot(Namespace = "http://www.xyz.org/lifelogevents", ElementName = "video", DataType = "string", IsNullable = true)]
    public class VideoEvent : Event
    {
        [XmlElement("filepath", Namespace = "http://www.xyz.org/lifelogevents")]
        public string Path { get; set; }

        [XmlElement("location", Namespace = "http://www.xyz.org/lifelogevents")]
        public Location Location { get; set; }

        [XmlElement("start-time", Namespace = "http://www.xyz.org/lifelogevents")]
        public string StartTime { get; set; }

        [XmlElement("end-time", Namespace = "http://www.xyz.org/lifelogevents")]
        public string EndTime { get; set; }

        public override Location GetLocation()
        {
            return this.Location;
        }
        public override string GetPath()
        {
            return this.Path;
        }

        public VideoEvent() : base()
        {
            this.Path = "";
            this.Location = new Location();
            this.StartTime = "";
            this.EndTime = "";
        }

        public VideoEvent(String eventID) : base(eventID)
        {
            this.Path = "";
            this.Location = new Location();
            this.StartTime = "";
            this.EndTime = "";
        }
    }
}
