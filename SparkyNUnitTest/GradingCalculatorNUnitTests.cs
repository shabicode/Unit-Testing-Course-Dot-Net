using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator? gradingCalculator;
        [SetUp]
        public void Setup()
        {
            gradingCalculator = new GradingCalculator();    
        }
        [Test]
        public void Gradecalc_InputScore95Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void Gradecalc_InputScore85Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void Gradecalc_InputScore65Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void Gradecalc_InputScore95Attendance65_GetAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        [TestCase(95,55)]
        [TestCase(65,55)]
        [TestCase(50,90)]
        public void Gradecalc_FailureScenarios_GetFGrade(int score,int attendance )
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90,ExpectedResult = "A")]
        [TestCase(85, 90,ExpectedResult = "B")]
        [TestCase(65, 90,ExpectedResult = "C")]
        [TestCase(95, 65,ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string Gradecalc_AllGradeScenarios_GradeOutPut(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;
            return gradingCalculator.GetGrade(); 
        }
    }
}
