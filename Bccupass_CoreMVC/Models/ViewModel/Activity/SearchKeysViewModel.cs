using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.Activity
{
    public class SearchKeysViewModel
    {
        public string SearchInput { get; set; }
        public IEnumerable<ThemeData> ThemesList { get; set; }
        public IEnumerable<int> SelectedThemeIds { get; set; }
        public IEnumerable<TypesData> TypesList { get; set; }
        public IEnumerable<int> SelectedTypeIds { get; set; }
        public IEnumerable<StartTimeData> StartTimeList { get; set; }
        public IEnumerable<TicketPriceData> TicketPriceList { get; set; }
        public class ThemeData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class TypesData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class StartTimeData
        {
            public int EnumValue { get; set; }
            public string EnumName { get; set; }
            public string Description { get; set; }
            public bool Selected { get; set; }
        }
        public class TicketPriceData
        {
            public int EnumValue { get; set; }
            public string EnumName { get; set; }
            public string Description { get; set; }
            public bool Selected { get; set; }
        }
    }
}
