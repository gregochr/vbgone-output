using NUnit.Framework;
using System;

namespace ArithmeticCalculatorTests
{
    public interface IArithmeticCalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        double Divide(int a, int b);
        void Clear();
    }

    public class ArithmeticCalculator : IArithmeticCalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return (double)a / b;
        }

        public void Clear()
        {
        }
    }

    [TestFixture]
    public class ArithmeticCalculatorAddTests
    {
        private IArithmeticCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new ArithmeticCalculator();
        }

        [Test]
        public void Add_TwoPositiveIntegers_ReturnsCorrectSum()
        {
            int result = _calculator.Add(3, 5);
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Add_TwoNegativeIntegers_ReturnsCorrectSum()
        {
            int result = _calculator.Add(-4, -6);
            Assert.That(result, Is.EqualTo(-10));
        }

        [Test]
        public void Add_PositiveAndNegativeInteger_ReturnsCorrectSum()
        {
            int result = _calculator.Add(10, -3);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Add_NegativeAndPositiveInteger_ReturnsCorrectSum()
        {
            int result = _calculator.Add(-7, 12);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Add_ZeroAndPositiveInteger_ReturnsPositiveInteger()
        {
            int result = _calculator.Add(0, 9);
            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void Add_PositiveIntegerAndZero_ReturnsPositiveInteger()
        {
            int result = _calculator.Add(9, 0);
            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void Add_ZeroAndZero_ReturnsZero()
        {
            int result = _calculator.Add(0, 0);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Add_MaxIntAndZero_ReturnsMaxInt()
        {
            int result = _calculator.Add(int.MaxValue, 0);
            Assert.That(result, Is.EqualTo(int.MaxValue));
        }

        [Test]
        public void Add_MinIntAndZero_ReturnsMinInt()
        {
            int result = _calculator.Add(int.MinValue, 0);
            Assert.That(result, Is.EqualTo(int.MinValue));
        }

        [Test]
        public void Add_LargePositiveNumbers_ReturnsCorrectSum()
        {
            int result = _calculator.Add(1000000, 2000000);
            Assert.That(result, Is.EqualTo(3000000));
        }

        [Test]
        public void Add_LargeNegativeNumbers_ReturnsCorrectSum()
        {
            int result = _calculator.Add(-1000000, -2000000);
            Assert.That(result, Is.EqualTo(-3000000));
        }

        [Test]
        public void Add_SymmetricValues_ReturnsSameResult()
        {
            int resultA = _calculator.Add(7, 3);
            int resultB = _calculator.Add(3, 7);
            Assert.That(resultA, Is.EqualTo(resultB));
        }

        [Test]
        public void Add_NegativeAndItsPositive_ReturnsZero()
        {
            int result = _calculator.Add(-5, 5);
            Assert.That(result, Is.EqualTo(0));
        }
    }

    [TestFixture]
    public class ArithmeticCalculatorSubtractTests
    {
        private IArithmeticCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new ArithmeticCalculator();
        }

        [Test]
        public void Subtract_TwoPositiveIntegers_ReturnsCorrectDifference()
        {
            int result = _calculator.Subtract(10, 4);
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Subtract_SmallerFromLarger_ReturnsNegativeResult()
        {
            int result = _calculator.Subtract(4, 10);
            Assert.That(result, Is.EqualTo(-6));
        }

        [Test]
        public void Subtract_TwoNegativeIntegers_ReturnsCorrectDifference()
        {
            int result = _calculator.Subtract(-5, -3);
            Assert.That(result, Is.EqualTo(-2));
        }

        [Test]
        public void Subtract_NegativeFromPositive_ReturnsCorrectDifference()
        {
            int result = _calculator.Subtract(7, -3);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Subtract_PositiveFromNegative_ReturnsCorrectDifference()
        {
            int result = _calculator.Subtract(-7, 3);
            Assert.That(result, Is.EqualTo(-10));
        }

        [Test]
        public void Subtract_ZeroFromPositive_ReturnsPositiveInteger()
        {
            int result = _calculator.Subtract(8, 0);
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Subtract_PositiveFromZero_ReturnsNegativeInteger()
        {
            int result = _calculator.Subtract(0, 8);
            Assert.That(result, Is.EqualTo(-8));
        }

        [Test]
        public void Subtract_ZeroFromZero_ReturnsZero()
        {
            int result = _calculator.Subtract(0, 0);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Subtract_SameValues_ReturnsZero()
        {
            int result = _calculator.Subtract(15, 15);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Subtract_MaxIntFromMaxInt_ReturnsZero()
        {
            int result = _calculator.Subtract(int.MaxValue, int.MaxValue);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Subtract_LargeNumbers_ReturnsCorrectDifference()
        {
            int result = _calculator.Subtract(5000000, 3000000);
            Assert.That(result, Is.EqualTo(2000000));
        }

        [Test]
        public void Subtract_NegativeSameValues_ReturnsZero()
        {
            int result = _calculator.Subtract(-99, -99);
            Assert.That(result, Is.EqualTo(0));
        }
    }

    [TestFixture]
    public class ArithmeticCalculatorMultiplyTests
    {
        private IArithmeticCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new ArithmeticCalculator();
        }

        [Test]
        public void Multiply_TwoPositiveIntegers_ReturnsCorrectProduct()
        {
            int result = _calculator.Multiply(4, 5);
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Multiply_TwoNegativeIntegers_ReturnsPositiveProduct()
        {
            int result = _calculator.Multiply(-4, -5);
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Multiply_PositiveAndNegativeInteger_ReturnsNegativeProduct()
        {
            int result = _calculator.Multiply(4, -5);
            Assert.That(result, Is.EqualTo(-20));
        }

        [Test]
        public void Multiply_NegativeAndPositiveInteger_ReturnsNegativeProduct()
        {
            int result = _calculator.Multiply(-4, 5);
            Assert.That(result, Is.EqualTo(-20));
        }

        [Test]
        public void Multiply_AnyNumberByZero_ReturnsZero()
        {
            int result = _calculator.Multiply(99, 0);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Multiply_ZeroByAnyNumber_ReturnsZero()
        {
            int result = _calculator.Multiply(0, 99);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Multiply_ZeroByZero_ReturnsZero()
        {
            int result = _calculator.Multiply(0, 0);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Multiply_AnyNumberByOne_ReturnsSameNumber()
        {
            int result = _calculator.Multiply(42, 1);
            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void Multiply_OneByAnyNumber_ReturnsSameNumber()
        {
            int result = _calculator.Multiply(1, 42);
            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void Multiply_AnyNumberByNegativeOne_ReturnsNegatedNumber()
        {
            int result = _calculator.Multiply(42, -1);
            Assert.That(result, Is.EqualTo(-42));
        }

        [Test]
        public void Multiply_LargeNumbers_ReturnsCorrectProduct()
        {
            int result = _calculator.Multiply(1000, 2000);
            Assert.That(result, Is.EqualTo(2000000));
        }

        [Test]
        public void Multiply_SymmetricValues_ReturnsSameResult()
        {
            int resultA = _calculator.Multiply(6, 7);
            int resultB = _calculator.Multiply(7, 6);
            Assert.That(resultA, Is.EqualTo(resultB));
        }

        [Test]
        public void Multiply_NegativeNumberByZero_ReturnsZero()
        {
            int result = _calculator.Multiply(-50, 0);
            Assert.That(result, Is.EqualTo(0));
        }
    }

    [TestFixture]
    public class ArithmeticCalculatorDivideTests
    {
        private IArithmeticCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new ArithmeticCalculator();
        }

        [Test]
        public void Divide_TwoPositiveIntegers_ReturnsCorrectQuotient()
        {
            double result = _calculator.Divide(10, 2);
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void Divide_TwoNegativeIntegers_ReturnsPositiveQuotient()
        {
            double result = _calculator.Divide(-10, -2);
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void Divide_PositiveByNegative_ReturnsNegativeQuotient()
        {
            double result = _calculator.Divide(10, -2);
            Assert.That(result, Is.EqualTo(-5.0));
        }

        [Test]
        public void Divide_NegativeByPositive_ReturnsNegativeQuotient()
        {
            double result = _calculator.Divide(-10, 2);
            Assert.That(result, Is.EqualTo(-5.0));
        }

        [Test]
        public void Divide_NonEvenDivision_ReturnsDecimalQuotient()
        {
            double result = _calculator.Divide(7, 2);
            Assert.That(result, Is.EqualTo(3.5));
        }

        [Test]
        public void Divide_ZeroByPositive_ReturnsZero()
        {
            double result = _calculator.Divide(0, 5);
            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void Divide_ZeroByNegative_ReturnsZero()
        {
            double result = _calculator.Divide(0, -5);
            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.That(() => _calculator.Divide(10, 0), Throws.TypeOf<DivideByZeroException>());
        }

        [Test]
        public void Divide_NegativeByZero_ThrowsDivideByZeroException()
        {
            Assert.That(() => _calculator.Divide(-10, 0), Throws.TypeOf<DivideByZeroException>());
        }

        [Test]
        public void Divide_ZeroByZero_ThrowsDivideByZeroException()
        {
            Assert.That(() => _calculator.Divide(0, 0), Throws.TypeOf<DivideByZeroException>());
        }

        [Test]
        public void Divide_ByZero_ExceptionMessageIsCorrect()
        {
            var ex = Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
            Assert.That(ex.Message, Is.EqualTo("Cannot divide by zero."));
        }

        [Test]
        public void Divide_NumberByItself_ReturnsOne()
        {
            double result = _calculator.Divide(7, 7);
            Assert.That(result, Is.EqualTo(1.0));
        }

        [Test]
        public void Divide_NumberByOne_ReturnsSameNumber()
        {
            double result = _calculator.Divide(42, 1);
            Assert.That(result, Is.EqualTo(42.0));
        }

        [Test]
        public void Divide_NumberByNegativeOne_ReturnsNegatedNumber()
        {
            double result = _calculator.Divide(42, -1);
            Assert.That(result, Is.EqualTo(-42.0));
        }

        [Test]
        public void Divide_LargeNumbers_ReturnsCorrectQuotient()
        {
            double result = _calculator.Divide(1000000, 100);
            Assert.That(result, Is.EqualTo(10000.0));
        }

        [Test]
        public void Divide_OneByLargeNumber_ReturnsSmallDecimal()
        {
            double result = _calculator.Divide(1, 4);
            Assert.That(result, Is.EqualTo(0.25));
        }
    }

    [TestFixture]
    public class ArithmeticCalculatorClearTests
    {
        private IArithmeticCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new ArithmeticCalculator();
        }

        [Test]
        public void Clear_WhenCalled_DoesNotThrowException()
        {
            Assert.That(() => _calculator.Clear(), Throws.Nothing);
        }

        [Test]
        public void Clear_AfterOperations_CalculatorStillFunctional()
        {
            _calculator.Add(5, 3);
            _calculator.Subtract(10, 4);
            _calculator.Clear();

            int result = _calculator.Add(2, 2);
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void Clear_CalledMultipleTimes_DoesNotThrowException()
        {
            Assert.That(() =>
            {
                _calculator.Clear();
                _calculator.Clear();
                _calculator.Clear();
            }, Throws.Nothing);
        }
    }

    [TestFixture]
    public class ArithmeticCalculatorIntegrationTests
    {
        private IArithmeticCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new ArithmeticCalculator();
        }

        [Test]
        public void AddThenSubtract_ReturnsCorrectResults()
        {
            int sum = _calculator.Add(10, 5);
            int difference = _calculator.Subtract(sum, 3);
            Assert.That(difference, Is.EqualTo(12));
        }

        [Test]
        public void MultiplyThenDivide_ReturnsOriginalValue()
        {
            int product = _calculator.Multiply(6, 4);
            double quotient = _calculator.Divide(product, 4);
            Assert.That(quotient, Is.EqualTo(6.0));
        }

        [Test]
        public void AddThenMultiply_ReturnsCorrectResult()
        {
            int sum = _calculator.Add(3, 2);
            int product = _calculator.Multiply(sum, 4);
            Assert.That(product, Is.EqualTo(20));
        }

        [Test]
        public void SubtractResultIsZeroThenDivide_ThrowsDivideByZeroException()
        {
            int difference = _calculator.Subtract(5, 5);
            Assert.That(() => _calculator.Divide(10, difference), Throws.TypeOf<DivideByZeroException>());
        }

        [Test]
        public void AllOperations_WithBoundaryValues_DoNotThrowUnexpectedly()
        {
            Assert.That(() =>
            {
                _calculator.Add(int.MaxValue, 0);
                _calculator.Subtract(int.MinValue, 0);
                _calculator.Multiply(1, int.MaxValue);
                _calculator.Divide(int.MaxValue, 1);
            }, Throws.Nothing);
        }

        [Test]
        public void SequentialAdds_ProduceCorrectCumulativeResult()
        {
            int result = _calculator.Add(1, 2);
            result = _calculator.Add(result, 3);
            result = _calculator.Add(result, 4);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Divide_AfterClear_StillDividesCorrectly()
        {
            _calculator.Multiply(5, 5);
            _calculator.Clear();
            double result = _calculator.Divide(20, 4);
            Assert.That(result, Is.EqualTo(5.0));
        }
    }

    [TestFixture]
    public class ArithmeticCalculatorParseTests
    {
        [Test]
        public void ParseInput_ValidIntegerString_ReturnsCorrectInteger()
        {
            bool success = int.TryParse("42", out int value);
            Assert.That(success, Is.True);
            Assert.That(value, Is.EqualTo(42));
        }

        [Test]
        public void ParseInput_NullString_ReturnsFalse()
        {
            bool success = int.TryParse(null, out int value);
            Assert.That(success, Is.False);
        }

        [Test]
        public void ParseInput_EmptyString_ReturnsFalse()
        {
            bool success = int.TryParse("", out int value);
            Assert.That(success, Is.False);
        }

        [Test]
        public void ParseInput_WhitespaceString_ReturnsFalse()
        {
            bool success = int.TryParse("   ", out int value);
            Assert.That(success, Is.False);
        }

        [Test]
        public void ParseInput_AlphaString_ReturnsFalse()
        {
            bool success = int.TryParse("abc", out int value);
            Assert.That(success, Is.False);
        }

        [Test]
        public void ParseInput_MixedAlphaNumeric_ReturnsFalse()
        {
            bool success = int.TryParse("12abc", out int value);
            Assert.That(success, Is.False);
        }

        [Test]
        public void ParseInput_NegativeString_ReturnsCorrectNegativeInteger()
        {
            bool success = int.TryParse("-15", out int value);
            Assert.That(success, Is.True);
            Assert.That(value, Is.EqualTo(-15));
        }

        [Test]
        public void ParseInput_ZeroString_ReturnsZero()
        {
            bool success = int.TryParse("0", out int value);
            Assert.That(success, Is.True);
            Assert.That(value, Is.EqualTo(0));
        }

        [Test]
        public void ParseInput_MaxIntString_ReturnsMaxInt()
        {
            bool success = int.TryParse(int.MaxValue.ToString(), out int value);
            Assert.That(success, Is.True);
            Assert.That(value, Is.EqualTo(int.MaxValue));
        }

        [Test]
        public void ParseInput_MinIntString_ReturnsMinInt()
        {
            bool success = int.TryParse(int.MinValue.ToString(), out int value);
            Assert.That(success, Is.True);
            Assert.That(value, Is.EqualTo(int.MinValue));
        }

        [Test]
        public void ParseInput_FloatString_ReturnsFalse()
        {
            bool success = int.TryParse("3.14", out int value);
            Assert.That(success, Is.False);
        }

        [Test]
        public void ParseInput_OverflowValue_ReturnsFalse()
        {
            bool success = int.TryParse("99999999999999999999", out int value);
            Assert.That(success, Is.False);
        }
    }
}