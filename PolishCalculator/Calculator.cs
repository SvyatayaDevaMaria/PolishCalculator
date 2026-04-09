namespace PolishCalculator;

public interface ICalculator
{
    double Calculate(string expression);
}

public class Calculator : ICalculator
{
    public double Calculate(string expression)
    {
        throw new NotImplementedException("Not implemented yet");
    }
}