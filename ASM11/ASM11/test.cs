using NUnit.Framework;
using FactorialCalculator;

namespace FactorialCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(5, 120)]
        public void CalculateFactorial_ValidInput_ReturnsCorrectResult(int input, int expectedResult)
        {
            int result = calculator.CalculateFactorial(input);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(-1)]
        public void CalculateFactorial_NegativeNumber_ThrowsArgumentException(int input)
        {
            Assert.Throws<System.ArgumentException>(() => calculator.CalculateFactorial(input));
        }
    }
}
