using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyNUnitTest
{
    public class GradingCalculatorXNUnitTests
    {
        private GradingCalculator gradingCalculator;         
        public GradingCalculatorXNUnitTests()
        {
            gradingCalculator = new GradingCalculator();    
        } 
        [Fact]
        public void Gradecalc_InputScore95Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("A", result);
        }

        [Fact]
        public void Gradecalc_InputScore85Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("B", result);
        }

        [Fact]
        public void Gradecalc_InputScore65Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("C", result);
        }

        [Fact]
        public void Gradecalc_InputScore95Attendance65_GetAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("B", result);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void Gradecalc_FailureScenarios_GetFGrade(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("F",result);
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void Gradecalc_AllGradeScenarios_GradeOutPut(int score, int attendance, string expectedResult)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;
            var result = gradingCalculator.GetGrade();
            Assert.Equal(expectedResult, result);
        }
    }
}
