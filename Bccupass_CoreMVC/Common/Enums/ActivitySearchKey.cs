using System.Collections.Generic;
using System.ComponentModel;

namespace Bccupass_CoreMVC.Common.Enums
{
    public enum StartTime
    {
        [Description("全部")]
        All,
        [Description("今天")]
        Today,
        [Description("明天")]
        Tomorrow,
        [Description("本周")]
        ThisWeek,
        [Description("本周末")]
        ThisWeekend,
        [Description("本月")]
        ThisMonth
    }

    public enum TicketPrice
    {
        [Description("全部")]
        All,
        [Description("免費")]
        Free,
        [Description("付費")]
        Paid
    }

    public class GetEnumDescription
    {
        public string TimeDiscription(int enumValue)
        {
            return _dictionaryStartTime[enumValue];
        }

        public string PriceDiscription(int enumValue)
        {
            return _dictionaryTicketPrice[enumValue];
        }

        public Dictionary<int, string> _dictionaryStartTime = new Dictionary<int, string>()
        {
            {0, "今天"},
            {1, "明天"},
            {2, "本周"},
            {3, "本周末"},
            {4, "本月"}
        };

        public Dictionary<int, string> _dictionaryTicketPrice = new Dictionary<int, string>()
        {
            {0, "免費"},
            {1, "付費"},
        };
    }
}
