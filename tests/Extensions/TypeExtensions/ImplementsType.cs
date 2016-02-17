using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_extensions.Extensions;
using Xunit;

namespace csharp_extensions.tests.Extensions.TypeExtensions
{

    public class ImplementsType
    {
        [Fact]
        public void ImplementsInterface()
        {
            var listType = typeof (List<string>);
            var implementedType = typeof (IEnumerable<string>);

            Assert.True(listType.ImplementsType(implementedType));
        }

        [Fact]
        public void DoesNotImplementUnrelatedType()
        {
            var listType = typeof(List<string>);
            var implementedType = typeof(string);

            Assert.False(listType.ImplementsType(implementedType));
        }

        [Fact]
        public void DoesNotImplementExactlyTheSameType()
        {
            var listType = typeof(List<string>);
            var implementedType = typeof(string);

            Assert.False(listType.ImplementsType(implementedType));
        }
    }
}
