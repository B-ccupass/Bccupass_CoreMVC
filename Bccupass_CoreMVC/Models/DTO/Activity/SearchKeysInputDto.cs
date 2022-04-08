using Bccupass_CoreMVC.Common.Enums;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.DTO.Activity
{
    public class SearchKeysInputDto
    {
        public string SearchInput { get; set; }
        public IEnumerable<int> ThemesInput { get; set; }
        public IEnumerable<int> TypesInput { get; set; }
        public StartTime StartTimeInput { get; set; }
        public TicketPrice TicketPriceInput { get; set; }
    }
}
