using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    class Reservation
    {
        public int ReservationId { get; set; }

        public int SpaceId { get; set; }

        public int NumberOfAttendees { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ReservedFor { get; set; }

        public Reservation(int reservationId, int spaceId, int numberOfAtendees, DateTime startDate, DateTime endDate, string reservedFor)
        {
            ReservationId = reservationId;
            SpaceId = spaceId;
            NumberOfAttendees = numberOfAtendees;
            StartDate = startDate;
            EndDate = endDate;
            ReservedFor = reservedFor;
        }

        public Reservation()
        {

        }

        public override string ToString()
        {
            return ReservationId + " " + SpaceId + " " + NumberOfAttendees + " " + StartDate + " " + EndDate + " " + ReservedFor;
        }
    }
}
