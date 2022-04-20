using CSharp.Video.Rental.Data.Database;
using CSharp.Video.Rental.Data.Models;
using CSharp.Video.Rental.Services.Helpers;
using CSharp.Video.Rental.Services.Interfaces;
using CSharp.Video.Rental.Services.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSharp.Video.Rental.Services.Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;
        private MovieRepository _movieRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
            _movieRepository = new MovieRepository();
        }


        public User LogIn()
        {
            while (true)
            {
                Console.WriteLine("Enter card number: ");
                int idCard = InputParser.ToInteger(100, 999);
                User user = _userRepository.GetUserByIdCard(idCard);

                if(user != null)
                {
                    RenewSubscription(user);
                    Console.WriteLine($"Welcome {user.FullName}");
                    return user;
                }
                Console.WriteLine("User card id does not exists");
                Console.WriteLine("Try again y/n");
                if (!InputParser.ToConfirm())
                {
                    Console.WriteLine("Thank you for useing rent a video app");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }

            }
        }

        public User SingUp()
        {
            while (true)
            {
                Console.WriteLine("Enter full name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter date of birth: ");
                DateTime dob = InputParser.ToDateTime();
                int cardNumber = GenerateNewCardNumber();

                Console.WriteLine("Creating user please waith...");
                //lodaing indicator

                User user = new User
                {
                    CardNumber = cardNumber,
                    FullName = name,
                    DateOfBirth =dob
                };
                _userRepository.Insert(user);
                return user;

            }
        }

        private void ReturnMovie(User user)
        {
            if(user.RentedMovies.Count == 0)
            {
                Console.WriteLine("You don`t have any movies to return");
                return;
            }
            Console.WriteLine("Enter movie id in order to return the movie");
            var movieId = InputParser.ToInteger(1, int.MaxValue);
            var rental = user.RentedMovies.FirstOrDefault(x => x.Movie.Id == movieId);

            if(rental != null)
            {
                rental.DateRented = DateTime.Now;
                var movie = _movieRepository.GetById(movieId);
                if(movie.Quantity == 0)
                {
                    movie.IsAvailable = !movie.IsAvailable;
                    
                }
                movie.Quantity +=1;
                user.RentalHistory.Add(rental);
                user.RentedMovies.Remove(rental);

                _userRepository.Update(user);
                _movieRepository.Update(movie);
            }
            else
            {
                Console.WriteLine("You do not have that movie rented. Please enter vald movie id ");
                return;
            }
        }

        public void ViewRentalMovies(User user)
        {
            bool isActive = false;
            while (!isActive)
            {
                Screen.CleanScreen();
                user.ViewRentedMovies();
                Screen.RentedMovie();

                int selection = InputParser.ToInteger(0, 2);
                switch (selection)
                {
                    case 1:
                        user.ViewRentedMovies();
                        break;
                    case 2:
                        ReturnMovie(user);
                        break;
                    case 0:
                        isActive = !isActive;
                        break;
                    default:
                        break;
                }
            }
        }

        private int GenerateNewCardNumber()
        {
            const int max = 999;
            const int min = 100;
            Random rnd = new Random();
            List<int> takenCardNumber = _userRepository.GetAllCardNumbers();

            int cardNumber;

            do
            {
                cardNumber= rnd.Next(min,max);
            }
            while(takenCardNumber.Contains(cardNumber));
            return cardNumber;
        }

        private void RenewSubscription(User user)
        {
            if(user.SubscriptionExpireTime < DateTime.Now)
            {
                user.IsSubscriptionExpired = true;
            }
            if (user.IsSubscriptionExpired)
            {
                Console.WriteLine("Your subscription is expired. Do you want to renew y/n");
                bool renew = InputParser.ToConfirm();
                // lodaing indicator

                if (!renew)
                {
                    Console.WriteLine("Thank you for useing rent a video app");
                    Thread.Sleep(2000);
                    Environment.Exit(0);    
                }
                else
                {
                    user.IsSubscriptionExpired = false;
                    user.SubscriptionExpireTime = DateTime.Now.AddYears(1);
                    Console.WriteLine($"Your subscription is extended untill {user.SubscriptionExpireTime.ToShortDateString()}");
                }
            }
        }
    }
}
