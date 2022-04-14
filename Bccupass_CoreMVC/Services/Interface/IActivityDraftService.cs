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

        public void EditActivityThemeCat(CreateThemeCategoryDto request);
        public void EditActivityInfo(CreateInfoDto request);
        public CreateThemeCategoryDto GetActivityThemeCat(int? id);
        public CreateInfoDto GetActivityInfo(int? id);
        public IEnumerable<ActivityCategoryCardDto> GetAllActivityThemeForCategory();
        public IEnumerable<ActivityCategoryCardDto> GetAllActivityTypeForCategory();

        public CreateTicketDto GetActivityDraftTicket(int? id);
        public void EditActivityTicket(CreateTicketDto request);

        //Demo用
        public DemoActivityDraftDto GetAllActivityDraft(int id);
    }
}
