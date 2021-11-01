using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Repositoryinterfaces
{
    public interface IMovieRepository:IAsyncRepository<Movie>
    {
        // create methods mased on the business logic

        // Create methods to get top30 revenue movies

        Task<IEnumerable<Movie>> GetTopRevenueMovies();

        Task<Movie> GetMovieById(int id);
    }
}
