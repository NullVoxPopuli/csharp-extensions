﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_extensions.Extensions;
using csharp_extensions.Implementations;
using Xunit;

namespace csharp_extensions.tests.Extensions.IEnumerableExtensions
{
    public class AddRange
    {
        [Fact]
        public void CanAddAMoreGenericListToAParentList()
        {
            List<int> o = new List<int>() { 1, 2, 3 };
            var toAdd = new List<object>() { 4, 5, 6 };
            o.AddRange(toAdd);

            dynamic expected = new List<int> { 1, 2, 3, 4, 5, 6 };
            Assert.Equal(expected, o);
        }

        [Fact]
        public void CanAddADynamicListToAParentList()
        {
            List<int> o = new List<int>() { 1, 2, 3 };
            var toAdd = new List<dynamic>() { 4, 5, 6 };
            o.AddRange(toAdd);

            dynamic expected = new List<int> { 1, 2, 3, 4, 5, 6 };
            Assert.Equal(expected, o);
        }

        [Fact]
        public void CanAddADynamicListToADynamicParentList()
        {
            dynamic o = new List<int>() { 1, 2, 3 };
            var toAdd = new List<dynamic>() { 4, 5, 6 };
            //List<dynamic>.AddRange(o, toAdd);
            //o.AddRange(toAdd);

            //dynamic expected = new List<int> { 1, 2, 3, 4, 5, 6 };
            //Assert.Equal(expected, o);
        }
    }
}
