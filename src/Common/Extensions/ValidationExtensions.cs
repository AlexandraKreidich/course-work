using System;
using System.Reflection;
using JetBrains.Annotations;

namespace Common.Extensions
{
    public static class ValidationExtensions
    {
        public static void EnsureObjectPropertiesNotNull(this object item)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));

            foreach (PropertyInfo pi in item.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(item);

                    Attribute attr = pi.GetCustomAttribute(typeof(NotNullAttribute));

                    if (string.IsNullOrEmpty(value) && attr != null)
                    {
                        throw new ArgumentNullException(nameof(item));
                    }
                }
            }
        }
    }
}