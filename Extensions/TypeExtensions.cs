using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace csharp_extensions.Extensions
{
    public static class TypeExtensions
    {
        // returns a list of all properties matching a regex string
        public static List<string> GrepProperties(this Type type, string grep)
        {
            var infos = type.GetProperties();
            return Implementations.IEnumerableExtensions.Methods.GrepProperties<string>(infos, grep);
        }

        public static bool ImplementsType(this Type type, Type otherType)
        {
            return type.GetInterfaces().Contains(otherType);
        }

        public static bool HasGenericType(this Type type, Type otherType)
        {
            return type.GenericTypeArguments.Contains(otherType);
        }

    }
}
