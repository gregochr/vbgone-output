namespace ArithmeticOperations;

/// <summary>
/// Contract for arithmetic operations migrated from VB.NET.
/// </summary>
public interface IArithmeticOperations
{
    double Add(double a, double b);
    double Subtract(double a, double b);
    double Multiply(double a, double b);
    double Divide(double a, double b);
    double Modulus(double a, double b);
}
