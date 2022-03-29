using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class Activity
    {
        public Activity()
        {
            ActivityAnnouncements = new HashSet<ActivityAnnouncement>();
            ActivityIntroImgs = new HashSet<ActivityIntroImg>();
            Guests = new HashSet<Guest>();
            OrderDetails = new HashSet<OrderDetail>();
            Qas = new HashSet<Qa>();
            TicketDatails = new HashSet<TicketDatail>();
            UserFavorites = new HashSet<UserFavorite>();
        }

        public int ActivityId { get; set; }
        public int ActivityPrimaryThemeId { get; set; }
        public int? ActivitySecondThemeId { get; set; }
        public int ActivityTypeId { get; set; }
        public int OrganizerId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string AddressDetail { get; set; }
        public string StreamingWeb { get; set; }
        public string ActivityRefWebUrl { get; set; }
        public string RefWebDescription { get; set; }
        public string ActivityIntro { get; set; }
        public string ActivityDescription { get; set; }
        public string ActivityNotes { get; set; }
        public int ActivityState { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string AddressDescription { get; set; }
        public string StreamingWeb { get; set; }
        public string FormName { get; set; }
        public bool FormEmail { get; set; }
        public bool FormPhone { get; set; }
        public bool FormBirthday { get; set; }
        public bool FormAddress { get; set; }
        public bool FormGender { get; set; }
        public bool FormAge { get; set; }
        public bool FormHobby { get; set; }
        public bool FormMaritalStatus { get; set; }
        public bool FormIndustry { get; set; }
        public bool FormDepartment { get; set; }
        public bool FormMonthlyIncome { get; set; }
        public bool FormIdnumber { get; set; }
        public bool FormFax { get; set; }
        public bool FormEducationLevel { get; set; }
        public bool FormDiningNeeds { get; set; }
        public bool FormConpanyName { get; set; }
        public bool FormJobTitle { get; set; }

        public virtual ActivityTheme ActivityPrimaryTheme { get; set; }
        public virtual ActivityTheme ActivitySecondTheme { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        public virtual Organizer Organizer { get; set; }
        public virtual ICollection<ActivityAnnouncement> ActivityAnnouncements { get; set; }
        public virtual ICollection<ActivityIntroImg> ActivityIntroImgs { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Qa> Qas { get; set; }
        public virtual ICollection<TicketDatail> TicketDatails { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
    }
}
