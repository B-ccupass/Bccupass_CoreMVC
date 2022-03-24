using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class Guest
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Describe { get; set; }
        public string SocialLink { get; set; }
        public int ActivityId { get; set; }
        public int Sort { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
