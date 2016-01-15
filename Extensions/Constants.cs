using System;
using System.Collections.Generic;
using System.Reflection;

namespace csharp_extensions.Implementations
{
    /// <summary>
    /// This is the entry point for all extensions
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// These can be changed depending on what the level of access
        /// you want to allow is.
        /// </summary>
        public static BindingFlags DefaultFlags = BindingFlags.Public | BindingFlags.NonPublic |
                                                  BindingFlags.Instance | BindingFlags.Static;





    }
}