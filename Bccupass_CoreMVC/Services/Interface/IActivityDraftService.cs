using Bccupass_CoreMVC.Models.DTO.CreateActivity;

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
    }
}
