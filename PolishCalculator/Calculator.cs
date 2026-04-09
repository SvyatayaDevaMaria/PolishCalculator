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
        if (string.IsNullOrWhiteSpace(expression))
            throw new ArgumentException("Expression is empty");

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
            else if (IsOperator(token))
            {
                if (stack.Count < 2)
                    throw new InvalidOperationException($"Not enough operands for {token}");

                double a = stack.Pop();
                double b = stack.Pop();

                double result = token switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" when b == 0 => throw new DivideByZeroException("Division by zero!"),
                    "/" => a / b,
                    _ => throw new InvalidOperationException($"Unknown operator: {token}")
                };

                stack.Push(result);
            }
            else
            {
                throw new InvalidOperationException($"Invalid token: {token}");
            }
        }

        if (stack.Count != 1)
            throw new InvalidOperationException("Invalid expression");

        return stack.Pop();
    }

    private bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }
}