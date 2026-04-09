using Xunit;

namespace PolishCalculator.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData("+ 2 3", 5)]
    [InlineData("- 10 4", 6)]
    [InlineData("* 6 7", 42)]
    [InlineData("/ 15 3", 5)]
    public void TestSimpleOperations(string expression, double expected)
    {
        ICalculator calculator = new Calculator();
        double result = calculator.Calculate(expression);
        Assert.Equal(expected, result, 0.0001);
    }
}