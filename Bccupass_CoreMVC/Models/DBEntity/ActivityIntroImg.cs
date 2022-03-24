using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class ActivityIntroImg
    {
        public int ActivityIntroImageId { get; set; }
        public int ActivityId { get; set; }
        public string ActivityIntroImage { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
