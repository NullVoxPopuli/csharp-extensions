using csharp_extensions.Extensions;
using csharp_extensions.Implementations;
using Xunit;

namespace csharp_extensions_tests.Extensions.ObjectExtensions
{
    public class RespondsTo
    {
        [Fact]
        public void HasAProperty()
        {
            var o = new Support.ClassWithProperties { SomeNumber = 2 };
            var result = o.RespondsTo("SomeNumber");

            Assert.True(result);
        }

        [Fact]
        public void HasAMethod()
        {
            var o = new Support.ClassWithProperties();
            var result = o.RespondsTo("Square");

            Assert.True(result);
        }

        [Fact]
        public void HasAField()
        {
            var o = new Support.ClassWithProperties { AField = 2 };
            var result = o.RespondsTo("AField");

            Assert.True(result);
        }

        [Fact]
        public void DoesNotExist()
        {
            var o = new Support.ClassWithProperties { AField = 2 };
            var result = o.RespondsTo("A23423423423Field");

            Assert.False(result);
        }
    }
}
