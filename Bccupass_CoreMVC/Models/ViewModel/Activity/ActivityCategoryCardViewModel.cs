using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.Activity
{
    public class ActivityCategoryCardViewModel
    {
        public IEnumerable<CardData> Theme { get;  set; }
        public IEnumerable<CardData> Type { get;  set; }
        public string ThemeCategory { get; set; }
        public class CardData
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Icon { get; set; }
        }

    }
}
