﻿using Bccupass_CoreMVC.Common.Enums;
using Bccupass_CoreMVC.Common.Helpers;
using Bccupass_CoreMVC.Models.DTO.Activity;
using Bccupass_CoreMVC.Models.ViewModel;
using Bccupass_CoreMVC.Models.ViewModel.Activity;
using Bccupass_CoreMVC.Models.ViewModel.Activity.Data;
using Bccupass_CoreMVC.Models.ViewModel.ActivityCard;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bccupass_CoreMVC.Models.ViewModel.Activity.SearchKeysViewModel;

namespace Bccupass_CoreMVC.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly IOrganizerService _organizerService;
        private IEnumerable<ActivityCardDto> activityList;
        public ActivityController(IActivityService activityService, IOrganizerService organizerService)
        {
            _activityService = activityService;
            _organizerService = organizerService;
        }

        [Route("Activity/Index", Name = "ActivityFilter")]
        public IActionResult Index(
            int page = 1,
            string activityStateByTime = "0",
            string sortOrder = "0"
        )
        {
            var pageObj = new Pagination
            {
                ActivePage = page,
                ActionUrl = $"activityStateByTime={activityStateByTime}&sortOrder={sortOrder}",
            };
            var allActivity = new ActivityCardGroupByTimeDto();
            if (TempData["SearchResultCardList"] != null)
            {
                string json = (string)TempData["SearchResultCardList"];
                var searchInput = JsonConvert.DeserializeObject<SearchKeysDataModel>(json);
                var inputDto = new SearchKeysInputDto
                {
                    ThemesInput = searchInput.ThemesList,
                    TypesInput = searchInput.TypesList,
                    StartTimeInput = (StartTime)searchInput.StartTimeEnumValue,
                    TicketPriceInput = (TicketPrice)searchInput.TicketPriceEnumValue,
                };

                var outputDto = _activityService.ActivityFilter(inputDto);
                allActivity = outputDto.SearchResultCards;

                TempData.Keep();
            }
            else
            {
                allActivity = _activityService.GetAllActivityGroupByTime();
            }
            var res = new ActivityIndexViewModel();

            // 依活動狀態(進行中、尚未開始、已結束)篩選
            switch (int.Parse(activityStateByTime))
            {
                case (int)ActivityStateByTime.NotStart:
                    pageObj.Total = allActivity.NotStart.Count();
                    activityList = allActivity.NotStart.Skip(pageObj.StartRow).Take(pageObj.PageRows);
                    res.ActivityStateByTime = (int)ActivityStateByTime.NotStart;
                    break;
                case (int)ActivityStateByTime.End:
                    pageObj.Total = allActivity.End.Count();
                    activityList = allActivity.End.Skip(pageObj.StartRow).Take(pageObj.PageRows);
                    res.ActivityStateByTime = (int)ActivityStateByTime.End;
                    break;
                default:
                    pageObj.Total = allActivity.InProgress.Count();
                    activityList = allActivity.InProgress.Skip(pageObj.StartRow).Take(pageObj.PageRows);
                    res.ActivityStateByTime = (int)ActivityStateByTime.Inprogress;
                    break;
            }

            // 排序(開始時間、票價、收藏人數)
            switch (int.Parse(sortOrder))
            {
                case (int)ActivitySortOrder.Price:
                    activityList = activityList.OrderByDescending(x => x.IsFree).ThenBy(x => x.StartTime);
                    break;
                case (int)ActivitySortOrder.LikeCount:
                    activityList = activityList.OrderBy(x => x.Favorite);
                    break;
                default:
                    activityList = activityList.OrderBy(x => x.StartTime);
                    break;
            }

            var activityListByTime = activityList.Select(x => new ActivityCardViewModel.ActivityCardData()
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

            res.ActivityList = activityListByTime;
            res.pageInfo = pageObj;
            res.ActivitySortOrder = int.Parse(sortOrder);

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

        [HttpPost]
        public IActionResult FetchSearch([FromBody] SearchKeysDataModel request)
        {
            TempData["SearchResultCardList"] = JsonConvert.SerializeObject(request);

            return new JsonResult(new { isSuccess = true });
        }

        public IActionResult FetchSearchResult()
        {
            return RedirectToAction("Index");
        }

    }
}
