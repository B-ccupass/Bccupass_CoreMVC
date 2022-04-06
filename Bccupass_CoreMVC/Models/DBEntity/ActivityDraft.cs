using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class ActivityDraft
    {
        public int ActivityDraftId { get; set; }
        public int OrganizerId { get; set; }
        public string ThemeCategory { get; set; }
        public string ActivityInfo { get; set; }
        public string ActivityContent { get; set; }
        public string ActivityGuests { get; set; }
        public string ActivityQa { get; set; }
        public string ActivityTicket { get; set; }
        public string ActivityForm { get; set; }
        public DateTime DraftCreateTime { get; set; }

        public virtual Organizer Organizer { get; set; }
    }
}
