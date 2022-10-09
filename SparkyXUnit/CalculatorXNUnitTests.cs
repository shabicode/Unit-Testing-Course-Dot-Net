using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Sparky;

namespace Sparky
{
    public class CalculatorXNUnitFacts
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new Calculator();
            //Act
            int result = calc.AddNumber(10, 20);
            //Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void IsOddNumber_InputEvenNumber_ReturnFalse()
        {
            //Arrange
            Calculator calc = new Calculator();
            //Act
            bool isOdd = calc.IsOddNumber(10);
            //Assert
            //Assert.That(isOdd, Is.EqualTo(false));
            Assert.False(isOdd);
        }
        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsOddNumber_InputOffNumber_ReturnTrue(int a)
        {
            //Arrange
            Calculator calc = new Calculator();
            //Act
            bool isOdd = calc.IsOddNumber(a);
            //Assert 
            Assert.True(isOdd);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(10)]
        public bool IsOddNumber_InputNumber_ReturnTrue(int a)
        {
            Calculator calc = new Calculator();
            return calc.IsOddNumber(a);

        }

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnValidOddNumberRange()
        {
            Calculator calc = new Calculator();
            List<int> expectedOddRange = new() { 5, 7, 9 };
            List<int> result = calc.GetOddRange(5, 10);
            Assert.Equal(expectedOddRange,result);
            Assert.NotEmpty(result); 
        }
    }
}
