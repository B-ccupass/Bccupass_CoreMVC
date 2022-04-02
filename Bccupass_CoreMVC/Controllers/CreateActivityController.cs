using Bccupass_CoreMVC.Models.DTO.CreateActivity;
using Bccupass_CoreMVC.Models.ViewModel.CreateActivity;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace Bccupass_CoreMVC.Controllers
{
    public class CreateActivityController : Controller
    {
        private readonly IActivityDraftService _activityDraftservice;
        public CreateActivityController(IActivityDraftService service)
        {
            _activityDraftservice = service;
        }

        [HttpGet]
        public IActionResult Description(int id)
        {
            var inputDto = _activityDraftservice.GetActivityDraftDes(id);
            var json = (JObject)JsonConvert.DeserializeObject(inputDto.ActivityContent);
            var resultVM = new CreateDesViewModel()
            {
                activityDraftId = inputDto.activityDraftId,
                ActivityInfo = json["ActivityInfo"].Value<string>(),
                ActivityContent = json["ActivityContent"].Value<string>(),
                ActivityNotice = json["ActivityNotice"].Value<string>()
            };

            return View(resultVM);
        }
        [HttpPost]
        public IActionResult Description(int activityDraftId, string request)
        {
            var inputDto = new CreateDesDto()
            {
                activityDraftId = activityDraftId,
                ActivityContent = request
            };
            _activityDraftservice.EditActivityDes(inputDto);

            return View();
        }
    }
}
