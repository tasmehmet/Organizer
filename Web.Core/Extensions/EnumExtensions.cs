﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Web.Core.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<string> GetDescriptions(Type type)
        {
            var descs = new List<string>();
            var names = Enum.GetNames(type);
            foreach (var name in names)
            {
                var field = type.GetField(name);
                var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                foreach (DescriptionAttribute fd in fds)
                {
                    descs.Add(fd.Description);
                }
            }
            return descs;
        }

        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field?.GetCustomAttributes(typeof(DescriptionAttribute), false) ?? new string[0]{ };
            return attributes.Any() ? ((DescriptionAttribute)attributes.ElementAt(0)).Description : "";
        }


        public static Enum GetEnumByDecription(Type @enumType, string description)
        {
            var fields = @enumType.GetFields();

            foreach (var fieldInfo in fields)
            {

                var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Any())
                {
                    var desc = ((DescriptionAttribute)attributes.ElementAt(0)).Description;
                    if (desc == description)
                    {
                        return Enum.Parse(@enumType, fieldInfo.Name) as Enum;
                    }
                }
            }

            return null;
        }
    }
}
