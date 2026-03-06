using NUnit.Framework;
using System;

namespace ArithmeticCalculatorTests
{
    [TestFixture]
    public class ArithmeticCalculatorTests
    {
        private IArithmeticCalculator _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new ArithmeticCalculator();
        }

        // Add Tests - Happy Path
        [Test]
        public void Add_TwoPositiveIntegers_ReturnsCorrectSum()
        {
            int result = _sut.Add(5, 3);
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Add_TwoNegativeIntegers_ReturnsCorrectSum()
        {
            int result = _sut.Add(-4, -6);
            Assert.That(result, Is.EqualTo(-10));
        }

        [Test]
        public void Add_PositiveAndNegativeInteger_ReturnsCorrectSum()
        {
            int result = _sut.Add(10, -3);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Add_ZeroAndPositiveInteger_ReturnsPositiveInteger()
        {
            int result = _sut.Add(0, 7);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Add_ZeroAndZero_ReturnsZero()
        {
            int result = _sut.Add(0, 0);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Add_MaxIntAndZero_ReturnsMaxInt()
        {
            int result = _sut.Add(int.MaxValue, 0);
            Assert.That(result, Is.EqualTo(int.MaxValue));
        }

        [Test]
        public void Add_MinIntAndZero_ReturnsMinInt()
        {
            int result = _sut.Add(int.MinValue, 0);
            Assert.That(result, Is.EqualTo(int.MinValue));
        }

        [Test]
        public void Add_LargePositiveNumbers_ReturnsCorrectSum()
        {
            int result = _sut.Add(1000000, 2000000);
            Assert.That(result, Is.EqualTo(3000000));
        }

        // Subtract Tests - Happy Path
        [Test]
        public void Subtract_TwoPositiveIntegers_ReturnsCorrectDifference()
        {
            int result = _sut.Subtract(10, 3);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Subtract_TwoNegativeIntegers_ReturnsCorrectDifference()
        {
            int result = _sut.Subtract(-4, -6);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Subtract_PositiveAndNegativeInteger_ReturnsCorrectDifference()
        {
            int result = _sut.Subtract(5, -3);
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Subtract_ZeroFromPositiveInteger_ReturnsPositiveInteger()
        {
            int result = _sut.Subtract(7, 0);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Subtract_SameNumbers_ReturnsZero()
        {
            int result = _sut.Subtract(5, 5);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Subtract_ZeroFromZero_ReturnsZero()
        {
            int result = _sut.Subtract(0, 0);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Subtract_SmallerFromLarger_ReturnsNegativeResult()
        {
            int result = _sut.Subtract(3, 10);
            Assert.That(result, Is.EqualTo(-7));
        }

        [Test]
        public void Subtract_MaxIntFromMaxInt_ReturnsZero()
        {
            int result = _sut.Subtract(int.MaxValue, int.MaxValue);
            Assert.That(result, Is.EqualTo(0));
        }

        // Multiply Tests - Happy Path
        [Test]
        public void Multiply_TwoPositiveIntegers_ReturnsCorrectProduct()
        {
            int result = _sut.Multiply(4, 5);
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Multiply_TwoNegativeIntegers_ReturnsPositiveProduct()
        {
            int result = _sut.Multiply(-4, -5);
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Multiply_PositiveAndNegativeInteger_ReturnsNegativeProduct()
        {
            int result = _sut.Multiply(4, -5);
            Assert.That(result, Is.EqualTo(-20));
        }

        [Test]
        public void Multiply_ByZero_ReturnsZero()
        {
            int result = _sut.Multiply(100, 0);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Multiply_ZeroByZero_ReturnsZero()
        {
            int result = _sut.Multiply(0, 0);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Multiply_ByOne_ReturnsSameNumber()
        {
            int result = _sut.Multiply(7, 1);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Multiply_ByNegativeOne_ReturnsNegatedNumber()
        {
            int result = _sut.Multiply(7, -1);
            Assert.That(result, Is.EqualTo(-7));
        }

        [Test]
        public void Multiply_LargeNumbers_ReturnsCorrectProduct()
        {
            int result = _sut.Multiply(1000, 2000);
            Assert.That(result, Is.EqualTo(2000000));
        }

        // Divide Tests - Happy Path
        [Test]
        public void Divide_TwoPositiveIntegers_ReturnsCorrectQuotient()
        {
            double result = _sut.Divide(10, 2);
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void Divide_TwoNegativeIntegers_ReturnsPositiveQuotient()
        {
            double result = _sut.Divide(-10, -2);
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void Divide_PositiveByNegative_ReturnsNegativeQuotient()
        {
            double result = _sut.Divide(10, -2);
            Assert.That(result, Is.EqualTo(-5.0));
        }

        [Test]
        public void Divide_NegativeByPositive_ReturnsNegativeQuotient()
        {
            double result = _sut.Divide(-10, 2);
            Assert.That(result, Is.EqualTo(-5.0));
        }

        [Test]
        public void Divide_NumberByItself_ReturnsOne()
        {
            double result = _sut.Divide(7, 7);
            Assert.That(result, Is.EqualTo(1.0));
        }

        [Test]
        public void Divide_ZeroByPositiveInteger_ReturnsZero()
        {
            double result = _sut.Divide(0, 5);
            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void Divide_NumberByOne_ReturnsSameNumber()
        {
            double result = _sut.Divide(9, 1);
            Assert.That(result, Is.EqualTo(9.0));
        }

        [Test]
        public void Divide_NonEvenDivision_ReturnsDecimalQuotient()
        {
            double result = _sut.Divide(7, 2);
            Assert.That(result, Is.EqualTo(3.5));
        }

        [Test]
        public void Divide_LargeNumberBySmallNumber_ReturnsCorrectQuotient()
        {
            double result = _sut.Divide(1000000, 4);
            Assert.That(result, Is.EqualTo(250000.0));
        }

        // Divide Tests - Error Conditions
        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _sut.Divide(10, 0));
        }

        [Test]
        public void Divide_NegativeByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _sut.Divide(-10, 0));
        }

        [Test]
        public void Divide_ZeroByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _sut.Divide(0, 0));
        }

        // Add Tests - Boundary Values
        [Test]
        public void Add_NegativeAndPositiveResultingInZero_ReturnsZero()
        {
            int result = _sut.Add(-5, 5);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Add_OneAndNegativeOne_ReturnsZero()
        {
            int result = _sut.Add(1, -1);
            Assert.That(result, Is.EqualTo(0));
        }

        // Subtract Tests - Boundary Values
        [Test]
        public void Subtract_MinIntFromZero_ReturnsPositiveOverflowOrMinInt()
        {
            Assert.DoesNotThrow(() => _sut.Subtract(0, int.MinValue));
        }

        // Multiply Tests - Boundary Values
        [Test]
        public void Multiply_OneByOne_ReturnsOne()
        {
            int result = _sut.Multiply(1, 1);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Multiply_NegativeOneByNegativeOne_ReturnsOne()
        {
            int result = _sut.Multiply(-1, -1);
            Assert.That(result, Is.EqualTo(1));
        }

        // Divide Tests - Boundary Values
        [Test]
        public void Divide_MaxIntByOne_ReturnsMaxInt()
        {
            double result = _sut.Divide(int.MaxValue, 1);
            Assert.That(result, Is.EqualTo((double)int.MaxValue));
        }

        [Test]
        public void Divide_OneByLargeNumber_ReturnsSmallFraction()
        {
            double result = _sut.Divide(1, 1000000);
            Assert.That(result, Is.EqualTo(0.000001).Within(1e-10));
        }

        // Operator Consistency Tests
        [Test]
        public void Add_ThenSubtractSameValue_ReturnsOriginalValue()
        {
            int added = _sut.Add(10, 5);
            int result = _sut.Subtract(added, 5);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Multiply_ThenDivideBySameValue_ReturnsOriginalValue()
        {
            int multiplied = _sut.Multiply(6, 4);
            double result = _sut.Divide(multiplied, 4);
            Assert.That(result, Is.EqualTo(6.0));
        }

        [Test]
        public void Add_IsCommutative_SameResultBothWays()
        {
            int result1 = _sut.Add(3, 7);
            int result2 = _sut.Add(7, 3);
            Assert.That(result1, Is.EqualTo(result2));
        }

        [Test]
        public void Multiply_IsCommutative_SameResultBothWays()
        {
            int result1 = _sut.Multiply(4, 6);
            int result2 = _sut.Multiply(6, 4);
            Assert.That(result1, Is.EqualTo(result2));
        }

        [Test]
        public void Subtract_IsNotCommutative_DifferentResultsBothWays()
        {
            int result1 = _sut.Subtract(10, 3);
            int result2 = _sut.Subtract(3, 10);
            Assert.That(result1, Is.Not.EqualTo(result2));
        }

        [Test]
        public void Divide_IsNotCommutative_DifferentResultsBothWays()
        {
            double result1 = _sut.Divide(10, 2);
            double result2 = _sut.Divide(2, 10);
            Assert.That(result1, Is.Not.EqualTo(result2));
        }
    }
}