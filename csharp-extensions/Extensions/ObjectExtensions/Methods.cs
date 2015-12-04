using System;
using System.Linq;
using System.Reflection;

namespace csharp_extensions.Extensions.ObjectExtensions
{
    internal static class Methods
    {
        // http://stackoverflow.com/a/2493258/356849
        // http://stackoverflow.com/a/687420/356849
        internal static object Create(Type parentType, params Type[] genericTypes)
        {
            // generic type
            Type o = parentType.MakeGenericType(genericTypes);
            ConstructorInfo ci = o.GetConstructor(new Type[] { });

            return ci.Invoke(new object[] { });
        }

        internal static object NewInstanceOf(object obj)
        {
            var parentType = obj.GetType().GetGenericTypeDefinition();
            var genericType = obj.GetType().GetGenericArguments();

            return Create(parentType, genericType);
        }


        internal static bool IsA(object obj, System.Type t)
        {
            var objType = obj.GetType();

            // obj is the Type we passed
            if (objType == t)
            {
                return true;
            }

            // obj is a subclass of Type
            if (objType.GetTypeInfo().IsSubclassOf(t))
            {
                return true;
            }

            // obj has an interface of Type
            var hasGenericType = objType.GetInterfaces().Any(i => i == t);

            return hasGenericType;
        }

        internal static object Send(object obj, string callableName, params object[] parameters)
        {
            var info = InfoFor(obj, callableName, parameters);
            return ValueFor(obj, info, parameters);
        }

        internal static bool RespondsTo(dynamic obj, string callableName)
        {
            return HasCallable(obj, callableName);
        }

        #region Private Helpers

        private static dynamic InfoFor(object obj, string callableName, params object[] parameters)
        {
            var hasMethod = HasMethod(obj, callableName);
            var hasProperty = HasProperty(obj, callableName);
            var type = obj.GetType();

            if (hasMethod)
            {
                return type.GetMethod(callableName);
            }

            if (hasProperty)
            {
                return type.GetProperty(callableName);
            }

            throw new System.Exception("Method or Property not found: " + callableName);
        }

        public static BindingFlags DefaultFlags = BindingFlags.Public | BindingFlags.NonPublic |
                                                  BindingFlags.Instance | BindingFlags.Static;

        // http://stackoverflow.com/a/5114514/356849
        private static bool HasMethod(
            object objectToCheck,
            string methodName,
            BindingFlags flags = BindingFlags.DeclaredOnly)
        {
            flags = DefaultBindingFlags(flags);

            var type = objectToCheck.GetType();
            return type.GetMethod(methodName, flags) != null;
        }

        private static bool HasProperty(
            object objectToCheck,
            string propertyName,
            BindingFlags flags = BindingFlags.DeclaredOnly)
        {
            flags = DefaultBindingFlags(flags);

            var type = objectToCheck.GetType();
            return type.GetProperty(propertyName, flags) != null;
        }

        private static bool HasCallable(
            object objectToCheck,
            string callableName,
            BindingFlags flags = BindingFlags.DeclaredOnly)
        {
            var result = HasProperty(objectToCheck, callableName, flags);
            if (!result)
            {
                result = HasMethod(objectToCheck, callableName, flags);
            }
            return result;
        }

        private static BindingFlags DefaultBindingFlags(BindingFlags requested)
        {
            // using declared only for the default, cause it's worthless
            if (requested == BindingFlags.DeclaredOnly)
            {
                return DefaultFlags;
            }

            return requested;
        }


        // TODO: figure out why the editor thinks .MemberType and
        // MemberTypes should be errors.
        // This succeeds at runtime
        private static object ValueFor(object obj, MemberInfo member, params object[] parameters)
        {
            object value = null;

            // crazy workaround
            // https://github.com/dotnet/corefx/issues/4670#issuecomment-159665089
            if (member != null)
            {
                var field = member as FieldInfo;
                if (field != null)
                {
                    return ((FieldInfo)member).GetValue(obj);
                }

                var property = member as PropertyInfo;
                if (property != null)
                {
                    return ((PropertyInfo)member).GetValue(obj, null);
                }
                var method = member as MethodInfo;
                if (method != null)
                {
                    return ((MethodInfo)member).Invoke(obj, parameters);
                }
            }

            return value;
        }

        #endregion
    }
}