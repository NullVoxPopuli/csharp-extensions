using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace csharp_extensions.Implementations.IEnumerableExtensions
{
    class Methods
    {
        // returns each pais as a KeyValuePair<,>
        public static IEnumerable<KeyValuePair<TLeft, TRight>> Zip<TLeft, TRight>(
            IEnumerable<TLeft> left, IEnumerable<TRight> right)
        {
            return Zip(left, right, (x, y) => new KeyValuePair<TLeft, TRight>(x, y));
        }

        // http://stackoverflow.com/a/242420/356849
        // accepts a projection from the caller for each pair
        public static IEnumerable<TResult> Zip<TLeft, TRight, TResult>(
            IEnumerable<TLeft> left, IEnumerable<TRight> right,
            Func<TLeft, TRight, TResult> selector)
        {
            using (IEnumerator<TLeft> leftE = left.GetEnumerator())
            using (IEnumerator<TRight> rightE = right.GetEnumerator())
            {
                while (leftE.MoveNext() && rightE.MoveNext())
                {
                    yield return selector(leftE.Current, rightE.Current);
                }
            }
        }

        internal static List<string> GrepProperties<T>(PropertyInfo[] infos, string grep)
        {
            var names = (from info in infos
                         select info.Name).ToList();

            return GrepEnumerable(names, grep);
        }

        internal static List<T> AddRange<T>(
            List<T> list,
            List<object> otherList)
        {
            // convert the otherList to be the same type as list
            //dynamic other = list.NewInstance();
            foreach (var item in otherList)
            {
                list.Add((T)item);
            }
            //list.AddRange(other);
            return list;
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
