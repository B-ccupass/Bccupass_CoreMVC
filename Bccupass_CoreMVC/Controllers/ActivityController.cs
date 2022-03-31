using Bccupass_CoreMVC.Models.ViewModel;
using Bccupass_CoreMVC.Models.ViewModel.Activity;
using Bccupass_CoreMVC.Models.ViewModel.ActivityCard;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bccupass_CoreMVC.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly IOrganizerService _organizerService;
        private static int total;
        public ActivityController(IActivityService activityService, IOrganizerService organizerService)
        {
            _activityService = activityService;
            _organizerService = organizerService;
            if(total == 0)
            {
                total = _activityService.GetAllActivity().Count();
            }
        }
        public IActionResult Index(int id=1)
        {

            int activePage = id; // 目前在第幾頁
            int pageRows = 3; // 一頁幾筆資料

            // 計算頁數
            int pages = 0;
            if(total % pageRows == 0)
            {
                pages = total / pageRows;
            }
            else
            {
                pages = (total / pageRows) + 1;
            }

            int startRow = (activePage - 1) * pageRows; // 起始紀錄 Index

            var activityList = _activityService.GetAllActivity().Skip(startRow).Take(pageRows).Select(x => new ActivityCardViewModel.ActivityCardData()
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

            var res = new ActivityIndexViewModel()
            {
                ActivityList = activityList
            };

            ViewData["ActivePage"] = id;
            ViewData["Pages"] = pages;

            return View(res);
        }
        public IActionResult Detail(int id)
        {
            var activityDetailDto = _activityService.GetActivityDetail(id);
            var organizer = _organizerService.GetOrganizerByActivityId(id);
            var activityDetailVM = new ActivityDetailViewModel()
            {
                Activity = new ActivityDetailViewModel.ActivityData()
                {
                    Id = activityDetailDto.Activity.Id,
                    Name = activityDetailDto.Activity.Name,
                    Image = activityDetailDto.Activity.Image,
                    StartTime = activityDetailDto.Activity.StartTime,
                    EndTime = activityDetailDto.Activity.EndTime,
                    ActivityRefWebUrl = activityDetailDto.Activity.ActivityRefWebUrl,
                    RefWebDescription = activityDetailDto.Activity.RefWebDescription,
                    ActivityIntro = activityDetailDto.Activity.ActivityIntro,
                    ActivityDescription = activityDetailDto.Activity.ActivityDescription,
                    ActivityNotes = activityDetailDto.Activity.ActivityNotes,
                    StreamingWeb = activityDetailDto.Activity.StreamingWeb,
                    City = activityDetailDto.Activity.City,
                    District = activityDetailDto.Activity.District,
                    Address = activityDetailDto.Activity.Address,
                    AddressDescription = activityDetailDto.Activity.AddressDescription
                },
                Organizer = new ActivityDetailViewModel.OrganizerData()
                {
                    OrganizerId = organizer.OrganizerId,
                    Name = organizer.Name,
                    Image = organizer.Image,
                    Description = organizer.Description,
                    Email = organizer.Email
                },
                Categories = new ActivityDetailViewModel.CategoriesData()
                {
                    MainTheme = activityDetailDto.Categories.MainTheme,
                    SecondTheme = activityDetailDto.Categories.SecondTheme,
                    Type = activityDetailDto.Categories.Type
                },
                Tags = activityDetailDto.Tags.Select(x => new ActivityDetailViewModel.TagData()
                {
                    TagId = x.TagId,
                    TagName = x.TagName,
                }),
                GuestList = activityDetailDto.GuestList.Select(x => new ActivityDetailViewModel.GuestData()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Photo = x.Photo,
                    Title = x.Title,
                    Describe = x.Describe,
                }),
                CommentList = activityDetailDto.CommentList.Select(x => new ActivityDetailViewModel.CommentData()
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    UserImage = x.UserImage,
                    BuildTime = x.BuildTime,
                    Comment = x.Comment,
                    StarRank = x.StarRank,
                }),
                QaList = activityDetailDto.QaList.Select(x => new ActivityDetailViewModel.QaData()
                {
                    Id = x.Id,
                    Question = x.Question,
                    Answer = x.Answer,
                }),
                AnnounceList = activityDetailDto.AnnounceList.Select(x => new ActivityDetailViewModel.AnnounceData()
                {
                    AnnouncementId = x.AnnouncementId,
                    AnnouncementContent = x.AnnouncementContent,
                    CreateTime = x.CreateTime,
                })
            };
            return View(activityDetailVM);
        }
    }
}
