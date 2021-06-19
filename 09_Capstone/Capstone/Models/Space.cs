using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Space 
    {
        // id, venue id, name, is accessible, open from, open to, daily rate, max occupancy
        public int Id { get; set; }
        public string SpaceName { get; set; }
        public int VenueId { get; set; }
        public bool IsAccessible { get; set; }
        public int OpenFrom { get; set; }
        public int OpenTo { get; set; }
        public double DailyRate { get; set; }
        public int MaxOccupancy { get; set; }

        public Space(int id, string spaceName, int venueId, bool isAccessible, int openFrom, int openTo, double dailyRate, int maxOccupancy)
        {
            Id = id;
            SpaceName = spaceName;
            VenueId = venueId;
            IsAccessible = isAccessible;
            OpenFrom = openFrom;
            OpenTo = openTo;
            DailyRate = dailyRate;
            MaxOccupancy = maxOccupancy;
        }
        public Space()
        {

        }
        public override string ToString()
        {
            return Id + " " + SpaceName + " " + OpenFrom + " " + OpenTo + " " + DailyRate + " " + MaxOccupancy;

        }
    }
}
