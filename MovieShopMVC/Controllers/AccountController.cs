using ApplicationCore.Models;
using ApplicationCore.Serviceinterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel requestModel)
        {
            var user = await _userService.RegisterUser(requestModel);
            return View();
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel requestModel)
        {
            var user = await _userService.LoginUser(requestModel);
            if(user == null)
            {
                return View();
            }

            return LocalRedirect("~/");
        }


    }
}
