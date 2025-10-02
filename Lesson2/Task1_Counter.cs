using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


public class Program
{
    public static void Main(string[] args)
    {
        Counter counter = CreateCounterFromInput();
        if (counter == null) return;

        counter.Increment();
        Console.WriteLine("Після збільшення: " + counter.Value);

        counter.Decrement();
        Console.WriteLine("Після зменшення: " + counter.Value);

        Console.WriteLine("TryDecrement значення: " + counter.TryDecrement());
        Console.WriteLine("Текуще значення: " + counter.Value);

        counter.Reset();
        Console.WriteLine("Після скидання: " + counter.Value);
    }

    private static Counter CreateCounterFromInput()
    {
        Console.Write("Введіть початкове значення лічильника: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int startValue))
        {
            try
            {
                return new Counter(startValue);
            }
            catch (ArgumentOutOfRangeException excuse)
            {
                Console.WriteLine("Помилка: " + excuse.Message);
            }
        }
        else
        {
            Console.WriteLine("Некоректний ввід. Будь ласка, введіть ціле число.");
        }

        return null;
    }
}

public class Counter
{
    public uint Value { get; private set; }

    public Counter(int start)
    {
        if (start < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(start), "Початкове значення лічильника не може бути від'ємним.");
        }

        Value = (uint)start;
    }

    public void Increment() => Value++;

    public void Decrement()
    {
        if (Value == 0)
        {
            throw new InvalidOperationException("Неможливо зменшити лічильник, оскільки він уже дорівнює нулю.");
        }

        Value--;
    }

    public bool TryDecrement()
    {
        if (Value == 0) return false;
        Value--;
        return true;
    }

    public void Reset() => Value = 0;
}