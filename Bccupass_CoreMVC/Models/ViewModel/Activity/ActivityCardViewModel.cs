﻿using System;

namespace Bccupass_CoreMVC.Models.ViewModel.Activity
{
    public class ActivityCardViewModel
    {
        public class ActivityCardData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string City { get; set; }
            public string ActivityTheme { get; set; }
            public bool IsFree { get; set; }
            public int? Favorite { get; set; }
        }
    }
}
