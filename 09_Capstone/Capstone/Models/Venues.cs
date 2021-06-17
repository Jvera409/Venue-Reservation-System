using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Venues
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CityId { get; set; }

        public string Description { get; set; }


        public Venues(int id, string name, int cityId, string description)
        {
            Id = id;
            Name = name;
            CityId = cityId;
            Description = description;
        }
        public Venues()
        {

        }

        public override string ToString()
        {
            return Id + " " + Name + " " + CityId + " " + Description; 
        }
    }
}
