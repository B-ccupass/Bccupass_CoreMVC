using System.ComponentModel;

namespace Bccupass_CoreMVC.Common.Enum
{
    public enum OrderState
    {
        [Description("已付款")]
        Paid,
        [Description("未付款")]
        NotPaid,
        [Description("已取消")]
        Cancel,
        [Description("已退票")]
        Refund
    }
}
