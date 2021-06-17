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

        private string sqlSelectVenue = "Select * FROM venue WHERE id = @id";

        private string sqlCategory = "SELECT catergory.name FROM category_venue JOIN category " +
            "ON category_venue.category_id = category.id WHERE category_id = @venue_id";

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

        public List<Venues> SelectVenue(int Id)
        {
            List<Venues> venues = new List<Venues>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlSelectVenue, conn);

                    cmd.Parameters.AddWithValue("@id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Venues venues1 = new Venues();

                        venues1.Id = Convert.ToInt32(reader["id"]);
                        //venues1.Name = Convert.ToString(reader["name"]);
                        //venues1.CityId = Convert.ToInt32(reader["city_id"]);
                        venues1.Description = Convert.ToString(reader["description"]);

                        venues.Add(venues1);
                    }

                    foreach (Venues venues2 in venues)
                    {
                        List<Category> categories = new List<Category>();
                        SqlCommand cmd2 = new SqlCommand(sqlCategory, conn);

                        cmd2.Parameters.AddWithValue("@venue_id", venues2.Id);

                        SqlDataReader sqlDataReader = cmd2.ExecuteReader();

                        if (reader.Read() == true)
                        {
                            Category category = new Category();
                            //category.ID = Convert.ToInt32(reader["id"]);
                            category.Name = Convert.ToString(reader["name"]);

                            categories.Add(category);
                        }
                        venues2.Categories = categories;
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
