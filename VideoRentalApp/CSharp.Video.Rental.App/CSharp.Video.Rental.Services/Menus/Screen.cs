using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Video.Rental.Services.Menus
{
    public static class Screen
    {
        public static void HomeScreen()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==  \\\\    //  || ||||   ||||||  ||||||   ||||||  ||||||  ||  || ||||||  ==");
            Console.WriteLine("==   \\\\  //   || ||  || ||=     ||  ||   ||\\\\    ||=     ||\\\\||   ||    ==");
            Console.WriteLine("==    \\\\//    || ||||   ||||||  ||||||   ||  \\\\  ||||||  ||  ||   ||    ==");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void StartMenu()
        {
            Console.WriteLine("Welcome to video rental store.");
            Console.WriteLine("Use the number in fromt  of selection to navigate thru the application.");
            Console.WriteLine("1. Rent a movie with existing account.");
            Console.WriteLine("2. Rent a movie and create acount");
            Console.WriteLine("3. Exit aplication");
        }
        public static void MainMenu(string name)
        {
            Console.WriteLine(string.Format("Welcome {0}. What do you want to do today", name));
            Console.WriteLine("Use the numbers in front of the selection to navigate thru the applicaton.");
            Console.WriteLine("1. View all videos");
            Console.WriteLine("2. View rented videos");
            Console.WriteLine("3. View history");
            Console.WriteLine("4. Exit application");
        }
        public static void OrderingMenu()
        {
            Console.WriteLine("Use the numbers in front of the selection to navigate thru the applicaton.");
            Console.WriteLine("1. View all videos");
            Console.WriteLine("2. Order videos by genre");
            Console.WriteLine("3. Get videos by genre");
            Console.WriteLine("4. Order videos by release date");
            Console.WriteLine("5. Get movies by year of release");
            Console.WriteLine("6. Order videos by availability");
            Console.WriteLine("7. Get available videos");
            Console.WriteLine("8. Search videos by title");

            Console.WriteLine("9. Rent a video");
            Console.WriteLine("0. Go back");
        }

        public static void RentedMovie()
        {
            Console.WriteLine("Use the numbers in front of the selection to navigate thru the applicaton.");
            Console.WriteLine("1. View all videos");
            Console.WriteLine("2. Return video");
            Console.WriteLine("0. Go back");
        }
        public static void CleanScreen()
        {
            Console.Clear();
            HomeScreen();
        }

    }
}
