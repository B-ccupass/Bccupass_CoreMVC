using Bccupass_CoreMVC.Common.Helpers;
using Bccupass_CoreMVC.Models.ViewModel.Activity.Data;
using Bccupass_CoreMVC.Models.ViewModel.ActivityCard;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.Activity
{
    public class ActivityIndexViewModel
    {
        //public SearchKeysViewModel SearchKeys { get; set; }
        public IEnumerable<ActivityCardViewModel.ActivityCardData> ActivityList { get; set; }
        public Pagination pageInfo { get; set; }
        public int ActivityStateByTime { get; set; }
        public int ActivitySortOrder { get; set; }

        public IEnumerable<ThemeData> ThemeList { get; set; }
        public IEnumerable<TypeData> TypeList { get; set; }
        public SearchKeysDataModel searchInput { get; set; }

        public class ThemeData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class TypeData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
