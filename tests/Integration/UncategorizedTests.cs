using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using csharp_extensions.Extensions;
using csharp_extensions.Implementations;
using csharp_extensions_tests.Support;
using Xunit;

namespace csharp_extensions.tests.Integration
{
    public class UncategorizedTests
    {
        [Fact]
        public void BaseTypeIsFound()
        {
            // sanity for parts of ValueFor
            var someObject = new ClassWithProperties();
            var info = someObject.CallableInfo("Square");

            var dynamicInfo = (dynamic)info;


            Assert.Null(dynamicInfo as FieldInfo);
            Assert.Null(dynamicInfo as PropertyInfo);
            Assert.NotNull(dynamicInfo as MethodInfo);

            var memberType = dynamicInfo.MemberType;
            var infoType = info.GetType();
            var infoBaseType = infoType.Send("BaseType");
            var infoBaseTypeName = infoBaseType.Send("Name");
            var typeOfInfo = (string)infoBaseTypeName;

            Assert.Equal("MethodInfo", typeOfInfo);
            Assert.Equal("Method", memberType.ToString());
        }
    }
}
