using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.CreateActivity
{
    public class CreateThemeCategoryVM
    {
        public int ActivityDraftId { get; set; }
        public int ActivityPrimaryThemeId { get; set; }
        public int ActivitySecondThemeId { get; set; }
        public int ActivityTypeId { get; set; }

        public CreateThemeCategoryVM DataThemeCategory { get; set; }
        public List<CreateThemeCategoryVM> DataJSON { get; set; }

        public IEnumerable<CardData> Theme { get; set; }
        public IEnumerable<CardData> Type { get; set; }
        public class CardData
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Icon { get; set; }
        }
    }
}
