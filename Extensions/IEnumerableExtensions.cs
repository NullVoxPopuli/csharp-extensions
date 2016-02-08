using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_extensions.Implementations.IEnumerableExtensions;

namespace csharp_extensions.Extensions
{
    public static class IEnumerableExtensions
    {

        // Why isn't this available by default?
        public static T FirstOrDefault<T>(
            this IEnumerable<T> list,
            Func<T, bool> func,
            T defaultValue)
        {
            return Methods.FirstOrDefault(list, func, defaultValue);
        }

        /// <summary>
        /// http://rosettacode.org/wiki/Flatten_a_list#C.23
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> list)
        {
            return Methods.Flatten(list);
        }

        public static List<T> AddRange<T>(this List<T> list, List<object> otherList)
        {
            return Methods.AddRange<T>(list, otherList);
        }

        public static IEnumerable<T> Subset<T>(this IEnumerable<T> array, int beginIndex, int endIndex)
        {
            return array.Skip(beginIndex).Take(endIndex);
        }

        public static string Join(this IEnumerable<string> array, string seperator)
        {
            return string.Join(seperator, array);
        }
    }
}
