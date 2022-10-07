using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyMsTest
{
    [TestClass]
    internal class CalculatorMSTests
    {

        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new Calculator();
            //Act
            int result = calc.AddNumber(10, 20);
            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
