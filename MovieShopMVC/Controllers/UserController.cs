using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICurrentUserService _currentUserService;
        public UserController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;

        }


        // all the action methods in User Controller should work only when user is Authenticated (login success)
        
        [HttpPost]
        [Authorize]
            //Authorize filter check the users isAuthenticated
            // this will not work if you remove the middleware registration
        public async Task<IActionResult> Purchase()
        {
            var userId = _currentUserService.UserId;

                // purchase a movie when user clicks on Buy button on Movie Details Page
                return View();
        }

            [HttpPost]
            public async Task<IActionResult> Favorite()
            {
                // favorite a movie when user clicks on Favorite Button on Movie Details Page
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Review()
            {
                // add a new review done by the user for that movie
                return View();
            }

            [HttpGet]
            public async Task<IActionResult> Purchases(int id)
            {
                // get all the movies purchased by user => List<MovieCard> 
                return View();
            }

            [HttpGet]
            public async Task<IActionResult> Favorites(int id)
            {
                // get all movies favorited by that user
                return View();
            }

            public async Task<IActionResult> Reviews(int id)
            {
                // get all the reviews done by this user
                return View();
            }
    }


    
}
