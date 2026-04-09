using System;
using System.Collections.Generic;
using System.Globalization;

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

            // Поддержка десятичных чисел с точкой
            if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
            {
                stack.Push(number);
            }
            else
            {
                if (stack.Count < 2)
                    throw new InvalidOperationException("Not enough operands");

                double a = stack.Pop();
                double b = stack.Pop();
                double result = 0;

                switch (token)
                {
                    case "+": result = a + b; break;
                    case "-": result = a - b; break;
                    case "*": result = a * b; break;
                    case "/": result = a / b; break;
                    default: throw new InvalidOperationException($"Unknown operator: {token}");
                }

                stack.Push(result);
            }
        }

        if (stack.Count != 1)
            throw new InvalidOperationException("Invalid expression");

        return stack.Pop();
    }
}