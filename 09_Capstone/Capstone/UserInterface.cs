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
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. List Venues");
            Console.WriteLine("Q. Quit program");
        }

        private void GetAllVenues()
        {
            Console.WriteLine("Here are all available Venues:");

            foreach (Venues venues in venueDAO.GetAllVenues())
            {
                Console.WriteLine(venues);
            }
      
        }
    }
}
