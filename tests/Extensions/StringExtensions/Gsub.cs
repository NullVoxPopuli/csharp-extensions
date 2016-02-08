using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_extensions.Extensions;
using Xunit;

namespace csharp_extensions.tests.Extensions.StringExtensions
{
    public class Gsub
    {
        [Fact]
        public void GsubReplaces()
        {
            var str = "hello";
            var replaced = str.Gsub("\\A..l", "");

            Assert.Equal("lo", replaced);
        }

    }
}
