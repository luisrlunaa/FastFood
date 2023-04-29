using System;

namespace FastFood.Infrastructure.Utils
{
    public class AnyNullValueHelper
    {
        public static T AnyNullValue<T>(object obj)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                var isStringNull = property.PropertyType == typeof(string)
                                 && (property.GetValue(obj) == null
                                 || string.IsNullOrWhiteSpace(property.GetValue(obj)?.ToString()));

                if (property.GetValue(obj) == null || isStringNull)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(obj, "Sin " + property.Name);
                    }
                    else if (property.PropertyType == typeof(int?)
                            || property.PropertyType == typeof(decimal?)
                            || property.PropertyType == typeof(double?)
                            || property.PropertyType == typeof(float?))
                    {
                        property.SetValue(obj, 0);
                    }
                    else if (property.PropertyType == typeof(char?))
                    {
                        property.SetValue(obj, '\0');
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        property.SetValue(obj, DateTime.MinValue);
                    }
                }
            }
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
