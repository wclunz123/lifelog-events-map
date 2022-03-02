using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ICT365_Assignment1
{
    [XmlRoot(Namespace = "http://www.xyz.org/lifelogevents", ElementName = "location", DataType = "string", IsNullable = true)]
    public class Location
    {
        [XmlElement("lat", Namespace = "http://www.xyz.org/lifelogevents")]
        public double Latitude { get; set; }
        [XmlElement("long", Namespace = "http://www.xyz.org/lifelogevents")]
        public double Longitude { get; set; }

        public Location()
        {
            this.Latitude = 0.0;
            this.Longitude = 0.0;
        }
        public Location(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
