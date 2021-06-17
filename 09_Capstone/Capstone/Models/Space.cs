using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    class Space
    {
        // id, venue id, name, is accessible, open from, open to, daily rate, max occupancy
        public int Id { get; set; }
        public string Name { get; set; }
        public int VenueId { get; set; }
        public bool IsAccessible { get; set; }
        public int OpenFrom { get; set; }
        public int OpenTo { get; set; }
        public double DailyRate { get; set; }
        public int MaxOccupancy { get; set; }

        public Space(int id, string name, int venueId, bool isAccessible, int openFrom, int openTo, double dailyRate, int maxOccupancy)
        {
            Id = id;
            Name = name;
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
            return Id + " " + Name + " " + OpenFrom + " " + OpenTo + " " + DailyRate + " " + MaxOccupancy;

        }
    }
}
