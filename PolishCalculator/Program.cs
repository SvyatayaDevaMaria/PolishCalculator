using System;

namespace PolishCalculator;

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        Console.WriteLine("========================================");
        Console.WriteLine("     КАЛЬКУЛЯТОР ПОЛЬСКОЙ ЗАПИСИ");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("Польская запись (префиксная нотация):");
        Console.WriteLine("  Сначала пишется операция, потом операнды");
        Console.WriteLine();
        Console.WriteLine("Примеры правильного ввода:");
        Console.WriteLine("  + 2 3          -> 5");
        Console.WriteLine("  - 10 4         -> 6");
        Console.WriteLine("  * 6 7          -> 42");
        Console.WriteLine("  / 15 3         -> 5");
        Console.WriteLine("  + + 2 3 4      -> 9");
        Console.WriteLine("  * + 2 3 4      -> 20");
        Console.WriteLine("  + 1.5 2.5      -> 4.0");
        Console.WriteLine("  + 1 * 2 3      -> 7");
        Console.WriteLine("  * + 1 2 + 3 4  -> 21");
        Console.WriteLine();
        Console.WriteLine("Поддерживаемые операции: +  -  *  /");
        Console.WriteLine("Для выхода напишите 'exit'");
        Console.WriteLine("========================================");
        Console.WriteLine();

        while (true)
        {
            Console.Write("Введите выражение: ");
            string input = Console.ReadLine();

            // Проверка на выход
            if (string.IsNullOrEmpty(input))
                continue;

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("До свидания!");
                break;
            }

            try
            {
                double result = calculator.Calculate(input);
                Console.WriteLine($"Результат: {result}");
                Console.WriteLine();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
                Console.WriteLine();
            }
        }
    }
}