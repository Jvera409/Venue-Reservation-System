using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Venues
    {
        public int Id { get; set; }
        public string VenueName { get; set; }

        public int CityId { get; set; }

        public string Description { get; set; }

        public string CityName { get; set; }

        public string StateAbbreviation { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();


        public Venues(int id, string venueName, int cityId, string description, string cityName, string stateAbreviation)
        {
            Id = id;
            VenueName = venueName;
            CityId = cityId;
            Description = description;
            CityName = cityName;
            StateAbbreviation = stateAbreviation;
        }
        public Venues()
        {

        }

        public override string ToString()
        {
            return Id + " " + VenueName + " " + CityId + " " + Description + " " + CityName + " " + StateAbbreviation; 
        }
    }
}
