using CSharp.Video.Rental.Data.Database;
using CSharp.Video.Rental.Data.Enumeration;
using CSharp.Video.Rental.Data.Models;
using CSharp.Video.Rental.Services.Helpers;
using CSharp.Video.Rental.Services.Interfaces;
using CSharp.Video.Rental.Services.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Video.Rental.Services.Services
{
    public class MovieService : IMovieService
    {
        private MovieRepository _movieRepository;
        private UserRepository _userRepository;

        public MovieService()
        {
            _movieRepository = new MovieRepository();
            _userRepository = new UserRepository();
        }


        public void ViewMovierList(User user)
        {
            List<Movie> movies = new List<Movie>();
            bool isFinished = false;
            string errorMessage = string.Empty;

            while (isFinished)
            {
                Screen.CleanScreen();
                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                    Console.ResetColor();
                    errorMessage = string.Empty;
                }

                if(movies.Count != 0)
                {
                    var selection = InputParser.ToInteger(0, 9);
                    switch (selection)
                    {
                        case 1:
                            movies = _movieRepository.GetAll();
                            break;
                        case 2:
                            movies = _movieRepository.OrderByGenre(true);
                            break;
                        case 3:
                            Genre genre = InputParser.ToGenre();
                            movies = _movieRepository.Filter(x => x.Genre == genre);
                            break;
                        case 4:
                            movies = _movieRepository.OrderByReliseDate(true);
                            break;
                        case 5:
                            int year = InputParser.ToInteger(_movieRepository.GetAll()
                                .Min(_movie => _movie.ReleaseDate.Year), DateTime.Now.Year - 1);
                            movies = _movieRepository.Filter(x => x.ReleaseDate.Year == year);
                            break;
                        case 6:
                            movies = _movieRepository.OrderByAvailability(true);
                            break;
                        case 7:
                            movies = _movieRepository.Filter(x => x.IsAvailable);
                            break;
                        case 8:
                            string titlePart = Console.ReadLine();
                            string trimetTitlePart = titlePart.Trim().ToLower();
                            movies = _movieRepository.Filter(x => x.Title.ToLower().Contains(trimetTitlePart));
                            break;
                        case 9:
                            try
                            {
                                RentMovie(user);
                            }
                            catch (Exception ex)
                            {
                                errorMessage = ex.Message;
                                
                            }
                            break;
                        case 0:
                            isFinished = !isFinished;
                            break;

                    }

                }
            }

        }

        private void RentMovie(User user)
        {
            Console.WriteLine("Enter movie id: ");
            var idSelected = InputParser.ToInteger(
                _movieRepository.GetAll().Min(x => x.Id),
                _movieRepository.GetAll().Max(x => x.Id)
               );
            var movie = _movieRepository.GetById(idSelected);
            if(movie != null)
            {
                var listOfRentedMovies = user.RentedMovies.Select(rental => rental.Movie.Id).ToList();
                if (listOfRentedMovies.Contains(idSelected))
                {
                    throw new Exception($"Already rented {movie.Title}. Please return it first");
                }
                if (!movie.IsAvailable)
                {
                    throw new Exception($"Movie {movie.Title} is not available at the moment");
                }

                Console.WriteLine($"Are you sure you want to rent {movie.Title}? y/n");
                bool confirm = InputParser.ToConfirm();
                if (!confirm)
                {
                    return;
                }
                Console.WriteLine("Return movie.Please wait...");
                movie.Quantity--;
                if(movie.Quantity  == 0)
                {
                    movie.IsAvailable = !movie.IsAvailable;
                }
                user.RentedMovies.Add(new RentalInfo(movie));
                _movieRepository.Update(movie);
                _userRepository.Update(user);
            }
            else
            {
                throw new Exception($"No movie was found with {idSelected} id");
            }


        }
    }
}
