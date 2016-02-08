using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_extensions.Extensions;
using Xunit;

namespace csharp_extensions.tests.Extensions.IEnumerableExtensions
{
    public class Join
    {
        [Fact]
        public void Joins()
        {
            var list = new List<string>() {"Hi", "There"};
            var result = list.Join(" ");

            Assert.Equal("Hi There", result);
        }
    }
}
