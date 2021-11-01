using ApplicationCore.Models;
using ApplicationCore.Serviceinterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userService.RegisterUser(requestModel);
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
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
            // create the cookie and store some information in the cookies
            // we need to tell application that we're gonna use cookie based authentication
            // information: name of the cookie, how long the cookie is valid, where to re-direct when cookie expired

            // create a claim with the information you want to show on the bar after the user login
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToShortDateString()),
                new Claim("FullName", user.FirstName +" "+ user.LastName)
            };
            // Identity
            // AuthenticationScheme goes to the start up where we tell it to create the cookies
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            // print out our card
            // creating a cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            // manully create cookies:HttpContext.Response.Cookies.Append("name of the cookie", value
            return LocalRedirect("~/");

        }

        public async Task<IActionResult> Logout()
        {
            // invalidate the cookies and re-direct to login
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }


    }
}
