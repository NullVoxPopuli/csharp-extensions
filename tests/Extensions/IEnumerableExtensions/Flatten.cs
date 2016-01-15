using System.Collections.Generic;
using csharp_extensions.Implementations;
using Xunit;
using csharp_extensions.Extensions;

namespace csharp_extensions_tests.Extensions.IEnumerableExtensions
{
    public class Flatten
    {
        [Fact]
        public void FlattensNestedListOfIntegers()
        {
            var list = new List<dynamic>() { 1, 2, 33, new List<dynamic>() { 4, 5, 6 } };

            var result = list.Flatten();

            var expected = new List<dynamic>() { 1, 2, 33, 4, 5, 6 };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FlattenDeeplyNestedListOfIntegers()
        {
            var list = new List<dynamic>() { 1, 2, 33, new List<dynamic>() { 4, new List<dynamic>() {45, 53}, 6 } };
            var result = list.Flatten();
            var expected = new List<dynamic>() { 1, 2, 33, 4, 45, 53, 6 };

            Assert.Equal(expected, result);
        }
    }
}
