using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.Activity;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Services.Interface
{
    public interface IActivityService
    {
        public IEnumerable<ActivityCardDto> GetAllActivity();
        public IEnumerable<ActivityCardDto> GetNewestActivity();
        public IEnumerable<ActivityCardDto> GetChosenActivity();
        public IEnumerable<ActivityCardDto> GetOrganizerActivity(int organzierId);
        public ActivityBuyTicketDto GetActivityById(int activityId);
        public ActivityDetailDto GetActivityDetail(int id);
    }
}
