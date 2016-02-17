using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_extensions.Extensions;
using csharp_extensions_tests.Support;
using Xunit;

namespace csharp_extensions.tests.Extensions.ObjectExtensions
{
    public class GetInstanceFields
    {
        [Fact]
        public void GetAllInstanceFields()
        {
            var obj = new ClassWithProperties();
            var fields = obj.GetInstanceFields();

            Assert.Equal(3, fields.Count());
        }

        [Fact]
        public void DoesNotIncludeStaticFields()
        {
            var obj = new ClassWithProperties();
            var fields = obj.GetInstanceFields();

            var field = fields.FirstOrDefault(f => f.Name.Contains("Static"));

            Assert.Null(field);
        }
    }
}
