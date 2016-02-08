using System;
using System.Linq;
using System.Reflection;

namespace csharp_extensions.Implementations.ObjectExtensions
{
    internal static class Methods
    {
        // http://stackoverflow.com/a/2493258/356849
        // http://stackoverflow.com/a/687420/356849
        internal static object Create(Type parentType, params Type[] genericTypes)
        {
            Type o = genericTypes.Any()
                    ? parentType.MakeGenericType(genericTypes)
                    : parentType;

            ConstructorInfo ci = o.GetConstructor(new Type[] { });

            return ci.Invoke(new object[] { });
        }

        internal static object NewInstanceOf(object obj)
        {
            var parentType = obj.GetType();

#if DNX451
            if (parentType.IsGenericType)
            {
                parentType = parentType.GetGenericTypeDefinition();
            }
#else
            if (parentType.IsConstructedGenericType)
            {
                parentType = parentType.GetGenericTypeDefinition();
            }
#endif
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
            return Send(obj, callableName, false, null, parameters);
        }

        internal static object Send(object obj, string callableName, bool useDefault = false, object defaultValue = null, params object[] parameters)
        {
            if (callableName.EndsWith("="))
            {
                SetValue(obj, callableName, parameters);
                return obj;
            }

            var info = InfoFor(obj, callableName, parameters);

            if (info != null) return ValueFor(obj, info, parameters);

            if (useDefault){
                return defaultValue;
            }

                throw new System.Exception("Method or Property not found: " + callableName);
        }

        internal static bool RespondsTo(dynamic obj, string callableName)
        {
            return HasCallable(obj, callableName);
        }

#region Private Helpers


        private static bool HasCallable(
            object objectToCheck,
            string callableName)
        {
            var result = InfoFor(objectToCheck, callableName);

            return result != null;
        }


        internal static dynamic InfoFor(object obj, string callableName, params object[] parameters)
        {
            var hasMethod = HasMethod(obj, callableName);
            var hasProperty = HasProperty(obj, callableName);
            var hasField = HasField(obj, callableName);
            var type = obj.GetType();

            if (hasMethod)
            {
                return type.GetMethod(callableName, Implementations.Constants.DefaultFlags);
            }

            if (hasProperty)
            {
                return type.GetProperty(callableName, Implementations.Constants.DefaultFlags);
            }

            if (hasField)
            {
                return type.GetField(callableName, Implementations.Constants.DefaultFlags);
            }

            return null;
        }

        // http://stackoverflow.com/a/5114514/356849
        private static bool HasMethod(
            object objectToCheck,
            string methodName)
        {
            var type = objectToCheck.GetType();
            return type.GetMethod(methodName, Implementations.Constants.DefaultFlags) != null;
        }

        private static bool HasProperty(
            object objectToCheck,
            string propertyName)
        {
            var type = objectToCheck.GetType();
            return type.GetProperty(propertyName, Implementations.Constants.DefaultFlags) != null;
        }

        private static bool HasField(object objectToCheck, string fieldName)
        {
            var type = objectToCheck.GetType();
            return type.GetField(fieldName, Implementations.Constants.DefaultFlags) != null;
        }


        private static BindingFlags DefaultBindingFlags(BindingFlags requested)
        {
            // using declared only for the default, cause it's worthless
            if (requested == BindingFlags.DeclaredOnly)
            {
                return Implementations.Constants.DefaultFlags;
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

        private static void SetValue(object obj, string callableName, params object[] parameters)
        {
            var withoutEquals = callableName.Replace("=", "");
            var member = InfoFor(obj, withoutEquals, parameters);

            var property = member as PropertyInfo;
            var field = member as FieldInfo;

            if (property != null || field != null)
            {
                member.SetValue(obj, parameters[0]);
            }
        }


        #endregion
    }
}