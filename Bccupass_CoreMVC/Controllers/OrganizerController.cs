using Bccupass_CoreMVC.Models.ViewModel.Organizer;
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

        public OrganizerController(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
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
