using Bccupass_CoreMVC.Models;
using Bccupass_CoreMVC.Models.ViewModel.ActivityCard;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActivityService _activityCardService;

        public HomeController(IActivityService activityCardService)
        {
            _activityCardService = activityCardService;
        }

        public IActionResult Index()
        {
            var activityCardViewModel = _activityCardService.GetNewestActivity().Select(x => new ActivityCardViewModel.ActivityData()
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
            var activityCardViewModelSec = _activityCardService.GetChosenActivity().Select(x => new ActivityCardViewModel.ActivityData()
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


            var result = new ActivityCardViewModel()
            {
                ActivityList = activityCardViewModel,
                ActivityListSec = activityCardViewModelSec
            };

            //ViewData["Chosen"] = activityCardViewModelSec;
            //ViewData["Newest"] = activityCardViewModel;

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
