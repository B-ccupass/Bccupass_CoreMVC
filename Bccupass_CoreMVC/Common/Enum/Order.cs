using System.ComponentModel;

namespace Bccupass_CoreMVC.Common.Enums
{
    public class Order
    {
        public enum OrderState
        {
            [Description("未付款")]
            NotPaid,
            [Description("已付款")]
            Paid,
            [Description("已取消")]
            Cancel,
            [Description("已退票")]
            Refund
        }
    }
}
