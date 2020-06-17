using FitnessAPI.Models.Setup;
using FitnessAPI.Resources;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace FitnessAPI.Helpers
{
    public static class EnumEx
    {
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            return default(T);
        }

        public static string GetDescription(Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description;
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static string ToEnumName<T>(this T value)
        {
            return Enum.GetName(typeof(T), value);
        }

        public static string ToResourceName<T>(this T value, LanguageType languageType) where T : struct
        {
            string language = GetDescription(languageType);
            string key = value.ToEnumName().ToLower();
            return Language.ResourceManager.GetString(key, CultureInfo.CreateSpecificCulture(language));
        }
    }
}