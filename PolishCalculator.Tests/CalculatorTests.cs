using Xunit;

namespace PolishCalculator.Tests;

public class CalculatorTests
{
    private readonly ICalculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    [Theory]
    [InlineData("+ 2 3", 5)]
    [InlineData("- 10 4", 6)]
    [InlineData("* 6 7", 42)]
    [InlineData("/ 15 3", 5)]
    public void TestSimpleOperations(string expression, double expected)
    {
        double result = _calculator.Calculate(expression);
        Assert.Equal(expected, result, 0.0001);
    }

    [Theory]
    [InlineData("+ + 2 3 4", 9)]
    [InlineData("* + 2 3 4", 20)]
    [InlineData("/ - 10 4 2", 3)]
    public void TestThreeOperands(string expression, double expected)
    {
        double result = _calculator.Calculate(expression);
        Assert.Equal(expected, result, 0.0001);
    }
}