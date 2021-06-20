using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class ReservationDAOTest : ParentTest
    {
        [TestMethod]
        public void ReservationDAOConstructor()
        {
            Assert.IsNotNull(reservationDAO);
        }

        //[TestMethod]

        //    public void AddANewReservationTest(DateTime date, int days, int amountOfPeople, int id)
        //    {
        //        //Arrange

        //        reservationDAO = new ReservationDAO(connectionString);
        //        reservationDAO.ReserveASpace(reservationDAO);

        //        //Act
        //        List<Space> reservations = reservationDAO.SearchSpaces(date, days, amountOfPeople, id)



        //        reservationDAO.ReserveASpace(newReservation);

        //        reservations = reservationDAO.SearchSpaces


        //    }
        //}
    }
}
