using Bccupass_CoreMVC.Models.DTO.Activity;
using Bccupass_CoreMVC.Models.DTO.CreateActivity;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Services.Interface
{
    public interface IActivityDraftService
    {
        public void EditActivityDes(CreateDesDto request);
        public CreateDesDto GetActivityDraftDes(int? id);
        public CreateGuestDto GetActivityDraftGuest(int? id);
        public void EditActivityGuest(CreateGuestDto request);
        public CreateQADto GetActivityDraftQA(int? id);
        public void EditActivityQA(CreateQADto request);

        public IEnumerable<ActivityCategoryCardDto> GetAllActivityThemeForCategory();
        public IEnumerable<ActivityCategoryCardDto> GetActivityType();
        public void CreateThemeCategory(ActivityCategoryCardDto request);
        public IEnumerable<ActivityCategoryCardDto> GetAllActivityTypeForCategory();

        public CreateTicketDto GetActivityDraftTicket(int? id);
        public void EditActivityTicket(CreateTicketDto request);
    }
}
