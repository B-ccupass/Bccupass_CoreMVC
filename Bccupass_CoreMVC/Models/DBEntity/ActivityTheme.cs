using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class ActivityTheme
    {
        public ActivityTheme()
        {
            ActivityActivityPrimaryThemes = new HashSet<Activity>();
            ActivityActivitySecondThemes = new HashSet<Activity>();
        }

        public int ActivityThemeId { get; set; }
        public string ActivityThemeName { get; set; }
        public string ActivityThemeImage { get; set; }

        public virtual ICollection<Activity> ActivityActivityPrimaryThemes { get; set; }
        public virtual ICollection<Activity> ActivityActivitySecondThemes { get; set; }
    }
}
