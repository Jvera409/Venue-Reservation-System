using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]

    public class SpaceDAOTest : ParentTest
    {

        [TestMethod]

        public void SpaceDAOConstructor()
        {
            Assert.IsNotNull(spaceDAO);
        }

        [TestMethod]
        [DataRow(90)]

        public void SelectSpaceTest(int id)
        {
            Space space = new Space();

            space.Id = id;

            List<Space> spaces = spaceDAO.SelectSpace(id);
            int count = spaces.Count;

            spaceDAO.SelectSpace(id);

            venueDAO.SelectVenue(id);

            Assert.AreEqual(count, spaces.Count);
        }

        [TestMethod]
        [DataRow(90)]

        public void SelectIndividualSpaceTest(int id)
        {
            Space space = new Space();

            space.Id = id;

            List<Space> spaces = spaceDAO.SelectSpace(id);
            int count = spaces.Count;

            spaceDAO.SelectSpace(id);

            spaceDAO.SelectSpace(id);

            Assert.AreEqual(count, spaces.Count);
        }
    }
}