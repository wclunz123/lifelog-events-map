using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT365_Assignment1
{
    public class EventFactory
    {
        public enum EventType
        {
            Twitter, Facebook, Photo, Video, Tracklog
        }

        public static Event GetEvent(EventType inputEvent) 
        {
            Event returnEvent;
            if (inputEvent == EventType.Twitter)
            {
                returnEvent = new TwitterEvent();
            } 
            else if  (inputEvent == EventType.Facebook)
            {
                returnEvent = new FacebookEvent();
            } 
            else if (inputEvent == EventType.Photo)
            {
                returnEvent = new PhotoEvent();
            } 
            else if (inputEvent == EventType.Video)
            {
                returnEvent = new VideoEvent();
            }
            else
            {
                returnEvent = new TracklogEvent();
            }
            return returnEvent;
        }
    }
}
