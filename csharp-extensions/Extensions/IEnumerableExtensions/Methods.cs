﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace csharp_extensions.Extensions.IEnumerableExtensions
{
    class Methods
    {
        internal static List<string> GrepProperties<T>(PropertyInfo[] infos, string grep)
        {
            var names = (from info in infos
                         select info.Name).ToList();

            return GrepEnumerable(names, grep);
        }

        internal static List<T> GrepEnumerable<T>(IEnumerable<T> list, string grep)
        {
            var regex = new Regex(grep);

            return (from item in list
                    where regex.Matches(item.ToString()).Count > 0
                    select item).ToList();
        }

        internal static T FirstOrDefault<T>(
            IEnumerable<T> list,
            Func<T, bool> func,
            T defaultValue)
        {
            var originalFirstOrDefault = list.FirstOrDefault(func);

            return originalFirstOrDefault == null
                       ? defaultValue
                       : originalFirstOrDefault;
        }

        public static IEnumerable<T> Flatten<T>(IEnumerable<T> list)
        {
            var result = new List<T>();
            foreach (var item in list)
            {
                if (item is List<T>)
                {
                    result.AddRange(Flatten(item as List<T>));
                }
                else
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
