using MyMangerLibrary;
using MyMangerLibrary.Exceptions;
using MyMangerLibrary.Model;
using MyMangerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMoviesAppV2.Controller
{
    internal class MovieController
    {
        public static int movieCount = 0;

        public void Start()
        {   
            int choice;

            do
            {
                new MovieManager();
                int movieCount = MovieManager.MovieCount();
                Console.WriteLine($"Movie store status: {movieCount}/{MovieManager.MAX_MOVIES}");
                Console.WriteLine("=============Menu=============");
                Console.WriteLine("1. Display movies");
                Console.WriteLine("2. Display movies by year");
                Console.WriteLine("3. Add movie");
                Console.WriteLine("4. Remove movie by name");
                Console.WriteLine("5. Clear all movies");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayMovies();
                        break;
                    case 2:
                        DisplayMoviesByYear();
                        break;
                    case 3:
                        AddMovie();
                        break;
                    case 4:
                        RemoveMovie();
                        break;
                    case 5:
                        ClearAllMovies();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 6);
        }

        private void DisplayMovies()
        {
            if (MovieManager.MovieCount() == 0)
            {
                throw new MoviesListEmptyException("Movies list is empty.");
            }
            Console.WriteLine("Movies list is..");
            Console.WriteLine("========================");
            List<Movies> movies = MovieManager.GetAllMovies();

            foreach (Movies movie in movies)
            {
                Console.WriteLine($"Movie Id: {movie.MovieId}");
                Console.WriteLine($"Name: {movie.MovieName}");
                Console.WriteLine($"Genre: {movie.MovieGenre}");
                Console.WriteLine($"Year: {movie.MovieYear}");
                Console.WriteLine("-----------------------------------");
            }
        }

        private void DisplayMoviesByYear()
        {
            Console.Write("Enter the year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"List of Movies released in the {year}:");
            Console.WriteLine("-----------------------------------");
            List<Movies> movies = MovieManager.GetAllMovies();
            foreach (Movies movie in movies)
            {
                if(movie.MovieYear == year)
                {
                    Console.WriteLine($"Movie Id: {movie.MovieId}");
                    Console.WriteLine($"Name: {movie.MovieName}");
                    Console.WriteLine($"Genre: {movie.MovieGenre}");
                    Console.WriteLine($"Year: {movie.MovieYear}");
                    Console.WriteLine("-----------------------------------");
                }
            }
        }

        private void AddMovie()
        {
            try
            {
                Console.Write("Enter Movie Id: ");
                int movieId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Movie Name: ");
                string movieName = Console.ReadLine();

                Console.Write("Enter Movie Genre: ");
                string movieGenre = Console.ReadLine();

                Console.Write("Enter Movie Year: ");
                int movieYear = Convert.ToInt32(Console.ReadLine());

                MovieManager.AddMovie(movieId, movieName, movieGenre, movieYear);
                Console.WriteLine("Movie added successfully!");
            }
            catch (MaxLimitReachedException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
        private void RemoveMovie()
        {
            Console.Write("Enter the name of the movie you want to remove: ");
            string movieName = Console.ReadLine();

            try
            {
                if (MovieManager.RemoveMovieByName(movieName))
                {
                    Console.WriteLine($"{movieName} movie removed from the list");
                }
                else
                {
                    Console.WriteLine($"No movie named {movieName} found in the list");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing movie: {ex.Message}");
            }
        }

        private void ClearAllMovies()
        {
            MovieManager.ClearAllMovies();
            Console.WriteLine("All movies list has been cleared...");
        }
    }
}
