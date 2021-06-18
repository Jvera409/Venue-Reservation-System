using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    class ReservationDAO
    {
        private string connectionString;

        private string SqlReserveASpace = "INSERT INTO reservation (space_id, number_of_attendees, reserved_for, start_date, end_date) " +
        " VALUES(@space_id,@number_of_attendees, @reserved_for, @start_date, @end_date)";

        private string sqlSearchSpaces = "SELECT * FROM space WHERE venue_id = @venue_id AND space.id NOT IN " +
          " (SELECT space.id from reservation JOIN space ON reservation.space_id = space.id WHERE space.venue_id= @venue_id " +
          " AND reservation.end_date >= @start_date AND reservation.start_date <= @end_date)";

        public ReservationDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public List<Space> SearchSpaces(DateTime date, int days, int amountOfPeople)
        {
            List<Space> spaces = new List<Space>();
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlSearchSpaces, conn);

                    cmd.Parameters.AddWithValue("@start_date", date);
                    cmd.Parameters.AddWithValue("@end_date", date.AddDays(days));
                    cmd.Parameters.AddWithValue("@max_occupancy", amountOfPeople);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Space space = new Space();

                        space.Id = Convert.ToInt32(reader["id"]);
                        space.Name = Convert.ToString(reader["name"]);
                        space.DailyRate = Convert.ToDouble(reader["daily_rate"]);
                        space.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
                        space.IsAccessible = Convert.ToBoolean(reader["is_accessible"]);

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
        
    
        public int ReserveASpace(Reservation newReservation)
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SqlReserveASpace, conn);

                    cmd.Parameters.AddWithValue("@start_date", newReservation.StartDate);
                    cmd.Parameters.AddWithValue("@end_date", newReservation.EndDate);
                    cmd.Parameters.AddWithValue("@reserved_for", newReservation.ReservedFor);
                    cmd.Parameters.AddWithValue("@number_of_attendees", newReservation.NumberOfAttendees);
                    cmd.Parameters.AddWithValue("@space_id", newReservation.SpaceId);
                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = count;
                    }

                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }
    }
}
