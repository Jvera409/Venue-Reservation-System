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

        //Add a join to city here
        private string sqlSelectVenue = "SELECT * FROM venue WHERE id = @id";

        private string sqlCategory = "SELECT * FROM category_venue JOIN category " +
            " ON category_venue.category_id = category.id WHERE category_venue.venue_id = @venue_id";

        private string sqlCityState = "SELECT * FROM city JOIN venue " +
            " ON venue.city_id = city.id WHERE venue.id = @id";

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
                        venues1.VenueName = Convert.ToString(reader["name"]);
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

        public Venues SelectVenue(int Id)
        {
            Venues venue = new Venues();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlSelectVenue, conn);

                    cmd.Parameters.AddWithValue("@id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() == true)
                    {

                        venue.Id = Convert.ToInt32(reader["id"]);
                        venue.VenueName = Convert.ToString(reader["name"]);
                        venue.CityId = Convert.ToInt32(reader["city_id"]);
                        venue.Description = Convert.ToString(reader["description"]);

                    }
                    reader.Close();


                    List<Category> categories = new List<Category>();
                    cmd = new SqlCommand(sqlCategory, conn);

                    cmd.Parameters.AddWithValue("@venue_id", venue.Id);

                    reader = cmd.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        Category category = new Category();
                        category.ID = Convert.ToInt32(reader["id"]);
                        category.Name = Convert.ToString(reader["name"]);

                        categories.Add(category);
                    }
                    venue.Categories = categories;
                    reader.Close();

                    cmd = new SqlCommand(sqlCityState, conn);

                    cmd.Parameters.AddWithValue("@id", Id);

                    reader = cmd.ExecuteReader();

                    if (reader.Read() == true)
                    {

                        venue.CityName = Convert.ToString(reader["name"]);
                        venue.StateAbbreviation = Convert.ToString(reader["state_abbreviation"]);

                    }

                }
            }
            catch (Exception ex)
            {
                venue = new Venues();
            }
            return venue;
        }
    }
}
