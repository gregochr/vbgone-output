using ArithmeticOperations;
using NUnit.Framework;

namespace ArithmeticOperations.Tests;

[TestFixture]
public class ArithmeticOperationsTests
{
    private IArithmeticOperations _sut = null!;

    [SetUp]
    public void SetUp()
    {
        _sut = new ArithmeticOperations();
    }

    // --- Add ---

    [Test]
    public void Add_PositiveNumbers_ReturnsSum()
    {
        Assert.That(_sut.Add(2, 3), Is.EqualTo(5));
    }

    [Test]
    public void Add_NegativeNumbers_ReturnsSum()
    {
        Assert.That(_sut.Add(-2, -3), Is.EqualTo(-5));
    }

    [Test]
    public void Add_Zero_ReturnsOther()
    {
        Assert.That(_sut.Add(0, 7), Is.EqualTo(7));
    }

    [Test]
    public void Add_LargeNumbers_ReturnsSum()
    {
        Assert.That(_sut.Add(1_000_000, 2_000_000), Is.EqualTo(3_000_000));
    }

    [Test]
    public void Add_DecimalNumbers_ReturnsSum()
    {
        Assert.That(_sut.Add(1.5, 2.5), Is.EqualTo(4.0));
    }

    [Test]
    public void Add_MixedSign_ReturnsSum()
    {
        Assert.That(_sut.Add(-10, 3), Is.EqualTo(-7));
    }

    [Test]
    public void Add_BothZero_ReturnsZero()
    {
        Assert.That(_sut.Add(0, 0), Is.EqualTo(0));
    }

    // --- Subtract ---

    [Test]
    public void Subtract_PositiveNumbers_ReturnsDifference()
    {
        Assert.That(_sut.Subtract(10, 3), Is.EqualTo(7));
    }

    [Test]
    public void Subtract_ResultNegative_ReturnsDifference()
    {
        Assert.That(_sut.Subtract(3, 10), Is.EqualTo(-7));
    }

    [Test]
    public void Subtract_Zero_ReturnsSame()
    {
        Assert.That(_sut.Subtract(5, 0), Is.EqualTo(5));
    }

    [Test]
    public void Subtract_SameNumber_ReturnsZero()
    {
        Assert.That(_sut.Subtract(42, 42), Is.EqualTo(0));
    }

    [Test]
    public void Subtract_NegativeFromNegative_ReturnsDifference()
    {
        Assert.That(_sut.Subtract(-5, -3), Is.EqualTo(-2));
    }

    // --- Multiply ---

    [Test]
    public void Multiply_PositiveNumbers_ReturnsProduct()
    {
        Assert.That(_sut.Multiply(4, 5), Is.EqualTo(20));
    }

    [Test]
    public void Multiply_ByZero_ReturnsZero()
    {
        Assert.That(_sut.Multiply(100, 0), Is.EqualTo(0));
    }

    [Test]
    public void Multiply_ByOne_ReturnsSame()
    {
        Assert.That(_sut.Multiply(7, 1), Is.EqualTo(7));
    }

    [Test]
    public void Multiply_NegativeByPositive_ReturnsNegative()
    {
        Assert.That(_sut.Multiply(-3, 4), Is.EqualTo(-12));
    }

    [Test]
    public void Multiply_NegativeByNegative_ReturnsPositive()
    {
        Assert.That(_sut.Multiply(-3, -4), Is.EqualTo(12));
    }

    [Test]
    public void Multiply_Decimals_ReturnsProduct()
    {
        Assert.That(_sut.Multiply(2.5, 4), Is.EqualTo(10.0));
    }

    // --- Divide ---

    [Test]
    public void Divide_EvenDivision_ReturnsQuotient()
    {
        Assert.That(_sut.Divide(10, 2), Is.EqualTo(5));
    }

    [Test]
    public void Divide_UnevenDivision_ReturnsDecimal()
    {
        Assert.That(_sut.Divide(7, 2), Is.EqualTo(3.5));
    }

    [Test]
    public void Divide_ByOne_ReturnsSame()
    {
        Assert.That(_sut.Divide(9, 1), Is.EqualTo(9));
    }

    [Test]
    public void Divide_ZeroDividend_ReturnsZero()
    {
        Assert.That(_sut.Divide(0, 5), Is.EqualTo(0));
    }

    [Test]
    public void Divide_NegativeByPositive_ReturnsNegative()
    {
        Assert.That(_sut.Divide(-10, 2), Is.EqualTo(-5));
    }

    [Test]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _sut.Divide(10, 0));
    }

    // --- Modulus ---

    [Test]
    public void Modulus_EvenDivision_ReturnsZero()
    {
        Assert.That(_sut.Modulus(10, 5), Is.EqualTo(0));
    }

    [Test]
    public void Modulus_UnevenDivision_ReturnsRemainder()
    {
        Assert.That(_sut.Modulus(10, 3), Is.EqualTo(1));
    }

    [Test]
    public void Modulus_SmallerDividend_ReturnsDividend()
    {
        Assert.That(_sut.Modulus(3, 10), Is.EqualTo(3));
    }

    [Test]
    public void Modulus_NegativeDividend_ReturnsNegativeRemainder()
    {
        Assert.That(_sut.Modulus(-7, 3), Is.EqualTo(-1));
    }

    [Test]
    public void Modulus_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _sut.Modulus(10, 0));
    }

    [Test]
    public void Modulus_ByOne_ReturnsZero()
    {
        Assert.That(_sut.Modulus(7, 1), Is.EqualTo(0));
    }
}
