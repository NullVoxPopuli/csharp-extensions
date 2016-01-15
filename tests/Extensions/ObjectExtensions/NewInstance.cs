using System.Collections.Generic;
using csharp_extensions.Extensions;
using csharp_extensions.Implementations;
using csharp_extensions_tests.Support;
using Xunit;

namespace csharp_extensions_tests.Extensions.ObjectExtensions
{
    public class NewInstance
    {

        [Fact]
        public void BuildsNewInstanceFromExistingGeneric()
        {
            var list = new List<string>();
            var result = list.NewInstance();
            Assert.Equal(list.GetType(), result.GetType());
        }

        [Fact]
        public void BuildsNewInstanceFromExisting()
        {
            var obj = new ClassWithProperties();
            var result = obj.NewInstance();
            Assert.Equal(obj.GetType(), result.GetType());
        }
    }
}
