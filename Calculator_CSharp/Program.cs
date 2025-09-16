// See https://aka.ms/new-console-template for more information

namespace Calculator_CSharp;

class Calculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Простий калькулятор: ");
        Console.WriteLine("---------------------");

        // First number
        Console.Write("Введіть перше число: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        
        Console.Write("Введіть операцію (+, -, *, /): ");
        char op = Convert.ToChar(Console.ReadLine());

        // Second number
        Console.Write("Введіть друге число: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result ;

        // result
        switch (op)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
               
                
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else
                {
                    Console.WriteLine("Помилка: Ділення на нуль неможливе.");
                    return;
                }
                break;
            default:
                Console.WriteLine("Помилка: Невідома операція.");
                return;
        }

        
        Console.WriteLine($"Результат: {num1} {op} {num2} = {result}");
    }
}