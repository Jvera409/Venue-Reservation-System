using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Capstone.Tests
{
    [TestClass]
    public class VenueDAOTest : ParentTest
    {

        [TestMethod]
        public void VenueDaoContructor()
        {
            Assert.IsNotNull(venueDAO);
        }

        [TestMethod]
        public void GetAllVenuesTest()
        {
            //Arrange

            venueDAO = new VenueDAO(connectionString);

            //Act

            List<Venues> venues = venueDAO.GetAllVenues();
            int count = venues.Count;

            //Assert
            Assert.AreEqual(count, venues.Count);

        }

        [TestMethod]
        [DataRow(90)]

        public void SelectVenueTest(int id)
        {
            Venues venues = new Venues();

            venues.Id = id;

            List<Venues> venues1 = venueDAO.GetAllVenues();
            int count = venues1.Count;

            venueDAO.SelectVenue(id);

            venues1 = venueDAO.GetAllVenues();

            Assert.AreEqual(count, venues1.Count);
        }
    }
}
