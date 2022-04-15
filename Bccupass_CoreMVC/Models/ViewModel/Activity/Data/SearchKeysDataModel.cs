using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.Activity.Data
{
    public class SearchKeysDataModel
    {
        public string SearchInput { get; set; }
        public IEnumerable<int> ThemesList { get; set; }
        public IEnumerable<int> TypesList { get; set; }
        public int StartTimeEnumValue { get; set; }
        public int TicketPriceEnumValue { get; set; }
    }
}
