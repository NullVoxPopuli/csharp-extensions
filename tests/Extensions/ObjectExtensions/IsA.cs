
using csharp_extensions.Extensions;
using Xunit;

namespace csharp_extensions_tests.Extensions.ObjectExtensions
{
    public class IsA
    {
        [Fact]
        public void InstanceOfItself()
        {
            var o = new Support.ClassWithProperties();

            Assert.True(o.IsA(typeof (Support.ClassWithProperties)));
        }

        [Fact]
        public void InstanceOfSubClass()
        {
            var o = new Support.SubClass();

            Assert.True(o.IsA(typeof(Support.ClassWithProperties)));
        }

        [Fact]
        public void InstanceOfInterface()
        {
            var o = new Support.SubClass();

            Assert.True(o.IsA(typeof(Support.AnInterface)));
        }
    }
}
