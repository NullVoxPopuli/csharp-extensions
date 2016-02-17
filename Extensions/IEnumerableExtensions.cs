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

        /// <summary>
        /// int[] left = { 1, 2, 3, 4, 5 };
        /// string[] right = { "abc", "def", "ghi", "jkl", "mno" };
        /// // using KeyValuePair<> approach
        /// foreach (var item in left.Zip(right))
        /// {
        ///     Console.WriteLine("{0}/{1}", item.Key, item.Value);
        /// }
        ///
        /// // using projection approach
        /// foreach (string item in left.Zip(right,
        ///     (x,y) => string.Format("{0}/{1}", x, y)))
        /// {
        ///     Console.WriteLine(item);
        /// }
        /// </summary>
        /// <typeparam name="TLeft"></typeparam>
        /// <typeparam name="TRight"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        // http://stackoverflow.com/a/242420/356849
        // returns each pais as a KeyValuePair<,>
        public static IEnumerable<KeyValuePair<TLeft, TRight>> Zip<TLeft, TRight>(
            this IEnumerable<TLeft> left,
            IEnumerable<TRight> right)
        {
            return Methods.Zip(left, right);
        }
    }
}
