using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICT365_Assignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT365_Assignment1.Tests
{
    [TestClass()]
    public class EventFactoryTest
    {
        [TestMethod()]
        public void GetEventTwitterEventTest()
        {
            EventFactory.EventType CurrentEventType = EventFactory.EventType.Twitter;

            Event newEvent = EventFactory.GetEvent(CurrentEventType);
            Assert.IsTrue(newEvent is TwitterEvent);
        }

        [TestMethod()]
        public void GetEventFacebookEventTest()
        {
            EventFactory.EventType CurrentEventType = EventFactory.EventType.Facebook;

            Event newEvent = EventFactory.GetEvent(CurrentEventType);
            Assert.IsTrue(newEvent is FacebookEvent);
        }

        [TestMethod()]
        public void GetEventPhotoEventTest()
        {
            EventFactory.EventType CurrentEventType = EventFactory.EventType.Photo;

            Event newEvent = EventFactory.GetEvent(CurrentEventType);
            Assert.IsTrue(newEvent is PhotoEvent);
        }

        [TestMethod()]
        public void GetEventVideoEventTest()
        {
            EventFactory.EventType CurrentEventType = EventFactory.EventType.Video;

            Event newEvent = EventFactory.GetEvent(CurrentEventType);
            Assert.IsTrue(newEvent is VideoEvent);
        }

        [TestMethod()]
        public void GetEventTracklogEventTest()
        {
            EventFactory.EventType CurrentEventType = EventFactory.EventType.Tracklog;

            Event newEvent = EventFactory.GetEvent(CurrentEventType);
            Assert.IsTrue(newEvent is TracklogEvent);
        }
    }
}