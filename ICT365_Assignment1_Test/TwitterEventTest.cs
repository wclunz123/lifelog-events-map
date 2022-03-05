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
    public class TwitterEventTest
    {
        [TestMethod()]
        public void TwitterEventInheritanceTest()
        {
            Location loc = new Location(1.052251, 103.25215);
            Event newEvent = new TwitterEvent("ID123", "Tweet birdy day.", loc, "20221231105922");
            Assert.IsTrue(newEvent is TwitterEvent);
        }

        [TestMethod()]
        public void TwitterEventConstructorTest()
        {
            Location loc = new Location(1.052251, 103.25215);
            Event newEvent = new TwitterEvent("ID123", "Tweet birdy day.", loc, "20221231105922");

            if (newEvent is TwitterEvent twitterEvent)
            {
                Assert.AreEqual("Tweet birdy day.", twitterEvent.Text);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void TwitterEventStartDateTimeTest()
        {
            string DateTimeString = "20211015175521";
            string DateTimeFormat = "yyyyMMddHHmmss";

            TwitterEvent twitterEvent = new TwitterEvent();
            twitterEvent.DateTimeString = DateTimeString;

            DateTime CorrectStartDateTime = DateTime.ParseExact(DateTimeString, DateTimeFormat, null);
            Assert.AreEqual(CorrectStartDateTime, twitterEvent.DateTime);
        }
    }
}