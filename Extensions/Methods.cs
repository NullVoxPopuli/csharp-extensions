using System;
using System.Collections.Generic;
using System.Reflection;

namespace csharp_extensions.Extensions
{
    /// <summary>
    /// This is the entry point for all extensions
    /// </summary>
    public static class Methods
    {
        public static object NewInstance(this object obj)
        {
            return ObjectExtensions.Methods.NewInstanceOf(obj);
        }

        // based off ruby's object.send(...)
        //
        // based on the callableName, get the value.
        // params are optional.
        //
        // This is to avoid having to get a methodinfo or propertyinfo object
        // everytime we want to dynamically get the value of something on an object
        //
        // This also allows us to invoke methods that are private on the object
        public static object Send(this object obj, string callableName, params object[] parameters)
        {
            return ObjectExtensions.Methods.Send(obj, callableName, parameters);
        }
        
        public static object SendWithDefault(this object obj, string callableName, object defaultValue, params object[] parameters)
        {
            return ObjectExtensions.Methods.Send(obj, callableName, true, defaultValue, parameters);
        }

        // based off ruby's object.respond_to?
        //
        // Determines if an object can respond to a particular property or method,
        // as defined by callableName
        public static bool RespondsTo(this object obj, string callableName)
        {
            return ObjectExtensions.Methods.RespondsTo(obj, callableName);
        }

        // because checking types is too complicated in C#....
        public static bool IsA(this object obj, Type t)
        {
            return ObjectExtensions.Methods.IsA(obj, t);
        }

        // returns a list of all properties matching a regex string
        public static List<string> GrepProperties(this Type type, string grep)
        {
            var infos = type.GetProperties();
            return IEnumerableExtensions.Methods.GrepProperties<string>(infos, grep);
        }

        // Why isn't this available by default?
        public static T FirstOrDefault<T>(this IEnumerable<T> list, Func<T, bool> func, T defaultValue)
        {
            return IEnumerableExtensions.Methods.FirstOrDefault(list, func, defaultValue);
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
            return IEnumerableExtensions.Methods.Flatten(list);
        }
    }
}
