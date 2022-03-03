using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    [Serializable]
    [XmlRoot(Namespace = "http://www.xyz.org/lifelogevents", ElementName = "tracklog", DataType = "string", IsNullable = true)]
    public class TracklogEvent : Event
    {
        [XmlElement("filepath", Namespace = "http://www.xyz.org/lifelogevents")]
        public string Path { get; set; }

        [XmlElement("data", Namespace = "http://www.xyz.org/lifelogevents")]
        public string Data { get; set; }

        [XmlElement("start-time", Namespace = "http://www.xyz.org/lifelogevents")]
        public string StartTime { get; set; }

        [XmlElement("end-time", Namespace = "http://www.xyz.org/lifelogevents")]
        public string EndTime { get; set; }

        public override Location GetLocation()
        {
            return null;
        }
        public override string GetPath()
        {
            return this.Path;
        }

        public TracklogEvent() : base()
        {
            this.Path = "";
            this.Data = "";
            this.StartTime = "";
            this.EndTime = "";
        }

        public TracklogEvent(string eventID) : base(eventID)
        {
            this.Path = "";
            this.Data = "";
            this.StartTime = "";
            this.EndTime = "";
        }

        public TracklogEvent(string eventID, string path, string data, string startTime, string endTime) : base(eventID)
        {
            this.Path = path;
            this.Data = data;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
