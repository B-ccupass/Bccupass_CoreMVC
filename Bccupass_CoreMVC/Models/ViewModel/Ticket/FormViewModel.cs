using System;

namespace Bccupass_CoreMVC.Models.ViewModel.Ticket
{
    public class FormViewModel
    {
        public bool IsFreeTicket { get; set; }
        public ActivityData ActivityList { get; set; }
        public FormBoolData FormBool { get; set; }
        public CartDataModel CartData { get; set; }
        public class ActivityData
        {
            public int ActivityId { get; set; }
            public string ActivityName { get; set; }
            public string Image { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string City { get; set; }
            public string District { get; set; }
            public string Address { get; set; }
        }

        public class FormBoolData
        {
            public bool Name { get; set; }
            public bool Email { get; set; }
            public bool Phone { get; set; }
            public bool BirthDay { get; set; }
            public bool Address { get; set; }
            public bool Gender { get; set; }
            public bool Age { get; set; }
            //public bool Hobby { get; set; }
            //public bool MaritalStatus { get; set; }
            //public bool Industry { get; set; }
            //public bool Department { get; set; }
            public bool IdNumber { get; set; }
            //public bool Fax { get; set; }
            //public bool EducationLevel { get; set; }
            //public bool DiningNeeds { get; set; }
            //public bool CompanyName { get; set; }
            //public bool JobTitle { get; set; }
        }
    }
}
