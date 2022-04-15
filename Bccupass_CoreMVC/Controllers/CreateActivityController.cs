using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.Activity;
using Bccupass_CoreMVC.Models.DTO.CreateActivity;
using Bccupass_CoreMVC.Models.ViewModel.Activity;
using Bccupass_CoreMVC.Models.ViewModel.CreateActivity;
using Bccupass_CoreMVC.Repositories;
using Bccupass_CoreMVC.Services;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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
                    GuestName = null,
                    GuestImg = "https://static.accupass.com/frontend/image/eventedit/organizer/organizer_avatar_placeholder.svg",
                    GuestJob = "",
                    GuestCompany = "",
                    GuestInfo = "",
                    GuestWeb = "",
                    ItemId = 0
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

        [HttpPost]
        public IActionResult FetchGuest([FromBody] List<CreateGuestViewModel> request)
        {
            var inputDto = new CreateGuestDto()
            {
                ActivityDraftId = request[0].ActivityDraftId,
                ActivityGuests = JsonConvert.SerializeObject(request)
            };
            _activityDraftservice.EditActivityGuest(inputDto);

            return RedirectToAction("Guest", new { id = request[0].ActivityDraftId });
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
                    Sort = 0,
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
                ActivityQA = request.QuestDataJson
            };
            _activityDraftservice.EditActivityQA(inputDto);

            return RedirectToAction("Ticket", new { id = request.ActivityDraftId });
        }

        [HttpPost]
        public IActionResult FetchQuestion([FromBody] List<CreateQAViewModel> request)
        {
            var inputDto = new CreateQADto()
            {
                ActivityDraftId = request[0].ActivityDraftId,
                ActivityQA = JsonConvert.SerializeObject(request)
            };
            _activityDraftservice.EditActivityQA(inputDto);

            return RedirectToAction("Question", new { id = request[0].ActivityDraftId });
        }
        #endregion


        #region 票卷設定
        public IActionResult Ticket(int id)
        {

            var inputDto = _activityDraftservice.GetActivityDraftTicket(id);

            List<CreateTicketViewModel> resultVM = new List<CreateTicketViewModel>();
            if (inputDto.ActivityTicket == null)
            {
                resultVM.Add(new CreateTicketViewModel()
                {
                    ActivityDraftId = id,
                    TicketName = "",
                    Quantity = 0,
                    Price = 0,
                    Description = "",
                    SellStartTime = "20200102",
                    SellStartHour = "1",
                    SellStartMin = "0",
                    SellEndTime = "20200102",
                    SellEndHour = "1",
                    SellEndMin = "0",
                    CheckStartTime = "20200102",
                    CheckStartHour = "1",
                    CheckStartMin = "0",
                    CheckEndTime = "20200102",
                    CheckEndHour = "1",
                    CheckEndMin = "0",
                    IsSell = false,
                    IsCheckEqualActivityTime = false,
                    IsFree = true,
                    BuyLimitLeast = 0,
                    BuyLimitMost = 0,
                    TicketGroup = "",
                    Sort = 0
                });
            }
            else
            {
                var json = JsonConvert.DeserializeObject<CreateTicketViewModel[]>(inputDto.ActivityTicket);

                resultVM = json.ToList();
            }

            ViewData["ActivityDraftId"] = id;
            return View(resultVM);
        }
        [HttpPost]
        public IActionResult Ticket(TicketInputViewModel request)
        {
            var inputDto = new CreateTicketDto()
            {
                ActivityDraftId = request.ActivityDraftId,
                ActivityTicket = request.TicketDataJson
            };
            _activityDraftservice.EditActivityTicket(inputDto);

            return RedirectToAction("TicketGroup", new { id = request.ActivityDraftId });
        }


        [HttpPost]
        public IActionResult FetchTicket([FromBody] List<CreateTicketViewModel> request)
        {
            var inputDto = new CreateTicketDto()
            {
                ActivityDraftId = request[0].ActivityDraftId,
                ActivityTicket = JsonConvert.SerializeObject(request)
            };
            _activityDraftservice.EditActivityTicket(inputDto);

            return new JsonResult(request);
        }

        #endregion


        #region 票卷分組
        public IActionResult TicketGroup(int id)
        {

            var inputDto = _activityDraftservice.GetActivityDraftTicket(id);

            List<CreateTicketViewModel> resultVM = new List<CreateTicketViewModel>();
            if (inputDto.ActivityTicket == null)
            {
                return RedirectToAction("Ticket",new { id = id });
            }
            else
            {
                var json = JsonConvert.DeserializeObject<CreateTicketViewModel[]>(inputDto.ActivityTicket);

                resultVM = json.ToList();
            }

            ViewData["ActivityDraftId"] = id;
            return View(resultVM);
        }

        [HttpPost]
        public IActionResult FetchTicketGroup([FromBody] List<CreateTicketViewModel> request)
        {
            var inputDto = new CreateTicketDto()
            {
                ActivityDraftId = request[0].ActivityDraftId,
                ActivityTicket = JsonConvert.SerializeObject(request)
            };
            _activityDraftservice.EditActivityTicket(inputDto);

            return RedirectToAction("DemoDraftJson", new { id = request[0].ActivityDraftId });
        }

        #endregion

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
            var _themeList = _activityDraftservice.GetAllActivityThemeForCategory().Select(x => new ThemeAndTypeDataVM.CardData()
            {
                Id = x.Id,
                Name = x.Title,
                Img = x.Icon,
            });
            var _typeList = _activityDraftservice.GetAllActivityTypeForCategory().Select(x => new ThemeAndTypeDataVM.CardData()
            {
                Id = x.Id,
                Name = x.Title,
                Img = x.Icon,
            });
            CreateThemeCategoryVM JsonData;
            ThemeAndTypeDataVM ShowData;
            PackageCatgoryVM packageCatgoryVM;
            if (inputDto.ThemeCategory == null)
            {
                JsonData = new CreateThemeCategoryVM()
                {
                    ActivityDraftId = inputDto.ActivityDraftId,
                    ActivityPrimaryThemeId = 0,
                    ActivitySecondThemeId = 0,
                    ActivityTypeId = 0,
                };
                ShowData = new ThemeAndTypeDataVM()
                {
                    Theme = _themeList,
                    Type = _typeList
                };
                packageCatgoryVM = new PackageCatgoryVM()
                {
                    JSONVM = JsonData,
                    DataVM = ShowData
                };
            }
            else
            {
                ShowData = new ThemeAndTypeDataVM()
                {
                    Theme = _themeList,
                    Type = _typeList
                };
                packageCatgoryVM = new PackageCatgoryVM()
                {
                    JSONVM = JsonConvert.DeserializeObject<CreateThemeCategoryVM>(inputDto.ThemeCategory),
                    DataVM = ShowData
                };
            }

            ViewData["ActivityDraftId"] = id;
            return View(packageCatgoryVM);
        }
        [HttpPost]
        public IActionResult Category([FromBody] CreateThemeCategoryVM request)
        {
            var inputDto = new CreateThemeCategoryDto()
            {
                ActivityDraftId = request.ActivityDraftId,
                ThemeCategory = JsonConvert.SerializeObject(request)
            };
            _activityDraftservice.EditActivityThemeCat(inputDto);
            return RedirectToAction("Info", new { id = request.ActivityDraftId });
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
            var inputDto = _activityDraftservice.GetActivityInfo(id);
            CreateActivityInfoVM resultVM;
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


        public IActionResult DemoDraftJson(int id)
        {
            var target = _activityDraftservice.GetAllActivityDraft(id);

            var result = new DemoActivityDraftViewModel()
            {
                ActivityDraftId = target.ActivityDraftId,
                ThemeCategory = target.ThemeCategory,
                ActivityInfo = target.ActivityInfo,
                ActivityContent = target.ActivityContent,
                ActivityGuests = target.ActivityGuests,
                ActivityQa = target.ActivityQa,
                ActivityTicket = target.ActivityTicket

            };
            ViewData["ActivityDraftId"] = id;
            return View(result);
        }
    }
}
