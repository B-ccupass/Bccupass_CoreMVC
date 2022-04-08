﻿using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.Activity;
using Bccupass_CoreMVC.Models.DTO.CreateActivity;
using Bccupass_CoreMVC.Repositories.Interface;
using Bccupass_CoreMVC.Services.Interface;
using System.Collections.Generic;
using System.Diagnostics;
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


        #region 活動內容RU
        public CreateDesDto GetActivityDraftDes(int? id)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().FirstOrDefault(x => x.ActivityDraftId == id);
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
        #endregion

        #region 活動嘉賓RU
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
        #endregion

        #region 新增問答RU
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

        #region 票卷設定RU
        public CreateTicketDto GetActivityDraftTicket(int? id)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().FirstOrDefault(x => x.ActivityDraftId == id);
            var result = new CreateTicketDto()
            {
                ActivityDraftId = target.ActivityDraftId,
                ActivityTicket = target.ActivityQa
            };

            return result;
        }
        public void EditActivityTicket(CreateTicketDto request)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().First(x => x.ActivityDraftId == request.ActivityDraftId);
            target.ActivityQa = request.ActivityTicket;
            _activityDraft.Update(target);
            _activityDraft.Save();
        }
        #endregion

        public CreateThemeCategoryDto GetActivityThemeCat(int? id)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().FirstOrDefault(x => x.ActivityDraftId == id);
            var result = new CreateThemeCategoryDto()
            {
                ActivityDraftId = target.ActivityDraftId,
                ThemeCategory = target.ThemeCategory,
            };
            return result;
        }

        public CreateActivityInfoDto GetActivityInfo(int? id)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().FirstOrDefault(x => x.ActivityDraftId == id);
            var result = new CreateActivityInfoDto()
            {
                ActivityDraftId = target.ActivityDraftId,
                ActivityInfo = target.ActivityInfo
            };
            return result;
        }

        public void EditActivityThemeCat(CreateThemeCategoryDto request)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().First(x => x.ActivityDraftId == request.ActivityDraftId);
            target.ThemeCategory = request.ThemeCategory;
            _activityDraft.Update(target);
            _activityDraft.Save();
        }

        public void EditActivityInfo(CreateActivityInfoDto request)
        {
            var target = _activityDraft.GetAll<ActivityDraft>().First(x => x.ActivityDraftId == request.ActivityDraftId);
            target.ActivityInfo = request.ActivityInfo;
            _activityDraft.Update(target);
            _activityDraft.Save();
        }
        
    }
}
