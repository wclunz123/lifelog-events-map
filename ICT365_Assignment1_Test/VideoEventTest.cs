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

        //[TestMethod()]
        //public void VideoEventDateTimeTest2()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetLocationDateTimeTest()
        //{
        //    Assert.Fail();
        //}
    }
}