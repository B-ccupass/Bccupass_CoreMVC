using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.Activity;
using Bccupass_CoreMVC.Models.DTO.CreateActivity;
using Bccupass_CoreMVC.Models.ViewModel.Activity;
using Bccupass_CoreMVC.Models.ViewModel.CreateActivity;
using Bccupass_CoreMVC.Services;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Bccupass_CoreMVC.Controllers
{
    public class CreateActivityController : Controller
    {
        private readonly IActivityDraftService _activityDraftservice;
        private readonly IOrganizerService _organizerService;
        public CreateActivityController(IActivityDraftService service, IOrganizerService organizerService)
        {
            _activityDraftservice = service;
            _organizerService = organizerService;
        }

        #region 活動內容Controller
        [HttpGet]
        public IActionResult Description(int id)
        {
            var inputDto = _activityDraftservice.GetActivityDraftDes(id);

            var resultVM = new CreateDesViewModel();
            if (inputDto.ActivityContent == null)
            {
                resultVM = new CreateDesViewModel()
                {
                    ActivityDraftId = inputDto.ActivityDraftId,
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
                    ActivityDraftId = inputDto.ActivityDraftId,
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
                ActivityDraftId = activityDraftId,
                ActivityContent = JsonConvert.SerializeObject(request),
            };
            _activityDraftservice.EditActivityDes(inputDto);

            return RedirectToAction("Guest", new { id = activityDraftId });
        }
        #endregion


        #region 新增嘉賓Controller
        [HttpGet]
        public IActionResult Guest(int id)
        {
            var inputDto = _activityDraftservice.GetActivityDraftGuest(id);

            List<CreateGuestViewModel> resultVM = new List<CreateGuestViewModel>();
            if (inputDto.ActivityGuests == null)
            {
                resultVM.Add(new CreateGuestViewModel()
                {
                    ActivityDraftId = inputDto.ActivityDraftId,
                    GuestName = "",
                    GuestImg = "https://static.accupass.com/frontend/image/eventedit/organizer/organizer_avatar_placeholder.svg",
                    GuestJob = "",
                    GuestCompany = "",
                    GuestInfo = "",
                    GuestWeb = ""
                });
            }
            else
            {
                var json = JsonConvert.DeserializeObject<CreateGuestViewModel[]>(inputDto.ActivityGuests);

                resultVM = json.ToList();
            }

            ViewData["ActivityDraftId"] = id;
            return View(resultVM);
        }
        [HttpPost]
        public IActionResult Guest(GuestInputViewModel request)
        {
            var inputDto = new CreateGuestDto()
            {
                ActivityDraftId = request.ActivityDraftId,
                ActivityGuests = request.GuestDataJson
            };
            _activityDraftservice.EditActivityGuest(inputDto);

            return RedirectToAction("Question", new { id = request.ActivityDraftId });
        }
        #endregion


        #region 活動問答Controller
        [HttpGet]
        public IActionResult Question(int id)
        {
            var inputDto = _activityDraftservice.GetActivityDraftQA(id);

            List<CreateQAViewModel> resultVM = new List<CreateQAViewModel>();
            if (inputDto.ActivityQA == null)
            {
                resultVM.Add(new CreateQAViewModel()
                {
                    ActivityDraftId = inputDto.ActivityDraftId,
                    ActivityQuest = "這裡填上您的問題",
                    ActivityAnswer = "這裡填上您的回答",
                    Sort = 1,
                });
            }
            else
            {
                var json = JsonConvert.DeserializeObject<CreateQAViewModel[]>(inputDto.ActivityQA);

                resultVM = json.ToList();
            }

            ViewData["ActivityDraftId"] = id;
            return View(resultVM);
        }
        [HttpPost]
        public IActionResult Question(QAInputViewModel request)
        {
            var inputDto = new CreateQADto()
            {
                ActivityDraftId = request.ActivityDraftId,
                ActivityQA = request.GuestDataJson
            };
            _activityDraftservice.EditActivityQA(inputDto);

            return RedirectToAction("Question", new { id = request.ActivityDraftId });
        }
        #endregion

        public IActionResult Ticket()
        {
            return View();
        }

        public IActionResult Policy(int id)
        {
            var target = _organizerService.GetOrganizer(id);
            var result = new ActivityCategoryCardViewModel()
            {
                OrganizerId = target.OrganizerId,
            };
            return View(result);
        }
        [HttpGet]
        public IActionResult Category(int id)
        {
            var inputDto = _activityDraftservice.GetActivityThemeCat(id);
            var _themeList = _activityDraftservice.GetAllActivityThemeForCategory().Select(x => new CreateThemeCategoryVM.CardData()
            {
                Id = x.Id,
                Title = x.Title,
                Icon = x.Icon,
            });
            var _typeList = _activityDraftservice.GetAllActivityTypeForCategory().Select(x => new CreateThemeCategoryVM.CardData()
            {
                Id = x.Id,
                Title = x.Title,
                Icon = x.Icon,
            });
            var _DataThemeCategory = new CreateThemeCategoryVM()
            {
                Theme = _themeList,
                Type = _typeList,
            };
            List<CreateThemeCategoryVM> _resultVM = new();
            if (inputDto.ThemeCategory == null)
            {
                _resultVM.Add(new CreateThemeCategoryVM()
                {
                    ActivityDraftId = inputDto.ActivityDraftId,
                    ActivityPrimaryThemeId = 0,
                    ActivitySecondThemeId = 0,
                    ActivityTypeId = 0,
                    Theme = _themeList,
                    Type = _typeList,
                });
            }
            else
            {
                var json = JsonConvert.DeserializeObject<CreateThemeCategoryVM[]>(inputDto.ThemeCategory);

                _resultVM = json.ToList();
            }
            var result = new CreateThemeCategoryVM()
            {
                DataThemeCategory = _DataThemeCategory,
                DataJSON = _resultVM,
            };

            ViewData["ActivityDraftId"] = id;
            return View(result);
        }
        [HttpPost]
        public IActionResult Category(ThemeCategoryInputVM request)
        {

            return View();
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
            var inputDto = _activityDraftservice.GetActivityInfo(id);
            CreateActivityInfoVM resultVM = new();
            if (inputDto.ActivityInfo == null)
            {
                resultVM = new CreateActivityInfoVM()
                {
                    ActivityDraftId = inputDto.ActivityDraftId,
                    Image = "https://i.imgur.com/GSjcP32.png",
                    ActivityName = "",
                    StartTime = default,
                    EndTime = default,
                    ActivityRefWebUrl = "",
                    RefWebDescription = "",
                    City = "",
                    District = "",
                    CitySelectIndex = 0,
                    DistrictSelectIndex = 0,
                    Address = "",
                    AddressDetail = "",
                    StreamingWeb = ""
                };
            }
            else
            {
                var json = JsonConvert.DeserializeObject<CreateActivityInfoVM>(inputDto.ActivityInfo);

                resultVM = json;
            }
            ViewData["ActivityDraftId"] = id;
            return View(resultVM);
        }
        [HttpPost]
        public IActionResult Info([FromBody] CreateActivityInfoVM request)
        {
            var inputDto = new CreateInfoDto()
            {
                ActivityDraftId = request.ActivityDraftId,
                ActivityInfo = JsonConvert.SerializeObject(request)

            };
            _activityDraftservice.EditActivityInfo(inputDto);

            return RedirectToAction("Info", new { id = request.ActivityDraftId });

        }
    }
}
