using System.Collections.Generic;
using csharp_extensions.Extensions;
using Xunit;

namespace csharp_extensions_tests.Extensions.ObjectExtensions
{
    public class Send
    {
        [Fact]
        public void CallsAProperty()
        {
            var expected = 2;
            var o = new Support.ClassWithProperties {SomeNumber = expected};

            var result = o.Send("SomeNumber");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CallsAMethod()
        {
            var expected = 64.0;
            var o = new Support.ClassWithProperties();

            var result = o.Send("Square", 8);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CallsAField()
        {
            var expected = 2;
            var o = new Support.ClassWithProperties {AField = expected};
            var result = o.Send("AField");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CallsAPrivateField()
        {
            var expected = 3;
            var o = new Support.ClassWithProperties(aPrivateField: expected);
            var result = o.Send("_aPrivateField");

            Assert.Equal(expected, result);
        }

    }
}