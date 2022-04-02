using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.Activity;
using Bccupass_CoreMVC.Models.DTO.CreateActivity;
using Bccupass_CoreMVC.Repositories.Interface;
using Bccupass_CoreMVC.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Bccupass_CoreMVC.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activity;
        private readonly IActivityDraftRepository _activityDraft;

        public ActivityService(IActivityRepository activity, IActivityDraftRepository activityDraft)
        {
            _activity = activity;
            _activityDraft = activityDraft;
        }

        public IEnumerable<ActivityCardDto> GetAllActivity()
        {
            var target = _activity.GetAll<Activity>();
            return ActivityCardDtoResult(target);
        }

        // 活動內頁
        public ActivityDetailDto GetActivityDetail(int activityId)
        {
            return new ActivityDetailDto()
            {
                Activity = GetActivity(activityId),
                Categories = GetCategoriesByActivityId(activityId),
                Tags = GetTagsByActivityId(activityId),
                GuestList = GetGuestsByActivityId(activityId).OrderBy(x => x.Sort),
                QaList = GetQasByActivityId(activityId).OrderBy(x => x.Sort),
                CommentList = GetCommentsByActivityId(activityId),
                AnnounceList = GetAnnouncesByActivityId(activityId).OrderBy(x => x.Sort),
            };
        }

        #region 活動內頁所需資料
        private ActivityDetailDto.ActivityData GetActivity(int activityId)
        {
            var resource = _activity.GetAll<Activity>().First(x => x.ActivityId == activityId);
            return new ActivityDetailDto.ActivityData()
            {
                Id = resource.ActivityId,
                Name = resource.Name,
                Image = resource.Image,
                StartTime = resource.StartTime,
                EndTime = resource.EndTime,
                ActivityRefWebUrl = resource.ActivityRefWebUrl,
                RefWebDescription = resource.RefWebDescription,
                ActivityIntro = resource.ActivityIntro,
                ActivityDescription = resource.ActivityDescription,
                ActivityNotes = resource.ActivityNotes,
                StreamingWeb = resource.StreamingWeb,
                City = resource.City,
                District = resource.District,
                Address = resource.Address,
                AddressDescription = resource.ActivityDescription
            };
        }

        private ActivityDetailDto.CategoriesData GetCategoriesByActivityId(int activityId)
        {
            var activity = _activity.GetAll<Activity>().First(x => x.ActivityId == activityId); ;
            var mainTheme = _activity.GetAll<ActivityTheme>().First(x => x.ActivityThemeId == activity.ActivityPrimaryThemeId);
            var secondTheme = _activity.GetAll<ActivityTheme>().First(x => x.ActivityThemeId == activity.ActivitySecondThemeId);
            var type = _activity.GetAll<ActivityType>().First(x => x.ActivityTypeId == activity.ActivityTypeId);

            return new ActivityDetailDto.CategoriesData()
            {
                MainTheme = mainTheme.ActivityThemeName,
                SecondTheme = secondTheme.ActivityThemeName,
                Type = type.TypeName
            };
        }

        private IEnumerable<ActivityDetailDto.TagData> GetTagsByActivityId(int activityId)
        {
            var res = _activity.GetAll<ActivityTag>().Where(x => x.ActivityId == activityId).Select(x => x.TagId);
            
            return _activity.GetAll<Tag>().Where(x => res.Any(y => y == x.TagId)).Select(x => new ActivityDetailDto.TagData()
            {
                TagId = x.TagId,
                TagName = x.TagName,
            });
        }

        private IEnumerable<ActivityDetailDto.CommentData> GetCommentsByActivityId(int activityId)
        {
            return _activity.GetAll<Comment>().Where(x => x.ActivityId == activityId).Select(x => new ActivityDetailDto.CommentData()
            {
                UserId = x.UserId,
                UserImage = (_activity.GetAll<User>().First(y => y.UserId == x.UserId)).Photo,
                UserName = (_activity.GetAll<User>().First(y => y.UserId == x.UserId)).DisplayName,
                BuildTime = x.BuildTime,
                Comment = x.Comment1,
                StarRank = x.StarRank
            });
        }

        private IEnumerable<ActivityDetailDto.GuestData> GetGuestsByActivityId(int activityId)
        {
            return _activity.GetAll<Guest>().Where(x => x.ActivityId == activityId).Select(x => new ActivityDetailDto.GuestData()
            {
                Id = x.GuestId,
                Name = x.Name,
                Photo = x.Photo,
                Title = x.Title,
                Describe = x.Describe,
                Sort = x.Sort
            });
        }

        private IEnumerable<ActivityDetailDto.QaData> GetQasByActivityId(int activityId)
        {
            return _activity.GetAll<Qa>().Where(x => x.ActivityId == activityId).Select(x => new ActivityDetailDto.QaData()
            {
                Id = x.QaId,
                Question = x.Question,
                Answer = x.Answer,
                Sort = x.Sort
            });
        }

        private IEnumerable<ActivityDetailDto.AnnounceData> GetAnnouncesByActivityId(int activityId)
        {
            return _activity.GetAll<ActivityAnnouncement>().Where(x => x.ActivityId == activityId).Select(x => new ActivityDetailDto.AnnounceData()
            {
                AnnouncementId = x.ActivityAnnouncementId,
                Sort = x.AnnouncementOrder,
                AnnouncementContent = x.ActivityAnnouncementText,
                CreateTime = x.ReleaseTime,
            });
        }

        #endregion


        #region 活動卡牌模組
        public IEnumerable<ActivityCardDto> GetNewestActivity()
        {
            int takeNum = 6;//target抓多少筆
            var target = _activity.GetAll<Activity>().Where(x => x.ActivityState == 1).OrderByDescending(x => x.CreateTime).Take(takeNum);//抓最新的前6個(活動的篩選)

            if (target.Count() != takeNum)
            {
                target = _activity.GetAll<Activity>().Where(x => x.ActivityState == 1).OrderByDescending(x => x.CreateTime);
            }

            return ActivityCardDtoResult(target);
        }

        public IEnumerable<ActivityCardDto> GetChosenActivity()
        {
            int takeNum = 6;//target抓多少筆
            var userFollowing = _activity.GetAll<UserFollowOrganizer>().GroupBy(x => x.OrganizerId).OrderByDescending(x => (x.Select(s => s.UserId).Count()));//追隨數前4名的主辦
            var ordId = userFollowing.Select(group => new { OrganizerId = group.Key }).ToList();

            var target = _activity.GetAll<Activity>().Where(x => x.OrganizerId == ordId[0].OrganizerId).OrderByDescending(x => x.CreateTime).Take(takeNum);
            //var target = _context.GetAll<Activity>().Where(x => x.OrganizerId == ordId[0].OrganizerId || x.OrganizerId == ordId[1].OrganizerId || x.OrganizerId == ordId[2].OrganizerId || x.OrganizerId == ordId[3].OrganizerId).OrderByDescending(x => x.CreateTime).Take(takeNum);

            //var target = _context.GetAll<Activity>();//假資料不夠多測試用
            return ActivityCardDtoResult(target);
        }

        public IEnumerable<ActivityCardDto> GetOrganizerActivity(int organzierId)
        {
            var target = _activity.GetAll<Activity>().Where(x => x.OrganizerId == organzierId && x.ActivityState == 1);

            return ActivityCardDtoResult(target);
        }

        private IEnumerable<ActivityCardDto> ActivityCardDtoResult(IQueryable<Activity> target)
        {
            var theme = _activity.GetAll<ActivityTheme>();//主題
            var ticket = _activity.GetAll<TicketDatail>();//票卷
            var favorite = _activity.GetAll<UserFavorite>();//喜歡

            var result = target.Select(x => new ActivityCardDto()
            {
                Id = x.ActivityId,
                Name = x.Name,
                Image = x.Image,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                City = x.City,
                ActivityTheme = theme.First(q => q.ActivityThemeId == x.ActivityPrimaryThemeId).ActivityThemeName,
                IsFree = ticket.Where(t => t.ActivityId == x.ActivityId).Sum(t => t.Price) == 0,
                Favorite = favorite.Where(f => f.ActivityId == x.ActivityId).Count()
            });

            return result;
        }
        #endregion


        public ActivityBuyTicketDto GetActivityById(int activityId)
        {
            var target = _activity.GetAll<Activity>().FirstOrDefault(x => x.ActivityId == activityId);
            var result = new ActivityBuyTicketDto()
            {
                Id = target.ActivityId,
                Name = target.Name,
                Image = target.Image,
                StartTime = target.StartTime,
                EndTime = target.EndTime,
                City = target.City,
                District = target.District,
                Address = target.Address
            };

            return result;
        }

        
    }
}
