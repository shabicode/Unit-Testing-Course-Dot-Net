using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparky;

namespace SpartyTest
{
    [TestClass]
    public class CalculatorMSTests
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