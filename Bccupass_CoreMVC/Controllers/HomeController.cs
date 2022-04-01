﻿using Bccupass_CoreMVC.Models;
using Bccupass_CoreMVC.Models.ViewModel.Activity;
using Bccupass_CoreMVC.Models.ViewModel.ActivityCard;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActivityService _activityCardService;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController(IActivityService activityCardService, IHttpContextAccessor httpContextAccessor)
        {
            _activityCardService = activityCardService;
            _contextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            #region FakeUserCookie

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "1"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            _contextAccessor.HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

            // var userId = int.Parse(User.Identity.Name); -> 抓 cookie 裡的 userId

            #endregion

            var activityCardViewModel = _activityCardService.GetNewestActivity().Select(x => new ActivityCardViewModel.ActivityCardData()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                City = x.City,
                ActivityTheme = x.ActivityTheme,
                IsFree = x.IsFree,
                Favorite = x.Favorite
            }) ;
            var activityCardViewModelSec = _activityCardService.GetChosenActivity().Select(x => new ActivityCardViewModel.ActivityCardData()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                City = x.City,
                ActivityTheme = x.ActivityTheme,
                IsFree = x.IsFree,
                Favorite = x.Favorite
            });


            var result = new ActivityHomeViewModel()
            {
                ActivityList = activityCardViewModel,
                ActivityListSec = activityCardViewModelSec
            };

            return View(result);
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
