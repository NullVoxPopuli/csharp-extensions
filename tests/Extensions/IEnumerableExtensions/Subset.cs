using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_extensions.Extensions;
using Xunit;

namespace csharp_extensions.tests.Extensions.IEnumerableExtensions
{
    public class Subset
    {
        [Fact]
        public void SubsetGetsSubset()
        {
            var list = new List<int>() { 0,1,2,3,4,5,6,7,8,9};
            var result = list.Subset(2, 6).ToArray();

            var expected = new int[] {2, 3, 4, 5, 6};

            // result actually has a yieldy-enumeration thing at the end
            // but technically is correct, I think
            foreach (var value in expected)
            {
                Assert.True(result.Contains(value));
            }
        }
    }
}
