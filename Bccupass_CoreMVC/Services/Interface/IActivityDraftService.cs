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
        public void EditActivityInfo(CreateActivityInfoDto request);
        public CreateThemeCategoryDto GetActivityThemeCat(int? id);
        public CreateActivityInfoDto GetActivityInfo(int? id);
    }
}
