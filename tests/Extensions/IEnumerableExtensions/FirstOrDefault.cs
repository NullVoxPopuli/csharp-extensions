using System.Collections.Generic;
using csharp_extensions.Extensions;
using csharp_extensions.Implementations;
using Xunit;

namespace csharp_extensions_tests.Extensions.IEnumerableExtensions
{
    public class FirstOrDefault
    {
        [Fact]
        public void ReturnsACustomDefault()
        {
            var list = new List<string> {"string", "something"};
            var expected = "hi";
            var result = list.FirstOrDefault(s => s.Contains("zzz"), expected);

            Assert.Equal(expected, result);
        }

    }
}
