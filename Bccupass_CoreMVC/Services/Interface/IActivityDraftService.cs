using Bccupass_CoreMVC.Models.DTO.CreateActivity;

namespace Bccupass_CoreMVC.Services.Interface
{
    public interface IActivityDraftService
    {
        public void EditActivityDes(CreateDesDto request);
        public CreateDesDto GetActivityDraftDes(int? id);
    }
}
