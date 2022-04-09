using System;

namespace Bccupass_CoreMVC.Models.ViewModel.CreateActivity
{
    public class CreateActivityInfoVM
    {
        public int ActivityDraftId { get; set; }
        public string ActivityName { get; set; }
        public string Image { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ActivityRefWebUrl { get; set; } //活動參考網址
        public string RefWebDescription { get; set; } //活動參考網址描述
        public string City { get; set; } //城市
        public string District { get; set; } //行政區
        public string Address { get; set; } //地址
        public string AddressDetail { get; set; } //地址詳細資料
        public string StreamingWeb { get; set; } //直播網址

    }
}
