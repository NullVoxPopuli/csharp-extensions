using System.Collections.Generic;
using csharp_extensions.Extensions;
using Xunit;

namespace csharp_extensions_tests.Extensions.ObjectExtensions
{
    public class NewInstance
    {

        [Fact]
        public void BuildsNewInstanceFromExisting()
        {
            var list = new List<string>();
            var result = list.NewInstance();
            Assert.Equal(list.GetType(), result.GetType());
        }
    }
}
