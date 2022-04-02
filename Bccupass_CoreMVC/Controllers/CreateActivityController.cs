using Bccupass_CoreMVC.Models.DTO.CreateActivity;
using Bccupass_CoreMVC.Models.ViewModel.CreateActivity;
using Microsoft.AspNetCore.Mvc;

namespace Bccupass_CoreMVC.Controllers
{
    public class CreateActivityController : Controller
    {
        [HttpGet]
        public IActionResult Description(int? activityDraftId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Description(int activityDraftId, CreateDesViewModel request)
        {
            var inputDto = new CreateDesDto()
            {
                activityDraftId = activityDraftId,
                ActivityContent = Newtonsoft.Json.JsonConvert.DeserializeObject<CreateDesViewModel>(request.ActivityContent).ToString()
            };

            return View();
        }
    }
}
