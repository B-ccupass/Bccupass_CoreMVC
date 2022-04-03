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

            var resultVM = new CreateDesViewModel();
            if (inputDto.ActivityContent == null)
            {
                resultVM = new CreateDesViewModel()
                {
                    activityDraftId = inputDto.activityDraftId,
                    ActivityInfo = "",
                    ActivityContent = "",
                    ActivityNotice = ""
                };
            }
            else
            {
                var json = (JObject)JsonConvert.DeserializeObject(inputDto.ActivityContent);
                resultVM = new CreateDesViewModel()
                {
                    activityDraftId = inputDto.activityDraftId,
                    ActivityInfo = json["ActivityInfo"].Value<string>(),
                    ActivityContent = json["ActivityContent"].Value<string>(),
                    ActivityNotice = json["ActivityNotice"].Value<string>()
                };
            }

            

            return View(resultVM);
        }
        [HttpPost]
        public IActionResult Description(int activityDraftId, CreateDesViewModel request)
        {
            var inputDto = new CreateDesDto()
            {
                activityDraftId = activityDraftId,
                ActivityContent = JsonConvert.SerializeObject(request),
            };
            _activityDraftservice.EditActivityDes(inputDto);

            return RedirectToAction("Description");
        }
    }
}
