using Bccupass_CoreMVC.Models.DTO.Activity;
using Bccupass_CoreMVC.Repositories.Interface;
using System.Collections.Generic;
using Bccupass_CoreMVC.Models.DBEntity;
using System.Linq;
using Bccupass_CoreMVC.Services.Interface;

namespace Bccupass_CoreMVC.Services
{
    public class ActivityCardService : IActivityCardService
    {
        private readonly IActivityRepository _context;
        public ActivityCardService(IActivityRepository context)
        {
            _context = context;
        }
        public IEnumerable<ActivityCardDto> GetLatestActivity()
        {
            var target = _context.GetAll<Activity>().OrderByDescending(x => x.CreateTime).Take(6);
            var theme = _context.GetAll<ActivityTheme>();
            var ticket = _context.GetAll<TicketDatail>();

            var result = target.Select(x => new ActivityCardDto()
            {
                Id = x.ActivityId,
                Name = x.Name,
                Image = x.Image,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                City = x.City,
                ActivityTheme = theme.First(q => q.ActivityThemeId == x.ActivityPrimaryThemeId).ActivityThemeName,
                IsFree = ticket.Where(t => t.ActivityId == x.ActivityId).Sum(t => t.Price) == 0
            });

            return result;

        }
        

    }
}
