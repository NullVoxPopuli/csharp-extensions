using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_extensions.Extensions;
using csharp_extensions_tests.Support;
using Xunit;

namespace csharp_extensions.tests.Extensions.ObjectExtensions
{
    public class HasFieldMatching
    {

        [Fact]
        public void DoesNotPullEqualNameDifferentType()
        {
            var baseObj = new ClassWithProperties();
            var evaluated = new {SomeString = 4};

            var fields = baseObj.GetInstanceFields();
            var field = fields.First(n => n.Name.Equals("AField"));
            var result = evaluated.HasFieldMatching(field);

            Assert.False(result);
        }

        [Fact]
        public void ReturnsFalseIfTheFieldDoesNotExist()
        {
            var evaluated = new { };
            var result = evaluated.HasFieldMatching(null);

            Assert.False(result);
        }


        [Fact]
        public void AMatchIsFound()
        {
            var baseObj = new ClassWithProperties();
            var evaluated = new SubClass();

            var fields = baseObj.GetInstanceFields();
            var field = fields.First(n => n.Name.Equals("AField"));
            var result = evaluated.HasFieldMatching(field);

            Assert.True(result);
        }
    }
}
