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
    public class VideoEventTest
    {
        [TestMethod()]
        public void VideoEventInheritanceTest()
        {
            Location loc = new Location(1.052251, 103.25215);
            Event newEvent = new VideoEvent("ID123", "/img/test.png", loc, "20221231105922", "20230112082921");
            Assert.IsTrue(newEvent is VideoEvent);
        }

        [TestMethod()]
        public void VideoEventStartDateTimeTest()
        {
            string StartDateTimeString = "20211015175521";
            string DateTimeFormat = "yyyyMMddHHmmss";

            VideoEvent videoEvent = new VideoEvent();
            videoEvent.StartTimeString = StartDateTimeString;

            DateTime CorrectStartDateTime = DateTime.ParseExact(StartDateTimeString, DateTimeFormat, null);
            Assert.AreEqual(CorrectStartDateTime, videoEvent.StartDateTime);
        }

        [TestMethod()]
        public void VideoEventEndDateTimeTest()
        {
            string EndDateTimeString = "20211015175521";
            string DateTimeFormat = "yyyyMMddHHmmss";

            VideoEvent videoEvent = new VideoEvent();
            videoEvent.EndTimeString = EndDateTimeString;

            DateTime CorrectEndDateTime = DateTime.ParseExact(EndDateTimeString, DateTimeFormat, null);
            Assert.AreEqual(CorrectEndDateTime, videoEvent.EndDateTime);
        }

        [TestMethod()]
        public void VideoEventConstructorTest()
        {
            Location loc = new Location(1.052251, 103.25215);
            Event newEvent = new VideoEvent("ID123", "/img/test.png", loc, "20221231105922", "20230112082921");
            

            if (newEvent is VideoEvent videoEvent)
            {
                Assert.AreEqual("/img/test.png", videoEvent.Path);
            }
            else
            {
                Assert.Fail();
            }    
        }
    }
}