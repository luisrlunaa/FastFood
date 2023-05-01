using System.Collections.Generic;

namespace FastFood.Infrastructure.Utils
{
    public static class StringsExtension
    {
        public static string CleanSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? string.Empty : str.Trim();
        }

        public static string CleanSpace(this string str, string defaultValue)
        {
            return string.IsNullOrWhiteSpace(str) ? defaultValue : str.Trim();
        }

        public static List<string> CleanSpaceList(this List<string> str)
        {
            var newList = new List<string>();
            foreach (var item in str)
            {
                newList.Add(string.IsNullOrWhiteSpace(item) ? string.Empty : item.Trim());
            }

            return newList;
        }
    }
}
