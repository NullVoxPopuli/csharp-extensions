using csharp_extensions.Extensions;
using Xunit;

namespace csharp_extensions_tests.Extensions.TypeExtensions
{
    public class Grep
    {
        [Fact]
        public void FiltersThePropertyNames()
        {
            var type = typeof (Support.ClassWithProperties);

            var propertyNames = type.GrepProperties("Some");

            Assert.Contains("SomeNumber", propertyNames);
            Assert.Contains("SomeString", propertyNames);
            Assert.DoesNotContain("AnotherString", propertyNames);
        }
    }
}
