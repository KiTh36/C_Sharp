using System;
using System.Text.RegularExpressions;

public static class StringTransformer
{
    public static string Transform(string s, Func<string, string> strategy)
    {
        return strategy(s);
    }

    public static string TrimToUpper(string s)
    {
        return s.Trim().ToUpper();
    }

    public static string MaskDigits(string s)
    {
        return Regex.Replace(s, @"\d", "*");
    }
}

public class Program
{
    public static void Main()
    {
        string input = "   Hello123   ";

        string result1 = StringTransformer.Transform(input, StringTransformer.TrimToUpper);
        string result2 = StringTransformer.Transform(input, StringTransformer.MaskDigits);
        string result3 = StringTransformer.Transform(input, s => $"[{s}]");

        Console.WriteLine(result1);
        Console.WriteLine(result2);
        Console.WriteLine(result3);
    }
}