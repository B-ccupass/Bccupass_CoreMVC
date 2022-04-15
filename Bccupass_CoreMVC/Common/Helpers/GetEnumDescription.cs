using System;
using System.ComponentModel;
using System.Reflection;

namespace Bccupass_CoreMVC.Common.Helpers
{
    public static class GetEnumDescription
    {
        public static string GetDescriptionText(Enum source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false
            );

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return source.ToString();
            }
        }
    }
}
