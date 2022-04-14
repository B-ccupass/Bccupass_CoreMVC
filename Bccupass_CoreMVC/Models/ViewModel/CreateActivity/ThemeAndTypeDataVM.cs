using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.CreateActivity
{
    public class ThemeAndTypeDataVM
    {
        public IEnumerable<CardData> Theme { get; internal set; }
        public IEnumerable<CardData> Type { get; internal set; }
        //public CreateThemeCategoryVM DataThemeCategory { get; internal set; }
        //public CreateThemeCategoryVM DataJSON { get; internal set; }

        public class CardData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Img { get; set; }
        }
    }
}
