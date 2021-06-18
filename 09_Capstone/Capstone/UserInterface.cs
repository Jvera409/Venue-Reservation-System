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

        public UserInterface(string connectionString)
        {
            this.connectionString = connectionString;
            venueDAO = new VenueDAO(connectionString);
            spaceDAO = new SpaceDAO(connectionString);
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
                Console.WriteLine(venues.Id + " " + venues.Name);
            }

        }

        private void SelectVenue()
        {
            Console.WriteLine();
            Console.WriteLine("Which venue would you like to view?");
            int venueSelect = int.Parse(Console.ReadLine());

            Venues venues = venueDAO.SelectVenue(venueSelect);

            Console.WriteLine();
            Console.WriteLine(venues.Name);

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
                        //ReserveASpace();
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

            foreach (Space space in spaces)
            {
                Console.WriteLine(space.Id + " " + space.Name + " " + space.OpenFrom + " " + space.OpenTo + " " + space.IsAccessible + " " + space.DailyRate + " " + space.MaxOccupancy);
            }

        }
    }

}
