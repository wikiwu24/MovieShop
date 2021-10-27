using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Repositoryinterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieReposiroty : IMovieRepository
    {
        public MovieShopDbContext _dbContext;

        public MovieReposiroty(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Movie> GetMovieById(int id)
        {
            var movie = _dbContext.Movies.Include(m => m.Casts).ThenInclude(m => m.Cast)
                .Include(m => m.Genres).ThenInclude(m => m.Genre).Include(m => m.Trailers)
                .FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }

        

        public async Task<IEnumerable<Movie>> GetTopRevenueMovies()
        {
            // use EF with LINQ to get top30 movies
            // 1. need a dbcontext
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
            
        }
    }
}
