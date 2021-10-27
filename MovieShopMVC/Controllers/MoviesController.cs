using ApplicationCore.Serviceinterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieService _movieService;
       
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails =await _movieService.GetMovieDetails(id);
            return View(movieDetails);
        }
    }
}
