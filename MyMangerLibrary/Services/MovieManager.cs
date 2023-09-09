using MyMangerLibrary.Exceptions;
using MyMangerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyMangerLibrary.Services
{
    public class MovieManager
    {
        public static string filePath = @"D:\Csharp\Session17\SimpleMoviesAppV2\MovieListUpdated.txt";

        private static List<Movies> moviesList;
        public const int MAX_MOVIES = 5;

        public MovieManager()
        {
            moviesList = new List<Movies>();
            moviesList = Serializer.Deserialize(filePath);
        }
        public static int MovieCount()
        {
            int count = moviesList.Count;
            return count;
        }
        public static void AddMovie(int movieId, string movieName, string movieGenre, int movieYear)
        {
            if (moviesList.Count >= MAX_MOVIES)
            {
                throw new MaxLimitReachedException("Maximum movie limit reached.");
            }
            Movies movie = new Movies(movieId,movieName,movieGenre, movieYear);
            moviesList.Add(movie);
            Serializer.Serialize(moviesList, filePath);
        }

        public static bool RemoveMovieByName(string movieName)
        {
            Movies movieToRemove = moviesList.Find(m => m.MovieName.Equals(movieName));

            if (movieToRemove != null)
            {
                moviesList.Remove(movieToRemove);
                Serializer.Serialize(moviesList, filePath);
                return true;
            }

            return false;
        }

        public List<Movies> GetMoviesByYear(int year)
        {
            List<Movies> moviesByYear = moviesList.FindAll(m => m.MovieYear == year);

            if (moviesByYear.Count == 0)
            {
                throw new NoMovieInYearException($"No movies found for the year {year}");
            }

            return moviesByYear;
        }

        public static void ClearAllMovies()
        {
            moviesList.Clear();
            Serializer.Serialize(moviesList, filePath);
        }

        public static List<Movies> GetAllMovies()
        {
            return moviesList;
        }
    }
}
