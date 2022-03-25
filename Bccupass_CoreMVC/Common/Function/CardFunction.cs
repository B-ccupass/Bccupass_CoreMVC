namespace Bccupass_CoreMVC.Common.Function
{
    public class CardFunction
    {
        public static string IsFree(bool free)
        {
            string result;
            if (free)
            {
                result = "免費";
            }
            else
            {
                result = "收費";
            }
            return result;
        }
    }
}
