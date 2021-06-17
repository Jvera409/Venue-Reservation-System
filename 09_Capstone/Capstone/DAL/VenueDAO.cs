using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class VenueDAO
    {
        // NOTE: No Console.ReadLine or Console.WriteLine in this class

        private string connectionString;

        private string sqlGetAllVenues = "SELECT * FROM venue;";

        public VenueDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public List<Venues> GetAllVenues()
        {
            List<Venues> venues = new List<Venues>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllVenues, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Venues venues1 = new Venues();

                        venues1.Id = Convert.ToInt32(reader["id"]);
                        venues1.Name = Convert.ToString(reader["name"]);
                        venues1.CityId = Convert.ToInt32(reader["city_id"]);
                        venues1.Description = Convert.ToString(reader["description"]);

                        venues.Add(venues1);
                    }

                }
            }
            catch (Exception ex)
            {
                venues = new List<Venues>();
            }
            return venues;
        }

    }
}
