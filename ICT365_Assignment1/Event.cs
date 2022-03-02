﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    [XmlRoot(ElementName = "Event", Namespace = "http://www.xyz.org/lifelogevents")]
    abstract public class Event
    {
        [XmlElement("eventid", Namespace = "http://www.xyz.org/lifelogevents")]
        public string EventID { get; set; }

        public abstract Location GetLocation();
        public abstract string GetPath();
        //private HashSet<string> linkedEventID = new HashSet<string>();

        public Event()
        {
            this.EventID = "";
        }

        public Event(string eventID)
        {
            this.EventID = eventID;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        //public HashSet<string> LinkedEventID { get => linkedEventID; set => linkedEventID = value; }
    }
}
