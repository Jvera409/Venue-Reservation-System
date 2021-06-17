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

        public UserInterface(string connectionString)
        {
            this.connectionString = connectionString;
            venueDAO = new VenueDAO(connectionString);
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
                        //GetAllSpaces();
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

            
            {
                Console.WriteLine();
                Console.WriteLine(venues.Name);
                Console.WriteLine(venues.CityId);
                Console.WriteLine(venues.Categories);
                Console.WriteLine();

            SelectSpace(venueSelect);
        }

        private void SelectSpace(int venue)
        {

        }

    }
}
