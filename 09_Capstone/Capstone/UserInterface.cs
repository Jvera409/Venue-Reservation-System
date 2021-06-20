using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class UserInterface
    {
        //ALL Console.ReadLine and WriteLine in this class
        //NONE in any other class

        private string connectionString;
        private VenueDAO venueDAO;
        private SpaceDAO spaceDAO;
        private ReservationDAO reservationDAO;

        public UserInterface(string connectionString)
        {
            this.connectionString = connectionString;
            venueDAO = new VenueDAO(connectionString);
            spaceDAO = new SpaceDAO(connectionString);
            reservationDAO = new ReservationDAO(connectionString);
        }

        public void Run()
        {
            bool done = false;

            while (!done)
            {
                MainMenu();
                string input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "1": //callSQLMethod
                        GetAllVenues();
                        SelectVenue();
                        break;
                    case "Q":
                        done = true;
                        Console.WriteLine("Thank you for using Excelsior Venues.");
                        break;
                }
            }

        }
        private void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. List Venues");
            Console.WriteLine("Q. Quit program");
            Console.WriteLine();
        }

        private void GetAllVenues()
        {
            Console.WriteLine();
            Console.WriteLine("Here are all available Venues:");

            foreach (Venues venues in venueDAO.GetAllVenues())
            {
                Console.WriteLine(venues.Id + " " + venues.VenueName);
            }

        }

        private void SelectVenue()
        {
            Console.WriteLine();
            Console.WriteLine("Which venue would you like to view?");
            int venueSelect = int.Parse(Console.ReadLine());

            Venues venues = venueDAO.SelectVenue(venueSelect);

            Console.WriteLine();
            Console.WriteLine(venues.VenueName);

            Console.WriteLine("Location: " + venues.CityName + ", " + venues.StateAbbreviation);

            foreach (Category category in venues.Categories)
            {
                Console.WriteLine("Categories: " + category.Name);
            }
            Console.WriteLine();
            Console.WriteLine(venues.Description);

            bool done = false;
            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do next ?");
                Console.WriteLine();
                Console.WriteLine("1) View Spaces");
                Console.WriteLine("2) Reserve a Space");
                Console.WriteLine("R) Return to Previous Screen");
                Console.WriteLine();


                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SelectSpace(venueSelect);
                        break;
                    case "2":
                        ReserveASpace(venueSelect);
                        break;
                    case "R":
                    case "r":
                        GetAllVenues();
                        SelectVenue();
                        break;
                    default:
                        Console.WriteLine("Please make valid selection.");
                        break;
                }
            }

        }

        private void SelectSpace(int id)
        {
            Console.WriteLine();
            Console.WriteLine("Here are all available spaces for venue selected:");

            List<Space> spaces = spaceDAO.SelectSpace(id);

            Console.WriteLine("ID  Name            Open From  Open To  Is Accessible     Daily Rate     Max Occupancy");
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            foreach (Space space in spaces)
            {
                Console.WriteLine(space.Id.ToString().PadRight(2) + " " + space.SpaceName.PadRight(20) + " " + space.OpenFrom.ToString().PadRight(9) + " " + space.OpenTo.ToString().PadRight(10) + " " + space.IsAccessible.ToString().PadRight(14) + " " + space.DailyRate.ToString().PadRight(15) + " " + space.MaxOccupancy);
            }

            ReserveASpace(id);
        }

        //private void SearchSpaces(int id)
        //{
        //    Console.WriteLine();
        //    Console.WriteLine("When do you need the space?");
        //    DateTime date = DateTime.Parse(Console.ReadLine());

        //    Console.WriteLine();
        //    Console.WriteLine("How many days will you need the space?");
        //    int days = int.Parse(Console.ReadLine());

        //    Console.WriteLine();
        //    Console.WriteLine("How many people will be in attendance?");
        //    int amountOfPeople = int.Parse(Console.ReadLine());

        //    List<Space> spaces = reservationDAO.SearchSpaces(date, days, amountOfPeople, id);

        //    Console.WriteLine();
        //    Console.WriteLine("Below are the available spaces: ");
        //    Console.WriteLine();

        //    foreach (Space space in spaces)
        //    {
        //        Console.WriteLine(space.Id + " " + space.Name + " " + space.DailyRate + " " + " " + space.MaxOccupancy + " " + space.IsAccessible + " " + space.DailyRate * days);
        //    }

        //    ReserveASpace(date, days, amountOfPeople, id);
        //}
        //DateTime date, int days, int amountOfPeople, int id



        private void ReserveASpace(int id)
        {
            Console.WriteLine();
            Console.WriteLine("When do you need the space?");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("How many days will you need the space?");
            int days = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("How many people will be in attendance?");
            int amountOfPeople = int.Parse(Console.ReadLine());

            List<Space> spaces = reservationDAO.SearchSpaces(date, days, amountOfPeople, id);

            Console.WriteLine();
            Console.WriteLine("Below are the available spaces: ");
            Console.WriteLine();

            Console.WriteLine("Space #  Name            Daily Rate  Max Occuapncy  Accessible?  Total Cost");
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach (Space space in spaces)
            {
                Console.WriteLine(space.Id.ToString().PadRight(7) + " " + space.SpaceName.PadRight(20) + " " + space.DailyRate.ToString().PadRight(9) + " " + " " + space.MaxOccupancy.ToString().PadRight(13) + " " + space.IsAccessible.ToString().PadRight(14) + " " + space.DailyRate * days);
            }

            Console.WriteLine();
            Console.WriteLine("Which space would you like to reserve(enter 0 to cancel)?");
            int spaceId = int.Parse(Console.ReadLine());


            if (spaceId == 0)
            {
                GetAllVenues();
            }

            Console.WriteLine("Who is this reservation for?");
            string customerName = Console.ReadLine();

            DateTime endDate = date.AddDays(days);

            Reservation reservation = new Reservation(spaceId, amountOfPeople, date, endDate, customerName);

            int reservationId = reservationDAO.ReserveASpace(reservation);



            Console.WriteLine();
            Console.WriteLine("Thanks for submitting your reservation! The details for your event are listed below: ");
            Console.WriteLine("------------------------------------------------------------------------------------");
            //return the results of a sql query for the new reservation we just made and return the values
            Console.WriteLine("Confirmation Number: " + reservationId);
            Console.WriteLine("Venue: " + venueDAO.SelectVenue(id).VenueName);
            Console.WriteLine("Space: " + spaceDAO.SelectIndividualSpace(id).SpaceName);
            Console.WriteLine("Reserved for: " + customerName);
            Console.WriteLine("Attendees: " + amountOfPeople);
            Console.WriteLine("Arrival Date: " + date);
            Console.WriteLine("Departure: " + endDate);
            Console.WriteLine("Total Cost: " + spaceDAO.SelectIndividualSpace(id).DailyRate * days);

        }
    }

}
