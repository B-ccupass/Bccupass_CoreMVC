using System;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel
{
    public class ActivityDetailViewModel
    {
        public ActivityData Activity { get; set; }
        public OrganizerData Organizer { get; set; }
        public CategoriesData Categories { get; set; }
        public IEnumerable<TagData> Tags { get; set; }
        public IEnumerable<GuestData> GuestList { get; set; }
        public IEnumerable<CommentData> CommentList { get; set; }
        public IEnumerable<QaData> QaList { get; set; }
        public IEnumerable<AnnounceData> AnnounceList { get; set; }


        public class ActivityData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string ActivityRefWebUrl { get; set; }
            public string RefWebDescription { get; set; }
            public string ActivityIntro { get; set; }
            public string ActivityDescription { get; set; }
            public string ActivityNotes { get; set; }

            // 線上活動
            public string StreamingWeb { get; set; }

            // 線下活動
            public string City { get; set; }
            public string District { get; set; }
            public string Address { get; set; }
            public string AddressDescription { get; set; }
        }
        public class OrganizerData
        {
            public int OrganizerId { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public string Description { get; set; }
            public string Email { get; set; }
        }
        public class CategoriesData
        {
            public string MainTheme { get; set; }
            public string SecondTheme { get; set; }
            public string Type { get; set; }
        }
        public class TagData
        {
            public int TagId { get; set; }
            public string TagName { get; set; }
        }
        public class GuestData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Photo { get; set; }
            public string Title { get; set; }
            public string Describe { get; set; }
        }
        public class CommentData
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string UserImage { get; set; }
            public DateTime BuildTime { get; set; }
            public string Comment { get; set; }
            public int StarRank { get; set; }
        }
        public class QaData
        {
            public int Id { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }
        }
        public class AnnounceData
        {
            public int AnnouncementId { get; set; }
            public string AnnouncementContent { get; set; }
            public DateTime CreateTime { get; set; }
        }

    }
}
