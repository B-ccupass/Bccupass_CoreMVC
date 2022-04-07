using Bccupass_CoreMVC.Models.ViewModel.ActivityCard;
using Bccupass_CoreMVC.Models.ViewModel.Organizer;
using Bccupass_CoreMVC.Models.DTO.Activity;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bccupass_CoreMVC.Models.DTO.Organizer;
using Bccupass_CoreMVC.Models.ViewModel;
using Bccupass_CoreMVC.Models.ViewModel.Activity;

namespace Bccupass_CoreMVC.Controllers
{
    public class OrganizerController : Controller
    {
        private readonly IOrganizerService _organizerService;
        private readonly IActivityService _activityService;
        //private readonly IActivityService _activityCardService;


        public OrganizerController(IOrganizerService organizerService, IActivityService activityService)
        {
            _organizerService = organizerService;
            _activityService = activityService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About(int id)
        {
            var organizerDto = _organizerService.GetOrganizer(id);
            var org = new OrganizerAboutViewModel.OrganizerData()
            {
                OrganizerId = organizerDto.OrganizerId,
                Name = organizerDto.Name,
                Image = organizerDto.Image,
                Banner = organizerDto.Banner,
                Email = organizerDto.Email,
                OfficialWebsite = organizerDto.OfficialWebsite,
                Description = organizerDto.Description,
                FacebookWebsite = organizerDto.FacebookWebsite
            };
            var inProgress = _activityService.GetOrganizerActivity(id).InProgress.Select(x => new ActivityCardViewModel.ActivityCardData()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                City = x.City,
                ActivityTheme = x.ActivityTheme,
                IsFree = x.IsFree,
                Favorite = x.Favorite,
            });
            var notStart = _activityService.GetOrganizerActivity(id).NotStart.Select(x => new ActivityCardViewModel.ActivityCardData()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                City = x.City,
                ActivityTheme = x.ActivityTheme,
                IsFree = x.IsFree,
                Favorite = x.Favorite,
            });
            var end = _activityService.GetOrganizerActivity(id).End.Select(x => new ActivityCardViewModel.ActivityCardData()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                City = x.City,
                ActivityTheme = x.ActivityTheme,
                IsFree = x.IsFree,
                Favorite = x.Favorite,
                //State = x.State
            });

            var result = new OrganizerAboutViewModel()
            {
                ActivityInProgressList = inProgress,
                ActivityNotStartList = notStart,
                ActivityEndList = end,
                organizer = org
            };

            return View(result);
        }

        [HttpGet]
        public IActionResult CreateOrganizer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateOrganizer(CreateOrganizerDto request)
        {
            _organizerService.CreateOrganizer(request);
            return RedirectToAction(nameof(CreateOrganizer));
        }
    }
}
