using csharp_extensions.Extensions;
using Xunit;

namespace csharp_extensions_tests.Extensions.ObjectExtensions
{
    public class SendWithDefault
    {
        [Fact]
        public void CallsAProperty()
        {
            var o = new Support.ClassWithProperties {SomeNumber = 2};

            var result = o.SendWithDefault("Some13212312312312312321Number", defaultValue: true);

            Assert.Equal(true, result);
        }

        [Fact]
        public void CallsAMethod()
        {
            var o = new Support.ClassWithProperties();

            var result = o.SendWithDefault("Squar12312312312312e", -1, 8);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void CallsAField()
        {
            var o = new Support.ClassWithProperties { AField = 2 };
            var result = o.SendWithDefault("AFuuuuuuuuuuuuuaaaaaaaaaaaaaaaaaaaaaaield", "hi");

            Assert.Equal("hi", result);
        }
    }
}
