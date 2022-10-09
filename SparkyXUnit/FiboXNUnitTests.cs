﻿using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyNUnitTest
{
    public class FiboXUnitTests
    {
        [Fact]
        public void FiboChecker_Input1_ReturnFiboSeries()
        {
            List<int> expectedRange = new() { 0 };
            Fibo fibo = new();
            fibo.Range = 1;
            List<int> result = fibo.GetFiboSeries();
            Assert.NotEmpty(result);
            Assert.Equal(expectedRange.OrderBy(u=>u),result);
            Assert.True(result.SequenceEqual(expectedRange));
        }

        [Fact]
        public void FiboChecker_Input6_ReturnFiboSeries()
        {
            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };
            Fibo fibo = new();
            fibo.Range = 6;
            List<int> result = fibo.GetFiboSeries();
            Assert.Contains(3,result);
            Assert.DoesNotContain(4,result);

        }
    }
}
