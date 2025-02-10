using System;

public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner)
    // TODO: complete the definition of the constructor
    {
        Operand1 = operand1;
        Operand2 = operand2;
        Message = message;
        Inner = inner;
    }

    public Exception Inner { get; }
    public string Message { get; }
    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x, y);
            return "Multiply succeeded";
        }
        catch (CalculationException ex)
        {
            return (x > 0 || y > 0) ? $"Multiply failed for mixed or positive operands. {ex.Message}" : $"Multiply failed for negative operands. {ex.Message}";
        }
        
    }

    public void Multiply(int x, int y)
    {
        try
        {
            checked {
                int r = x * y; }

        } catch
        {
            throw new CalculationException(x, y, "Arithmetic operation resulted in an overflow.", new OverflowException());
        }
        
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
