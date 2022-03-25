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

        public IEnumerable<ActivityCardDto> GetNewestActivity()
        {
            var target = _context.GetAll<Activity>().OrderByDescending(x => x.CreateTime).Take(6);//抓最新的前6個(活動的篩選)

            
            return ActivityCardDtoResult(target);
        }

        public IEnumerable<ActivityCardDto> GetOrganizerActivity(int organzierId)
        {
            var target = _context.GetAll<Activity>().Where(x => x.OrganizerId == organzierId);

            return ActivityCardDtoResult(target);
        }

        private IEnumerable<ActivityCardDto> ActivityCardDtoResult(IQueryable<Activity> target)
        {
            var theme = _context.GetAll<ActivityTheme>();//主題
            var ticket = _context.GetAll<TicketDatail>();//票卷
            var favorite = _context.GetAll<UserFavorite>();//喜歡

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
    }
}
