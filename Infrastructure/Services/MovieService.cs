using ApplicationCore.Models;
using ApplicationCore.Repositoryinterfaces;
using ApplicationCore.Serviceinterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);
            if(movie == null)
            {
                throw new Exception($"No Movie Found Fro Id {id}");
            }
            var movieDetails = new MovieDetailResponseModel
            { 
                Id = movie.Id,
                Budget = movie.Budget,
                Overview = movie.Overview,
                Price = movie.Price,
                PosterUrl = movie.PosterUrl,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                Rating = movie.Rating,
                Tagline = movie.Tagline,
                Title= movie.Title,
                RunTime = movie.RunTime,
                BackdropUrl = movie.BackdropUrl,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl 
            };
            foreach (var t in movie.Trailers)
            {
                movieDetails.Trailers.Add(new TrailerResponseModel 
                { 
                    Id = t.Id,
                    Name = t.Name,
                    TrailerUrl = t.TrailerUrl,
                    MovieId = t.MovieId
                });
            }
            foreach (var genre in movie.Genres)
            {
                movieDetails.Genres.Add(new GenreModel
                {
                    Id = genre.GenreId, 
                    Name = genre.Genre.Name
                });
            }
            foreach (var cast in movie.Casts)
            {
                movieDetails.Casts.Add(
                    new CastResponseModel
                    {
                        Id = cast.CastId,
                        Character = cast.Character,
                        Name = cast.Cast.Name,
                        ProfilePath = cast.Cast.ProfilePath
                    }
                    );
            }
            return movieDetails;
            
        }

        public async Task<List<MovieCardResponseModel>> GetTop30RevenueMovies()
        {
            // calling movierepository with DI based on IMovieRepository
            var movies = await _movieRepository.GetTopRevenueMovies();

            // convert movies to moviecard
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title

                });
            }
            return movieCards;
        }

    }
}
 