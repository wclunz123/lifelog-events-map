using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    [Serializable]
    [XmlRoot(Namespace = "http://www.xyz.org/lifelogevents", ElementName = "video", DataType = "string", IsNullable = true)]
    public class VideoEvent : Event
    {
        [XmlElement("filepath", Namespace = "http://www.xyz.org/lifelogevents")]
        public string Path { get; set; }

        [XmlElement("location", Namespace = "http://www.xyz.org/lifelogevents")]
        public Location Location { get; set; }

        [XmlElement(ElementName = "start-time", DataType = "string", Namespace = "http://www.xyz.org/lifelogevents")]
        public string StartTimeString { get; set; }

        [XmlElement(ElementName = "end-time", Namespace = "http://www.xyz.org/lifelogevents")]
        public string EndTimeString { get; set; }

        public DateTime StartDateTime
        {
            get
            {
                return ConvertDateTime(this.StartTimeString);
            }
        }

        public DateTime EndDateTime
        {
            get
            {
                return ConvertDateTime(this.EndTimeString);
            }
        }


        public EventFactory.EventType EventType = EventFactory.EventType.Video;

        public VideoEvent() : base()
        {
            this.Path = "";
            this.Location = new Location();
            this.StartTimeString = "";
            this.EndTimeString = "20220222222222";
        }

        public VideoEvent(string eventID) : base(eventID)
        {
            this.Path = "";
            this.Location = new Location();
            this.StartTimeString = "";
            this.EndTimeString = "20220222222222";
        }
        public VideoEvent(string eventID, string path, Location loc, string startTime, string endTime) : base(eventID)
        {
            this.Path = path;
            this.Location = loc;
            this.StartTimeString = startTime;
            this.EndTimeString = endTime;
        }

        public override Location GetLocation()
        {
            return this.Location;
        }

        private DateTime ConvertDateTime(string val)
        {
            string format = "yyyyMMddHHmmss";
            return DateTime.ParseExact(val, format, null);
        }
    }
}
