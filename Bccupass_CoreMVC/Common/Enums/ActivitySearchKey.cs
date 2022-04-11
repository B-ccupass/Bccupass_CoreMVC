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

}
