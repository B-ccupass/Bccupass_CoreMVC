using System.Collections.Generic;
using System.ComponentModel;

namespace Bccupass_CoreMVC.Common.Enum
{
    public enum StartTime
    {
        Today,
        Tomorrow,
        ThisWeek,
        ThisWeekend,
        ThisMonth
    }

    public enum TicketPrice
    {
        Free,
        Paid
    }
    //public class GetEnumDescription
    //{
    //    public string TimeDiscription(int enumValue)
    //    {
    //        return _dictionaryStartTime[enumValue];
    //    }

    //    public string PriceDiscription(int enumValue)
    //    {
    //        return _dictionaryTicketPrice[enumValue];
    //    }

    //    public Dictionary<int, string> _dictionaryStartTime = new Dictionary<int, string>()
    //    {
    //        {0, "今天"},
    //        {1, "明天"},
    //        {2, "本周"},
    //        {3, "本周末"},
    //        {4, "本月"}
    //    };

    //    public Dictionary<int, string> _dictionaryTicketPrice = new Dictionary<int, string>()
    //    {
    //        {0, "免費"},
    //        {1, "付費"},
    //    };
    //}
}
