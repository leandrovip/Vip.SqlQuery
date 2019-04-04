using System.ComponentModel;

namespace Vip.SqlQuery.Extensions
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string GetDescription<T>(this T source)
        {
            var fieldInfo = source.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute),
                false);

            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }
    }
}