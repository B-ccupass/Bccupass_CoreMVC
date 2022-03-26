using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.Activity;
using Bccupass_CoreMVC.Repositories.Interface;
using Bccupass_CoreMVC.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Bccupass_CoreMVC.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _context;
        public ActivityService(IActivityRepository context)
        {
            _context = context;
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
                CommentList = GetCommentsByActivityId(activityId)
            };
        }

        #region 活動內頁所需資料
        private ActivityDetailDto.ActivityData GetActivity(int activityId)
        {
            var resource = _context.GetAll<Activity>().First(x => x.ActivityId == activityId);
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
                //City = resource.City,
                //District = resource.District,
                Address = resource.Address,
                AddressDescription = resource.AddressDescription
            };
        }

        private ActivityDetailDto.CategoriesData GetCategoriesByActivityId(int activityId)
        {
            var activity = _context.GetAll<Activity>().First(x => x.ActivityId == activityId); ;
            var mainTheme = _context.GetAll<ActivityTheme>().First(x => x.ActivityThemeId == activity.ActivityPrimaryThemeId);
            var secondTheme = _context.GetAll<ActivityTheme>().First(x => x.ActivityThemeId == activity.ActivitySecondThemeId);
            var type = _context.GetAll<ActivityType>().First(x => x.ActivityTypeId == activity.ActivityTypeId);

            return new ActivityDetailDto.CategoriesData()
            {
                MainTheme = mainTheme.ActivityThemeName,
                SecondTheme = secondTheme.ActivityThemeName,
                Type = type.TypeName
            };
        }

        private IEnumerable<ActivityDetailDto.TagData> GetTagsByActivityId(int activityId)
        {
            var res = _context.GetAll<ActivityTag>().Where(x => x.ActivityId == activityId).Select(x => x.TagId);
            
            return _context.GetAll<Tag>().Where(x => res.Any(y => y == x.TagId)).Select(x => new ActivityDetailDto.TagData()
            {
                TagId = x.TagId,
                TagName = x.TagName,
            });
        }

        private IEnumerable<ActivityDetailDto.CommentData> GetCommentsByActivityId(int activityId)
        {
            return _context.GetAll<Comment>().Where(x => x.ActivityId == activityId).Select(x => new ActivityDetailDto.CommentData()
            {
                UserId = x.UserId,
                BuildTime = x.BuildTime,
                Comment = x.Comment1,
                StarRank = x.StarRank
            });
        }

        private IEnumerable<ActivityDetailDto.GuestData> GetGuestsByActivityId(int activityId)
        {
            return _context.GetAll<Guest>().Where(x => x.ActivityId == activityId).Select(x => new ActivityDetailDto.GuestData()
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
            return _context.GetAll<Qa>().Where(x => x.ActivityId == activityId).Select(x => new ActivityDetailDto.QaData()
            {
                Id = x.QaId,
                Question = x.Question,
                Answer = x.Answer,
                Sort = x.Sort
            });
        }

        #endregion
    }
}
