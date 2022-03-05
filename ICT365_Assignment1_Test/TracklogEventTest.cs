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
    public class TracklogEventTest
    {
        [TestMethod()]
        public void TracklogEventInheritanceTest()
        {
            TracklogEvent newEvent = new TracklogEvent("ID123", "/tracklog/test.gpx", "Some data..", "20221231105922", "20230112082921");
            Assert.IsTrue(newEvent is TracklogEvent);
        }

        [TestMethod()]
        public void TracklogEventStartDateTimeTest()
        {
            string StartDateTimeString = "20211015175521";
            string DateTimeFormat = "yyyyMMddHHmmss";

            TracklogEvent tracklogEvent = new TracklogEvent();
            tracklogEvent.StartTimeString = StartDateTimeString;

            DateTime CorrectStartDateTime = DateTime.ParseExact(StartDateTimeString, DateTimeFormat, null);
            Assert.AreEqual(CorrectStartDateTime, tracklogEvent.StartDateTime);
        }

        [TestMethod()]
        public void TracklogEventEndDateTimeTest()
        {
            string EndDateTimeString = "20211015175521";
            string DateTimeFormat = "yyyyMMddHHmmss";

            TracklogEvent tracklogEvent = new TracklogEvent();
            tracklogEvent.EndTimeString = EndDateTimeString;

            DateTime CorrectEndDateTime = DateTime.ParseExact(EndDateTimeString, DateTimeFormat, null);
            Assert.AreEqual(CorrectEndDateTime, tracklogEvent.EndDateTime);
        }

        [TestMethod()]
        public void TracklogEventConstructorTest()
        {
            Event newEvent = new TracklogEvent("ID123", "/tracklog/test.gpx", "Some data..", "20221231105922", "20230112082921");


            if (newEvent is TracklogEvent tracklogEvent)
            {
                Assert.AreEqual("/tracklog/test.gpx", tracklogEvent.Path);
            }
        }
    }
}