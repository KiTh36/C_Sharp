using System;
using System.Collections.Generic;
using System.Linq;

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

        foreach (var item in myColorList)
        {
            Console.WriteLine(item);
        }
    
        using (IEnumerator<string> enumerator = myColorList.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                string currentColor = enumerator.Current;
                Console.WriteLine(currentColor);
            }
        }

        foreach (string color in myColorList)
        {
            Console.WriteLine($"Current color is: {color}");
        }

        List<string> colorsToAdd = new List<string>();

        foreach (string color in myColorList)
        {
            if (color == "White")
            {
                Console.WriteLine(">>> Trying to add some green color to the mix...");
                colorsToAdd.Add("Green");
            }
        }

        //foreach (string color in colorAddition){
        //if(color == "White") {Console.WriteLine($"Found '{color}'. Adding 'Green' to the ORIGINAL list.");
        // myColorList.Add("Green"); }}

        myColorList.AddRange(colorsToAdd);
        Console.WriteLine("Final list content:");
        foreach (string color in myColorList)
        {
            Console.WriteLine(color);
        }
    }

}
