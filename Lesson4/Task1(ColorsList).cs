using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> myColorList = new List<string>
        {
            "Red",
            "Black",
            "Orange",
            "Blue",
            "White"
        };

        // First foreach loop
        foreach (var item in myColorList)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(new string('-', 30));

        // Manual enumerator
        using (IEnumerator<string> enumerator = myColorList.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                string currentColor = enumerator.Current;
                Console.WriteLine(currentColor);  // Added output for completeness
            }
        }

        Console.WriteLine(new string('-', 30));

        // Second foreach loop
        foreach (string color in myColorList)
        {
            Console.WriteLine($"Current color is: {color}");  // Fixed variable and message
        }

        Console.WriteLine(new string('-', 30));

        // Try-catch for modification during enumeration
        try
        {
            foreach (string color in myColorList)
            {
                if (color == "White")  // Fixed variable
                {
                    Console.WriteLine(">>> Trying to add some green color to the mix...");
                    myColorList.Add("Green");  // Fixed list name
                }
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");  // Added handling for demonstration
        }

        Console.WriteLine(new string('-', 30));
    }
}
