using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new Calculator();
            //Act
            int result = calc.AddNumber(10, 20);
            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddNumber_InputEvenNumber_ReturnFalse()
        {
            //Arrange
            Calculator calc = new Calculator();
            //Act
            bool isOdd = calc.IsOddNumber(10);
            //Assert
            Assert.That(isOdd,Is.EqualTo(false));
            Assert.IsFalse(isOdd);
        }
        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddNumber_InputOffNumber_ReturnTrue(int a)
        {
            //Arrange
            Calculator calc = new Calculator();
            //Act
            bool isOdd = calc.IsOddNumber(a);
            //Assert
            Assert.That(isOdd, Is.EqualTo(true));
            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(11, ExpectedResult = true)]
        [TestCase(10, ExpectedResult = false)]
        public bool IsOddNumber_InputNumber_ReturnTrue(int a)
        {
            Calculator calc = new Calculator();
            return calc.IsOddNumber(a);
             
        }

        [Test] 
        public void OddRanger_InputMinAndMaxRange_ReturnValidOddNumberRange()
        {
            Calculator calc = new Calculator();
            List<int> expectedOddRange = new() { 5,7,9};
            List<int> result = calc.GetOddRange(5, 10);
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.AreEqual(expectedOddRange,result);
            Assert.Contains(7,expectedOddRange);
        }
    }
}
