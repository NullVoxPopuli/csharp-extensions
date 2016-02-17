using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_extensions.Extensions;
using Xunit;

namespace csharp_extensions.tests.Extensions.ObjectExtensions
{

    public class IsIterable
    {
        [Fact]
        public void ArrayIsIterable()
        {
            Assert.True((new int[1]).IsIterable());
        }

        [Fact]
        public void IsNotIterable()
        {
            Assert.False(1.IsIterable());

        }

        [Fact]
        public void DictionaryIsIterable()
        {
            var dict = new Dictionary<string, int> { { "hi", 1 }, { "there", 2 } };
            Assert.True(dict.IsIterable());
        }

        [Fact]
        public void ListIsIterable()
        {
            var list = new List<int> { 1, 2, 3 };
            Assert.True(list.IsIterable());
        }
    }
}
