using Bccupass_CoreMVC.Models.ViewModel.ActivityCard;
using Bccupass_CoreMVC.Models.ViewModel.Organizer;
using Bccupass_CoreMVC.Models.DTO.Activity;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Controllers
{
    public class OrganizerController : Controller
    {
        private readonly IOrganizerService _organizerService;
        private readonly IActivityService _activityService;


        public OrganizerController(IOrganizerService organizerService,IActivityService activityService)
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

            var result = new OrganizerAboutViewModel()
            {
                organizer = org
            };

            return View(result);
        }
    }
}
