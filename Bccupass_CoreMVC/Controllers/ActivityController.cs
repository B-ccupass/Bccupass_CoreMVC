using Bccupass_CoreMVC.Models.ViewModel;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bccupass_CoreMVC.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            var activityDetailDto = _activityService.GetActivityDetail(id);
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
                })
            };
            return View(activityDetailVM);
        }
    }
}
