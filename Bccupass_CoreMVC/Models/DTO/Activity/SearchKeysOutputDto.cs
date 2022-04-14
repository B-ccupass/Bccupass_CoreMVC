using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.DTO.Activity
{
    public class SearchKeysOutputDto
    {
        public string SearchInput { get; set; }
        public List<int> SelectedThemeId { get; set; }
        public List<int> SelectedTypeId { get; set; }
        public int SelectedStartTimeEnumValue { get; set; }
        public int SelectedTicketPriceEnumValue { get; set; }
        public ActivityCardGroupByTimeDto SearchResultCards { get; set; }
    }
}
