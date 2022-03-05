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
    public class FacebookEventTest
    {
        [TestMethod()]
        public void FacebookEventInheritanceTest()
        {
            Location loc = new Location(1.052251, 103.25215);
            Event newEvent = new FacebookEvent("ID123", "Raining day.", loc, "20221231105922");
            Assert.IsTrue(newEvent is FacebookEvent);
        }

        [TestMethod()]
        public void FacebookEventConstructorTest()
        {
            Location loc = new Location(1.052251, 103.25215);
            Event newEvent = new FacebookEvent("ID123", "Raining day.", loc, "20221231105922");

            if (newEvent is FacebookEvent facebookEvent)
            {
                Assert.AreEqual("Raining day.", facebookEvent.Text);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void FacebookEventStartDateTimeTest()
        {
            string DateTimeString = "20211015175521";
            string DateTimeFormat = "yyyyMMddHHmmss";

            FacebookEvent facebookEvent = new FacebookEvent();
            facebookEvent.DateTimeString = DateTimeString;

            DateTime CorrectStartDateTime = DateTime.ParseExact(DateTimeString, DateTimeFormat, null);
            Assert.AreEqual(CorrectStartDateTime, facebookEvent.DateTime);
        }
    }
}