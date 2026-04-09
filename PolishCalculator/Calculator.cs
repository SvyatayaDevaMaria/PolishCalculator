using System;
using System.Collections.Generic;

namespace PolishCalculator;

public interface ICalculator
{
    double Calculate(string expression);
}

public class Calculator : ICalculator
{
    public double Calculate(string expression)
    {
        string[] tokens = expression.Trim().Split(' ');
        Stack<double> stack = new Stack<double>();

        for (int i = tokens.Length - 1; i >= 0; i--)
        {
            string token = tokens[i];

            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else
            {
                double a = stack.Pop();
                double b = stack.Pop();
                double result = 0;

                switch (token)
                {
                    case "+": result = a + b; break;
                    case "-": result = a - b; break;
                    case "*": result = a * b; break;
                    case "/": result = a / b; break;
                }

                stack.Push(result);
            }
        }

        return stack.Pop();
    }
}