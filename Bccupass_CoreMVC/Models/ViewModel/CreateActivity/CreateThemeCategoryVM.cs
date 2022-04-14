using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.CreateActivity
{
    public class CreateThemeCategoryVM
    {
        public int ActivityDraftId { get; set; }
        /// <summary>
        /// 活動主題ID
        /// </summary>
        public int ActivityPrimaryThemeId { get; set; }
        /// <summary>
        /// 活動次主題ID
        /// </summary>
        public int ActivitySecondThemeId { get; set; }
        /// <summary>
        /// 活動類型ID
        /// </summary>
        public int ActivityTypeId { get; set; }
        /// <summary>
        /// 選擇活動主題陣列
        /// </summary>
        public int[] ActivityArray { get; set; }
    }
}
