using System;

class CurrencyConverter
{
    static void Main(string[] args)
    {
        // Курси валют приклад
        const double UAH_TO_USD_RATE = 0.027;
        const double UAH_TO_EUR_RATE = 0.025;
        const double USD_TO_UAH_RATE = 37.0;
        const double EUR_TO_UAH_RATE = 40.0;
        const double USD_TO_EUR_RATE = 0.93;
        const double EUR_TO_USD_RATE = 1.07;

        Console.WriteLine("Конвертер валют");
        Console.WriteLine("Доступні валюти: UAH, USD, EUR");

        
        Console.Write("Введіть початкову валюту (UAH, USD, EUR): ");
        string fromCurrency = Console.ReadLine().ToUpper();

        Console.Write("Введіть кінцеву валюту (UAH, USD, EUR): ");
        string toCurrency = Console.ReadLine().ToUpper();
        
       Console.Write("Введіть суму: ");
        double amount;
        
        if (!double.TryParse(Console.ReadLine(), out amount))
        {
            Console.WriteLine("Увага! Некоректний формат суми. Спробуйте знову.");
            return;
        }

        double convertedAmount;

        switch (fromCurrency)
        {
            case "UAH":
                if (toCurrency == "USD") convertedAmount = amount * UAH_TO_USD_RATE;
                else if (toCurrency == "EUR") convertedAmount = amount * UAH_TO_EUR_RATE;
                else if (toCurrency == "UAH") convertedAmount = amount;
                else
                {
                    Console.WriteLine("Невідома кінцева валюта.");
                    return;
                }
                break;
            case "USD":
                if (toCurrency == "UAH") convertedAmount = amount * USD_TO_UAH_RATE;
                else if (toCurrency == "EUR") convertedAmount = amount * USD_TO_EUR_RATE;
                else if (toCurrency == "USD") convertedAmount = amount;
                else
                {
                    Console.WriteLine("Невідома кінцева валюта.");
                    return;
                }
                break;
            case "EUR":
                if (toCurrency == "UAH") convertedAmount = amount * EUR_TO_UAH_RATE;
                else if (toCurrency == "USD") convertedAmount = amount * EUR_TO_USD_RATE;
                else if (toCurrency == "EUR") convertedAmount = amount;
                else
                {
                    Console.WriteLine("Невідома кінцева валюта.");
                    return;
                }
                break;
            default:
                Console.WriteLine("Невідома початкова валюта.");
                return;
        }

        Console.WriteLine($"Результат: {amount} {fromCurrency} = {convertedAmount:F2} {toCurrency}");
    }
}