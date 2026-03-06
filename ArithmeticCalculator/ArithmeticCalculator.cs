using System;

public class ArithmeticCalculator : IArithmeticCalculator
{
    private int _lastResult;

    public int Add(int a, int b) => a + b;

    public int Subtract(int a, int b) => a - b;

    public int Multiply(int a, int b) => a * b;

    public int Divide(int a, int b) =>
        b == 0
            ? throw new DivideByZeroException("Cannot divide by zero.")
            : (int)Math.Floor((double)a / b);

    public void Clear() => _lastResult = 0;
}