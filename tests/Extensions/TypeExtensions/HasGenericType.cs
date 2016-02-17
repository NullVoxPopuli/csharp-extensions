using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_extensions.Extensions;
using Xunit;

namespace csharpextensions.lib
{
    public class HasGenericType
    {
        [Fact]
        public void ListHasGenericType()
        {
            var listType = typeof(List<string>);
            var genericType = typeof(string);

            Assert.True(listType.HasGenericType(genericType));
        }

        [Fact]
        public void ListDoesNotHaveAType()
        {
            var listType = typeof(List<string>);
            var genericType = typeof(int);

            Assert.False(listType.HasGenericType(genericType));
        }

        [Fact]
        public void DictionaryHasTwoTypes()
        {
            var type = typeof (Dictionary<string, int>);
            Assert.True(type.HasGenericType(typeof(string)));
            Assert.True(type.HasGenericType(typeof(int)));
        }
    }
}
