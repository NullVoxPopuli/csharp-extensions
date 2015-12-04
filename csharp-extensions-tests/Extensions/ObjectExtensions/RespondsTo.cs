using csharp_extensions.Extensions;
using Xunit;

namespace csharp_extensions_tests.Extensions.ObjectExtensions
{
    public class RespondsTo
    {
        [Fact]
        public void HasAProperty()
        {
            var expected = 2;
            var o = new Support.ClassWithProperties { SomeNumber = expected };

            var result = o.RespondsTo("SomeNumber");

            Assert.True(result);
        }

        [Fact]
        public void HasAMethod()
        {
            var expected = 64;
            var o = new Support.ClassWithProperties();

            var result = o.RespondsTo("Square");

            Assert.True(result);
        }
    }
}
