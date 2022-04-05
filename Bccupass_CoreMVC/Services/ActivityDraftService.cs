﻿using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.CreateActivity;
using Bccupass_CoreMVC.Repositories.Interface;
using Bccupass_CoreMVC.Services.Interface;
using System.Linq;

namespace Bccupass_CoreMVC.Services
{
    public class ActivityDraftService : IActivityDraftService
    {
        private readonly IActivityDraftRepository _activityDraft;
        public ActivityDraftService(IActivityDraftRepository activityDraft)
        {
            _activityDraft = activityDraft;
        }


        #region 主辦活動模組
        public CreateDesDto GetActivityDraftDes(int? id)
        {
            var target =  _activityDraft.GetAll<ActivityDraft>().FirstOrDefault(x => x.ActivityDraftId == id);
            var result = new CreateDesDto()
            {
                ActivityDraftId = target.ActivityDraftId,
                ActivityContent = target.ActivityContent
            };

            return result;
        }
        public void EditActivityDes(CreateDesDto request)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().First(x => x.ActivityDraftId == request.ActivityDraftId);
            target.ActivityContent = request.ActivityContent;
            _activityDraft.Update(target);
            _activityDraft.Save();
        }

        public CreateGuestDto GetActivityDraftGuest(int? id)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().FirstOrDefault(x => x.ActivityDraftId == id);
            var result = new CreateGuestDto()
            {
                ActivityDraftId = target.ActivityDraftId,
                ActivityGuests = target.ActivityGuests
            };

            return result;
        }
        public void EditActivityGuest(CreateGuestDto request)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().First(x => x.ActivityDraftId == request.ActivityDraftId);
            target.ActivityGuests = request.ActivityGuests;
            _activityDraft.Update(target);
            _activityDraft.Save();
        }

        public CreateQADto GetActivityDraftQA(int? id)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().FirstOrDefault(x => x.ActivityDraftId == id);
            var result = new CreateQADto()
            {
                ActivityDraftId = target.ActivityDraftId,
                ActivityQA = target.ActivityQa
            };

            return result;
        }
        public void EditActivityQA(CreateQADto request)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().First(x => x.ActivityDraftId == request.ActivityDraftId);
            target.ActivityQa = request.ActivityQA;
            _activityDraft.Update(target);
            _activityDraft.Save();
        }


        #endregion


    }
}
