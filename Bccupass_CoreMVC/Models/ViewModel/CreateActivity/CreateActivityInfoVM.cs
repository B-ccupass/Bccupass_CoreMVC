using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bccupass_CoreMVC.Models.ViewModel.CreateActivity
{
    public class CreateActivityInfoVM
    {
        public int ActivityDraftId { get; set; }
        /// <summary>
        /// 活動名稱
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// 活動圖片
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public string StartTime { set; get; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 活動標籤
        /// </summary>
        public string[] Tag { get; set; }
        /// <summary>
        /// 活動參考網址
        /// </summary>
        public string ActivityRefWebUrl { get; set; }
        /// <summary>
        /// 參考網址描述
        /// </summary>
        public string RefWebDescription { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 城市選項
        /// </summary>
        public int CitySelectIndex { get; set; }
        /// <summary>
        /// 行政區
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// 行政區選項
        /// </summary>
        public int DistrictSelectIndex { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 地址詳細資料
        /// </summary>
        public string AddressDetail { get; set; } //地址詳細資料
        /// <summary>
        /// 直播網址
        /// </summary>
        public string StreamingWeb { get; set; } //直播網址

        
                 
        


    }
}
