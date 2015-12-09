﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_extensions_tests.Support
{
    class ClassWithProperties
    {
        public int SomeNumber { get; set; }
        public string SomeString { get; set; }
        public string AnotherString { get; set; }
        public int AField;
        public string AnotherField;

        public double Square(double number)
        {
            return Math.Pow(number, 2);
        }
    }
}
