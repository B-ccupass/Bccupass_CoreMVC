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
        private readonly IActivityCardService _activityCardService;

        public HomeController(IActivityCardService activityCardService)
        {
            _activityCardService = activityCardService;
        }

        public IActionResult Home()
        {
            var activityCardViewModel = _activityCardService.GetLatestActivity().Select(x => new ActivityCardViewModel.ActivityData()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                City = x.City,
                ActivityPrimaryThemeId = x.ActivityPrimaryThemeId

            });
            var result = new ActivityCardViewModel()
            {
                ActivityList = activityCardViewModel
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
