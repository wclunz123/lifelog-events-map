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
    public class PhotoEventTest
    {
        [TestMethod()]
        public void PhotoEventInheritanceTest()
        {
            Location loc = new Location(1.052251, 103.25215);
            Event newEvent = new PhotoEvent("ID123", "/photo/test.png", loc);
            Assert.IsTrue(newEvent is PhotoEvent);
        }

        [TestMethod()]
        public void PhotoEventConstructorTest()
        {
            Location loc = new Location(1.052251, 103.25215);
            Event newEvent = new PhotoEvent("ID123", "/photo/test.png", loc);

            if (newEvent is PhotoEvent photoEvent)
            {
                Assert.AreEqual("/photo/test.png", photoEvent.Path);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}