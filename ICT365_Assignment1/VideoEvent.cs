﻿using System;
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
        public string StartTime { get; set; }

        [XmlElement(ElementName = "end-time", DataType = "string", IsNullable = false, Namespace = "http://www.xyz.org/lifelogevents")]
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

        public VideoEvent(string eventID) : base(eventID)
        {
            this.Path = "";
            this.Location = new Location();
            this.StartTime = "";
            this.EndTime = "";
        }
        public VideoEvent(string eventID, string path, Location loc, string startTime, string endTime) : base(eventID)
        {
            this.Path = path;
            this.Location = loc;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
