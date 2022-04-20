using CSharp.Video.Rental.Data.Models;
using CSharp.Video.Rental.Services.Helpers;
using CSharp.Video.Rental.Services.Interfaces;
using CSharp.Video.Rental.Services.Menus;
using CSharp.Video.Rental.Services.Services;
using System;

namespace CSharp.Video.Rental.App
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = null;
            IUserService userService = new UserService();
            IMovieService movieService = new MovieService();


            #region Login/SingUp

            Screen.HomeScreen();
            bool isLoggedIn = false;
            while (!isLoggedIn)
            {
                Screen.StartMenu();
                int startManuInput = InputParser.ToInteger(1, 3);
                switch (startManuInput)
                {
                    case 1:
                        user = userService.LogIn();
                        if(user != null)
                        {
                            isLoggedIn = true;
                        }
                        break;
                    case 2:
                        user = userService.SingUp();
                        if(user != null)
                        {
                            isLoggedIn = true;
                        }
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;

                }
            }


            #endregion

            while (true)
            {
                Screen.CleanScreen();
                Screen.MainMenu(user.FullName);

                var selection = InputParser.ToInteger(1, 4);
                switch (selection)
                {
                    case 1:
                        movieService.ViewMovierList(user);
                        break;
                    case 2:
                        userService.ViewRentalMovies(user);
                        break;
                    case 3:
                        //ToDo:
                        break;
                    case 4:
                    default: 
                        Environment.Exit(0);
                        break;
                }
            }



            Console.ReadLine();
        }
    }
}
