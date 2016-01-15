using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_extensions.Implementations.ObjectExtensions;

namespace csharp_extensions.Extensions
{
    public static class ObjectExtensions
    {

        public static object NewInstance(this object obj)
        {
            return Methods.NewInstanceOf(obj);
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
            return Methods.Send(obj, callableName, parameters);
        }

        public static object SendWithDefault(
            this object obj,
            string callableName,
            object defaultValue,
            params object[] parameters)
        {
            return Methods.Send(obj, callableName, true, defaultValue, parameters);
        }

        public static object CallableInfo(this object obj, string callableName)
        {
            return Methods.InfoFor(obj, callableName);
        }

        // based off ruby's object.respond_to?
        //
        // Determines if an object can respond to a particular property or method,
        // as defined by callableName
        public static bool RespondsTo(this object obj, string callableName)
        {
            return Methods.RespondsTo(obj, callableName);
        }

        // because checking types is too complicated in C#....
        public static bool IsA(this object obj, Type t)
        {
            return Methods.IsA(obj, t);
        }
    }
}
