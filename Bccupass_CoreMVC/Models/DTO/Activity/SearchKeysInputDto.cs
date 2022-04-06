using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.DTO.Activity
{
    public class SearchKeysInputDto
    {
        public string SearchInput { get; set; }
        public IEnumerable<ThemeData> Themes { get; set; }
        public IEnumerable<TypesData> Types { get; set; }
        public IEnumerable<StartTimeData> StartTime { get; set; }
        public IEnumerable<TicketPriceData> TicketPrice { get; set; }
        public class ThemeData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Select { get; set; }
        }
        public class TypesData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Select { get; set; }
        }
        public class StartTimeData
        {
            public int EnumValue { get; set; }
            public string EnumName { get; set; }
            public string Description { get; set; }
            public bool Select { get; set; }
        }
        public class TicketPriceData
        {
            public int EnumValue { get; set; }
            public string EnumName { get; set; }
            public string Description { get; set; }
            public bool Select { get; set; }
        }
    }
}
