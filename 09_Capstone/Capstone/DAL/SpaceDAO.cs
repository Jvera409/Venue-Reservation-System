using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    class SpaceDAO
    {
        private string connectionString;

        private string sqlGetAllSpaces = "SELECT * FROM space WHERE venue_id = @venue_id";

        public SpaceDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Space> GetAllSpaces()
        {
            List<Space> spaces = new List<Space>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllSpaces, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read() == true)
                    {
                        Space space = new Space();

                        space.Id = Convert.ToInt32(reader["id"]);
                        space.VenueId = Convert.ToInt32(reader["venue_id"]);
                        space.Name = Convert.ToString(reader["name"]);
                        space.IsAccessible = Convert.ToBoolean(reader["is_accessible"]);
                        space.OpenFrom = Convert.ToInt32(reader["open_from"]);
                        space.OpenTo = Convert.ToInt32(reader["open_to"]);
                        space.DailyRate = Convert.ToDouble(reader["daily_rate"]);
                        space.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);

                        spaces.Add(space);
                    }
                }
            }
            catch (Exception ex)
            {
                spaces = new List<Space>();

            }
            return spaces;
        }

    }
}
